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
            afficheMiniature.Image = null;
            pagedListbox.Clear();
            var empruntsProlongés = Utils.AvoirLesEmpruntProlonger();

            foreach (EMPRUNTER emprunt in empruntsProlongés)
            {
                pagedListbox.Add("L'abonné " + emprunt.CODE_ABONNÉ + " a prolongé l'album " + emprunt.CODE_ALBUM);
            }
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;

        }

        private void listRetardButton_Click(object sender, EventArgs e)
        {

            afficheMiniature.Image = null;
            pagedListbox.Clear();
            IQueryable<ABONNÉS> abonnésEnRetard = Utils.AvoirAbonneAvecEmpruntRetardDe10Jours();

            foreach (ABONNÉS abo in abonnésEnRetard)
            {
                pagedListbox.Add("L'abonné " + abo.CODE_ABONNÉ + " est en retard sur un retour");
            }
        }

        private void showLockersButton_Click(object sender, EventArgs e)
        {
            casiers = new Casiers();
            casiers.ShowDialog();
        }

        private void notEmprunterSinceAYear_Click(object sender, EventArgs e)
        {
            afficheMiniature.Image = null;
            pagedListbox.Clear();
            var albums = Utils.AvoirAlbumsPasEmprunteDepuisUnAn();
            pagedListbox.AddRange(albums);
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;

        }

        private void top10Button_Click(object sender, EventArgs e)
        {
            afficheMiniature.Image = null;
            pagedListbox.Clear();

            List<ALBUMS> top10 = Utils.AvoirTopAlbum();

            foreach (ALBUMS al in top10)
            {
                pagedListbox.Add(al);
            }
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;
        }

        private void suppIdleUsersButton_Click(object sender, EventArgs e)
        {
            afficheMiniature.Image = null;
            pagedListbox.Clear();
            foreach (ABONNÉS a in Utils.SupprimerAbosPasEmpruntDepuisUnAn())
            {
                pagedListbox.Add("L'abonné \"" + a.NOM_ABONNÉ.Trim() + " " + a.PRÉNOM_ABONNÉ.Trim() + "\" a été supprimé pour inactivité");
            }
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;
        }

        private void listerAbonner_Click(object sender, EventArgs e)
        {
            afficheMiniature.Image = null;
            pagedListbox.Clear();
            List<ABONNÉS> toutLesAbonner = Utils.GetAllAbonnes();
            pagedListbox.Add("Voici la liste de tout les abonnés :");
            pagedListbox.AddRange(toutLesAbonner);
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;
        }

        private void nextPage_Click(object sender, EventArgs e)
        {
            pagedListbox.NextPage();
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;
        }

        private void previousPage_Click(object sender, EventArgs e)
        {
            pagedListbox.PreviousPage();
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;
        }

        private void log_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pagedListbox.SelectedItem != null && pagedListbox.SelectedItem is ALBUMS obtAlbum)
            {
                if (obtAlbum.POCHETTE == null)
                {
                    afficheMiniature.Image = null;
                    afficheMiniature.Text = "Cet album ne possède pas de pochette.";
                }
                else
                {
                    afficheMiniature.Text = null;
                    var pochette = obtAlbum.POCHETTE;
                    afficheMiniature.Image = Utils.ResizeImage(Utils.byteArrayToImage(pochette), afficheMiniature.Width, afficheMiniature.Height);
                }

            }
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void changePassword_Click(object sender, EventArgs e)
        {
            if (pagedListbox.SelectedItem is ABONNÉS a)
            {
                AdminChangePassword c = new AdminChangePassword(a);
                c.Show();
            }

        }

        private void AdminView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
