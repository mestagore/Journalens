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
    public partial class FormPresseUser : Form
    {
        public FormPresseUser()
        {
            InitializeComponent();
            labCopyright.Text = AppliBD.ToStringCopyright();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labCopyright_Click(object sender, EventArgs e)
        {

        }
    }
}
