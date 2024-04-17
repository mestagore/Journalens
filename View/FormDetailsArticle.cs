﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresseRESA
{
    public partial class FormDetailsArticle : Form
    {
        private Article article;

        public FormDetailsArticle(Article articleSelectionne)
        {
            InitializeComponent();
            article = articleSelectionne;

            // CG0006E - Initialisation de la listeBox des états
            comboBEtatArticle.Items.Clear();
            List<string> lesEtats = new List<string> { "EN ATTENTE", "VALIDE", "REJET" };
            comboBEtatArticle.Items.AddRange(lesEtats.ToArray());
        }

        private void FormDetailsArticle_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Fonction utilisée pour afficher les informations d'un article sur le formulaire.
        /// </summary>
        /// <param name="article">L'article selectionné.</param>
        // CG0006F - Afficher les informations d'un article
        public void AfficherInfosArticle(Article article)
        {
            // Affichez les informations de l'utilisateur dans les labels du formulaire
            labIdArticle.Text = article.GetId().ToString();
            labCreaArticle.Text = article.GetDateCreation().ToLongDateString();
            labAuteurArticle.Text = article.GetAuteur();
            labTitreArticle.Text = article.GetTitre();
            labDescriptionArticle.Text = article.GetDescription();
            switch (article.GetEtat())
            {
                case "EN ATTENTE":
                    comboBEtatArticle.SelectedIndex = 0;
                    break;
                case "VALIDE":
                    comboBEtatArticle.SelectedIndex = 1;
                    break;
                case "REJET":
                    comboBEtatArticle.SelectedIndex = 2;
                    break;
            }
        }

        // CG0006D - Modification de l'état d'un article
        private void comboBEtatArticle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newEtat = 0;
            switch (comboBEtatArticle.SelectedIndex)
            {
                case 0:
                    newEtat = 1;
                    break;
                case 1:
                    newEtat = 2;
                    break;
                case 2:
                    newEtat = 3;
                    break;
            }
            AppliBD.UpdateEtatArticle(article, newEtat);
        }

        private void FormDetailsArticle_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((FormPresseAdmin)this.Owner).InitializeArticleList();
        }

        private void btnAddAvertissement_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(" Voulez-vous vraiment ajouter un avertissement à l'auteur de cet article : " + article.GetAuteur(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                _ = AppliBD.UpdateAvertissmentCpteUser(article.GetAuteur());
                bool verif = AppliBD.UpdateAvertissmentCpteUser(article.GetAuteur());
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void labDescriptionArticle_Click(object sender, EventArgs e)
        {

        }
    }
}
