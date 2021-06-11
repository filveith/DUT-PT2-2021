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
            newPassBox.PasswordChar = '*';
            abonne = a;
        }

        /// <summary>
        /// Permet d'afficher ou pas le mot de passe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eyeButton_Click(object sender, EventArgs e)
        {
            isHidden = !isHidden;
            if (isHidden)
            {
                eyeButton.Image = Utils.ResizeImage(Properties.Resources.eyeClosed_Icon, 20, 20);
                newPassBox.PasswordChar = '*';
            }
            else
            {
                eyeButton.Image = Utils.ResizeImage(Properties.Resources.eyeIcon, 20, 20);
                newPassBox.PasswordChar = (char)0;
            }
        }

        /// <summary>
        /// Valide le nouveau mot de passe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valider_Click(object sender, EventArgs e)
        {
            if(newPassBox.TextLength > 0 )
            {
                abonne.PASSWORD_ABONNÉ = Utils.ComputeSha256Hash(newPassBox.Text);
                Utils.Connexion.SaveChanges();
                MessageBox.Show("Vous avez bien changé le mot de passe de l'utilisateur \"" + abonne.NOM_ABONNÉ.Trim() + " " + abonne.PRÉNOM_ABONNÉ.Trim() + "\"");
                this.Close();
                return;
            }
            MessageBox.Show("Veuillez rentrer un nouveau mot de passe pour l'utilisateur!", "Erreur");
        }

        /// <summary>
        /// Valide si la touche Entrée est pressée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminChangePassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                valider_Click(this, null);
            }
        }
    }
}
