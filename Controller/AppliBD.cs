using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresseRESA
{
    public static class AppliBD {
        // Déclaration des variables
        private static MySqlConnection conn = null;

        // --------------------------------------------------------- PARTIE BDD ---------------------------------------------------------

        /// <summary>
        /// Fonction utilisée pour se connecter à la base de données.
        /// </summary>
        /// <returns>Un boolean.</returns>
        // CG0001A - Connexion à la BDD
        public static bool ConnexionBD() {
            conn = new MySqlConnection(Properties.Settings.Default.conn);
            
            // Si la Base de données ne fonctionne pas, on affiche une boîte de dialogue
            try {
                conn.Open();
            }
            catch (Exception ex) {
                MessageBox.Show("Erreur avec la Base de données. Contactez l'administrateur.", "Base de données non reconnue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine(ex);
            }
            
            return (conn.State == System.Data.ConnectionState.Open);
        }

        // --------------------------------------------------------- PARTIE GESTION DE LA CONNEXION A L'APPLICATION ---------------------------------------------------------

        /// <summary>
        /// Fonction utilisée pour vérifier l'existance de l'utilisateur dans notre base de données.
        /// </summary>
        /// <param name="mail">L'adresse email saisie.</param>
        /// <param name="pass">Le mot de passe saisie.</param>
        /// <returns>Une chaîne de caractère, soit le type de compte de l'utilisateur.</returns>
        // CG0002A - Vérification de l'existence de l'utilisateur dans la BDD 
        public static string ConnexionUser(string mail, string pass)
        {
            string typeU = "I"; // Valeur par défaut : I pour Inconnu
            bool connValidBD = AppliBD.ConnexionBD();
            
            // Si la connexion avec la base de donnée à réussi, on exécute les étapes de recherche du type du compte de l'utilisateur connecté
            if (connValidBD)
            {

                MySqlCommand cmd = conn.CreateCommand();

                string chHash = mail + pass; // Chaîne de caractère haché

                // Requête préparé permettant de récupérer le type de l'utilisateur qui tente de se connecter
                string req = "SELECT COMPTE.numAdherent, TYPE_CPTE.nomTypeCpte FROM TYPE_CPTE " +
                             "INNER JOIN COMPTE ON TYPE_CPTE.idTypeCpte = COMPTE.typeCpte " +
                             "WHERE adrMailCompte = @mail AND passeHash = MD5(@chHash)";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@chHash", chHash);
                cmd.Prepare();

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Si on peux lire un résultat, on insère le nom du type du compte dans la variable typeU
                    if (rdr.Read())
                    {
                        Session.SetIdUtilisateur(rdr.GetInt32("numAdherent")); // On enregistre son ID dans la Session
                        typeU = rdr.GetString("nomTypeCpte");
                    }
                    rdr.Close();
                }
            }

            // On retourne le type du compte de l'utilisateur
            return typeU;
        }

        /// <summary>
        /// Fonction utilisée pour vérifier le nombre d'avertissement de l'utilisateur qui tente d'accéder à l'application.
        /// </summary>
        /// <param name="mail">L'adresse email de l'utilisateur.</param>
        /// <returns>Un entier, soit le nombre d'avertissement du compte de l'utilisateur</returns>
        // CG0002B - Récupération de l'ensemble des informations pour vérifier la conformité du compte
        public static Utilisateur GetUtilisateurParEmail(string saisieAdresseMel)
        {
            Utilisateur user = null;
            bool connValidBD = AppliBD.ConnexionBD();

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour récupérer l'ensemble des utilisateurs
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparé pour récupérer les informations de l'utilisateur concerné
                string req = "SELECT adrMailCompte, nomCompte, prenomCompte, dateInscription, dateFermeture, nbAvertissement, noTelCompte, noPortableCompte, TYPE_CPTE.nomTypeCpte " +
                             "FROM COMPTE INNER JOIN TYPE_CPTE ON COMPTE.typeCpte = TYPE_CPTE.idTypeCpte WHERE adrMailCompte = @adresseEmail;";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@adresseEmail", saisieAdresseMel);
                cmd.Prepare();

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Tant qu'on peux lire un résultat, on crée un utilisateur et on l'ajoute à la liste
                    if (rdr.Read())
                    {
                        string mail = rdr.GetString("adrMailCompte");
                        string nom = rdr.GetString("nomCompte");
                        string prenom = rdr.GetString("prenomCompte");
                        DateTime dateInscrit = rdr.GetDateTime("dateInscription");
                        int nbAvertissement = rdr.GetInt32("nbAvertissement");
                        string telephone = rdr.IsDBNull(rdr.GetOrdinal("noTelCompte")) ? null : rdr.GetString("noTelCompte");
                        string portable = rdr.IsDBNull(rdr.GetOrdinal("noPortableCompte")) ? null : rdr.GetString("noPortableCompte");
                        string typeCompte = rdr.GetString("nomTypeCpte");
                        if (rdr.IsDBNull(rdr.GetOrdinal("dateFermeture")))
                        {
                            user = new Utilisateur(mail, nom, prenom, dateInscrit, nbAvertissement, telephone, portable, typeCompte);
                        }
                        else
                        {
                            DateTime dateFermeture = rdr.GetDateTime("dateFermeture");
                            user = new Utilisateur(mail, nom, prenom, dateInscrit, dateFermeture, nbAvertissement, telephone, portable, typeCompte);
                        }
                    }
                    rdr.Close();
                }
            }
            // On retourne l'utilisateur
            return user;
        }

        // ================================================================== ADMINISTRATION =================================================================
        // --------------------------------------------------------- PARTIE GESTION DES UTILISATEURS ---------------------------------------------------------

        /// <summary>
        /// Fonction utilisée pour récupérer tous les utilisateurs de la BDD.
        /// </summary>
        /// <param name="status">Option choisie par l'utilisateur.</param>
        /// <returns>Une liste d'utilisateurs, soit la liste des utilisateurs de la base de données.</returns>
        // CG0005A - Récupération des utilisateurs en fonction du filtrage
        public static List<Utilisateur> GetLesUtilisateurs(string status)
        {
            List<Utilisateur> lesUsers = new List<Utilisateur>();
            bool connValidBD = AppliBD.ConnexionBD();

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour récupérer l'ensemble des utilisateurs
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparé pour récupérer les utilisateurs de la BDD
                string req = "SELECT adrMailCompte, nomCompte, prenomCompte, dateInscription, dateFermeture, nbAvertissement, noTelCompte, noPortableCompte, TYPE_CPTE.nomTypeCpte " +
                             "FROM COMPTE INNER JOIN TYPE_CPTE ON COMPTE.typeCpte = TYPE_CPTE.idTypeCpte ";


                // En fonction du bouton radio selectionné, le status sera différent (par défaut, c'est All)
                switch (status)
                {
                    case "GOOD":
                        req += "WHERE nbAvertissement < 3 AND dateFermeture IS NULL ";
                        break;
                    case "AVERTISSEMENT":
                        req += "WHERE nbAvertissement >= 3 ";
                        break;
                    case "BLOQUE":
                        req += "WHERE dateFermeture IS NOT NULL ";
                        break;
                    default:
                        break;
                }
                req += "ORDER BY adrMailCompte;";

                cmd.CommandText = req;

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Tant qu'on peux lire un résultat, on crée un utilisateur et on l'ajoute à la liste
                    while (rdr.Read())
                    {
                        Utilisateur user;
                        string mail = rdr.GetString("adrMailCompte");
                        string nom = rdr.GetString("nomCompte");
                        string prenom = rdr.GetString("prenomCompte");
                        DateTime dateInscrit = rdr.GetDateTime("dateInscription");
                        int nbAvertissement = rdr.GetInt32("nbAvertissement");
                        string telephone = rdr.IsDBNull(rdr.GetOrdinal("noTelCompte")) ? null : rdr.GetString("noTelCompte");
                        string portable = rdr.IsDBNull(rdr.GetOrdinal("noPortableCompte")) ? null : rdr.GetString("noPortableCompte");
                        string typeCompte = rdr.GetString("nomTypeCpte");

                        if (rdr.IsDBNull(rdr.GetOrdinal("dateFermeture")))
                        {
                            user = new Utilisateur(mail, nom, prenom, dateInscrit, nbAvertissement, telephone, portable, typeCompte);
                        }
                        else
                        {
                            DateTime dateFermeture = rdr.GetDateTime("dateFermeture");
                            user = new Utilisateur(mail, nom, prenom, dateInscrit, dateFermeture, nbAvertissement, telephone, portable, typeCompte);
                        }

                        lesUsers.Add(user);
                    }
                    rdr.Close();
                }
            }
            // On retourne la liste des utilisateurs de la BDD
            return lesUsers;
        }

        /// <summary>
        /// Fonction utilisée pour ajouter un nouvel utilisateur dans la BDD.
        /// </summary>
        /// <param name="mail">L'adresse mail de l'utilisateur.</param>
        /// <param name="nom">Le nom de l'utilisateur.</param>
        /// <param name="prenom">Le prénom de l'utilisateur.</param>
        /// <param name="numTelephone">Le numéro de téléphone de l'utilisateur.</param>
        /// <param name="numPortable">Le numéro de portable de l'utilisateur.</param>
        /// <param name="typeCpte">Le type du compte de l'utilisateur.</param>
        /// <returns>Un entier, soit le nombre d'insertion</returns>
        // CG0005B - Ajout d'un nouvel utilisateur
        public static int AddUtilisateur(string mail, string nom, string prenom, string numTelephone, string numPortable, int typeCpte)
        {
            bool connValidBD = AppliBD.ConnexionBD(); // Connexion à la base de donnée
            int nbInsert = 0;
            bool existeMail = false;

            // Nous allons d'abord vérifier que l'adresse mail est bel et bien utiliser une seule fois.
            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour ajouter notre nouvel utilisateur.
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparé pour récupérer l'adresse mail de notre utilisateur dans la BDD
                string reqSelect = "SELECT adrMailCompte FROM COMPTE WHERE adrMailCompte = @mail;";

                cmd.CommandText = reqSelect;
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Prepare();

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Si on peux lire un résultat, on valorise notre variable existeMail en Vrai (il existe déjà une adresse mail dans la BDD)
                    if (rdr.Read()) { existeMail = true; }
                    rdr.Close();
                }

                // S'il n'existe pas déjà un compte associé à ce mail, alors on l'ajoute
                if (!existeMail)
                {
                    string chHash = CreateMdpAleatoire(mail); // Chaîne de caractère haché, mot de passe provisoire.
                    string dateDuJour = DateTime.Now.ToString("yyyy-MM-dd"); // Date du jour
                    string numTel = numTelephone != "" ? numTelephone : null; // Si un numéro de téléphone est renseignée, on l'ajoute.
                    string numPort = numPortable != "" ? numPortable : null; // Si un numéro de portable est renseignée, on l'ajoute.

                    // Requête préparé pour insérer un nouvel utilisateur
                    string reqInsert = "INSERT INTO COMPTE (adrMailCompte, passeHash, nomCompte, prenomCompte, dateInscription, dateFermeture, nbAvertissement, noTelCompte, noPortableCompte, typeCpte) " +
                                       "VALUES(@adrMail, MD5(@chHash), @nom, @prenom, @dateInscription, NULL, 0, @numTel, @numPort, @numType);";

                    cmd.CommandText = reqInsert;
                    cmd.Parameters.AddWithValue("@adrMail", mail);
                    cmd.Parameters.AddWithValue("@chHash", chHash);
                    cmd.Parameters.AddWithValue("@nom", nom);
                    cmd.Parameters.AddWithValue("@prenom", prenom);
                    cmd.Parameters.AddWithValue("@dateInscription", dateDuJour);
                    cmd.Parameters.AddWithValue("@numTel", numTel);
                    cmd.Parameters.AddWithValue("@numPort", numPort);
                    cmd.Parameters.AddWithValue("@numType", typeCpte);
                    cmd.Prepare();

                    // Si le typeCpte est égal à 2, alors instancier le type en "ADMIN", sinon en "USER"
                    string type = typeCpte == 2 ? "ADMIN" : "USER";

                    // L'utilisation de "_" est simplement une variable non utilisé.
                    _ = new Utilisateur(mail, nom, prenom, Convert.ToDateTime(dateDuJour), 0, numTel, numPort, type);

                    nbInsert = cmd.ExecuteNonQuery();
                }
                else
                {
                    return -1; // Le chiffre -1 désigne l'erreur "Une adresse mail est déjà associé à un compte."
                }
            }
            // On retourne le nombre de ligne insérée (soit 1, soit 0)
            return nbInsert;
        }

        /// <summary>
        /// Fonction utilisée pour créer un mot de passe provisoire.
        /// </summary>
        /// <param name="mail">L'adresse email de l'utilisateur.</param>
        /// <returns>Une chaîne de caractères, soit le mot de passe haché.</returns>
        // CG0005C - Création d'un mot de passe provisoire pour l'ajout d'un utilisateur
        public static string CreateMdpAleatoire(string mail)
        {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            char[] Charsarr = new char[12];
            Random random = new Random();

            // On ajoute des caractères aléatoires à la suite
            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            string pass = new string(Charsarr);
            string mdpProvisoire = mail + pass;

            Console.WriteLine("Mot de passe de " + mail + " : " + pass);
            MessageBox.Show("Le mot de passe provisoire de l'utilisateur " + mail + " est " + pass, "Mot de passe Provisoire", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return mdpProvisoire; // On retourne le mot de passe provisoire, haché.
        }

        /// <summary>
        /// Fonction utilisée pour incrémenter un avertissement à l'utilisateur selectionné.
        /// </summary>
        /// <param name="userMail">L'adresse mail de l'utilisateur.</param>
        /// <returns>Un booléen, soit la vérification de l'éxection de la requête.</returns>
        // CG0005D - Incrémentation d'un avertissement
        public static bool UpdateAvertissmentCpteUser(string userMail)
        {
            bool connValidBD = AppliBD.ConnexionBD();
            bool verification = false; // Pour vérifier si l'incrémentation à bien été effectuée
            Utilisateur user = AppliBD.GetUtilisateurParEmail(userMail);

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour incrémenter un avertissement à notre utilisateur.
            if (connValidBD)
            {
                // Si le compte possède en dessous de 3 avertissements, on peux lui en rajouter un.
                if (user.GetNbAvertissement() < 3)
                {
                    MySqlCommand cmd = conn.CreateCommand();

                    // Requête préparé pour mettre à jour le nombre d'avertissement de notre utilisateur
                    string req = "UPDATE COMPTE SET nbAvertissement = nbAvertissement + 1 WHERE adrMailCompte = @mail";

                    cmd.CommandText = req;
                    cmd.Parameters.AddWithValue("@mail", userMail);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
                verification = true;
            }
            // On retourne notre vérification
            return verification;
        }

        /// <summary>
        /// Fonction utilisée pour fermer le compte de l'utilisateur selectionné.
        /// </summary>
        /// <param name="mail">L'adresse mail de l'utilisateur.</param>
        /// <returns>Un booléen, soit la vérification de l'éxection de la requête.</returns>
        // CG0005E - Fermeture du compte d'un utilisateur
        public static bool FermetureCpteUser(Utilisateur user)
        {
            bool connValidBD = AppliBD.ConnexionBD();
            bool verification = false; // Pour vérifier si l'ajout de la date de fermeture du compte a été réussie
            string dateDuJour = DateTime.Now.ToString("yyyy-MM-dd"); // Date du jour

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour ajouter notre nouvel utilisateur.
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparé pour mettre à jour la date de fermeture de l'utilisateur
                string req = "UPDATE COMPTE " +
                             "SET dateFermeture = @dateJour " +
                             "WHERE adrMailCompte = @mail;";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@mail", user.GetEmail());
                cmd.Parameters.AddWithValue("@dateJour", dateDuJour);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                user.SetDateFermeture(Convert.ToDateTime(dateDuJour));

                verification = true;
            }
            // On retourne notre verification
            return verification;
        }

        // --------------------------------------------------------- PARTIE GESTION DES ARTICLES ---------------------------------------------------------

        /// <summary>
        /// Fonction utilisée pour récupérer tous les articles de la BDD.
        /// </summary>
        /// <param name="status">Option choisie par l'utilisateur.</param>
        /// <returns>Une liste d'articles, soit la liste des articles de la base de données.</returns>
        // CG0006A - Récupération des articles en fonction du type de filtrage choisi
        public static List<Article> GetLesArticles(string status)
        {
            List<Article> lesArticles = new List<Article>();
            bool connValidBD = AppliBD.ConnexionBD();

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour récupérer l'ensemble des articles
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparé pour récupérer les articles de la BDD
                string req = "SELECT idArticle, titreArticle, descriptionArticle, dateArticleCreation, COMPTE.adrMailCompte, ETAT_VALID.nomValid " +
                             "FROM ARTICLE INNER JOIN ETAT_VALID ON ARTICLE.idValid = ETAT_VALID.idValid " +
                             "INNER JOIN COMPTE ON ARTICLE.auteurArticle = COMPTE.numAdherent ";


                // En fonction du bouton radio selectionné, le status sera différent (par défaut, c'est All)
                switch (status)
                {
                    case "EN_ATTENTE":
                        req += " WHERE ARTICLE.idValid = 1 ";
                        break;
                    case "VALIDE":
                        req += " WHERE ARTICLE.idValid = 2 ";
                        break;
                    case "REJET":
                        req += " WHERE ARTICLE.idValid = 3 ";
                        break;
                    default:
                        break;
                }

                req += "ORDER BY dateArticleCreation DESC;";

                cmd.CommandText = req;

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Tant qu'on peux lire un résultat, on crée un article et on l'ajoute à la liste
                    while (rdr.Read())
                    {
                        Article article;
                        int id = rdr.GetInt32("idArticle");
                        string titre = rdr.IsDBNull(rdr.GetOrdinal("titreArticle")) ? "Titre" : rdr.GetString("titreArticle");
                        string description = rdr.IsDBNull(rdr.GetOrdinal("descriptionArticle")) ? "Description de l'article" : rdr.GetString("descriptionArticle");
                        string auteur = rdr.GetString("adrMailCompte");
                        DateTime dateCreation = rdr.GetDateTime("dateArticleCreation");
                        string etat = rdr.GetString("nomValid");

                        article = new Article(id, titre, description, auteur, dateCreation, etat);
                        lesArticles.Add(article);
                    }
                    rdr.Close();
                }
            }
            // On retourne la liste des articles de la BDD
            return lesArticles;
        }

        /// <summary>
        /// Fonction utilisée pour associée une rubrique à un article.
        /// </summary>
        /// <param name="article">L'article concerné.</param>
        /// <param name="rubrique">La rubrique concernée.</param>
        /// <returns>Un booléen, soit la vérification de l'éxecution de la requête.</returns>
        // CG0006B - Association d'une rubrique à un article
        public static bool AddRubriquePourArticle(Article article, Rubrique rubrique)
        {
            bool connValidBD = AppliBD.ConnexionBD();
            bool verification = false; // Pour vérifier si l'association entre une rubrique et un article a été effectuée

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour associer une rubrique à un article.
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparé pour ajouter une nouvelle association entre une rubrique et un article
                string req = "INSERT INTO ARTICLE_RUBRIQUE (idArticle, idRubrique) VALUES (@idArticle, @idRubrique);";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@idArticle", article.GetId());
                cmd.Parameters.AddWithValue("@idRubrique", rubrique.GetId());
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                verification = true;
            }
            // On retourne la vérification
            return verification;
        }

        /// <summary>
        /// Fonction utilisée pour supprimer toutes les rubriques pour un article donné.
        /// </summary>
        /// <param name="article">L'article concerné.</param>
        /// <returns>Un booléen, soit la vérification de l'execution de la requête.</returns>
        // CG0006C - Suppression des rubriques pour un article donné
        public static bool ResetRubriquesArticle(Article article)
        {
            bool connValidBD = AppliBD.ConnexionBD();
            bool verification = false; // Pour vérifier si la suppression des associations de notre article a été effectué

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour supprimer toutes les associations entre les rubriques et notre article.
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparé pour supprimer toutes les associations entre notre article et les rubriques
                string req = "DELETE FROM ARTICLE_RUBRIQUE WHERE idArticle = @idArticle;";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@idArticle", article.GetId());
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                verification = true;
            }
            // On retourne la verification
            return verification;
        }

        /// <summary>
        /// Fonction utilisée pour mettre à jour l'état de l'article selectionné.
        /// </summary>
        /// <param name="article">L'article selectionné.</param>
        /// <param name="etatArticle">Le nouvel état.</param>
        /// <returns>Un booléen, soit la vérification de l'éxecution de la requête.</returns>
        // CG0006D - Mise à jour de l'état de l'article
        public static bool UpdateEtatArticle(Article article, int etatArticle)
        {
            bool connValidBD = AppliBD.ConnexionBD();
            bool verification = false; // Pour vérifier si la mise à jour de l'état de notre article a été effectuée


            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour mettre à jour l'état de l'article.
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparé pour mettre à jour l'état d'un article dans la BDD
                string req = "UPDATE ARTICLE " +
                             "SET idValid = @newEtat " +
                             "WHERE idArticle = @idArticle;";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@newEtat", etatArticle);
                cmd.Parameters.AddWithValue("@idArticle", article.GetId());
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                string etat = "";
                switch (etatArticle)
                {
                    case 1:
                        etat = "EN ATTENTE";
                        break;
                    case 2:
                        etat = "VALIDE";
                        break;
                    case 3:
                        etat = "REJET";
                        break;
                }
                article.SetEtat(etat);
                verification = true;
            }
            // On retourne la verification
            return verification;
        }

        /// <summary>
        /// Fonction utilisée pour récupérer les rubriques d'un article donné.
        /// </summary>
        /// <param name="idArticle">L'identifiant de l'article concerné.</param>
        /// <returns>Une liste de rubriques, soit les rubriques associées à l'article.</returns>
        // CG0006G - Récupération des rubriques d'un article
        public static List<Rubrique> GetRubriquesParArticle(int idArticle)
        {
            List<Rubrique> lesRubriques = new List<Rubrique>();
            bool connValidBD = AppliBD.ConnexionBD();

            // Si la connexion avec la base de données a réussi, on exécute les étapes pour récupérer les rubriques associées à l'article
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparée pour récupérer les rubriques associées à l'article de la BDD
                string req = "SELECT RUBRIQUE.idRubrique, RUBRIQUE.nomRubrique " +
                             "FROM RUBRIQUE " +
                             "INNER JOIN ARTICLE_RUBRIQUE ON RUBRIQUE.idRubrique = ARTICLE_RUBRIQUE.idRubrique " +
                             "WHERE ARTICLE_RUBRIQUE.idArticle = @idArticle " +
                             "ORDER BY RUBRIQUE.nomRubrique;";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@idArticle", idArticle);

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Tant qu'on peut lire un résultat, on crée une rubrique et on l'ajoute à la liste
                    while (rdr.Read())
                    {
                        Rubrique rubrique;
                        int id = rdr.GetInt32("idRubrique");
                        string nom = rdr.GetString("nomRubrique").ToUpper();

                        rubrique = new Rubrique(id, nom);
                        lesRubriques.Add(rubrique);
                    }
                    rdr.Close();
                }
            }
            // On retourne la liste des rubriques associées à l'article de la BDD
            return lesRubriques;
        }

        /// <summary>
        /// Fonction utilisée pour rechercher des articles en fonction de la saisie de l'utilisateur
        /// </summary>
        /// <param name="saisieIdArticle">L'identifiant de l'article recherché.</param>
        /// <param name="saisieAuteurArticle">L'auteur de l'article recherché.</param>
        /// <returns>Une liste d'articles, soit les articles recherchés.</returns>
        // CG0006A - Récupération des articles en fonction de la saisie de l'utilisateur
        public static List<Article> GetRechercheArticle(string saisieIdArticle, string saisieAuteurArticle)
        {
            List<Article> articlesTrouves = new List<Article>();
            bool connValidBD = AppliBD.ConnexionBD();

            // Si la connexion avec la base de données a réussi, on exécute les étapes pour récupérer les articles recherchés.
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparée pour récupérer les articles en fonction des critères de recherche
                string req = "SELECT idArticle, titreArticle, descriptionArticle, dateArticleCreation, COMPTE.adrMailCompte, ETAT_VALID.nomValid " +
                             "FROM ARTICLE INNER JOIN ETAT_VALID ON ARTICLE.idValid = ETAT_VALID.idValid " +
                             "INNER JOIN COMPTE ON ARTICLE.auteurArticle = COMPTE.numAdherent " +
                             "WHERE ARTICLE.idArticle = @idArticle ";


                // On vérifie si l'utilisateur a fourni un auteur dans sa recherche
                if (!string.IsNullOrEmpty(saisieAuteurArticle))
                {
                    // Si oui, on ajoute la condition sur l'auteur
                    req += " OR COMPTE.adrMailCompte LIKE @auteurArticle ";
                }

                req += "ORDER BY dateArticleCreation DESC;";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@idArticle", saisieIdArticle);
                if (!string.IsNullOrEmpty(saisieAuteurArticle)) { cmd.Parameters.AddWithValue("@auteurArticle", "%" + saisieAuteurArticle + "%");}
                cmd.Prepare();

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Tant qu'on peut lire un résultat, on crée un article et on l'ajoute à la liste
                    while (rdr.Read())
                    {
                        Article article;
                        int id = rdr.GetInt32("idArticle");
                        string titre = rdr.IsDBNull(rdr.GetOrdinal("titreArticle")) ? "Titre" : rdr.GetString("titreArticle");
                        string description = rdr.IsDBNull(rdr.GetOrdinal("descriptionArticle")) ? "Description de l'article" : rdr.GetString("descriptionArticle");
                        string auteur = rdr.GetString("adrMailCompte");
                        DateTime dateCreation = rdr.GetDateTime("dateArticleCreation");
                        string etat = rdr.GetString("nomValid");

                        article = new Article(id, titre, description, auteur, dateCreation, etat);
                        articlesTrouves.Add(article);
                    }
                    rdr.Close();
                }
            }
            // On retourne la liste des articles trouvés dans la BDD
            return articlesTrouves;
        }

        /// <summary>
        /// Fonction utilisée pour récupérer l'ensemble des avis d'un article
        /// </summary>
        /// <param name="idArticle">L'identifiant de l'article concerné.</param>
        /// <returns>Une liste d'avis, soit les avis sur l'article.</returns>
        // CG0007A - Récupération de l'ensemble des avis de l'article
        public static List<Avis> GetAvisParArticle(int idArticle)
        {
            List<Avis> avisParArticle = new List<Avis>();
            bool connValidBD = AppliBD.ConnexionBD();

            // Si la connexion avec la base de données a réussi, on exécute les étapes pour récupérer les avis sur l'article.
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparée pour récupérer tous les avis sur l'article
                string req = "SELECT idAvis, dateAvisCreation, commentaire, idArticle, COMPTE.adrMailCompte FROM AVIS " +
                             "INNER JOIN COMPTE ON AVIS.idAdherent = COMPTE.numAdherent " +
                             "WHERE idArticle = @idArticle " +
                             "ORDER BY dateAvisCreation DESC;";


                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@idArticle", idArticle);
                cmd.Prepare();

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Tant qu'on peut lire un résultat, on crée un avis et on l'ajoute à la liste
                    while (rdr.Read())
                    {
                        int idAvis = rdr.GetInt32("idAvis");
                        DateTime dateCreation = rdr.GetDateTime("dateAvisCreation");
                        string commentaireAvis = rdr.GetString("commentaire");
                        int numArticle = rdr.GetInt32("idArticle");
                        string auteur = rdr.GetString("adrMailCompte");

                        Avis avis = new Avis(idAvis, dateCreation, commentaireAvis, numArticle, auteur);
                        avisParArticle.Add(avis);
                    }
                    rdr.Close();
                }
            }
            // On retourne la liste des avis sur l'article
            return avisParArticle;
        }

        /// <summary>
        /// Fonction utilisée pour supprimer un avis
        /// </summary>
        /// <param name="saisieIdArticle">L'identifiant de l'avis concerné.</param>
        /// <returns>Un booléen, soit la vérification de l'execution de la requête.</returns>
        // CG0007C - Suppression de l'avis
        public static bool DeleteAvis(int idAvis) {
            bool connValidBD = AppliBD.ConnexionBD();
            bool verification = false; // Pour vérifier si la suppression de l'avis a été effectuée.

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour supprimer l'avis.
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparée pour supprimer l'avis
                string req = "DELETE FROM AVIS WHERE idAvis = @idAvis;";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@idAvis", idAvis);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                verification = true;
            }
            return verification;
        }

        // --------------------------------------------------------- PARTIE GESTION DES RUBRIQUES ---------------------------------------------------------

        /// <summary>
        /// Fonction utilisée pour récupérer l'ensemble des rubriques.
        /// </summary>
        /// <returns>Une liste de rubriques, soit toutes les rubriques de la base de données.</returns>
        // CG0008A - Récupération de toutes les rubriques.
        public static List<Rubrique> GetLesRubriques()
        {
            List<Rubrique> lesRubriques = new List<Rubrique>();
            bool connValidBD = AppliBD.ConnexionBD(); // Connexion à la base de donnée

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour récupérer l'ensemble des rubriques
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparé pour récupérer les rubriques de la BDD
                string req = "SELECT RUBRIQUE.idRubrique, RUBRIQUE.nomRubrique " +
                             "FROM RUBRIQUE " +
                             "ORDER BY RUBRIQUE.idRubrique;";

                cmd.CommandText = req;

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Tant qu'on peux lire un résultat, on crée une rubrique et on l'ajoute à la liste
                    while (rdr.Read())
                    {
                        Rubrique rubrique;
                        int id = rdr.GetInt32("idRubrique");
                        string nom = rdr.GetString("nomRubrique").ToUpper();

                        rubrique = new Rubrique(id, nom);
                        lesRubriques.Add(rubrique);
                    }
                    rdr.Close();
                }
            }
            // On retourne la liste des rubriques de la BDD
            return lesRubriques;
        }

        /// <summary>
        /// Fonction utilisée pour ajouter une nouvelle rubrique.
        /// </summary>
        /// <param name="nomRubrique">Le nom de la Rubrique à ajouter.</param>
        /// <returns>Un entier, soit le nombre d'insertion de lignes.</returns>
        // CG0008B - Ajout d'une nouvelle rubrique
        public static int AddRubrique(string nomRubrique)
        {
            bool connValidBD = AppliBD.ConnexionBD();
            bool existeRubrique = false; // Pour vérifier s'il existe déjà une rubrique du même nom, afin de minimiser les duplicatas.

            // Nous allons d'abord vérifier que le nom de cette rubrique n'existe pas déjà dans la base de données.
            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour ajouter notre nouvelle rubrique.
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparé pour récupérer le nom de notre rubrique dans la BDD
                string reqSelect = "SELECT nomRubrique FROM RUBRIQUE WHERE nomRubrique = @nom;";

                cmd.CommandText = reqSelect;
                cmd.Parameters.AddWithValue("@nom", nomRubrique);
                cmd.Prepare();

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read()) { existeRubrique = true; }
                    rdr.Close();
                }

                // Si le nom de la rubrique n'existe pas, alors on l'ajoute
                if (!existeRubrique)
                {
                    // Requête préparée pour insérer une nouvelle rubrique
                    string reqInsert = "INSERT INTO RUBRIQUE (nomRubrique) VALUES (@nom); SELECT LAST_INSERT_ID();";

                    cmd.CommandText = reqInsert;
                    int idNewRubrique = Convert.ToInt32(cmd.ExecuteScalar());

                    _ = new Rubrique(idNewRubrique, nomRubrique);
                    return 1; // Le chiffre 1 désigne le succès de l'insertion.
                }
                else
                {
                    return -1; // Le chiffre -1 désigne l'erreur "Une rubrique du même nom existe déjà."
                }
            }
            return 0; // Le chiffre 0 désigne l'échec' de l'insertion.
        }

        /// <summary>
        /// Fonction utilisée pour mettre à jour le nom de la rubrique donnée.
        /// </summary>
        /// <param name="rubrique">La rubrique concernée.</param>
        /// <param name="newName">Le nouveau nom de la rubrique.</param>
        /// <returns>Un entier, soit le nombre d'insertion de lignes.</returns>
        // CG0008C - Mise à jour d'une rubrique déjà existante
        public static int UpdateRubrique(Rubrique rubrique, string newName)
        {
            bool connValidBD = AppliBD.ConnexionBD();
            bool existeRubrique = false; // Pour vérifier s'il existe déjà une rubrique du même nom, afin de minimiser les duplicatas.

            // Nous allons d'abord vérifier que le nom de cette rubrique n'existe pas déjà dans la base de données.
            // Si la connexion avec la base de données a réussi, on exécute les étapes pour mettre à jour la rubrique.
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparé pour récupérer le nom de notre rubrique dans la BDD
                string reqSelect = "SELECT nomRubrique FROM RUBRIQUE WHERE nomRubrique = @nom;";

                cmd.CommandText = reqSelect;
                cmd.Parameters.AddWithValue("@nom", newName);
                cmd.Prepare();

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read()) { existeRubrique = true; }
                    rdr.Close();
                }

                // Si le nom de la rubrique n'existe pas, alors on l'ajoute
                if (!existeRubrique)
                {
                    // Requête préparée pour mettre à jour le nom de la rubrique
                    string req = "UPDATE RUBRIQUE SET nomRubrique = @nom WHERE idRubrique = @idRubrique;";

                    cmd.CommandText = req;
                    cmd.Parameters.AddWithValue("@idRubrique", rubrique.GetId());
                    cmd.Prepare();
                    int lignesAffectées = cmd.ExecuteNonQuery();

                    if (lignesAffectées > 0)
                    {
                        rubrique.SetNom(newName); // Mettre à jour le nom de la rubrique dans l'objet Rubrique
                        return 1; // Le chiffre 1 indique le succès de la mise à jour.
                    }
                    else
                    {
                        return 0; // Le chiffre 0 indique que la mise à jour a échoué.
                    }
                }
                else
                {
                    return -1; // Le chiffre -1 désigne l'erreur "Une rubrique du même nom existe déjà."
                }
            }
            return 0; // Le chiffre 0 désigne l'échec de l'insertion.
        }

        /// <summary>
        /// Fonction utilisée pour supprimer une rubrique donnée
        /// </summary>
        /// <param name="rubrique">La rubrique concernée.</param>
        /// <returns>Un booléen, soit la vérification de l'execution de la requête.</returns>
        // CG0008D - Suppression d'une rubrique déjà existante
        public static bool DeleteRubrique(Rubrique rubrique)
        {
            bool connValidBD = AppliBD.ConnexionBD();

            // Si la connexion avec la base de données a réussi, on exécute les étapes pour supprimer la rubrique.
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparée pour supprimer la rubrique
                string req = "DELETE FROM RUBRIQUE WHERE idRubrique = @idRubrique;";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@idRubrique", rubrique.GetId());
                cmd.Prepare();
                int lignesAffectées = cmd.ExecuteNonQuery();

                if (lignesAffectées > 0)
                {
                    return true; // Si au moins une ligne a été affectée, cela signifie que la rubrique a été supprimée avec succès
                }
            }
            return false; // Si quelque chose s'est mal passé, ou si aucune ligne n'a été affectée, retournez false
        }

        /// <summary>
        /// Fonction utilisée pour rechercher une rubrique en particulier
        /// </summary>
        /// <param name="motCle">Le nom approximatif de la rubrique.</param>
        /// <returns>Une liste de rubriques, soit la liste des rubriques attendues.</returns>
        // CG0008A - Récupération des rubriques en fonction du motCle (nom de la rubrique).
        public static List<Rubrique> GetRechercheRubrique(string motCle)
        {
            List<Rubrique> rubriquesTrouvees = new List<Rubrique>();
            bool connValidBD = AppliBD.ConnexionBD();

            // Si la connexion avec la base de données a réussi, on exécute les étapes pour récupérer les rubriques.
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparée pour récupérer les rubriques contenant le mot clé
                string req = "SELECT RUBRIQUE.idRubrique, RUBRIQUE.nomRubrique FROM RUBRIQUE " +
                                   "WHERE RUBRIQUE.nomRubrique LIKE @motCle;";
                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@motCle", "%" + motCle + "%");
                cmd.Prepare();

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Tant qu'on peut lire un résultat, on crée une rubrique et on l'ajoute à la liste
                    while (rdr.Read())
                    {
                        int id = rdr.GetInt32("idRubrique");
                        string nom = rdr.GetString("nomRubrique").ToUpper();

                        Rubrique rubrique = new Rubrique(id, nom);
                        rubriquesTrouvees.Add(rubrique);
                    }
                    rdr.Close();
                }
            }
            // On retourne la liste des rubriques trouvées.
            return rubriquesTrouvees;
        }

        // ================================================================== UTILISATEUR ==================================================================
        // --------------------------------------------------------- PARTIE CONSULTATION DU PROFIL ---------------------------------------------------------

        /// <summary>
        /// Fonction utilisée pour vérifier le nombre d'avertissement de l'utilisateur qui tente d'accéder à l'application.
        /// </summary>
        /// <param name="mail">L'adresse email de l'utilisateur.</param>
        /// <returns>Un entier, soit le nombre d'avertissement du compte de l'utilisateur</returns>
        // CG0012 - Récupération de l'ensemble des informations de l'utilisateur
        public static Utilisateur GetUtilisateurParId(int idUser)
        {
            Utilisateur user = null;
            bool connValidBD = AppliBD.ConnexionBD();

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour récupérer l'ensemble des utilisateurs
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparé pour récupérer les informations de l'utilisateur concerné
                string req = "SELECT adrMailCompte, nomCompte, prenomCompte, dateInscription, nbAvertissement, noTelCompte, noPortableCompte " +
                             "FROM COMPTE WHERE numAdherent = @id;";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@id", idUser);
                cmd.Prepare();

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Tant qu'on peux lire un résultat, on crée un utilisateur et on l'ajoute à la liste
                    if (rdr.Read())
                    {
                        string mail = rdr.GetString("adrMailCompte");
                        string nom = rdr.GetString("nomCompte");
                        string prenom = rdr.GetString("prenomCompte");
                        DateTime dateInscrit = rdr.GetDateTime("dateInscription");
                        int nbAvertissement = rdr.GetInt32("nbAvertissement");
                        string telephone = rdr.IsDBNull(rdr.GetOrdinal("noTelCompte")) ? null : rdr.GetString("noTelCompte");
                        string portable = rdr.IsDBNull(rdr.GetOrdinal("noPortableCompte")) ? null : rdr.GetString("noPortableCompte");
                        user = new Utilisateur(mail, nom, prenom, dateInscrit, nbAvertissement, telephone, portable, "USER");
                    }
                    rdr.Close();
                }
            }
            // On retourne l'utilisateur
            return user;
        }

        public static int UpdateProfil(int idUtilisateur, string saisieTelephone, string saisiePortable)
        {
            bool connValidBD = AppliBD.ConnexionBD();

            // Nous allons d'abord vérifier que le nom de cette rubrique n'existe pas déjà dans la base de données.
            // Si la connexion avec la base de données a réussi, on exécute les étapes pour mettre à jour la rubrique.
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparée pour mettre à jour le numéro de portable et de téléphone de l'utilisateur
                string req = "UPDATE COMPTE " +
                             "SET noTelCompte = @Telephone, noPortableCompte = @Portable " +
                             "WHERE numAdherent = @idUtilisateur";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@Telephone", saisieTelephone);
                cmd.Parameters.AddWithValue("@Portable", saisiePortable);
                cmd.Parameters.AddWithValue("@idUtilisateur", idUtilisateur);
                cmd.Prepare();
                int lignesAffectées = cmd.ExecuteNonQuery();

                if (lignesAffectées > 0)
                {
                    return 1; // Le chiffre 1 indique le succès de la mise à jour.
                }
                else
                {
                    return 0; // Le chiffre 0 indique que la mise à jour a échoué.
                }
            }
            return 0; // Le chiffre 0 désigne une erreur avec la base de données.
        }

        // --------------------------------------------------------- PARTIE TABLEAU DE BORD ---------------------------------------------------------

        public static List<Article> GetSesArticles(int idUtilisateur)
        {
            List<Article> lesArticles = new List<Article>();
            bool connValidBD = AppliBD.ConnexionBD();

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour récupérer l'ensemble des utilisateurs
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête SQL pour sélectionner les articles de l'utilisateur spécifié
                string req = "SELECT idArticle, titreArticle, descriptionArticle, dateArticleCreation, COMPTE.adrMailCompte, ETAT_VALID.nomValid " +
                             "FROM ARTICLE INNER JOIN ETAT_VALID ON ARTICLE.idValid = ETAT_VALID.idValid " +
                             "INNER JOIN COMPTE ON ARTICLE.auteurArticle = COMPTE.numAdherent " +
                             "WHERE auteurArticle = @idUtilisateur";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@idUtilisateur", idUtilisateur);
                cmd.Prepare();

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Tant qu'on peux lire un résultat, on crée un utilisateur et on l'ajoute à la liste
                    while (rdr.Read())
                    {
                        int id = rdr.GetInt32("idArticle");
                        string titre = rdr.IsDBNull(rdr.GetOrdinal("titreArticle")) ? "Titre" : rdr.GetString("titreArticle");
                        string description = rdr.IsDBNull(rdr.GetOrdinal("descriptionArticle")) ? "Description de l'article" : rdr.GetString("descriptionArticle");
                        string auteur = rdr.GetString("adrMailCompte");
                        DateTime dateCreation = rdr.GetDateTime("dateArticleCreation");
                        string etat = rdr.GetString("nomValid");

                        Article article = new Article(id, titre, description, auteur, dateCreation, etat);
                        lesArticles.Add(article);
                    }
                    rdr.Close();
                }
            }
            return lesArticles;
        }

        public static List<Avis> GetSesAvis(int idUtilisateur)
        {
            List<Avis> lesAvis = new List<Avis>();
            bool connValidBD = AppliBD.ConnexionBD();

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour récupérer l'ensemble des utilisateurs
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparée pour récupérer tous les avis sur l'article
                string req = "SELECT idAvis, dateAvisCreation, commentaire, idArticle, COMPTE.adrMailCompte FROM AVIS " +
                             "INNER JOIN COMPTE ON AVIS.idAdherent = COMPTE.numAdherent " +
                             "WHERE idAdherent = @idUtilisateur " +
                             "ORDER BY dateAvisCreation DESC;";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@idUtilisateur", idUtilisateur);
                cmd.Prepare();

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Tant qu'on peux lire un résultat, on crée un utilisateur et on l'ajoute à la liste
                    while (rdr.Read())
                    {
                        int idAvis = rdr.GetInt32("idAvis");
                        DateTime dateCreation = rdr.GetDateTime("dateAvisCreation");
                        string commentaireAvis = rdr.GetString("commentaire");
                        int numArticle = rdr.GetInt32("idArticle");
                        string auteur = rdr.GetString("adrMailCompte");

                        Avis avis = new Avis(idAvis, dateCreation, commentaireAvis, numArticle, auteur);
                        lesAvis.Add(avis);
                    }
                    rdr.Close();
                }
            }
            return lesAvis;
        }

        // --------------------------------------------------------- AUTRE(S) METHODE(S) ---------------------------------------------------------

        /// <summary>
        /// Fonction utilisée pour afficher le copyright avec l'année actuelle.
        /// </summary>
        /// <returns>Une chaîne de caractères, soit le copyright.</returns>
        // CG0003 - Affichage du copyright
        public static string ToStringCopyright() {
            return "@VVA - " + DateTime.Today.Year;
        }
    }
}
