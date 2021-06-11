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
    public partial class ChangePassword : Form
    {
        private bool isFirstHidden = true;
        private bool isSecondHidden = true;
        private bool isThirdHidden = true;
        private ABONNÉS abonne;
        public ChangePassword(ABONNÉS a)
        {
            InitializeComponent();
            button1.Image = Utils.ResizeImage(button1.Image, 20, 20);
            button2.Image = Utils.ResizeImage(button1.Image, 20, 20);
            button3.Image = Utils.ResizeImage(button1.Image, 20, 20);
            abonne = a;
        }

        /// <summary>
        /// Gère les clics sur les boutons por visualiser les mots de passe
        /// </summary>
        #region Yeux
        private void button1_Click(object sender, EventArgs e)
        {
            isFirstHidden = !isFirstHidden;
            if (isFirstHidden)
            {
                button1.Image = Utils.ResizeImage(Properties.Resources.eyeClosed_Icon, 20, 20);
                textBox1.PasswordChar = '*';
            }
            else
            {
                button1.Image = Utils.ResizeImage(Properties.Resources.eyeIcon, 20, 20);
                textBox1.PasswordChar = (char)0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isSecondHidden = !isSecondHidden;
            if (isSecondHidden)
            {
                button2.Image = Utils.ResizeImage(Properties.Resources.eyeClosed_Icon, 20, 20);
                textBox2.PasswordChar = '*';
            }
            else
            {
                button2.Image = Utils.ResizeImage(Properties.Resources.eyeIcon, 20, 20);
                textBox2.PasswordChar = (char)0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isThirdHidden = !isThirdHidden;
            if (isThirdHidden)
            {
                button3.Image = Utils.ResizeImage(Properties.Resources.eyeClosed_Icon, 20, 20);
                textBox3.PasswordChar = '*';
            }
            else
            {
                button3.Image = Utils.ResizeImage(Properties.Resources.eyeIcon, 20, 20);
                textBox3.PasswordChar = (char)0;
            }
        }
#endregion

        /// <summary>
        /// Permet de valider le nouveau mot de passe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valider_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength > 0)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    string hashedMdp = Utils.ComputeSha256Hash(textBox1.Text);
                    var abo = (from a in Utils.Connexion.ABONNÉS
                               where a.CODE_ABONNÉ == abonne.CODE_ABONNÉ && a.PASSWORD_ABONNÉ == hashedMdp
                               select a).FirstOrDefault();

                    if (abo != null)
                    {
                        abo.PASSWORD_ABONNÉ = Utils.ComputeSha256Hash(textBox2.Text);
                        ConnexionView.Pop("Vous avez bien changé votre mot de passe!", "Confirmation");
                        Utils.Connexion.SaveChanges();
                        this.Close();
                        return;
                    }
                    ConnexionView.Pop("Erreur! Vous n'avez pas entré le bon mot de passe!", "Erreur");
                    return;
                }
                ConnexionView.Pop("Erreur, nouveau mot de passe et confirmation non identiques!", "Erreur");
                return;
            }
            ConnexionView.Pop("Erreur, veuillez rentrer un mot de passe!", "Erreur");

        }

        /// <summary>
        /// Valide les entrées si la touche Espace est pressée
        /// </summary>
        #region Validations
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                valider_Click(this, null);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                valider_Click(this, null);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                valider_Click(this, null);
            }
        }
        #endregion

        /// <summary>
        /// Quitte la page si la touche Entrée est pressée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
