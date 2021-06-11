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
        /// Gère le clic sur le bouton de connexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connexion_Click(object sender, EventArgs e)
        {
            ConnexionView c = new ConnexionView();
            this.Visible = false;
            if (c.ShowDialog() == DialogResult.OK)
            {
                this.Visible = true;
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// Quitte la fenêtre si la touche Echap est pressée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
