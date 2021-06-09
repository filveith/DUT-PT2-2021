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


        public UserView2(ABONNÉS a)
        {
            InitializeComponent();
        }

        private void UserView2_Load(object sender, EventArgs e)
        {
            AffichageAbo.Items.Clear();
            Dictionary<EMPRUNTER, ALBUMS> emprunts = UserView.Abo.ConsulterEmprunts();
            if (emprunts.Count > 0)
            {
                foreach (KeyValuePair<EMPRUNTER, ALBUMS> emprunt in emprunts)
                {
                    AffichageAbo.Items.Add(emprunt.Value.ToString() + " | emprunté le     " + emprunt.Key.DATE_EMPRUNT + " | à rendre le " + emprunt.Key.DATE_RETOUR_ATTENDUE);
                }
            }
        }

        private void mesAlbums_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void prolongerEmprunt_Click(object sender, EventArgs e)
        {
            int position = AffichageAbo.SelectedItem.ToString().IndexOf("|");
            string titreAlbum = AffichageAbo.SelectedItem.ToString().Substring(0, position - 1);

            ALBUMS obtAlbum = (from a in Utils.Connexion.ALBUMS
                               where a.TITRE_ALBUM.ToString() == titreAlbum
                               select a).FirstOrDefault();

            if (obtAlbum is ALBUMS al)
            {
                AffichageAbo.Items.Remove(AffichageAbo.SelectedItem);
                UserView.Abo.ProlongerEmprunt(Utils.GetALBUM(al.CODE_ALBUM)).GetAwaiter().GetResult();
                ConnexionView.Pop("Emprunt prolongé de 1 mois !", "Attention");
            }
            else
            {
                ConnexionView.Pop("ce n'est pas un album", "Erreur");
            }

        }

        private void prolongerToutEmprunt_Click(object sender, EventArgs e)
        {
            AffichageAbo.Items.Clear();
            UserView.Abo.ProlongerTousEmprunts().GetAwaiter().GetResult();
            ConnexionView.Pop("Tous vos emprunts ont bien étés prolongés !", "Attention");
        }



    }
}
