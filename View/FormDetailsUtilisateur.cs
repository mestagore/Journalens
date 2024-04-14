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
        public FormDetailsUser()
        {
            InitializeComponent();
        }

        // CG0005H - Affichage des informations de l'utilisateur
        public void AfficherInfosUtilisateur(Utilisateur user)
        {
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
