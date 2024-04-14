using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresseRESA
{
    public partial class FormPresseAdmin : Form
    {
        public FormPresseAdmin()
        {
            InitializeComponent();
            labCopyright.Text = AppliBD.ToStringCopyright();

            // CG0004 - Non affichage du tabControl lors du démarrage du Form
            tabControlAdmin.TabPages.Remove(tabPUtilisateur);
            tabControlAdmin.TabPages.Remove(tabPArticle);
            tabControlAdmin.TabPages.Remove(tabPAvis);
            tabControlAdmin.TabPages.Remove(tabPRubrique);
            tabControlAdmin.Hide();
        }

        // CG0004 - Gestion des choix de l'utilisateur
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControlAdmin.Show();

            switch (comboBOnglet.SelectedIndex)
            {
                case 0: // Cas : Option Gestion des utilisateur choisi
                    tabControlAdmin.TabPages.Add(tabPUtilisateur);
                    tabControlAdmin.TabPages.Remove(tabPArticle);
                    tabControlAdmin.TabPages.Remove(tabPAvis);
                    tabControlAdmin.TabPages.Remove(tabPRubrique);

                    // CG0004 - Initialisation de la listeBox des utilisateurs
                    listBUsers.Items.Clear();
                    List<Utilisateur> lesUsers = AppliBD.GetLesUtilisateurs(false);
                    listBUsers.Items.AddRange(lesUsers.ToArray());
                    break;

                case 1: // Cas : Option Gestion des articles choisi
                    tabControlAdmin.TabPages.Remove(tabPUtilisateur);
                    tabControlAdmin.TabPages.Add(tabPArticle);
                    tabControlAdmin.TabPages.Remove(tabPAvis);
                    tabControlAdmin.TabPages.Remove(tabPRubrique);

                    // CG0006A - Initialisation de la listeBox de tous les articles
                    listBArticles.Items.Clear();
                    List<Article> lesArticles = AppliBD.GetLesArticles("");
                    listBArticles.Items.AddRange(lesArticles.ToArray());

                    // CG0008A - Initialisation de la listeBox des rubriques disponibles
                    listBRubriquesDispo.Items.Clear();
                    List<Rubrique> lesRubriquesDispo = AppliBD.GetLesRubriques();
                    listBRubriquesDispo.Items.AddRange(lesRubriquesDispo.ToArray());
                    break;

                case 2: // Cas : Option Gestion des avis choisi
                    tabControlAdmin.TabPages.Remove(tabPUtilisateur);
                    tabControlAdmin.TabPages.Remove(tabPArticle);
                    tabControlAdmin.TabPages.Add(tabPAvis);
                    tabControlAdmin.TabPages.Remove(tabPRubrique);
                    break;

                case 3: // Cas : Option Gestion des rubriques choisi
                    tabControlAdmin.TabPages.Remove(tabPUtilisateur);
                    tabControlAdmin.TabPages.Remove(tabPArticle);
                    tabControlAdmin.TabPages.Remove(tabPAvis);
                    tabControlAdmin.TabPages.Add(tabPRubrique);

                    // CG0008A - Initialisation de la listeBox des rubriques
                    listBRubriques.Items.Clear();
                    List<Rubrique> lesRubriques = AppliBD.GetLesRubriques();
                    listBRubriques.Items.AddRange(lesRubriques.ToArray());
                    break;
            }
        }

        // CG0005E - Fermeture d'un compte utilisateur
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBUsers.SelectedItem != null)
            {
                Utilisateur user = (Utilisateur)listBUsers.SelectedItem;

                if(user.GetDateFermeture() == null)
                {
                    DialogResult dr = MessageBox.Show(" Voulez-vous vraiment clôturer le compte de cet utilisateur : " + user.GetEmail(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        bool verif = AppliBD.FermetureCpteUser(user);
                        if (verif)
                        {
                            MessageBox.Show("Compte fermé avec succès.", "Update réussi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Erreur lors de la fermeture du compte, veuillez réessayez. Si le problème persiste, contactez l'administrateur.", "Echec de l'Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                } else
                {
                    MessageBox.Show("Le compte de cet utilisateur est déjà fermé.", "Compte déjà clôturé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            } else
            {
                MessageBox.Show("Aucun utilisateur n'est selectionné.", "Absence de sélection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CG0005C - Ajout d'un utilisateur
        private void button2_Click(object sender, EventArgs e)
        {
            string saisieAdresseMel = txtBAdrMailUser.Text;
            string saisieNom = txtBNomUser.Text;
            string saisiePrenom = txtBPrenomUser.Text;
            string saisieTelephone = txtBTelephoneUser.Text;
            string saisiePortable = txtBPortableUser.Text;

            if (saisieAdresseMel != "")
            {
                if (saisieAdresseMel.Contains("@"))
                {
                    if (saisieNom != "")
                    {
                        if (saisiePrenom != "")
                        {
                            int etatInsertion;

                            // En fonction de l'élément chosi, faire...
                            switch (comboBTypeCpte.SelectedIndex)
                            {
                                case 0: // Cas : Choix d'un USER
                                    etatInsertion = AppliBD.AddUtilisateur(saisieAdresseMel, saisieNom, saisiePrenom, saisieTelephone, saisiePortable, 1);
                                    verifInsertUser(etatInsertion);
                                    break;

                                case 1: // Cas : Choix d'un ADMIN
                                    etatInsertion = AppliBD.AddUtilisateur(saisieAdresseMel, saisieNom, saisiePrenom, saisieTelephone, saisiePortable, 2);
                                    verifInsertUser(etatInsertion);
                                    break;

                                default:
                                    MessageBox.Show("Veuillez choisir le type du compte de l'utilisateur.", "Absence de type de compte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Veuillez renseigner un prénom.", "Absence de prénom", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez renseigner un nom de famille.", "Absence de nom", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Afficher une boîte de dialogue MessageBox pour indiquer à l'utilisateur que la synthaxe est incorrecte
                    MessageBox.Show("L'adresse saisie est syntaxiquement incorrect. Veuillez essayer avec une autre adresse.", "Synthaxe Incorrecte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez renseigner une adresse mail.", "Absence de mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        // CG0002D - Déconnexion de l'utilisateur
        private void btnDecoAdmin_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(" Voulez-vous vraiment vous déconnecter  ? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Session.GetFormConnexion().Show();
                Session.GetFormConnexion().Focus();
                this.Dispose();
            }
        }

        /// <summary>
        /// Fonction utilisée pour vérifier l'étât de l'ajout de notre utilisateur.
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
                    MessageBox.Show("Succès de l'Insertion.", "Succès de l'Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 2: // Cas : Adresse Mail déjà utilisée
                    MessageBox.Show("Cette adresse mail est déjà associée à un compte. Veuillez fournir une nouvelle adresse mail.", "Adresse Mail Invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        // CG0005G - Ajouter un avertissement à l'utilisateur
        private void btnAddAvertissement_Click(object sender, EventArgs e)
        {
            if (listBUsers.SelectedItem != null)
            {
                Utilisateur user = (Utilisateur)listBUsers.SelectedItem;
                int nbAvertissement = user.GetNbAvertissement();

                if (nbAvertissement < 3)
                {
                    DialogResult dr = MessageBox.Show(" Voulez-vous vraiment ajouter un avertissement à cet utilisateur : " + user.GetEmail(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        bool verif = AppliBD.UpdateAvertissmentCpteUser(user);
                        if (verif)
                        {
                            MessageBox.Show("Avertissement ajouté avec succès.", "Update réussi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Erreur lors de l'ajout de l'avertissement, veuillez réessayez. Si le problème persiste, contactez l'administrateur.", "Echec de l'Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("L'utilisateur possède déjà le nombre maximale d'avertissement, c'est-à-dire 3 avertissements.", "Avertissement trop élevé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Aucun utilisateur n'est selectionné.", "Absence de sélection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CG0005H - Actualisation de la listeBox des utilisateurs
        private void btnActualisationAdmin_Click(object sender, EventArgs e)
        {
            listBUsers.Items.Clear();
            List<Utilisateur> lesUsers = AppliBD.GetLesUtilisateurs(false);
            listBUsers.Items.AddRange(lesUsers.ToArray());
        }

        // CG0005H - Affichage des utilisateurs malveillants et non malveillants
        private void button1_Click_1(object sender, EventArgs e)
        {
            switch (btnAffichageUserMal.Text)
            {
                case "Voir les utilisateurs malveillants":
                    {
                        btnAffichageUserMal.Text = "Enlever les utilisateurs malveillants";
                        listBUsers.Items.Clear();
                        List<Utilisateur> lesUsers = AppliBD.GetLesUtilisateurs(true);
                        listBUsers.Items.AddRange(lesUsers.ToArray());
                        break;
                    }

                default:
                    {
                        btnAffichageUserMal.Text = "Voir les utilisateurs malveillants";
                        listBUsers.Items.Clear();
                        List<Utilisateur> lesUsers = AppliBD.GetLesUtilisateurs(false);
                        listBUsers.Items.AddRange(lesUsers.ToArray());
                        break;
                    }
            }
        }

        // CG0005H - Affichage des informations d'un utilisateur
        private void ListBUsers_DoubleClick(object sender, EventArgs e)
        {
            if (listBUsers.SelectedItem != null)
            {
                Utilisateur utilisateurSelectionne = (Utilisateur)listBUsers.SelectedItem;

                FormDetailsUser userInfoForm = new FormDetailsUser();

                userInfoForm.AfficherInfosUtilisateur(utilisateurSelectionne);

                userInfoForm.Show();
            }
        }

        // CG0006A - Initialisation de la listeBox des articles refusés
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listBArticles.Items.Clear();
            List<Article> lesArticles = AppliBD.GetLesArticles("REJET");
            listBArticles.Items.AddRange(lesArticles.ToArray());
        }

        // CG0006F - Affichage des informations d'un article
        private void listBArticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBArticles.SelectedItem != null)
            {
                Article articleSelectionne = (Article)listBArticles.SelectedItem;

                FormDetailsArticle articleInfoForm = new FormDetailsArticle(articleSelectionne);

                articleInfoForm.AfficherInfosArticle(articleSelectionne);

                articleInfoForm.Show();
            }
        }

        // CG0006A - Initialisation de la listeBox des articles en attente
        private void radioBArticleEnAttente_CheckedChanged(object sender, EventArgs e)
        {
            listBArticles.Items.Clear();
            List<Article> lesArticles = AppliBD.GetLesArticles("EN_ATTENTE");
            listBArticles.Items.AddRange(lesArticles.ToArray());
        }

        // CG0006A - Initialisation de la listeBox des articles validés
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listBArticles.Items.Clear();
            List<Article> lesArticles = AppliBD.GetLesArticles("VALIDE");
            listBArticles.Items.AddRange(lesArticles.ToArray());
        }

        // CG0006A - Initialisation de la listeBox de tous les articles
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listBArticles.Items.Clear();
            List<Article> lesArticles = AppliBD.GetLesArticles("");
            listBArticles.Items.AddRange(lesArticles.ToArray());
        }

        // CG0006B - Attribution de la rubrique à l'article selectionné
        private void button1_Click_2(object sender, EventArgs e)
        {
            if (listBArticles.SelectedItem != null && listBRubriquesDispo.SelectedItem != null)
            {
                bool verif = AppliBD.UpdateRubriqueArticle((Article)listBArticles.SelectedItem, (Rubrique)listBRubriquesDispo.SelectedItem);
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

        // CG0006C - Reset des rubriques pour un article
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

        private void listBRubriquesArticle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // CG000 ...
        private void listBArticles_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBArticles.SelectedItem != null)
            {
                Article articleSelectionne = (Article)listBArticles.SelectedItem;
                List<Rubrique> rubriques = AppliBD.GetRubriquesParArticle(articleSelectionne.GetId());

                // Effacer la liste des rubriques précédentes
                listBRubriquesArticle.Items.Clear();

                // Ajouter les rubriques associées à l'article à la ListBox listBRubriquesArticle
                foreach (Rubrique rubrique in rubriques)
                {
                    listBRubriquesArticle.Items.Add(rubrique.GetNom());
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Fonction utilisée pour vérifier l'étât de l'ajout de notre rubrique.
        /// </summary>
        /// <param name="nbInsertion">Le nombre d'insertion effectué.</param>
        // CG0005G - Vérification de l'étât de notre insertion
        private void verifInsertRubrique(int nbInsertion)
        {
            switch (nbInsertion)
            {
                case 0: // Cas : Insertion échouée
                    MessageBox.Show("Echec de l'Insertion, veuillez réessayez. Si le problème persiste, contactez l'administrateur.", "Echec de l'Insertion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 1: // Cas : Insertion réussie
                    MessageBox.Show("Succès de l'Insertion.", "Succès de l'Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 2: // Cas : Adresse Mail déjà utilisée
                    MessageBox.Show("Une rubrique du même nom existe déjà.", "Rubrique redondante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            string saisieNom = txtBNomRubrique.Text.ToUpper();

            if (saisieNom != "")
            {
                int etatInsertion;
                etatInsertion = AppliBD.AddRubrique(saisieNom);
                verifInsertRubrique(etatInsertion);
            }
            else
            {
                MessageBox.Show("Veuillez renseigner un nom pour la rubrique.", "Absence de nom", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
