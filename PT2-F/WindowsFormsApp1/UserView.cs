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
        public List<Task> currentSugg { get; private set; } = new List<Task>();
        public static ABONNÉS Abo;
        public UserView2 u2;
        PagedListbox AffichageAbo;
        public UserView(ABONNÉS a)
        {
            InitializeComponent();
            Abo = a;
            Task.Run(() => CachedElements.RefreshSuggestions(a));
            AffichageAbo = new PagedListbox(TAffichageAbo);
            nextPage.Visible = AffichageAbo?.isOnLastPage == false;
            previousPage.Visible = AffichageAbo?.CurrentPage > 0;
            u2 = new UserView2(this);
        }

        private void UserView_Load(object sender, EventArgs e)
        {
            filtres.Items.Clear();
            filtres.Items.Add("genre");
            filtres.Items.Add("titre");

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
            AffichageAbo.Clear();
            HashSet<ALBUMS> sugg;
            sugg = Abo.AvoirSuggestions();
            if (sugg != null && sugg.Count > 0)
            {
                AffichageAbo.Add("Voici des albums qui devraient vous plairent : ");
                AffichageAbo.AddRange(sugg);
                nextPage.Visible = AffichageAbo?.isOnLastPage == false;
                previousPage.Visible = AffichageAbo?.CurrentPage > 0;
            }
            else
            {
                AffichageAbo.Add("Pas de suggestions");
            }
        }

        private void recherche()
        {
            string filtre = filtres.Text;
            string objet = searchBox.Text;
            AffichageAbo.Clear();
            if (filtre.Equals("titre"))
            {
                var recherce = from t in Utils.Connexion.ALBUMS
                               where t.TITRE_ALBUM.Contains(objet)
                               select t;

                foreach (var a in recherce)
                {
                    AffichageAbo.Add(a);
                }
            }
            else if (filtre.Equals("genre"))
            {
                var recherche = from t in Utils.Connexion.ALBUMS
                                join g in Utils.Connexion.GENRES on t.CODE_GENRE equals g.CODE_GENRE
                                where g.LIBELLÉ_GENRE.Contains(objet)
                                select t;

                foreach (var a in recherche)
                {
                    AffichageAbo.Add(a);
                }
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
                this.recherche();
            }
        }

        private void emprunter_Click(object sender, EventArgs e)
        {
            if (AffichageAbo.SelectedItem is ALBUMS al)
            {
                if (!dejaEmprunté(al))
                {
                    Abo.Emprunter(al).GetAwaiter().GetResult();
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

        private static bool dejaEmprunté(ALBUMS alb)
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

        private void suggest_Click(object sender, EventArgs e)
        {
            this.suggestions();
        }

        private void nextPage_Click(object sender, EventArgs e)
        {
            AffichageAbo.NextPage();
            nextPage.Visible = AffichageAbo?.isOnLastPage == false;
            previousPage.Visible = AffichageAbo?.CurrentPage > 0;
        }

        private void previousPage_Click(object sender, EventArgs e)
        {
            AffichageAbo.PreviousPage();
            nextPage.Visible = AffichageAbo?.isOnLastPage == false;
            previousPage.Visible = AffichageAbo?.CurrentPage > 0;
        }
    }
}
