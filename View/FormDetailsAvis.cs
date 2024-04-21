using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresseRESA
{
    public partial class FormDetailsAvis : Form
    {
        private Avis avis;
        private string typeCpte;

        public FormDetailsAvis(Avis avis, string typeCpte)
        {
            InitializeComponent();

            this.avis = avis;
            this.typeCpte = typeCpte;
            if (typeCpte == "ADMIN")
            {
                btnDeleteAvis.Show();
            }
            else
            {
                btnDeleteAvis.Hide();
            }
        }

        // CG0007B - Consulter les informations d'un avis
        public void AfficherInfosAvis()
        {
            // Affichez les informations de l'utilisateur dans les labels du formulaire
            labIdAvis.Text = this.avis.GetId().ToString();
            labCreaAvis.Text = this.avis.GetDateCreation().ToLongDateString();
            labAuteurAvis.Text = this.avis.GetAuteur();
            labCommentaireAvis.Text = this.avis.GetCommentaire();
        }

        // CG0005D - Ajouter un avertissement en fonction de l'avis frauduleux
        private void btnAddAvertissement_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Voulez-vous vraiment supprimer l'avis ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                _ = AppliBD.UpdateAvertissmentCpteUser(avis.GetAuteur());
                bool verif = AppliBD.DeleteAvis(avis.GetId());
                if (verif)
                {
                    MessageBox.Show("L'avis a été supprimé avec succès, un avertissement a été ajouté.", "Suppression réussi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Erreur lors de la suppression de l'avis, veuillez réessayez. Si le problème persiste, contactez l'administrateur.", "Echec de la suppresion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // CG0007A - Préserver l'intégrité des avis d'un article
        private void FormDetailsAvis_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (typeCpte == "ADMIN")
            {
                ((FormPresseAdmin)this.Owner).InitializeAvisList();
            }
            else
            {
                ((FormPresseUtilisateur)this.Owner).InitializeMesAvisList();
            }
        }

        private void FormDetailsAvis_Load(object sender, EventArgs e)
        {

        }

        private void labDescription_Click(object sender, EventArgs e)
        {

        }

        private void labDescriptionArticle_Click(object sender, EventArgs e)
        {

        }
    }
}
