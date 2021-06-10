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
    public partial class ConnexionView : Form
    {
        private static readonly MusiquePT2_FEntities Connexion = Utils.Connexion;
        public ConnexionView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Bouton 'Valider' cliqué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void validerButton_Click(object sender, EventArgs e)
        {
            this.valider();
        }

        /// <summary>
        /// Vérifie que le login et le mot de passe entrés sont corrects
        /// </summary>
        private void valider()
        {
            string login = idTextBox.Text;
            string password = passTextBox.Text;

            if (login.Length > 0 && password.Length > 0)
            {
                if (LoginValide(login))
                {
                    ABONNÉS a = Abonne(login, password);
                    if (a != null)
                    {

                        if (isAdmin(login))
                        {
                            AdminView ad = new AdminView();
                            this.Visible = false;
                            ad.ShowDialog();
                            this.Visible = true;
                        }
                        else
                        {
                            UserView u = new UserView(a);
                            this.Visible = false;
                            u.ShowDialog();
                            this.Visible = true;
                        }
                    }
                    else Pop("Mot de passe invalide", "Erreur");

                }
                else
                {
                    Pop("Votre identifiant n'est pas valide ", "Erreur");
                }

            }
            else
            {
                Pop("Un de vos champs est vide", "Erreur");
            }
        }




        /// <summary>
        /// Affiche les boites de message
        /// </summary>
        /// <param name="message">Le message</param>
        /// <param name="caption">Le type</param>
        public static void Pop(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);
        }



        /// <summary>
        /// Vérifie si le login entré existe
        /// </summary>
        /// <param name="login">Le login</param>
        /// <returns>Vrai si le login est correct</returns>
        private static bool LoginValide(string login)
        {
            bool loginValide = false;

            var logQuery = (from ab in Connexion.ABONNÉS
                            select ab.LOGIN_ABONNÉ).ToList();

            List<string> logins = logQuery;

            foreach (string s in logins)
            {

                if (login.Equals(s.Trim()))
                {
                    loginValide = true;

                }
            }

            return loginValide;
        }




        /// <summary>
        /// Vérifie si le mot de passe est le bon
        /// </summary>
        /// <param name="login">Le login</param>
        /// <param name="password">Le mot de passe</param>
        /// <returns>L'abonné correspondant</returns>
        private static ABONNÉS Abonne(string login, string password)
        {
            string hashedPass = Utils.ComputeSha256Hash(password);
            var passQuery = from ab in Connexion.ABONNÉS
                            where ab.LOGIN_ABONNÉ == login && ab.PASSWORD_ABONNÉ == hashedPass
                            select ab;

            return passQuery.FirstOrDefault();
        }

        private static bool isAdmin(string login)
        {
            bool admin = false;

            var adminQuery = (from ab in Connexion.ABONNÉS
                              where ab.isAdmin == true
                              select ab.LOGIN_ABONNÉ).ToList();

            List<string> admins = adminQuery;

            foreach (string s in admins)
            {

                if (login.Equals(s.Trim()))
                {
                    admin = true;
                    break;
                }
            }

            return admin;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.valider();
            }
        }
    }

}
