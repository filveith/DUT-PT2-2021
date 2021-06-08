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
        public static ABONNÉS Abo;
        public static UserView2 u2 = new UserView2(Abo);
        public UserView(ABONNÉS a)
        {
            InitializeComponent();
            Abo = a;
            Task.Run(() => CachedElements.RefreshSuggestions(a));
        }

        private void UserView_Load(object sender, EventArgs e)
        {
            this.suggestions();

            filtres.Items.Clear();
            filtres.Items.Add("genre");
            filtres.Items.Add("titre");
            filtres.Items.Add("vide");

            this.recherche();
        }
        private void mesAlbums_Click(object sender, EventArgs e)
        {

            this.Visible = false;
            u2.ShowDialog();
            this.Visible = true;

        }


        private void suggestions()
        {
            AffichageAbo.Items.Clear();
            HashSet<ALBUMS> sugg = CachedElements.suggestionsParAbo[Abo];
            if (sugg.Count > 0)
            {
                AffichageAbo.Items.Add("Voici des albums qui devraient vous plairent : ");
                foreach (ALBUMS s in sugg)
                {
                    AffichageAbo.Items.Add(s.ToString());
                }
            }
            else
            {
                AffichageAbo.Items.Add("Pas de suggestions, vous n'avez rien emprunté...");
            }
        }

        private void recherche()
        {
            string filtre = filtres.Text;
            string objet = searchBox.Text;
            AffichageAbo.Items.Clear();
            if (filtre.Equals("titre"))
            {
                var recherce = from t in Utils.Connexion.ALBUMS
                               where t.TITRE_ALBUM.Contains(objet)
                               select t.TITRE_ALBUM;

                foreach (string a in recherce)
                {
                    AffichageAbo.Items.Add(a);
                }
            }
            else if (filtre.Equals("genre"))
            {
                var recherche = from t in Utils.Connexion.ALBUMS
                                join g in Utils.Connexion.GENRES on t.CODE_GENRE equals g.CODE_GENRE
                                where g.LIBELLÉ_GENRE.Contains(objet)
                                select t.TITRE_ALBUM;

                foreach (string a in recherche)
                {
                    AffichageAbo.Items.Add(a);
                }
            }

        }

        private void userView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.recherche();
            }
        }

    }
}
