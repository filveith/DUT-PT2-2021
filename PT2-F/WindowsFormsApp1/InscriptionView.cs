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
        private bool isFirstHidden = true;
        private bool isSecondHidden = true;
        public InscriptionView()
        {
            InitializeComponent();
            button1.Image = Utils.ResizeImage(button1.Image, 20, 20);
            button2.Image = Utils.ResizeImage(button1.Image, 20, 20);
        }

        /// <summary>
        /// Vérifie que toutes les inforamtions nécessaires sont données et valides
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValiderInscription_Click(object sender, EventArgs e)
        {
            // les contrôles sont remplis ?
            string nom = textBoxNom.Text.Trim();
            string prenom = textBoxPrenom.Text.Trim();
            string login = textBoxID.Text.Trim();
            if (nom.Length != 0 && prenom.Length != 0 && login.Length != 0
                && textBoxID.TextLength != 0 && textBoxMdp.TextLength != 0 
                && textBoxCoMdp.TextLength != 0 && comboBoxPays.SelectedItem != null)
            {
                if (textBoxCoMdp.Text == textBoxMdp.Text)
                {
                    if (Utils.RegisterAbo(nom, prenom, login, textBoxMdp.Text, comboBoxPays.SelectedIndex) != null)
                    {
                        PopupErreurOK("Vous venez de vous inscrire avec le login \"" + login + "\"", "Bravo");
                        this.Close();
                    }
                    else
                    {
                        Utils.RefreshDatabase();
                        PopupErreurOK("Erreur login identique", "Erreur");
                    }

                }
                else PopupErreurOK("Erreur mot de passe", "Erreur");
            }
            else PopupErreurOK("Tous les champs doivent être remplis", "Erreur");
        }

        /// <summary>
        /// Affiche une fenêtre avec un message d'erreur
        /// </summary>
        /// <param name="message">Le message</param>
        /// <param name="caption">Le type</param>
        private void PopupErreurOK(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);
        }

        /// <summary>
        /// Prépare la fenêtre lors de son chargement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterView2_Load(object sender, EventArgs e)
        {
            IEnumerable<PAYS> pays = Utils.AvoirListeDesPays();
            comboBoxPays.Items.Clear();
            comboBoxPays.Items.Add("Autre");
            foreach (PAYS p in pays)
            {
                comboBoxPays.Items.Add(p);
            }
            comboBoxPays.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isFirstHidden = !isFirstHidden;
            if (isFirstHidden)
            {
                button1.Image = Utils.ResizeImage(Properties.Resources.eyeClosed_Icon, 20, 20);
                textBoxMdp.PasswordChar = '*';
            }
            else
            {
                button1.Image = Utils.ResizeImage(Properties.Resources.eyeIcon, 20, 20);
                textBoxMdp.PasswordChar = (char)0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isSecondHidden = !isSecondHidden;
            if (isSecondHidden)
            {
                button2.Image = Utils.ResizeImage(Properties.Resources.eyeClosed_Icon, 20, 20);
                textBoxCoMdp.PasswordChar = '*';
            }
            else
            {
                button2.Image = Utils.ResizeImage(Properties.Resources.eyeIcon, 20, 20);
                textBoxCoMdp.PasswordChar = (char)0;
            }
        }

        private void InscriptionView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ValiderInscription_Click(this, null);
            }
        }

        private void InscriptionView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
