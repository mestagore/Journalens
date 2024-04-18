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
    public partial class FormPresseUser : Form
    {
        // Déclaration des variables
        public string viewArticles;

        public FormPresseUser()
        {
            InitializeComponent();
            viewArticles = "ALL";
            labCopyright.Text = AppliBD.ToStringCopyright();

            // CG0009 - Non affichage du tabControl lors du démarrage du Form
            tabControlUser.TabPages.Remove(tabPDashboard);
            tabControlUser.TabPages.Remove(tabPAccueil);
            tabControlUser.TabPages.Remove(tabPProfil);

            comboBOnglet.SelectedIndex = 2;
            AfficherOngletMonProfil();
        }

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
        }

        // CG0004 - Choix : Gestion des articles
        private void AfficherOngletTableauDeBord()
        {
            tabControlUser.TabPages.Clear();
            tabControlUser.TabPages.Add(tabPDashboard);

            InitializeArticleList();
            InitializeAvisList();
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
            switch(labNbAvertissementUser.Text)
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

            btnModifRubrique.Text = "Modifier mes informations";
            groupBModifInfoProfil.Hide();
        }

        private void btnModifRubrique_Click(object sender, EventArgs e)
        {
            switch(btnModifRubrique.Text)
            {
                case "Annuler":
                    btnModifRubrique.Text = "Modifier mes informations";
                    txtBTelephoneUser.Clear();
                    txtBPortableUser.Clear();
                    groupBModifInfoProfil.Hide();
                    break;

                case "Modifier mes informations":
                    btnModifRubrique.Text = "Annuler";
                    groupBModifInfoProfil.Show();
                    break;
            }
        }

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

        private void listBArticles_DoubleClick(object sender, EventArgs e)
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

        public void InitializeArticleList()
        {
            listBArticles.Items.Clear();
            List<Article> lesArticles = AppliBD.GetSesArticles(Session.GetIdUtilisateur());
            listBArticles.Items.AddRange(lesArticles.ToArray());
        }

        public void InitializeAvisList()
        {
            listBAvis.Items.Clear();
            List<Avis> lesAvis = AppliBD.GetSesAvis(Session.GetIdUtilisateur());
            listBAvis.Items.AddRange(lesAvis.ToArray());
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
