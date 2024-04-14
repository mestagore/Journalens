using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresseRESA
{
    public static class AppliBD {
        private static MySqlConnection conn = null;

        /// <summary>
        /// Fonction utilisée pour se connecter à la base de donnée.
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


        /// <summary>
        /// Fonction utilisée pour permettre à l'utilisateur de se connecter à l'application.
        /// </summary>
        /// <param name="mail">L'adresse email de l'utilisateur.</param>
        /// <param name="pass">Le mot de passe de l'utilisateur.</param>
        /// <returns>Une chaîne de caractère, soit le type de compte de l'utilisateur</returns>
        // CG0002A - Vérification de l'existence dans la BDD 
        public static string ConnexionUser(string mail, string pass)
        {
            string typeU = "I"; // Valeur par défaut : I pour Inconnu
            bool connValidBD = AppliBD.ConnexionBD(); // Connexion à la base de donnée
            
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
        // CG0002B - Vérification du nombre d'avertissement
        public static int VerifAvertissement(string mail) {
            int nbAvertissement = 0;
            bool connValidBD = AppliBD.ConnexionBD(); // Connexion à la base de donnée

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes de recherche du nombre d'avertissement du compte de l'utilisateur qui tente de se connecter
            if (connValidBD) {

                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparé permettant de récupérer le nombre d'avertissement de l'utilisateur qui tente de se connecter
                string req = "SELECT nbAvertissement FROM COMPTE " +
                             "WHERE adrMailCompte = @mail";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Prepare();

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Si on peux lire un résultat, on valorise nbAvertissement avec la valeur renvoyé par la BDD
                    if (rdr.Read()) {
                        nbAvertissement = rdr.GetInt16("nbAvertissement");
                    }
                    rdr.Close();
                }
            }

            // On retourne le nombre d'avertissement de l'utilisateur
            return nbAvertissement;
        }

        /// <summary>
        /// Fonction utilisée pour récupérer tous les utilisateurs de la BDD (qui peuvent se connecter).
        /// </summary>
        /// <returns>Une liste d'utilisateurs.</returns>
        // CG0005A - Récupération des utilisateurs
        public static List<Utilisateur> GetLesUtilisateurs(bool allUsers)
        {
            List<Utilisateur> lesUsers = new List<Utilisateur>();
            bool connValidBD = AppliBD.ConnexionBD(); // Connexion à la base de donnée

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour récupérer l'ensemble des utilisateurs
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparé pour récupérer les utilisateurs de la BDD
                string req = "SELECT adrMailCompte, nomCompte, prenomCompte, dateInscription, dateFermeture, nbAvertissement, noTelCompte, noPortableCompte, TYPE_CPTE.nomTypeCpte " +
                             "FROM COMPTE INNER JOIN TYPE_CPTE ON COMPTE.typeCpte = TYPE_CPTE.idTypeCpte";
                if(allUsers) { 
                    req = req + ";";
                } else {
                    req = req + " WHERE nbAvertissement < 3 AND dateFermeture IS NULL;";
                }
                                 

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
        /// <param name="mail">L'adresse email de l'utilisateur.</param>
        /// <param name="nom">Le nom de l'utilisateur.</param>
        /// <param name="prenom">Le prénom de l'utilisateur.</param>
        /// <param name="numTelephone">Le numéro de téléphone de l'utilisateur.</param>
        /// <param name="numPortable">Le numéro de portable de l'utilisateur.</param>
        /// <param name="typeCpte">Le type du compte de l'utilisateur.</param>
        /// <returns>Un entier.</returns>
        // CG0005C - Ajout d'un nouvel adhérent (utilisateur) 
        public static int AddUtilisateur(string mail, string nom, string prenom, string numTelephone, string numPortable, int typeCpte) {
            bool connValidBD = AppliBD.ConnexionBD(); // Connexion à la base de donnée
            int nbInsert = 0;
            bool existeMail = false;

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour ajouter notre nouvel utilisateur.
            if (connValidBD)
            {
                // Nous allons d'abord vérifier que l'adresse mail est bel et bien utiliser une seule fois.
                MySqlCommand cmd = conn.CreateCommand();
                string reqSelect = "SELECT adrMailCompte FROM COMPTE WHERE adrMailCompte = @mail;";

                cmd.CommandText = reqSelect;
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Prepare();

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Si on peux lire un résultat, on crée un utilisateur et on l'ajoute à la liste
                    if (rdr.Read()) { existeMail = true; }
                    rdr.Close();
                }

                // S'il n'existe pas déjà un compte associé à ce mail, alors on l'ajoute
                if (!existeMail)
                {
                    string chHash = CreateMdpAleatoire(mail); // Chaîne de caractère haché, mot de passe provisoire
                    string dateDuJour = DateTime.Now.ToString("yyyy-MM-dd"); // Date du jour
                    string numTel = numTelephone != "" ? numTelephone : null; // Si un numéro de téléphone est renseignée, on l'ajoute.
                    string numPort = numPortable != "" ? numPortable : null; // Si un numéro de portable est renseignée, on l'ajoute.

                    // Requête préparé pour insérer l'utilisateur
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

                    // L'utilisation de "_" est simplement une variable temporaire ou non utilisée.
                    _ = new Utilisateur(mail, nom, prenom, Convert.ToDateTime(dateDuJour), 0, numTel, numPort, type);

                    nbInsert = cmd.ExecuteNonQuery();
                }
                else {
                    return 2; // Le chiffre 2 désigne l'erreur "Une adresse mail est déjà associé à un compte."
                }
            }
            return nbInsert;
        }

        /// <summary>
        /// Fonction utilisée pour concevoir un mot de passe provisoire.
        /// </summary>
        /// <param name="mail">L'adresse email de l'utilisateur.</param>
        /// <returns>Une chaîne de caractères.</returns>
        // CG0005D - Création d'un mot de passe provisoire pour l'ajout d'un utilisateur
        public static string CreateMdpAleatoire(string mail) {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            char[] Charsarr = new char[12];
            Random random = new Random();

            // On ajoute des caractères aléatoires à la suite
            for (int i = 0; i < Charsarr.Length; i++) {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            string pass = new String(Charsarr);
            string mdpProvisoire = mail + pass; // Assemblage du mail et du mot de passe aléatoire


            Console.WriteLine("Mot de passe de " + mail + " : " + pass);
            MessageBox.Show("Le mot de passe provisoire de " + mail + " est " + pass, "Mot de passe Provisoire", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return mdpProvisoire; // On retourne le mot de passe provisoire
        }

        /// <summary>
        /// Fonction utilisée pour clôturer le compte de l'utilisateur selectionné.
        /// </summary>
        /// <param name="mail">L'adresse email de l'utilisateur.</param>
        /// <returns>Un booléen.</returns>
        // CG0005E - Fermeture du compte d'un adhérent (utilisateur) 
        public static bool FermetureCpteUser(Utilisateur user)
        {
            bool connValidBD = AppliBD.ConnexionBD(); // Connexion à la base de donnée
            bool verifUpdate = false; // Pour vérifier si la suppression a été réussie
            string dateDuJour = DateTime.Now.ToString("yyyy-MM-dd"); // Date d'aujourd'hui

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour ajouter notre nouvel utilisateur.
            if (connValidBD) {
                MySqlCommand cmd = conn.CreateCommand();

                string req = "UPDATE COMPTE " +
                             "SET dateFermeture = @dateJour " +
                             "WHERE adrMailCompte = @mail;";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@mail", user.GetEmail());
                cmd.Parameters.AddWithValue("@dateJour", dateDuJour);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                user.SetDateFermeture(Convert.ToDateTime(dateDuJour));

                verifUpdate = true;
            }
            return verifUpdate;
        }

        /// <summary>
        /// Fonction utilisée pour ajouter un avertissement à l'utilisateur selectionné.
        /// </summary>
        /// <param name="user">L'utilisateur du compte.</param>
        // CG0005F - Ajout d'un avertissement
        public static bool UpdateAvertissmentCpteUser(Utilisateur user)
        {
            bool connValidBD = AppliBD.ConnexionBD(); // Connexion à la base de donnée
            bool verifUpdate = false; // Pour vérifier si la suppression a été réussie

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour ajouter notre nouvel utilisateur.
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                string req = "UPDATE COMPTE SET nbAvertissement = @nbAvert + 1 WHERE adrMailCompte = @mail";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@mail", user.GetEmail());
                cmd.Parameters.AddWithValue("@nbAvert", user.GetNbAvertissement());
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                user.SetNbAvertissement();

                verifUpdate = true;
            }
            return verifUpdate;
        }

        /// <summary>
        /// Fonction utilisée pour récupérer tous les articles de la BDD.
        /// </summary>
        /// <returns>Une liste d'articles.</returns>
        // CG0006A - Récupération des articles
        public static List<Article> GetLesArticles(string codeArticles)
        {
            List<Article> lesArticles = new List<Article>();
            bool connValidBD = AppliBD.ConnexionBD(); // Connexion à la base de donnée

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour récupérer l'ensemble des utilisateurs
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparé pour récupérer les utilisateurs de la BDD
                string req = "SELECT idArticle, titreArticle, descriptionArticle, dateArticleCreation, COMPTE.adrMailCompte, ETAT_VALID.nomValid " +
                             "FROM ARTICLE INNER JOIN ETAT_VALID ON ARTICLE.idValid = ETAT_VALID.idValid " +
                             "INNER JOIN COMPTE ON ARTICLE.auteurArticle = COMPTE.numAdherent";
                
                // En fonction du bouton radio selectionné, le codeArticles sera différent (par défaut, c'est All)
                switch (codeArticles)
                {
                    case "EN_ATTENTE":
                        req = req + " WHERE ARTICLE.idValid = 1;";
                        break;
                    case "VALIDE":
                        req = req + " WHERE ARTICLE.idValid = 2;";
                        break;
                    case "REJET":
                        req = req + " WHERE ARTICLE.idValid = 3;";
                        break;
                    default:
                        req = req + ";";
                        break;
                }

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
        /// Fonction utilisée pour mettre à jour l'état de l'article selectionné.
        /// </summary>
        /// <param name="article">L'article selectionné.</param>
        /// <param name="etatArticle">Le nouvel état.</param>
        // CG0006D - Mise à jour de l'état de l'article
        public static bool UpdateEtatArticle(Article article, int etatArticle)
        {
            bool connValidBD = AppliBD.ConnexionBD(); // Connexion à la base de donnée
            bool verifUpdate = false; // Pour vérifier si la mise à jour a été réussie


            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour mettre à jour l'état de l'article.
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();
                string etat = "";

                string req = "UPDATE ARTICLE " +
                             "SET idValid = @newEtat " +
                             "WHERE idArticle = @idArticle;";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@newEtat", etatArticle);
                cmd.Parameters.AddWithValue("@idArticle", article.GetId());
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                switch(etatArticle)
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

                verifUpdate = true;
            }
            return verifUpdate;
        }

        /// <summary>
        /// Fonction utilisée pour récupérer l'ensemble des rubriques.
        /// </summary>
        // CG0008 - Récupération de toutes les rubriques.
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
                             "FROM RUBRIQUE;";

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

        public static bool UpdateRubriqueArticle(Article article, Rubrique rubrique)
        {
            bool connValidBD = AppliBD.ConnexionBD(); // Connexion à la base de donnée
            bool verifUpdate = false; // Pour vérifier si la mise à jour a été réussie

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour mettre à jour l'état de l'article.
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                string req = "INSERT INTO ARTICLE_RUBRIQUE (idArticle, idRubrique) VALUES (@idArticle, @idRubrique);";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@idArticle", article.GetId());
                cmd.Parameters.AddWithValue("@idRubrique", rubrique.GetId());
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                verifUpdate = true;
            }
            return verifUpdate;
        }

        public static bool ResetRubriquesArticle(Article article)
        {
            bool connValidBD = AppliBD.ConnexionBD(); // Connexion à la base de donnée
            bool verifUpdate = false; // Pour vérifier si la mise à jour a été réussie

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour mettre à jour l'état de l'article.
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                string req = "DELETE FROM ARTICLE_RUBRIQUE WHERE idArticle = @idArticle;";

                cmd.CommandText = req;
                cmd.Parameters.AddWithValue("@idArticle", article.GetId());
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                verifUpdate = true;
            }
            return verifUpdate;
        }

        public static List<Rubrique> GetRubriquesParArticle(int idArticle)
        {
            List<Rubrique> lesRubriques = new List<Rubrique>();
            bool connValidBD = AppliBD.ConnexionBD(); // Connexion à la base de données

            // Si la connexion avec la base de données a réussi, on exécute les étapes pour récupérer les rubriques associées à l'article
            if (connValidBD)
            {
                MySqlCommand cmd = conn.CreateCommand();

                // Requête préparée pour récupérer les rubriques associées à l'article de la BDD
                string req = "SELECT RUBRIQUE.idRubrique, RUBRIQUE.nomRubrique " +
                             "FROM RUBRIQUE " +
                             "INNER JOIN ARTICLE_RUBRIQUE ON RUBRIQUE.idRubrique = ARTICLE_RUBRIQUE.idRubrique " +
                             "WHERE ARTICLE_RUBRIQUE.idArticle = @idArticle;";

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
        /// Fonction utilisée pour afficher le copyright avec l'année actuelle.
        /// </summary>
        /// <returns>Une chaîne de caractères.</returns>
        // CG0003 - Affichage du copyright
        public static string ToStringCopyright() {
            return "@VVA - " + DateTime.Today.Year;
        }

        public static int AddRubrique(string nomRubrique)
        {
            bool connValidBD = AppliBD.ConnexionBD(); // Connexion à la base de donnée
            bool existeRubrique = false;

            // Si la connexion avec la base de donnée à réussi, on exécute les étapes pour ajouter notre nouvel utilisateur.
            if (connValidBD)
            {
                // Nous allons d'abord vérifier que l'adresse mail est bel et bien utiliser une seule fois.
                MySqlCommand cmd = conn.CreateCommand();
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
                    // Requête préparée pour insérer la rubrique
                    string reqInsert = "INSERT INTO RUBRIQUE (nomRubrique) VALUES (@nom); SELECT LAST_INSERT_ID();";

                    cmd.CommandText = reqInsert;

                    // Exécution de la requête tout en récupérant l'ID
                    int idNewRubrique = Convert.ToInt32(cmd.ExecuteScalar());

                    _ = new Rubrique(idNewRubrique, nomRubrique);
                    return 1; // Le chiffre 1 désigne le succès de l'insertion.
                }
                else
                {
                    return 2; // Le chiffre 2 désigne l'erreur "Une rubrique du même nom existe déjà."
                }
            }
            return 0; // Le chiffre 0 désigne l'échec' de l'insertion.
        }
    }
}
