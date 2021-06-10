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
        public AdminView()
        {
            InitializeComponent();
            pagedListbox = new PagedListbox(log);
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;
        }

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

        private void listRetardButton_Click(object sender, EventArgs e)
        {
            pagedListbox.Clear();
            IQueryable<ABONNÉS> abonnésEnRetard = Utils.AvoirAbonneAvecEmpruntRetardDe10Jours();

            foreach (ABONNÉS abo in abonnésEnRetard)
            {
                pagedListbox.Add("L'abonné " + abo.CODE_ABONNÉ + " est en retard sur un retour");
            }
        }

        private void addAlbumButton_Click(object sender, EventArgs e)
        {
            pagedListbox.Clear();
            pagedListbox.Add("Pas implémenté");
        }

        private void removeAlbumButton_Click(object sender, EventArgs e)
        {
            pagedListbox.Clear();
            pagedListbox.Add("Pas implémenté");
        }

        private void notEmprunterSinceAYear_Click(object sender, EventArgs e)
        {
            pagedListbox.Clear();
            var albums = Utils.AvoirAlbumsPasEmprunteDepuisUnAn();
            List<string> allStrings = new List<string>();
            foreach (ALBUMS al in albums)
            {
                allStrings.Add("L'album " + al.TITRE_ALBUM.Trim() + " n'a pas été emprunté depuis 1 an");
            }
            pagedListbox.AddRange(allStrings);
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;

        }

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
    }
}
