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
        private ABONNÉS Abo;

        public UserView(ABONNÉS a)
        {
            InitializeComponent();
            Abo = a;
        }

        private void mesAlbums_Click(object sender, EventArgs e)
        {

            AffichageAbo.Items.Clear();
            var mesEmprunts = Abo.ConsulterEmprunts().Keys;

            foreach (EMPRUNTER emprunt in mesEmprunts)
            {
                AffichageAbo.Items.Add(emprunt);
            }

        }

        private void prolongerEmprunt_Click(object sender, EventArgs e)
        {
            if (AffichageAbo.SelectedItem is ALBUMS al)
            {
                Abo.ProlongerEmprunt(Utils.GetALBUM(al.CODE_ALBUM));
            }

        }

        private void prolongerToutEmprunt_Click(object sender, EventArgs e)
        {
            AffichageAbo.Items.Clear();
            Abo.ProlongerTousEmprunts();
        }

        private void suggestions_Click(object sender, EventArgs e)
        {
            AffichageAbo.Items.Clear();
            HashSet<ALBUMS> sugg = Abo.AvoirSuggestions();
            if (sugg.Count > 0)
            {
                foreach (ALBUMS s in sugg)
                {
                    AffichageAbo.Items.Add("Voici des albums qui devraient vous plairent : " + s.TITRE_ALBUM.Trim());
                }
            }
            else
            {
                AffichageAbo.Items.Add("Vous n'avez rien emprunté...");
            }
        }
    }
}
