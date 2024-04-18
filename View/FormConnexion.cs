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
    public partial class FormConnexion : Form
    {
        public FormConnexion()
        {
            InitializeComponent();
            labCopyright.Text = AppliBD.ToStringCopyright();

            // Pour vous connecter en temps qu'ADMIN :
            //              Mail : giovanni.rumilly@gmail.com
            //              MDP : admin - HASH : e3c9a0f109ee9595af1dc2b5d5c1dc86

            // Pour vous connecter en temps qu'USER :
            //              Mail : alice.smith@example.com
            //              MDP : alix91 - HASH : 814660ea649a08560f87c00a5f00d8da

            // Pour vous connecter en temps qu'USER mais MALVEILLANT :
            //              Mail : bob.johnson@example.com
            //              MDP : mal - HASH : 5655f26ec0c36c0b19a8a0ee219e9a70
        }

        // CG0002B / CG0002C - Vérification et Connexion à l'application
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string saisieAdresseMel = txtBoxMel.Text;
            if (saisieAdresseMel.Contains("@"))
            {
                
                string typeU = AppliBD.ConnexionUser(saisieAdresseMel, txtBoxMDP.Text);

                // Vérification de l'existance du compte dans la BDD
                if (typeU == "I")
                {
                    MessageBox.Show("L'identification semble avoir échoué. Veuillez vérifier vos identifiants et réessayer.", "Identifiants incorrects", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Utilisateur user = AppliBD.GetUtilisateurParEmail(saisieAdresseMel);

                    // Vérification de l'existence de l'utilisateur et de la non-existence de la date de fermeture du compte
                    if (user != null)
                    {
                        if (user.GetDateFermeture() != null)
                        {
                            MessageBox.Show("Accès refusé. Votre compte a été fermé.Veuillez contacter l'administrateur pour plus d'informations.", "Compte bloqué", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // On verifie son nombre d'avertissement.
                            if (user.GetNbAvertissement() < 3)
                            {
                                // Affichage de la forme appropriée en fonction du type de compte de l'utilisateur
                                if (typeU == "USER")
                                {
                                    new FormPresseUser().Show();
                                }
                                else
                                {
                                    new FormPresseAdmin().Show();
                                }
                                txtBoxMDP.Clear();
                                Session.SetformConnexion(this);
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Accès refusé. Votre compte possède trop d'avertissements. Veuillez contacter l'administrateur si cela s'agit d'une erreur.", "Nombre d'avertissement trop élevés", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }   
                    }
                }
            }
            else
            {
                MessageBox.Show("L'adresse saisie est syntaxiquement incorrect. Veuillez essayer avec une autre adresse.", "Synthaxe incorrecte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormConnexion_Load(object sender, EventArgs e)
        {

        }
    }
}
