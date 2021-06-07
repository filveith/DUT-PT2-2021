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
        private static MusiquePT2_FEntities Connexion = new MusiquePT2_FEntities();
        public static string Login;
        public static string Password;
        public ConnexionView()
        {
            InitializeComponent();
        }

        private void ConnexionView_Load(object sender, EventArgs e)
        {

        }

        private void validerButton_Click(object sender, EventArgs e)
        {
            string login = idTextBox.Text;
            string password = passTextBox.Text;

            if (login.Length > 0 && password.Length > 0)
            {
                if (LoginValide(login))
                {
                    if (BonMotDePasse(login, password))
                    {
                        Pop("vous êtes connectés", "Parfait");
                        if (isAdmin(login))
                        {
                            Pop("connecté en tant qu'admin", "Attention");
                        }
                    }

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
        private static void Pop(string message, string caption)
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
        private static bool BonMotDePasse(string login, string password)
        {
            bool BonMotDePasse = false;
            
            var passQuery = from ab in Connexion.ABONNÉS
                              where ab.LOGIN_ABONNÉ == login
                              select ab.PASSWORD_ABONNÉ;

            string pass = passQuery.FirstOrDefault().Trim() ;
           
            
            

            if(password.Equals(pass) || password == pass)
            {
                BonMotDePasse = true;
            }
            else
            {
                Pop("Mauvais mot de passe", "Erreur");
            }

            return BonMotDePasse;
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

                }
            }

            return admin;
        }
    }
    
}
