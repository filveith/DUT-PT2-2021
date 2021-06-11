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
        private PagedListbox AffichageAbo;
        public bool TousEmpruntsProlonges { get; set; } = false;

        public UserView2()
        {
            InitializeComponent();
            AffichageAbo = new PagedListbox(TAffichageAbo);
            rendreButton.Enabled = false;

        }

        /// <summary>
        /// Gère le chargement de la page 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserView2_Load(object sender, EventArgs e)
        {
            AffichageAbo.Clear();
            filtres.Items.Clear();
            filtres.Items.Add("titre");
            filtres.Items.Add("genre");
            filtres.Text = "titre";
            filtres.SelectedIndex = 0;
            prolongerAllEmpruntButton.Enabled = !TousEmpruntsProlonges;

            this.recherche();
        }

        private void Emprunts()
        {
            Dictionary<EMPRUNTER, ALBUMS> emprunts = UserView.Abo.ConsulterEmprunts();
            if (emprunts.Count > 0)
            {
                foreach (KeyValuePair<EMPRUNTER, ALBUMS> emprunt in emprunts)
                {
                    AffichageAbo.Add(emprunt.Value);
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

        }

        /// <summary>
        /// Gère le clic sur le bouton de prolongement de tout les emprunts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prolongerToutEmprunt_Click(object sender, EventArgs e)
        {
            UserView.Abo.ProlongerTousEmprunts();
            prolongerAllEmpruntButton.Enabled = false;
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


        private void recherche()
        {
            string filtre = filtres.Text;
            string objet = searchBox.Text;
            AffichageAbo.Clear();
            if(objet.Length == 0)
            {
                this.Emprunts();
                return;
            }
            if (filtre.Equals("titre"))
            {
                Dictionary<EMPRUNTER, ALBUMS> emprunts = UserView.Abo.ConsulterEmprunts();

                foreach (KeyValuePair<EMPRUNTER, ALBUMS> keyValuePair in emprunts)
                {
                    ALBUMS val = keyValuePair.Value;
                    if (val.TITRE_ALBUM.ToLower().Contains(objet.ToLower()))
                    {
                        AffichageAbo.Add(val);
                    }
                }

            }
            else if (filtre == "genre")
            {
                Dictionary<EMPRUNTER, ALBUMS> emprunts = UserView.Abo.ConsulterEmprunts();
                foreach (var v in emprunts.Where(v => v.Value.GENRES.LIBELLÉ_GENRE.ToLower().Contains(objet.ToLower())))
                {
                    AffichageAbo.Add(v.Value);
                }
            }
            else
            {
                this.Emprunts();
            }
            nextPage.Visible = AffichageAbo?.isOnLastPage == false;
            previousPage.Visible = AffichageAbo?.CurrentPage > 0;

        }
        private void userView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.recherche();
            }
        }

        private void TAffichageAbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AffichageAbo.SelectedItem is ALBUMS obtAlbum)
            {
                var emprunt = (from em in Utils.Connexion.EMPRUNTER
                               where em.CODE_ABONNÉ == UserView.Abo.CODE_ABONNÉ && em.DATE_RETOUR == null
                               where em.CODE_ALBUM == obtAlbum.CODE_ALBUM
                               select em).FirstOrDefault();
                var pochette = obtAlbum.POCHETTE;
                prolongerEmprunt.Enabled = emprunt.nbRallongements == 0;
                afficherMiniature.Image = Utils.ResizeImage(Utils.byteArrayToImage(pochette), 200, 200);
                dateEmprunt.Text = "Date d'emprunt: " + emprunt.DATE_EMPRUNT.ToString();
                dateRetour.Text = "Date de retour: " + emprunt.DATE_RETOUR_ATTENDUE.ToString();
            }
        }

        private void rendreButton_Click(object sender, EventArgs e)
        {
            if (AffichageAbo.SelectedItem is ALBUMS obtAlbum)
            {
                UserView.Abo.Rendre(obtAlbum);
                AffichageAbo.Remove(obtAlbum);
            }
        }

        private void prolongerEmprunt_Click_1(object sender, EventArgs e)
        {
            if (AffichageAbo.SelectedItem is ALBUMS al)
            {
                EMPRUNTER emp = UserView.Abo.ProlongerEmprunt(al);
                ConnexionView.Pop("Emprunt prolongé de 1 mois !", "Attention");
                dateRetour.Text = "Date de retour: " + emp.DATE_RETOUR_ATTENDUE.ToString();
                prolongerEmprunt.Enabled = false;
                TousEmpruntsProlonges = true;
            }
            else
            {
                ConnexionView.Pop("ce n'est pas un album", "Erreur");
            }
        }
    }
}
