using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresseRESA
{
    public partial class FormPresseUtilisateur : Form
    {

        public FormPresseUtilisateur()
        {
            InitializeComponent();
            labCopyright.Text = AppliBD.ToStringCopyright();

            // CG0009 - Non affichage du tabControl lors du démarrage du Form
            tabControlUser.TabPages.Remove(tabPDashboard);
            tabControlUser.TabPages.Remove(tabPAccueil);
            tabControlUser.TabPages.Remove(tabPProfil);

            comboBOnglet.SelectedIndex = 0;
            AfficherOngletAccueil();
        }

        // --------------------------------------------------------- PARTIE CONNEXION ET DECONNEXION ---------------------------------------------------------

        // CG0009 - Gestion des choix de l'utilisateur
        private void comboBOnglet_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBOnglet.SelectedIndex)
            {
                case 0:
                    AfficherOngletAccueil();
                    break;

                case 1:
                    AfficherOngletTableauDeBord();
                    break;

                case 2:
                    AfficherOngletMonProfil();
                    break;
            }
        }

        // CG0004 - Choix : Gestion des utilisateurs
        private void AfficherOngletAccueil()
        {
            tabControlUser.TabPages.Clear();
            tabControlUser.TabPages.Add(tabPAccueil);

            InitializeArticlesList();
            InitializeRubriqueList();

            this.Text = "Journalens - Home";
        }

        // CG0004 - Choix : Gestion des articles
        private void AfficherOngletTableauDeBord()
        {
            tabControlUser.TabPages.Clear();
            tabControlUser.TabPages.Add(tabPDashboard);

            InitializeMesArticleList();
            InitializeMesAvisList();

            this.Text = "Journalens - Tableau de bord";
        }

        // CG0004 - Choix : Gestion des rubriques
        private void AfficherOngletMonProfil()
        {
            tabControlUser.TabPages.Clear();
            tabControlUser.TabPages.Add(tabPProfil);

            Utilisateur user = AppliBD.GetUtilisateurParId(Session.GetIdUtilisateur());

            // Affichez les informations de l'utilisateur dans les labels du formulaire
            labMailUser.Text = user.GetEmail();
            labNomUser.Text = user.GetNom();
            labPrenomUser.Text = user.GetPrenom();
            labDateInscriptionUser.Text = user.GetDateInscription().ToLongDateString();
            labNbAvertissementUser.Text = user.GetNbAvertissement().ToString();
            switch (labNbAvertissementUser.Text)
            {
                case "0":
                    labStatusAvertissement.Text = "Super !";
                    labStatusAvertissement.ForeColor = Color.Green;
                    break;
                case "1":
                    labStatusAvertissement.Text = "Ca va...";
                    labStatusAvertissement.ForeColor = Color.Yellow;
                    break;
                case "2":
                    labStatusAvertissement.Text = "Attention !";
                    labStatusAvertissement.ForeColor = Color.Red;
                    break;
            }
            labNumTelUser.Text = !string.IsNullOrEmpty(user.GetTelephone()) ? user.GetTelephone() : "Non renseigné";
            labNumPortUser.Text = !string.IsNullOrEmpty(user.GetPortable()) ? user.GetPortable() : "Non renseigné";

            btnModifInfosProfil.Text = "Modifier mes informations";
            btnModifMDPProfil.Text = "Modifier mon mot de passe";
            groupBModifInfosProfil.Hide();
            groupBModifMDPProfil.Hide();
            this.Text = "Journalens - Profil";
        }

        // CG0002C - Déconnexion de l'utilisateur
        private void btnDecoAdmin_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(" Voulez-vous vraiment vous déconnecter  ? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Session.GetFormConnexion().Show();
                Session.GetFormConnexion().Focus();
                Close();
            }
        }

        // --------------------------------------------------------- PARTIE CONSULTATION DU PROFIL ---------------------------------------------------------

        // CG0012B - Affichage du groupBox pour modifier ses informations personnelles
        private void btnModifRubrique_Click(object sender, EventArgs e)
        {
            switch (btnModifInfosProfil.Text)
            {
                case "Annuler":
                    btnModifInfosProfil.Text = "Modifier mes informations";
                    txtBTelephoneUser.Clear();
                    txtBPortableUser.Clear();
                    groupBModifInfosProfil.Hide();
                    break;

                case "Modifier mes informations":
                    btnModifInfosProfil.Text = "Annuler";
                    groupBModifInfosProfil.Show();
                    break;
            }
        }

        // CGCG0012B - Vérification des numéros de téléphone et  mobile
        private void btnAjoutUser_Click(object sender, EventArgs e)
        {
            string saisieTelephone = txtBTelephoneUser.Text;
            string saisiePortable = txtBPortableUser.Text;

            try
            {
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

                int etatInsertion = AppliBD.UpdateProfil(Session.GetIdUtilisateur(), saisieTelephone, saisiePortable);
                verifModifInfosProfil(etatInsertion);
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
        /// Méthode utilisée pour vérifier l'étât de la mise à jour des informations de l'utilisateur.
        /// </summary>
        /// <param name="nbInsertion">Le nombre d'insertion effectué.</param>
        private void verifModifInfosProfil(int nbInsertion)
        {
            switch (nbInsertion)
            {
                case 0: // Cas : Opération échouée
                    MessageBox.Show("Echec de la modification, veuillez réessayez. Si le problème persiste, contactez l'administrateur.", "Echec de la modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 1: // Cas : Insertion réussie
                    AfficherOngletMonProfil();
                    MessageBox.Show("Succès de la modification. Vos numéros ont bien été mise à jour !", "Changement sur vos informations personnelles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        // CG0012C - Affichage du groupBox pour modifier son mot de passe
        private void brnModifMDP_Click(object sender, EventArgs e)
        {
            switch (btnModifMDPProfil.Text)
            {
                case "Annuler":
                    btnModifMDPProfil.Text = "Modifier mon mot de passe";
                    txtBNewMDP.Clear();
                    txtBMDP.Clear();
                    groupBModifMDPProfil.Hide();
                    break;

                case "Modifier mon mot de passe":
                    btnModifMDPProfil.Text = "Annuler";
                    groupBModifMDPProfil.Show();
                    break;
            }
        }

        // CG0012C - Vérification de la saisie des mots de passe
        private void btnModifMDP_Click(object sender, EventArgs e)
        {
            string saisieNewMDP = txtBNewMDP.Text;
            string saisieMDP = txtBMDP.Text;

            try
            {
                if (string.IsNullOrEmpty(saisieNewMDP) || string.IsNullOrEmpty(saisieMDP))
                {
                    throw new Exception("Les champs ne peuvent pas être vides mots de passe sont identiques.");
                }

                if (saisieMDP == saisieNewMDP)
                {
                    throw new Exception("Les mots de passe sont identiques.");
                }

                int etatInsertion = AppliBD.UpdateMotDePasse(Session.GetIdUtilisateur(), saisieNewMDP, saisieMDP);
                verifModifMDPProfil(etatInsertion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de la modification de votre mot de passe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void verifModifMDPProfil(int nbInsertion)
        {
            switch (nbInsertion)
            {
                case 0: // Cas : Opération échouée
                    MessageBox.Show("Votre mot de passe semble incorrect, veuillez réessayez. Si le problème persiste, contactez l'administrateur.", "Echec de la modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 1: // Cas : Insertion réussie
                    MessageBox.Show("Succès de la modification. Votre nouveau mot de passe a bien été enregistré.", "Changement sur vos informations personnelles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        // --------------------------------------------------------- PARTIE TABLEAU DE BORD ---------------------------------------------------------

        // CG0010A - Permettre l'intégrité des informations des articles de l'utilisateur de la liste
        public void InitializeMesArticleList()
        {
            listBMesArticles.Items.Clear();
            List<Article> lesArticles = AppliBD.GetSesArticles(Session.GetIdUtilisateur());
            listBMesArticles.Items.AddRange(lesArticles.ToArray());
        }

        // CG0011A - Permettre l'intégrité des avis de l'utilisateur dans la liste
        public void InitializeMesAvisList()
        {
            listBMesAvis.Items.Clear();
            List<Avis> lesAvis = AppliBD.GetSesAvis(Session.GetIdUtilisateur());
            listBMesAvis.Items.AddRange(lesAvis.ToArray());
        }

        // CG0010B / CG0010C / CG0010E / CG0011B / CG0011D - Gestion des options de Création, Modification et Suppression de ses articles et avis
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioBCreateArticle.Checked)
            {
                FormCreateArticle articleCreateForm = new FormCreateArticle();

                articleCreateForm.Owner = this;
                articleCreateForm.Show();
            }

            if (radioBModifArticle.Checked)
            {
                if (listBMesArticles.SelectedItem != null)
                {
                    FormCreateArticle articleModifForm = new FormCreateArticle();
                    Article articleSelectionne = (Article)listBMesArticles.SelectedItem;

                    articleModifForm.AfficherInfosArticle(articleSelectionne);

                    articleModifForm.Owner = this;
                    articleModifForm.Show();
                }
                else
                {
                    MessageBox.Show("Aucun article n'est selectionné.", "Absence de sélection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (radioBDeleteArticle.Checked)
            {
                if (listBMesArticles.SelectedItem != null)
                {
                    Article articleSelectionne = (Article)listBMesArticles.SelectedItem;

                    DialogResult dr = MessageBox.Show(" Voulez-vous vraiment supprimer l'article ayant pour titre : " + articleSelectionne.GetTitre() + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        bool verif = AppliBD.DeleteArticle(articleSelectionne);
                        if (!verif)
                        {
                            MessageBox.Show("Erreur lors de la suppression de l'article, veuillez réessayez.", "Echec de la Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            InitializeMesArticleList();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Aucun article n'est selectionné.", "Absence de sélection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (radioBModifAvis.Checked)
            {
                if (listBMesAvis.SelectedItem != null)
                {
                    Avis avisSelectionne = (Avis)listBMesAvis.SelectedItem;

                    FormCreateAvis avisModifForm = new FormCreateAvis(avisSelectionne.GetArticleConcerne());

                    avisModifForm.AfficherInfosAvis(avisSelectionne);

                    avisModifForm.Owner = this;
                    avisModifForm.Show();
                }
                else
                {
                    MessageBox.Show("Aucun avis n'est selectionné.", "Absence de sélection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (radioBDeleteAvis.Checked)
            {
                if (listBMesAvis.SelectedItem != null)
                {
                    Avis avisSelectionne = (Avis)listBMesAvis.SelectedItem;

                    DialogResult dr = MessageBox.Show(" Voulez-vous vraiment supprimer l'avis n° : " + avisSelectionne.GetId() + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        bool verif = AppliBD.DeleteAvis(avisSelectionne.GetId());
                        if (!verif)
                        {
                            MessageBox.Show("Erreur lors de la suppression de l'article, veuillez réessayez.", "Echec de la Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            InitializeMesAvisList();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Aucun avis n'est selectionné.", "Absence de sélection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // CG0010B / CG0010C - Ajout ou Modification d'un article dans un nouveau Formulaire
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (listBArticles.SelectedItem != null)
            {
                Article article = (Article)listBArticles.SelectedItem;

                FormCreateAvis avisModifForm = new FormCreateAvis(article.GetId());

                avisModifForm.Owner = this;
                avisModifForm.Show();
            }
            else
            {
                MessageBox.Show("Aucun article n'est selectionné.", "Absence de sélection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CG0007A - Affichage des avis associées à l'article
        private void listBMesArticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBMesArticles.SelectedItem != null)
            {
                Article articleSelectionne = (Article)listBMesArticles.SelectedItem;
                List<Avis> avis = AppliBD.GetAvisParArticle(articleSelectionne.GetId());

                // Effacer la liste des avis précédentes
                listBAvis.Items.Clear();

                foreach (Avis unAvis in avis)
                {
                    listBAvis.Items.Add(unAvis);
                }
            }
        }

        // CG0006E - (Double-Click) Consulter les informations de mon article dans une nouvelle fenêtre
        private void listBArticles_DoubleClick(object sender, EventArgs e)
        {
            if (listBMesArticles.SelectedItem != null)
            {
                Article articleSelectionne = (Article)listBMesArticles.SelectedItem;

                FormDetailsArticle articleInfoForm = new FormDetailsArticle(articleSelectionne, Session.GetTypeUtilisateur());

                articleInfoForm.AfficherInfosArticle();

                articleInfoForm.Owner = this;
                articleInfoForm.Show();
            }
        }

        // CG0007B - (Double-Click) Consulter les informations d'un avis dans une nouvelle fenêtre
        private void listBAvis_DoubleClick(object sender, EventArgs e)
        {
            if (listBAvis.SelectedItem != null)
            {
                Avis avisSelectionne = (Avis)listBAvis.SelectedItem;

                FormDetailsAvis avisInfoForm = new FormDetailsAvis(avisSelectionne, Session.GetTypeUtilisateur());

                avisInfoForm.AfficherInfosAvis();

                avisInfoForm.Owner = this;
                avisInfoForm.Show();
            }
        }

        // CG0007B - (Double-Click) Consulter les informations de mon avis dans une nouvelle fenêtre
        private void listBMesAvis_DoubleClick(object sender, EventArgs e)
        {
            if (listBMesAvis.SelectedItem != null)
            {
                Avis avisSelectionne = (Avis)listBMesAvis.SelectedItem;

                FormDetailsAvis avisInfoForm = new FormDetailsAvis(avisSelectionne, Session.GetTypeUtilisateur());

                avisInfoForm.AfficherInfosAvis();

                avisInfoForm.Owner = this;
                avisInfoForm.Show();
            }
        }

        // --------------------------------------------------------- PARTIE CONSULTATION ---------------------------------------------------------

        // CG0010D - Permettre l'intégrité des informations des articles de la liste
        public void InitializeArticlesList()
        {
            listBArticles.Items.Clear();
            List<Article> lesArticles = AppliBD.GetLesArticles();
            listBArticles.Items.AddRange(lesArticles.ToArray());
        }

        // CG0008A - Permettre l'intégrité des informations des rubriques de la liste
        public void InitializeRubriqueList()
        {
            comboBRubriques.Items.Clear();
            List<Rubrique> lesRubriques = AppliBD.GetLesRubriques();
            comboBRubriques.Items.AddRange(lesRubriques.ToArray());
        }

        // CG0007A - Permettre l'intégrité des avis de l'article dans la liste
        public void InitializeLesAvisList(int idArticle)
        {
            listBLesAvis.Items.Clear();
            List<Avis> avis = AppliBD.GetAvisParArticle(idArticle);
            listBLesAvis.Items.AddRange(avis.ToArray());
        }

        // CG0006A - Affichage des articles en fonction des options de filtrage
        private void btnFiltrage_Click(object sender, EventArgs e)
        {
            string saisieAuteurArticle = txtBAuteurArticle.Text;
            int? saisieIdRubrique = null;

            if (comboBRubriques.SelectedItem != null)
            {
                Rubrique rubrique = (Rubrique)comboBRubriques.SelectedItem;
                saisieIdRubrique = rubrique.GetId();
            }

            bool? avecAvis = radioBArticleAvecAvis.Checked ? true : radioBArticleSansAvis.Checked ? false : (bool?)null;

            listBArticles.Items.Clear();
            List<Article> articlesFiltres = AppliBD.GetLesArticles(saisieAuteurArticle, saisieIdRubrique, avecAvis);
            listBArticles.Items.AddRange(articlesFiltres.ToArray());
        }

        // CG0006A - Affichage de tous les articles
        private void btnResetFiltrage_Click(object sender, EventArgs e)
        {
            txtBAuteurArticle.Clear();
            comboBRubriques.SelectedItem = null;
            radioBArticleAvecAvis.Checked = false;
            radioBArticleSansAvis.Checked = false;

            InitializeArticlesList();
        }

        // CG0006E - (Double-Click) Consulter les informations d'un article, crée par un utilisateur, dans une nouvelle fenêtre
        private void listBArticles_DoubleClick_1(object sender, EventArgs e)
        {
            if (listBArticles.SelectedItem != null)
            {
                Article articleSelectionne = (Article)listBArticles.SelectedItem;

                FormDetailsArticle articleInfoForm = new FormDetailsArticle(articleSelectionne, Session.GetTypeUtilisateur());

                articleInfoForm.AfficherInfosArticle();

                articleInfoForm.Owner = this;
                articleInfoForm.Show();
            }
        }

        // CG0007B - (Double-Click) Consulter les informations d'un avis d'un artilce, dans une nouvelle fenêtre
        private void listBLesAvis_DoubleClick(object sender, EventArgs e)
        {
            if (listBLesAvis.SelectedItem != null)
            {
                Avis avisSelectionne = (Avis)listBLesAvis.SelectedItem;

                FormDetailsAvis avisInfoForm = new FormDetailsAvis(avisSelectionne, Session.GetTypeUtilisateur());

                avisInfoForm.AfficherInfosAvis();

                avisInfoForm.Owner = this;
                avisInfoForm.Show();
            }
        }

        // CG0007A - Affichage des avis associées à l'article
        private void listBArticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBArticles.SelectedItem != null)
            {
                Article articleSelectionne = (Article)listBArticles.SelectedItem;

                listBLesAvis.Items.Clear();
                List<Avis> avis = AppliBD.GetAvisParArticle(articleSelectionne.GetId());
                listBLesAvis.Items.AddRange(avis.ToArray());
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void labTitleProfil_Click(object sender, EventArgs e)
        {

        }

        private void labWarning_Click(object sender, EventArgs e)
        {

        }

        private void tabPProfil_Click(object sender, EventArgs e)
        {

        }

        private void groupBInfoProfil_Enter(object sender, EventArgs e)
        {

        }

        private void groupBModifInfoProfil_Enter(object sender, EventArgs e)
        {

        }

        private void listBAvis_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labCopyright_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormPresseUser_Load(object sender, EventArgs e)
        {

        }
    }
}
