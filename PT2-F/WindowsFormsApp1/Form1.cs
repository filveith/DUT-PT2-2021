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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ABONNÉS a = Utils.GetABONNÉ(65);


        }

        /// <summary>
        /// Gère le clic sur le bouton d'inscription
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inscription_Click(object sender, EventArgs e)
        {
            InscriptionView view = new InscriptionView();
            this.Visible = false;
            view.ShowDialog();
            this.Visible = true;
        }

        /// <summary>
        /// [PROVISOIRE] Permet d'accéder à certaines fenetres manuellement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'd')
            {
                DebugWindow d = new DebugWindow();
                d.Show();
            }
            if(e.KeyChar == 'c')
            {
                ChangePassword c = new ChangePassword(Utils.GetABONNÉ("jean"));
                c.Show();
            }
        }

        /// <summary>
        /// Gère le clic sur le bouton de connexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connexion_Click(object sender, EventArgs e)
        {
            ConnexionView c = new ConnexionView();
            this.Visible = false;
            c.ShowDialog();
            this.Close();
        }

        
    }
}
