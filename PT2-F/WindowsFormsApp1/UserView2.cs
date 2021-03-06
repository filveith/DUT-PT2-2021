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
        private UserView previousWindow;
        private PagedListbox AffichageAbo;
        public bool TousEmpruntsProlonges { get; set; } = false;

        public UserView2(UserView v)
        {
            InitializeComponent();
            AffichageAbo = new PagedListbox(TAffichageAbo);
            var emprunts = v.Abo.EMPRUNTER.Where(emp => emp.nbRallongements == 0);
            prolongerAllEmpruntButton.Enabled = emprunts.Count() > 0;
            previousWindow = v;
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
            prolongerEmprunt.Enabled = false;
            rendreButton.Enabled = false;

            this.recherche();
        }

        /// <summary>
        /// Affiche les emprunts
        /// </summary>
        private void Emprunts()
        {
            Dictionary<EMPRUNTER, ALBUMS> emprunts = previousWindow.Abo.ConsulterEmprunts();
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
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Gère le clic sur le bouton de prolongement de tout les emprunts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prolongerToutEmprunt_Click(object sender, EventArgs e)
        {
            previousWindow.Abo.ProlongerTousEmprunts();
            prolongerAllEmpruntButton.Enabled = false;
            TousEmpruntsProlonges = true;
            prolongerEmprunt.Enabled = false;
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

        /// <summary>
        /// Effectue une recherche
        /// </summary>
        private void recherche()
        {
            string filtre = filtres.Text;
            string objet = searchBox.Text;
            AffichageAbo.Clear();
            if (objet.Length == 0)
            {
                this.Emprunts();
                return;
            }
            if (filtre.Equals("titre"))
            {
                Dictionary<EMPRUNTER, ALBUMS> emprunts = previousWindow.Abo.ConsulterEmprunts();

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
                Dictionary<EMPRUNTER, ALBUMS> emprunts = previousWindow.Abo.ConsulterEmprunts();
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

        /// <summary>
        /// Valide si la touche Entrée est pressée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.recherche();
            }
        }

        /// <summary>
        /// Affiche la pochette de l'album sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TAffichageAbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AffichageAbo.SelectedItem is ALBUMS obtAlbum)
            {
                EMPRUNTER emprunt = obtAlbum.EMPRUNTER.First(em => em.ABONNÉS == previousWindow.Abo);

                if (obtAlbum.POCHETTE == null)
                {
                    afficherMiniature.Image = null;
                    afficherMiniature.Text = "Cet album ne possède pas de pochette.";
                }
                else
                {
                    afficherMiniature.Text = null;
                    var pochette = obtAlbum.POCHETTE;
                    prolongerEmprunt.Enabled = emprunt.nbRallongements == 0;
                    afficherMiniature.Image = Utils.ResizeImage(Utils.byteArrayToImage(pochette), 200, 200);
                }
                dateEmprunt.Text = "Date d'emprunt: " + emprunt.DATE_EMPRUNT.ToString();
                dateRetour.Text = "Date de retour: " + emprunt.DATE_RETOUR_ATTENDUE.ToString();
                if (emprunt.DATE_RETOUR == null)
                {
                    rendreButton.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Permet de rendre un albulm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rendreButton_Click(object sender, EventArgs e)
        {
            if (AffichageAbo.SelectedItem is ALBUMS obtAlbum)
            {
                previousWindow.Abo.Rendre(obtAlbum);
                AffichageAbo.Remove(obtAlbum);
            }
        }

        /// <summary>
        /// Prolonge l'emprunt d'un album
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prolongerEmprunt_Click_1(object sender, EventArgs e)
        {
            if (AffichageAbo.SelectedItem is ALBUMS al)
            {
                EMPRUNTER emp = previousWindow.Abo.ProlongerEmprunt(al);
                ConnexionView.Pop("Emprunt prolongé de 1 mois !", "Attention");
                dateRetour.Text = "Date de retour: " + emp.DATE_RETOUR_ATTENDUE.ToString();
                prolongerEmprunt.Enabled = false;

            }
            else
            {
                ConnexionView.Pop("ce n'est pas un album", "Erreur");
            }
        }

        /// <summary>
        /// Déconnecte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
            previousWindow.DialogResult = DialogResult.OK;
            previousWindow.Close();
        }

        /// <summary>
        /// Quitte si la touche Entrée est pressée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                label2_Click(this, null);
            }
        }

        private void TAffichageAbo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(TAffichageAbo.SelectedItem != null && TAffichageAbo.SelectedItem is ALBUMS a)
            {
                AlbumInfo albI = new AlbumInfo(a);
                albI.Show();
            }
        }
    }
}
