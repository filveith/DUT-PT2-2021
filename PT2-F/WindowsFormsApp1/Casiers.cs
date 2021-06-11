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
    public partial class Casiers : Form
    {
        int numCasier = 1;
        private PagedListbox pagedListbox;
        public Casiers()
        {
            InitializeComponent();
            pagedListbox = new PagedListbox(listCasiers);
        }

        /// <summary>
        /// Charge la fenêtre des casiers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Casiers_Load(object sender, EventArgs e)
        {
            pagedListbox.Clear();
            this.afficherAlbums();

        }

        /// <summary>
        /// Affiche les albums empruntés
        /// </summary>
        private void afficherAlbums()
        {
            var toutAlbums = Utils.AvoirAlbumsEmpruntes();

            pagedListbox.AddRange(toutAlbums);
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;
        }

        /// <summary>
        /// Affiche les albums empruntés du casier renseigné
        /// </summary>
        /// <param name="numéroDeCasier">Le code du casier</param>
        private void AfficherAlbumsSelonCasier(int numéroDeCasier)
        {
            pagedListbox.Clear();
            IEnumerable<ALBUMS> albumsManquantsParCasier = Utils.AvoirAlbumsEmpruntes().Where(al => al.CASIER_ALBUM == numéroDeCasier);

            pagedListbox.AddRange(albumsManquantsParCasier);
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;
        }

        /// <summary>
        /// Gère les clics sur les boutons selon le casier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Numéros de casier
        private void button1_Click(object sender, EventArgs e)
        {
            numCasier = 1;
            this.AfficherAlbumsSelonCasier(numCasier);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numCasier = 2;
            this.AfficherAlbumsSelonCasier(numCasier);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numCasier = 3;
            this.AfficherAlbumsSelonCasier(numCasier);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numCasier = 4;
            this.AfficherAlbumsSelonCasier(numCasier);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numCasier = 5;
            this.AfficherAlbumsSelonCasier(numCasier);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            numCasier = 6;
            this.AfficherAlbumsSelonCasier(numCasier);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            numCasier = 7;
            this.AfficherAlbumsSelonCasier(numCasier);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            numCasier = 8;
            this.AfficherAlbumsSelonCasier(numCasier);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            numCasier = 9;
            this.AfficherAlbumsSelonCasier(numCasier);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            numCasier = 10;
            this.AfficherAlbumsSelonCasier(numCasier);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            numCasier = 11;
            this.AfficherAlbumsSelonCasier(numCasier);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            numCasier = 12;
            this.AfficherAlbumsSelonCasier(numCasier);
        }
        #endregion

        /// <summary>
        /// Passe à la page précédente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previousPage_Click(object sender, EventArgs e)
        {
            pagedListbox.PreviousPage();
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;
        }

        /// <summary>
        /// Passe à la page suivante
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
        /// Affiche la pochette de l'album séléctionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listCasiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listCasiers.SelectedItem is ALBUMS a)
            {
                Image pochette = a.getPochette();
                if (pochette != null)
                {
                    affichageMinia.Image = Utils.ResizeImage(pochette, 200, 200);
                }
                else {
                    affichageMinia.Image = null;
                }
            }
        }

        /// <summary>
        /// Quitte la fenêtre si la touche Entrée est pressée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Casiers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void listCasiers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listCasiers.SelectedItem != null && listCasiers.SelectedItem is ALBUMS al)
            {
                AlbumInfo albumInfo = new AlbumInfo(al);
                albumInfo.Show();
            }
        }
    }


}
