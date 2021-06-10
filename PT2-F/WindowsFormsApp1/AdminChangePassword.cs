using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AdminChangePassword : Form
    {
        private bool isHidden = true;
        private ABONNÉS abonne;
        public AdminChangePassword(ABONNÉS a)
        {
            InitializeComponent();
            eyeButton.Image = Utils.ResizeImage(eyeButton.Image, 20, 20);
            abonne = a;
        }

        private void eyeButton_Click(object sender, EventArgs e)
        {
            isHidden = !isHidden;
            if (isHidden)
            {
                eyeButton.Image = Utils.ResizeImage(Properties.Resources.eyeClosed_Icon, 20, 20);
                passTextBox.PasswordChar = '*';
            }
            else
            {
                eyeButton.Image = Utils.ResizeImage(Properties.Resources.eyeIcon, 20, 20);
                passTextBox.PasswordChar = (char)0;
            }
        }

        private void valider_Click(object sender, EventArgs e)
        {
            if(passTextBox.TextLength > 0)
            {
                abonne.PASSWORD_ABONNÉ = Utils.ComputeSha256Hash(passTextBox.Text);
                Utils.Connexion.SaveChanges();
                MessageBox.Show("Vous avez bien changé le mot de passe de l'utilisateur \"" + abonne.NOM_ABONNÉ.Trim() + " " + abonne.PRÉNOM_ABONNÉ.Trim() + "\"");
                this.Close();
                return;
            }
            MessageBox.Show("Veuillez rentrer un nouveau mot de passe pour l'utilisateur!", "Erreur");
        }

        private void AdminChangePassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                valider_Click(this, null);
            }
        }
    }
}
