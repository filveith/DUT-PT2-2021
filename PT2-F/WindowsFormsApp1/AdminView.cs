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
        public AdminView()
        {
            InitializeComponent();
        }

        private void listEmpruntsProlongButton_Click(object sender, EventArgs e)
        {
            log.Items.Clear();
            IQueryable<EMPRUNTER> empruntsProlongés = Utils.AvoirLesEmpruntProlonger();

            foreach (EMPRUNTER emprunt in empruntsProlongés)
            {
                log.Items.Add("L'abonné " + emprunt.CODE_ABONNÉ + " a prolongé l'album " + emprunt.CODE_ALBUM);
            }

        }

        private void listRetardButton_Click(object sender, EventArgs e)
        {
            log.Items.Clear();
            IQueryable<ABONNÉS> abonnésEnRetard = Utils.AvoirAbonneAvecEmpruntRetardDe10Jours();

            foreach (ABONNÉS abo in abonnésEnRetard)
            {
                log.Items.Add("L'abonné " + abo.CODE_ABONNÉ + " est en retard sur un retour");
            }
        }

        private void addAlbumButton_Click(object sender, EventArgs e)
        {
            log.Items.Clear();
            log.Items.Add("Pas implémenté");
        }

        private void removeAlbumButton_Click(object sender, EventArgs e)
        {
            log.Items.Clear();
            log.Items.Add("Pas implémenté");
        }

        private void notEmprunterSinceAYear_Click(object sender, EventArgs e)
        {
            log.Items.Clear();
            var albums = CachedElements.albumsPasEmpruntes;

            foreach (ALBUMS al in albums)
            {
                log.Items.Add("L'album " + al.TITRE_ALBUM.Trim() + " n'a pas été emprunté depuis 1 an");
            }

        }

        private void top10Button_Click(object sender, EventArgs e)
        {
            log.Items.Clear();

            List<ALBUMS> top10 = Utils.AvoirTopAlbum();

            foreach (ALBUMS al in top10)
            {
                log.Items.Add(al.TITRE_ALBUM.Trim());
            }
        }

        private void suppIdleUsersButton_Click(object sender, EventArgs e)
        {
            log.Items.Clear();
            foreach (ABONNÉS a in Utils.SupprimerAbosPasEmpruntDepuisUnAn().GetAwaiter().GetResult())
            {
                log.Items.Add("L'abonné \"" + a.NOM_ABONNÉ.Trim() + " " + a.PRÉNOM_ABONNÉ.Trim() + "\" a été supprimé pour inactivité");
            }

        }

        
    }
}
