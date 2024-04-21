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
    public partial class FormCreateAvis : Form
    {
        // Déclaration des variables
        private int idArticleConcerne;
        private Avis avis;

        public FormCreateAvis(int idArticleConcerne)
        {
            InitializeComponent();

            this.idArticleConcerne = idArticleConcerne;
        }

        private void btnAjoutUser_Click(object sender, EventArgs e)
        {
            if (txtBCommentaire != null)
            {
                bool verif = false;
                if (avis != null)
                {
                    verif = AppliBD.UpdateAvis(avis.GetId(), txtBCommentaire.Text);
                }
                else
                {
                    verif = AppliBD.AddAvis(txtBCommentaire.Text, idArticleConcerne);
                }

                if (verif && (avis != null))
                {
                    MessageBox.Show("Votre commentaire a bien été mise à jour.", "Succès de la modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FermetureFen();
                }
                else if (verif && (avis == null))
                {
                    MessageBox.Show("Votre avis a bien été publié.", "Succès de l'ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FermetureFen();
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'opération, veuillez réessayez. Si le problème persiste, contactez l'administrateur.", "Echec de l'opération", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void AfficherInfosAvis(Avis avisSelectionne)
        {
            // Si nous avons des informations à afficher, on en conclue qu'il existe un avis et que l'on veut modifier son contenu.
            avis = avisSelectionne;

            // Affichez le contenu de l'avis dans le textBox du Formulaire
            txtBCommentaire.Text = avisSelectionne.GetCommentaire();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            FermetureFen();
        }

        public void FermetureFen()
        {
            txtBCommentaire.Clear();
            Close();
        }

        private void FormCreateAvis_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((FormPresseUtilisateur)this.Owner).InitializeLesAvisList(idArticleConcerne);
        }
    }
}
