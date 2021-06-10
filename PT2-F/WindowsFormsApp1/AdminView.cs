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
    public partial class AdminView : Form
    {
        private PagedListbox pagedListbox;
        private Casiers casiers;
        public AdminView()
        {
            InitializeComponent();
            pagedListbox = new PagedListbox(log);
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;
        }

  
            /// <summary>
            /// Gère le clic sur le bouton 'Lister Emprunts Prolongés'
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void listEmpruntsProlongButton_Click(object sender, EventArgs e)
        {
            pagedListbox.Clear();
            var empruntsProlongés = Utils.AvoirLesEmpruntProlonger();

            foreach (EMPRUNTER emprunt in empruntsProlongés)
            {
                pagedListbox.Add("L'abonné " + emprunt.CODE_ABONNÉ + " a prolongé l'album " + emprunt.CODE_ALBUM);
            }
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;

        }

        /// <summary>
        /// Gère le clic sur le bouton 'Lister Retards'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listRetardButton_Click(object sender, EventArgs e)
        {
            pagedListbox.Clear();
            IQueryable<ABONNÉS> abonnésEnRetard = Utils.AvoirAbonneAvecEmpruntRetardDe10Jours();

            foreach (ABONNÉS abo in abonnésEnRetard)
            {
                pagedListbox.Add("L'abonné " + abo.CODE_ABONNÉ + " est en retard sur un retour");
            }
        }

        /// <summary>
        /// Gère le clic sur le bouton 'Ajouter Albums'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addAlbumButton_Click(object sender, EventArgs e)
        {
            casiers = new Casiers();
            casiers.ShowDialog();
        }

        /// <summary>
        /// Gère le clic sur le bouton 'Supprimer Albums'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeAlbumButton_Click(object sender, EventArgs e)
        {
            pagedListbox.Clear();
            pagedListbox.Add("Pas implémenté");
        }

        /// <summary>
        /// Gère le clic sur le bouton 'Album pas emprunté depuis 1 an'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notEmprunterSinceAYear_Click(object sender, EventArgs e)
        {
            pagedListbox.Clear();
            var albums = Utils.AvoirAlbumsPasEmprunteDepuisUnAn();
            List<string> allStrings = new List<string>();
            foreach (ALBUMS al in albums)
            {
                allStrings.Add(al.TITRE_ALBUM.Trim());
            }
            pagedListbox.AddRange(allStrings);
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;

        }

        /// <summary>
        /// Gère le clic sur le bouton 'Top 10 Albums'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void top10Button_Click(object sender, EventArgs e)
        {
            pagedListbox.Clear();

            List<ALBUMS> top10 = Utils.AvoirTopAlbum();

            foreach (ALBUMS al in top10)
            {
                pagedListbox.Add(al.TITRE_ALBUM.Trim());
            }
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;
        }

        /// <summary>
        /// Gère le clic sur le bouton 'Supprimer Utilisateurs Inactifs'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void suppIdleUsersButton_Click(object sender, EventArgs e)
        {
            pagedListbox.Clear();
            foreach (ABONNÉS a in Utils.SupprimerAbosPasEmpruntDepuisUnAn())
            {
                pagedListbox.Add("L'abonné \"" + a.NOM_ABONNÉ.Trim() + " " + a.PRÉNOM_ABONNÉ.Trim() + "\" a été supprimé pour inactivité");
            }
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;
        }

        /// <summary>
        /// Gère le clic sur le bouton 'Lister les abonnés'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listerAbonner_Click(object sender, EventArgs e)
        {
            pagedListbox.Clear();
            IQueryable<ABONNÉS> toutLesAbonner = Utils.GetAllAbonnes();
            pagedListbox.Add("Voici la liste de tout les abonnés :");
            foreach (ABONNÉS abo in toutLesAbonner)
            {
                pagedListbox.Add(abo.NOM_ABONNÉ.Trim() + " " + abo.PRÉNOM_ABONNÉ.Trim() + " date d'abonnement: " + abo.creationDate);
            }
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;
        }

        /// <summary>
        /// Gère le clic sur le bouton 'Page Suivante'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextPage_Click(object sender, EventArgs e)
        {
            pagedListbox.NextPage();
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;
        }

        /// <summary>
        /// Gère le clic sur le bouton 'Page Précédente'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previousPage_Click(object sender, EventArgs e)
        {
            pagedListbox.PreviousPage();
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;
        }

        private void log_SelectedIndexChanged(object sender, EventArgs e)
        {
            string titreAlbum = pagedListbox.SelectedItem.ToString();

            ALBUMS obtAlbum = (from a in Utils.Connexion.ALBUMS
                               where a.TITRE_ALBUM.ToString() == titreAlbum
                               select a).FirstOrDefault();
            
            var pochette = obtAlbum.POCHETTE;
            afficheMiniature.Image = Utils.ResizeImage(Utils.byteArrayToImage(pochette), 200, 200);
            
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
