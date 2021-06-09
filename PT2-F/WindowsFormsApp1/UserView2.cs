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
    public partial class UserView2 : Form
    {
        PagedListbox AffichageAbo;
        private UserView previousWindow;

        public UserView2(UserView v)
        {
            InitializeComponent();
            AffichageAbo = new PagedListbox(TAffichageAbo);
            AffichageAbo.page.SelectedIndexChanged += Page_SelectedIndexChanged;
            prolongerEmpruntButton.Enabled = false;
            previousWindow = v;

        }

        /// <summary>
        /// Change de page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_SelectedIndexChanged(object sender, EventArgs e)
        {
            int position = AffichageAbo.SelectedItem.ToString().IndexOf("|");
            string titreAlbum = AffichageAbo.SelectedItem.ToString().Substring(0, position - 1);

            ALBUMS obtAlbum = (from a in Utils.Connexion.ALBUMS
                               where a.TITRE_ALBUM.ToString() == titreAlbum
                               select a).FirstOrDefault();
            var emprunt = (from em in Utils.Connexion.EMPRUNTER
                           where em.CODE_ABONNÉ == UserView.Abo.CODE_ABONNÉ
                           where em.CODE_ALBUM == obtAlbum.CODE_ALBUM
                           select em).FirstOrDefault();
            prolongerEmpruntButton.Enabled = emprunt.nbRallongements == 0;
        }

        /// <summary>
        /// Gère le chargement de la page 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserView2_Load(object sender, EventArgs e)
        {
            AffichageAbo.Clear();
            Dictionary<EMPRUNTER, ALBUMS> emprunts = UserView.Abo.ConsulterEmprunts();
            if (emprunts.Count > 0)
            {
                foreach (KeyValuePair<EMPRUNTER, ALBUMS> emprunt in emprunts)
                {
                    AffichageAbo.Add(emprunt.Value.ToString() + " | emprunté le \"" + emprunt.Key.DATE_EMPRUNT + "\" | à rendre le " + emprunt.Key.DATE_RETOUR_ATTENDUE);
                }
            }
            nextPage.Visible = AffichageAbo?.isOnLastPage == false;
            previousPage.Visible = AffichageAbo?.CurrentPage > 0;
        }

        /// <summary>
        /// Gère le clic sur le bouton 'Mes Albums'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mesAlbums_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void prolongerEmprunt_Click(object sender, EventArgs e)
        {
            if (previousWindow.currentSugg == null)
            {
                int position = AffichageAbo.SelectedItem.ToString().IndexOf("|");
                string titreAlbum = AffichageAbo.SelectedItem.ToString().Substring(0, position - 1);

                ALBUMS obtAlbum = (from a in Utils.Connexion.ALBUMS
                                   where a.TITRE_ALBUM.ToString() == titreAlbum
                                   select a).FirstOrDefault();

            if (obtAlbum is ALBUMS al)
            {
                UserView.Abo.ProlongerEmprunt(Utils.GetALBUM(al.CODE_ALBUM));


                ConnexionView.Pop("Emprunt prolongé de 1 mois !", "Attention");
                prolongerEmpruntButton.Enabled = false;
            }
            else
            {
                ConnexionView.Pop("ce n'est pas un album", "Erreur");
            }


        }

        /// <summary>
        /// Gère le clic sur le bouton de prolongement de tout les emprunts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prolongerToutEmprunt_Click(object sender, EventArgs e)
        {
            UserView.Abo.ProlongerTousEmprunts();
            ConnexionView.Pop("Tous vos emprunts ont bien étés prolongés !", "Attention");
        }

        /// <summary>
        /// Gère le clic sur le bouton 'Page Suivante'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextPage_Click(object sender, EventArgs e)
        {
            AffichageAbo.NextPage();
            nextPage.Visible = AffichageAbo?.isOnLastPage == false;
            previousPage.Visible = AffichageAbo?.CurrentPage > 0;
        }

        /// <summary>
        /// Gère le clic sur le bouton 'Page Précédente'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previousPage_Click(object sender, EventArgs e)
        {
            AffichageAbo.PreviousPage();
            nextPage.Visible = AffichageAbo?.isOnLastPage == false;
            previousPage.Visible = AffichageAbo?.CurrentPage > 0;
        }
    }
}
