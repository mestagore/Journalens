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
    public partial class FormDetailsUser : Form
    {
        private Utilisateur user;

        public FormDetailsUser()
        {
            InitializeComponent();
        }

        // CG0005G - Affichage des informations de l'utilisateur
        public void AfficherInfosUtilisateur(Utilisateur user)
        {
            this.user = user;

            // Affichez les informations de l'utilisateur dans les labels du formulaire
            labMailUser.Text = user.GetEmail();
            labNomUser.Text = user.GetNom();
            labPrenomUser.Text = user.GetPrenom();
            labDateInscriptionUser.Text = user.GetDateInscription().ToLongDateString();
            labDateFermetureUser.Text = user.GetDateFermeture() != null ? user.GetDateFermeture().Value.ToString("dddd dd MMMM yyyy") : "Non renseigné";
            labNbAvertissementUser.Text = user.GetNbAvertissement().ToString();
            labNumTelUser.Text = !string.IsNullOrEmpty(user.GetTelephone()) ? user.GetTelephone() : "Non renseigné";
            labNumPortUser.Text = !string.IsNullOrEmpty(user.GetPortable()) ? user.GetPortable() : "Non renseigné";
            labTypeUser.Text = user.GetTypeCpte();
        }

        // CG0005D - Ajouter un avertissement à l'utilisateur
        private void btnAddAvertissement_Click(object sender, EventArgs e)
        {
            if (user.GetNbAvertissement() < 3)
            {
                DialogResult dr = MessageBox.Show(" Voulez-vous vraiment ajouter un avertissement à cet utilisateur : " + user.GetEmail(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    bool verif = AppliBD.UpdateAvertissmentCpteUser(user.GetEmail());
                    if (verif)
                    {
                        user.SetNbAvertissement();
                        AfficherInfosUtilisateur(user);
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

        // CG0005E - Fermeture d'un compte utilisateur
        private void btnFermetureCpte_Click(object sender, EventArgs e)
        {
            if (user.GetDateFermeture() == null)
            {
                DialogResult dr = MessageBox.Show(" Voulez-vous vraiment clôturer le compte de cet utilisateur : " + user.GetEmail(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    bool verif = AppliBD.FermetureCpteUser(user);
                    if (verif)
                    {
                        AfficherInfosUtilisateur(user);
                        MessageBox.Show("Compte fermé avec succès.", "Update réussi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la fermeture du compte, veuillez réessayez. Si le problème persiste, contactez l'administrateur.", "Echec de l'Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Le compte de cet utilisateur est déjà fermé.", "Compte déjà clôturé", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CG0005A - Préserver l'intégrité des données de l'utilisateur
        private void FormDetailsUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((FormPresseAdmin)this.Owner).InitializeUserList();
        }

        private void labMel_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void FormDetailsUser_Load(object sender, EventArgs e)
        {

        }
    }
}
