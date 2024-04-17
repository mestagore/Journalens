using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresseRESA
{
    public partial class FormPresseAdmin : Form
    {
        public string viewUsers;
        public string viewArticles;
        
        // Initialisation du Formulaire
        public FormPresseAdmin()
        {
            InitializeComponent();
            viewUsers = "ALL";
            viewArticles = "ALL";
            labCopyright.Text = AppliBD.ToStringCopyright();

            // CG0004 - Non affichage du tabControl lors du démarrage du Form
            tabControlAdmin.TabPages.Remove(tabPUtilisateur);
            tabControlAdmin.TabPages.Remove(tabPArticle);
            tabControlAdmin.TabPages.Remove(tabPRubrique);
            tabControlAdmin.Hide();
        }

        // --------------------------------------------------------- PARTIE CONNEXION ET DECONNEXION ---------------------------------------------------------

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControlAdmin.Show();

            switch (comboBOnglet.SelectedIndex)
            {
                case 0:
                    AfficherOngletUtilisateurs();
                    break;

                case 1:
                    AfficherOngletArticles();
                    break;

                case 2:
                    AfficherOngletRubriques();
                    break;
            }
        }

        private void AfficherOngletUtilisateurs()
        {
            tabControlAdmin.TabPages.Clear();
            tabControlAdmin.TabPages.Add(tabPUtilisateur);

            InitializeUserList();
        }

        private void AfficherOngletArticles()
        {
            tabControlAdmin.TabPages.Clear();
            tabControlAdmin.TabPages.Add(tabPArticle);

            InitializeArticleList();

            InitializeRubriqueList();

            listBAvis.Items.Clear();
        }

        private void AfficherOngletRubriques()
        {
            tabControlAdmin.TabPages.Clear();
            tabControlAdmin.TabPages.Add(tabPRubrique);

            InitializeRubriqueList();
        }

        // A VERIFIER
        public void ResetListeAvis()
        {
            if (listBArticles.SelectedItem != null)
            {
                Article articleSelectionne = (Article)listBArticles.SelectedItem;
                listBAvis.Items.Clear();

                List<Avis> lesAvis = AppliBD.GetAvisParArticle(articleSelectionne.GetId());
                listBArticles.Items.AddRange(lesAvis.ToArray());
            }
        }

        // CG0002D - Déconnexion de l'utilisateur
        private void btnDecoAdmin_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(" Voulez-vous vraiment vous déconnecter  ? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Session.GetFormConnexion().Show();
                Session.GetFormConnexion().Focus();
                Close(); // Fermer le formulaire actuel
            }
        }

        // --------------------------------------------------------- PARTIE GESTION DES UTILISATEURS ---------------------------------------------------------

        // Initialisation de la listeBox des utilisateurs
        public void InitializeUserList()
        {
            listBUsers.Items.Clear();
            List<Utilisateur> lesUsers = AppliBD.GetLesUtilisateurs(viewUsers);
            listBUsers.Items.AddRange(lesUsers.ToArray());
        }

        // CG0005C - Vérification des informations saisies pour ajouter l'utilisateur
        private void button2_Click(object sender, EventArgs e)
        {
            string saisieAdresseMel = txtBAdrMailUser.Text.ToLower();
            string saisieNom = txtBNomUser.Text.ToUpper();
            string saisiePrenom = txtBPrenomUser.Text;
            string saisieTelephone = txtBTelephoneUser.Text;
            string saisiePortable = txtBPortableUser.Text;

            try
            {
                if (string.IsNullOrEmpty(saisieAdresseMel))
                    throw new Exception("Veuillez renseigner une adresse mail.");

                if (!saisieAdresseMel.Contains("@"))
                    throw new Exception("L'adresse saisie est syntaxiquement incorrecte. Veuillez essayer avec une autre adresse.");

                if (string.IsNullOrEmpty(saisieNom))
                    throw new Exception("Veuillez renseigner un nom de famille.");

                if (string.IsNullOrEmpty(saisiePrenom))
                    throw new Exception("Veuillez renseigner un prénom.");

                if (!string.IsNullOrEmpty(saisieTelephone))
                {
                    if (!EstComposeUniquementDeChiffres(saisieTelephone) || saisieTelephone.Length != 10)
                        throw new Exception("Le numéro de téléphone doit contenir uniquement 10 chiffres.");
                }

                if (!string.IsNullOrEmpty(saisiePortable))
                {
                    if (!EstComposeUniquementDeChiffres(saisiePortable) || saisiePortable.Length != 10)
                    throw new Exception("Le numéro de portable doit contenir uniquement 10 chiffres.");
                }

                if (comboBTypeCpte.SelectedIndex == -1)
                {
                    throw new Exception("Veuillez sélectionner un type de compte.");
                }

                int typeCompte = comboBTypeCpte.SelectedIndex + 1; // Index 0 correspond à USER, Index 1 correspond à ADMIN
                int etatInsertion = AppliBD.AddUtilisateur(saisieAdresseMel, saisieNom, saisiePrenom, saisieTelephone, saisiePortable, typeCompte);
                verifInsertUser(etatInsertion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de l'ajout de l'utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool EstComposeUniquementDeChiffres(string maChaine)
        {
            return Regex.IsMatch(maChaine, @"^[0-9]+$");
        }

        /// <summary>
        /// Méthode utilisée pour vérifier l'étât de l'ajout de notre utilisateur.
        /// </summary>
        /// <param name="nbInsertion">Le nombre d'insertion effectué.</param>
        // CG0005G - Vérification de l'étât de notre insertion
        private void verifInsertUser(int nbInsertion) {
            switch (nbInsertion)
            {
                case 0: // Cas : Insertion échouée
                    MessageBox.Show("Echec de l'Insertion, veuillez réessayez. Si le problème persiste, contactez l'administrateur.", "Echec de l'Insertion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 1: // Cas : Insertion réussie
                    InitializeUserList();
                    MessageBox.Show("Succès de l'Insertion.", "Succès de l'Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case -1: // Cas : Adresse Mail déjà utilisée
                    MessageBox.Show("Cette adresse mail est déjà associée à un compte. Veuillez fournir une nouvelle adresse mail.", "Adresse Mail Invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        // Événement déclenché lorsque l'utilisateur sélectionne l'option "Tous les utilisateurs"
        private void radioBAllUsers_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBAllUsers.Checked)
            {
                viewUsers = "ALL";
                InitializeUserList();
            }
        }

        // Événement déclenché lorsque l'utilisateur sélectionne l'option "Utilisateurs conformes"
        private void radioBGoodUsers_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBGoodUsers.Checked)
            {
                viewUsers = "GOOD";
                InitializeUserList();
            }
        }

        // Événement déclenché lorsque l'utilisateur sélectionne l'option "Utilisateurs ayant un nombre d'avertissement égal à 3"
        private void radioBUsersAvertissement_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBUsersAvertissement.Checked)
            {
                viewUsers = "AVERTISSEMENT";
                InitializeUserList();
            }
        }

        // Événement déclenché lorsque l'utilisateur sélectionne l'option "Utilisateurs ayant un compte fermé"
        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioBUsersBloque.Checked)
            {
                viewUsers = "BLOQUE";
                InitializeUserList();
            }
        }

        // CG0005H - Affichage des informations d'un utilisateur dans un nouveau formulaire (FormDetailsUtilisateur)
        private void ListBUsers_DoubleClick(object sender, EventArgs e)
        {
            if (listBUsers.SelectedItem != null)
            {
                Utilisateur utilisateurSelectionne = (Utilisateur)listBUsers.SelectedItem;

                FormDetailsUser userInfoForm = new FormDetailsUser();

                userInfoForm.AfficherInfosUtilisateur(utilisateurSelectionne);

                userInfoForm.Owner = this;
                userInfoForm.Show();
            }
        }

        // --------------------------------------------------------- PARTIE GESTION DES ARTICLES ---------------------------------------------------------

        // CG0006A - Initialisation de la listeBox des articles
        public void InitializeArticleList()
        {
            listBArticles.Items.Clear();
            List<Article> lesArticles = AppliBD.GetLesArticles(viewArticles);
            listBArticles.Items.AddRange(lesArticles.ToArray());
        }

        // CG0006A - Événement déclenché lorsque l'utilisateur sélectionne l'option "Tous les articles"
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBAllArticle.Checked)
            {
                viewArticles = "ALL";
                InitializeArticleList();
            }
        }

        // CG0006A - Événement déclenché lorsque l'utilisateur sélectionne l'option "Articles en attente"
        private void radioBArticleEnAttente_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBArticleEnAttente.Checked)
            {
                viewArticles = "EN_ATTENTE";
                InitializeArticleList();
            }
        }

        // CG0006A - Événement déclenché lorsque l'utilisateur sélectionne l'option "Articles validés"
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBArticleValide.Checked)
            {
                viewArticles = "VALIDE";
                InitializeArticleList();
            }
        }

        // CG0006A - Événement déclenché lorsque l'utilisateur sélectionne l'option "Articles refusés"
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBArticleRefus.Checked)
            {
                viewArticles = "REJET";
                InitializeArticleList();
            }
        }

        // CG0006F - Affichage des informations d'un article dans un nouveau formulaire (FormDetailsArticle)
        private void listBArticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBArticles.SelectedItem != null)
            {
                Article articleSelectionne = (Article)listBArticles.SelectedItem;

                FormDetailsArticle articleInfoForm = new FormDetailsArticle(articleSelectionne);

                articleInfoForm.AfficherInfosArticle(articleSelectionne);

                articleInfoForm.Owner = this;
                articleInfoForm.Show();
            }
        }

        // CG0008F - Affichage des rubriques déjà ssociées à l'article
        private void listBArticles_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBArticles.SelectedItem != null)
            {
                Article articleSelectionne = (Article)listBArticles.SelectedItem;
                List<Rubrique> rubriques = AppliBD.GetRubriquesParArticle(articleSelectionne.GetId());
                List<Avis> avis = AppliBD.GetAvisParArticle(articleSelectionne.GetId());

                // Effacer la liste des rubriques précédentes
                listBRubriquesArticle.Items.Clear();
                listBAvis.Items.Clear();

                // Ajouter les rubriques associées à l'article à la ListBox listBRubriquesArticle
                foreach (Rubrique rubrique in rubriques)
                {
                    listBRubriquesArticle.Items.Add(rubrique.GetNom());
                }

                foreach (Avis unAvis in avis)
                {
                    listBAvis.Items.Add(unAvis);
                }
            }
        }

        // CG0006B - Attribution d'une rubrique à l'article selectionné
        private void button1_Click_2(object sender, EventArgs e)
        {
            if (listBArticles.SelectedItem != null && listBRubriquesDispo.SelectedItem != null)
            {
                bool verif = AppliBD.AddRubriquePourArticle((Article)listBArticles.SelectedItem, (Rubrique)listBRubriquesDispo.SelectedItem);
                Rubrique rubrique = (Rubrique)listBRubriquesDispo.SelectedItem;

                if (verif)
                {
                    MessageBox.Show("Rubrique attribué avec succès.", "Update réussi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listBRubriquesArticle.Items.Add(rubrique.GetNom());
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'attribution de la rubrique, veuillez réessayez. Si le problème persiste, contactez l'administrateur.", "Echec de l'Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez vérifier que vous avez bien selectionné l'article et la rubrique à lui attribuer.", "Absence de sélection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CG0006C - Suppression de toutes les rubriques associées à l'article
        private void btnResetRubrique_Click(object sender, EventArgs e)
        {
            if (listBArticles.SelectedItem != null)
            {
                Article article = (Article)listBArticles.SelectedItem;

                DialogResult dr = MessageBox.Show(" Voulez-vous vraiment réinitialiser les rubriques de l'article n°" + article.GetId() + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    bool verif = AppliBD.ResetRubriquesArticle(article);
                    if (!verif)
                    {
                        MessageBox.Show("Erreur lors de la réinitialisation des rubriques de cette article, veuillez réessayez.", "Echec de l'Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else {
                        listBRubriquesArticle.Items.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Aucun article n'est selectionné.", "Absence de sélection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listBArticles.Items.Clear();
            listBAvis.Items.Clear();
            switch (btnFiltrageArticle.Text)
            {
                case "Filtrer":
                    {
                        string saisieIdArticle = txtBIdArticle.Text;
                        string saisieAuteurArticle = txtBAuteurArticle.Text;

                        List<Article> lesArticles = AppliBD.GetRechercheArticle(saisieIdArticle, saisieAuteurArticle);
                        listBArticles.Items.AddRange(lesArticles.ToArray());

                        btnFiltrageArticle.Text = "Annuler";
                        break;
                    }

                default:
                    {

                        List<Article> lesArticles = AppliBD.GetLesArticles("");
                        listBArticles.Items.AddRange(lesArticles.ToArray());

                        btnFiltrageArticle.Text = "Filtrer";
                        break;
                    }
            }
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            listBRubriquesDispo.Items.Clear();
            switch (btnRecherche.Text)
            {
                case "Rechercher":
                    {
                        string saisieNom = txtBNomRechercheRubrique.Text.ToUpper();
                        List<Rubrique> lesRubriques = AppliBD.GetRechercheRubrique(saisieNom);
                        listBRubriquesDispo.Items.AddRange(lesRubriques.ToArray());

                        btnRecherche.Text = "Tout afficher";
                        break;
                    }

                default:
                    {
                        List<Rubrique> lesRubriques = AppliBD.GetLesRubriques();
                        listBRubriquesDispo.Items.AddRange(lesRubriques.ToArray());

                        btnRecherche.Text = "Rechercher";
                        break;
                    }
            }
        }

        private void listBAvis_DoubleClick(object sender, EventArgs e)
        {
            if (listBAvis.SelectedItem != null)
            {
                Avis avisSelectionne = (Avis)listBAvis.SelectedItem;

                FormDetailsAvis avisInfoForm = new FormDetailsAvis();

                avisInfoForm.AfficherInfosAvis(avisSelectionne);

                avisInfoForm.Owner = this;
                avisInfoForm.Show();
            }
        }

        // --------------------------------------------------------- PARTIE GESTION DES RUBRIQUES ---------------------------------------------------------

        // Initialisation de la listeBox des utilisateurs
        public void InitializeRubriqueList()
        {
            listBRubriquesDispo.Items.Clear();
            List<Rubrique> lesRubriquesDispo = AppliBD.GetLesRubriques();
            listBRubriquesDispo.Items.AddRange(lesRubriquesDispo.ToArray());
        }

        // CG0008B - Ajout d'une nouvelle rubrique
        private void button1_Click_3(object sender, EventArgs e)
        {
            string saisieNom = txtBNomRubrique.Text.ToUpper();

            if (saisieNom != "")
            {
                int etatInsertion = AppliBD.AddRubrique(saisieNom);
                verifRubrique(etatInsertion);
            }
            else
            {
                MessageBox.Show("Veuillez renseigner un nom pour la rubrique.", "Absence de nom", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Méthode utilisée pour vérifier si l'ajout de notre rubrique à bien été effectué.
        /// </summary>
        /// <param name="nbInsertion">Le nombre d'insertion effectué.</param>
        // CG0005G - Vérification de l'étât de notre insertion
        private void verifRubrique(int nbInsertion)
        {
            switch (nbInsertion)
            {
                case 0: // Cas : Opération échouée
                    MessageBox.Show("Echec de la manoeuvre, veuillez réessayez. Si le problème persiste, contactez l'administrateur.", "Echec de l'opération", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 1: // Cas : Opération réussie
                    InitializeRubriqueList();
                    MessageBox.Show("Succès de la manoeuvre.", "Succès de l'opération", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case -1: // Cas : Nom déjà existant
                    MessageBox.Show("Une rubrique du même nom existe déjà.", "Rubrique redondante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        // CG0008C - Mise à jour du nom d'une rubrique déjà existante
        private void button1_Click_4(object sender, EventArgs e)
        {
            if (listBRubriques.SelectedItem != null)
            {
                string saisieNom = txtBNomRubrique.Text.ToUpper();

                if (saisieNom != "")
                {
                    Rubrique rubriqueSelectionne = (Rubrique)listBRubriques.SelectedItem;

                    int etatInsertion = AppliBD.UpdateRubrique(rubriqueSelectionne, saisieNom);
                    verifRubrique(etatInsertion);
                }
                else
                {
                    MessageBox.Show("Vous ne pouvez pas modifier le nom de la rubrique par aucun caractère.", "Absence de caractères", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez choisir une rubrique à modifier.", "Absence de selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CG0008A - Affichage de toutes les rubriques.
        private void listBRubriques_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBRubriques.SelectedItem != null)
            {
                Rubrique rubriqueSelectionne = (Rubrique)listBRubriques.SelectedItem;
                txtBNomRubrique.Text = rubriqueSelectionne.GetNom().ToUpper();
            }
        }

        // CG0008D - Suppression d'une rubrique déjà existante
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBRubriques.SelectedItem != null)
            {
                Rubrique rubriqueSelectionne = (Rubrique)listBRubriques.SelectedItem;

                DialogResult dr = MessageBox.Show(" Voulez-vous vraiment supprimer la rubrique n°" + rubriqueSelectionne.GetId() + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    bool verif = AppliBD.DeleteRubrique(rubriqueSelectionne);
                    if (!verif)
                    {
                        MessageBox.Show("Erreur lors de la suppression de la rubrique, veuillez réessayez.", "Echec de la Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        InitializeRubriqueList();
                    }
                }
            }
            else
            {
                MessageBox.Show("Aucune rubrique n'est selectionnée.", "Absence de sélection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CG0008E - Filtrage des rubriques
        private void btnRechercheRubrique_Click(object sender, EventArgs e)
        {
            switch (btnRechercheRubrique.Text)
            {
                case "Rechercher":
                    {
                        btnRechercheRubrique.Text = "Afficher toutes les rubriques";
                        string saisieNom = txtBNomRubrique.Text.ToUpper();

                        listBRubriques.Items.Clear();
                        List<Rubrique> lesRubriques = AppliBD.GetRechercheRubrique(saisieNom);
                        listBRubriques.Items.AddRange(lesRubriques.ToArray());
                        break;
                    }

                default:
                    {
                        btnRechercheRubrique.Text = "Rechercher";
                        InitializeRubriqueList();
                        break;
                    }
            }
        }

        private void groupBRubriqueArticle_Enter(object sender, EventArgs e)
        {

        }

        private void listBAvis_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listBRubriquesArticle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
