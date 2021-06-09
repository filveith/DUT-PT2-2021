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
        PagedListbox AffichageAbo;
        public UserView(ABONNÉS a)
        {
            InitializeComponent();
            Abo = a;
            Task.Run(() => CachedElements.RefreshSuggestions(a));
            AffichageAbo = new PagedListbox(TAffichageAbo);
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
            CachedElements.suggestionsParAbo.TryGetValue(Abo, out sugg);
            if (sugg != null && sugg.Count > 0)
            {
                AffichageAbo.AddItem("Voici des albums qui devraient vous plairent : ");
                foreach (ALBUMS s in sugg)
                {
                    AffichageAbo.AddItem(s);
                }
            }
            else
            {
                AffichageAbo.AddItem("Pas de suggestions");
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
                               select t.TITRE_ALBUM;

                foreach (string a in recherce)
                {
                    AffichageAbo.AddItem(a);
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
                    AffichageAbo.AddItem(a);
                }
            }
            else
            {
                this.suggestions();
            }

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
            bool dejaEmprunte = false;
            int codeAlbumAEmprunté = alb.CODE_ALBUM;

            var mesEmprunts = from e in Utils.Connexion.EMPRUNTER
                              join a in Utils.Connexion.ABONNÉS on e.CODE_ABONNÉ equals a.CODE_ABONNÉ
                              where a.LOGIN_ABONNÉ == Abo.LOGIN_ABONNÉ
                              select e.CODE_ALBUM;

            foreach (int code in mesEmprunts)
            {
                if (code == codeAlbumAEmprunté)
                {
                    dejaEmprunte = true;
                }
            }


            return dejaEmprunte;
        }

        private void suggest_Click(object sender, EventArgs e)
        {
            this.suggestions();
        }
    }
}
