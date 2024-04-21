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
    public partial class FormCreateArticle : Form
    {
        // Déclaration des variables
        private Article article;

        public FormCreateArticle()
        {
            InitializeComponent();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            FermetureFen();
        }

        private void btnAjoutArticle_Click(object sender, EventArgs e)
        {
            if (txtBDescription != null && txtBTitre != null)
            {
                bool verif = false;
                if (article != null)
                {
                    verif = AppliBD.UpdateArticle(article.GetId(), txtBTitre.Text, txtBDescription.Text);
                } else
                {
                    verif = AppliBD.AddArticle(txtBTitre.Text, txtBDescription.Text);
                }
                
                if (verif && article != null)
                {
                    MessageBox.Show("Les informations ont bien été mise à jour.", "Succès de la modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FermetureFen();
                } else if(verif && article == null)
                {
                    MessageBox.Show("Votre article a bien été ajouté.", "Succès de l'ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FermetureFen();
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'opération, veuillez réessayez. Si le problème persiste, contactez l'administrateur.", "Echec de l'Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Veuillez saisir un titre et une description pour votre article.", "Saisie incomplète", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AfficherInfosArticle(Article articleSelectionne)
        {
            // Si nous avons des informations à afficher, on en conclue qu'il existe un article et que l'on veut modifier des informations.
            article = articleSelectionne;
            
            // Affichez les informations de l'article dans les textBox du Formulaire
            txtBTitre.Text = article.GetTitre();
            txtBDescription.Text = article.GetDescription();
        }

        public void FermetureFen()
        {
            txtBDescription.Clear();
            txtBTitre.Clear();
            Close();
        }

        private void FormCreateArticle_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((FormPresseUtilisateur)this.Owner).InitializeMesArticleList();
        }
    }
}
