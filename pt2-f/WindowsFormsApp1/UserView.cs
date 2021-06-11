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


    public partial class UserView : Form
    {
        public ABONNÉS Abo;
        public UserView2 u2;
        PagedListbox AffichageAbo;
        public UserView(ABONNÉS a)
        {
            InitializeComponent();
            Abo = a;
            AffichageAbo = new PagedListbox(TAffichageAbo);
            nextPage.Visible = AffichageAbo?.isOnLastPage == false;
            previousPage.Visible = AffichageAbo?.CurrentPage > 0;
            u2 = new UserView2();
        }

        /// <summary>
        /// Gère le chargement de la page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserView_Load(object sender, EventArgs e)
        {
            filtres.Items.Clear();
            filtres.Items.Add("titre");
            filtres.Items.Add("genre");
            filtres.Text = "titre";
            filtres.SelectedIndex = 0;

            this.suggestions();
        }

        /// <summary>
        /// Gère le clic sur le bouton 'Mes Albums'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mesAlbums_Click(object sender, EventArgs e)
        {

            this.Visible = false;
            u2.ShowDialog();
            this.Visible = true;

        }

        /// <summary>
        /// Calcule des suggestions pour l'abonné
        /// </summary>
        private void suggestions()
        {
            AffichageAbo.Clear();
            HashSet<ALBUMS> sugg;
            sugg = Abo.AvoirSuggestions();
            if (sugg != null && sugg.Count > 0)
            {
                AffichageAbo.AddRange(sugg);
                nextPage.Visible = AffichageAbo?.isOnLastPage == false;
                previousPage.Visible = AffichageAbo?.CurrentPage > 0;
            }
            else
            {
                AffichageAbo.Add("Pas de suggestions");
            }
        }

        /// <summary>
        /// Effectue une recherche selon le filtre
        /// </summary>
        private void recherche()
        {
            string filtre = filtres.Text;
            string objet = searchBox.Text;
            AffichageAbo.Clear();
            if (objet.Length == 0)
            {
                AffichageAbo.AddRange(Utils.Connexion.ALBUMS.ToList());
                return;
            }
            if (filtre.Equals("titre"))
            {
                var recherche = (from t in Utils.Connexion.ALBUMS
                                 where t.TITRE_ALBUM.ToLower().Contains(objet.ToLower())
                                 select t).ToList();

                AffichageAbo.AddRange(recherche);
            }
            else if (filtre.Equals("genre"))
            {
                List<ALBUMS> recherche;
                recherche = (from t in Utils.Connexion.ALBUMS
                             join g in Utils.Connexion.GENRES on t.CODE_GENRE equals g.CODE_GENRE
                             where g.LIBELLÉ_GENRE.ToLower().Contains(objet.ToLower())
                             select t).ToList();

                AffichageAbo.AddRange(recherche);
            }
            else
            {
                this.suggestions();
            }
            nextPage.Visible = AffichageAbo?.isOnLastPage == false;
            previousPage.Visible = AffichageAbo?.CurrentPage > 0;

        }

        private void userView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textSugg.Visible = false;
                this.recherche();
            }
        }

        /// <summary>
        /// Permet d'emprunter l'album sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void emprunter_Click(object sender, EventArgs e)
        {
            if (AffichageAbo.SelectedItem is ALBUMS al)
            {
                if (!dejaEmprunté(al))
                {
                    Abo.Emprunter(al);
                    u2.TousEmpruntsProlonges = false;
                    ConnexionView.Pop("Emprunt Réussi !", "Attention");
                }
                else
                {
                    ConnexionView.Pop("Vous avez déja emprunté cet Album", "Erreur");
                }

            }
            else
            {
                ConnexionView.Pop("ce n'est pas un album", "Erreur");
            }
        }

        /// <summary>
        /// Détermine si l'album a déjà été emprunté
        /// </summary>
        /// <param name="alb">L'album</param>
        /// <returns>Vrai si l'album a déjà été emprunté</returns>
        private bool dejaEmprunté(ALBUMS alb)
        {
            var mesEmprunts = Abo.ConsulterEmprunts();

            foreach (KeyValuePair<EMPRUNTER, ALBUMS> keyValuePair in mesEmprunts)
            {
                if (keyValuePair.Value == alb)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gère le clic sur le bouton de suggestion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void suggest_Click(object sender, EventArgs e)
        {
            textSugg.Visible = true;
            this.suggestions();
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

        private void TAffichageAbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TAffichageAbo.SelectedItem is ALBUMS alb)
            {

                if (alb.POCHETTE == null)
                {
                    imageLabel.Image = null;
                    imageLabel.Text = "Cet album ne possède pas de pochette.";
                }
                else
                {
                    Image image = alb.getPochette();
                    imageLabel.AutoSize = false;
                    imageLabel.Size = image.Size;
                    imageLabel.Image = Utils.ResizeImage(image, 200, 200);
                }
            }
            else
            {
                imageLabel.Image = null;
            }
        }
    }
}
