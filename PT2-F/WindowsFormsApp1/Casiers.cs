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
        private void Casiers_Load(object sender, EventArgs e)
        {
            pagedListbox.Clear();
            this.afficherAlbums();

        }


        private void afficherAlbums()
        {
            var toutAlbums = (from alb in Utils.Connexion.ALBUMS
                              join emp in Utils.Connexion.EMPRUNTER on alb.CODE_ALBUM equals emp.CODE_ALBUM
                              select new
                              {
                                  emprunt = emp,
                                  album = alb
                              });

            foreach (var a in toutAlbums)
            {

                pagedListbox.Add(a.album);
                nextPage.Visible = pagedListbox?.isOnLastPage == false;
                previousPage.Visible = pagedListbox?.CurrentPage > 0;
            }
        }
        private void AfficherAlbumsSelonCasier(int numéroDeCasier)
        {
            pagedListbox.Clear();
            List<ALBUMS> albumsManquantsParCasier = (from alb in Utils.Connexion.ALBUMS
                                                     join emp in Utils.Connexion.EMPRUNTER on alb.CODE_ALBUM equals emp.CODE_ALBUM
                                                     where alb.CASIER_ALBUM == numéroDeCasier && emp.DATE_EMPRUNT != null
                                                     select alb).ToList();

            foreach (ALBUMS a in albumsManquantsParCasier)
            {
                pagedListbox.Add(a);
                nextPage.Visible = pagedListbox?.isOnLastPage == false;
                previousPage.Visible = pagedListbox?.CurrentPage > 0;
            }
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;
        }

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

        private void previousPage_Click(object sender, EventArgs e)
        {
            pagedListbox.PreviousPage();
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;
        }

        private void nextPage_Click(object sender, EventArgs e)
        {
            pagedListbox.NextPage();
            nextPage.Visible = pagedListbox?.isOnLastPage == false;
            previousPage.Visible = pagedListbox?.CurrentPage > 0;
        }

        private void listCasiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listCasiers.SelectedItem is ALBUMS a)
            {
                if (a.POCHETTE == null)
                {
                    affichageMinia.Image = null;
                    affichageMinia.Text = "Cet album ne possède pas de pochette.";
                } else
                {
                    affichageMinia.Text = null;
                    Image pochette = Utils.byteArrayToImage(a.POCHETTE);
                    affichageMinia.Image = Utils.ResizeImage(pochette, 200, 200);
                }
            }
        }
    }


}
