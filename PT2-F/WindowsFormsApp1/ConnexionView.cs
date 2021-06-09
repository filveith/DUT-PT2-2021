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

        private void ConnexionView_Load(object sender, EventArgs e)
        {

        }

        private void validerButton_Click(object sender, EventArgs e)
        {
            this.valider();

        }

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




        /*
         *affiche les boites de messages 
         */
        public static void Pop(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);
        }



        /**
         *permet de verifier si le login existe  
         */
        private static bool LoginValide(string login)
        {
            bool loginValide = false;

            var logQuery = (from ab in Connexion.ABONNÉS
                           select ab.LOGIN_ABONNÉ).ToList();

            List<string> logins = logQuery;

            foreach(string s in logins)
            {
                
                if (login.Equals(s.Trim()))
                {
                    loginValide = true;

                }
            }

            return loginValide;
        }




        /**
         * permet de vérifier si le mot de passe est le bon
         */
        private static ABONNÉS Abonne(string login, string password)
        {
            
            var passQuery = from ab in Connexion.ABONNÉS
                              where ab.LOGIN_ABONNÉ == login && ab.PASSWORD_ABONNÉ == password
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
