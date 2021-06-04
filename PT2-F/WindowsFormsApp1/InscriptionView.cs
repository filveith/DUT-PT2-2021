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
    public partial class InscriptionView : Form
    {
        private static MusiquePT2_FEntities Connexion = new MusiquePT2_FEntities();
        public InscriptionView()
        {
            InitializeComponent();
        }

        private void ValiderInscription_Click(object sender, EventArgs e)
        {
            // les contrôles sont remplis ?
            if (textBoxNom.TextLength != 0 && textBoxPrenom.TextLength != 0 && textBoxID.TextLength != 0 && textBoxMdp.TextLength != 0 && textBoxCoMdp.TextLength != 0)
            {
                if (textBoxCoMdp.Text == textBoxMdp.Text)
                {
                    // on crée un nouveau Abonné
                    ABONNÉS a = new ABONNÉS();
                    a.NOM_ABONNÉ = textBoxNom.Text.Substring(0, Math.Min(textBoxNom.Text.Length, 32));
                    a.PRÉNOM_ABONNÉ = textBoxPrenom.Text.Substring(0, Math.Min(textBoxPrenom.Text.Length, 32));
                    a.LOGIN_ABONNÉ = textBoxID.Text.Substring(0, Math.Min(textBoxID.Text.Length, 32));
                    a.PASSWORD_ABONNÉ = textBoxMdp.Text.Substring(0, Math.Min(textBoxMdp.Text.Length, 32));
                    a.creationDate = DateTime.Now;


                    // ajout du nouveau Abonné
                    Connexion.ABONNÉS.Add(a);
                    Connexion.SaveChanges();
                    
                    Console.WriteLine("ok");
                }
                else PopupErreurOK("Erreur mot de passe", "Erreur");

            }
            else PopupErreurOK("Tous les champs doivent être remplis", "Erreur");
            this.Close();
        }

        private void PopupErreurOK(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);
        }
    }
}
