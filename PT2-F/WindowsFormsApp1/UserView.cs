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
        public UserView()
        {
            InitializeComponent();
        }

        private void mesAlbums_Click(object sender, EventArgs e)
        {

            AffichageAbo.Items.Clear();
            List<EMPRUNTER> mesAlbums = Utils.ConsulterEmprunts(login);

            foreach(EMPRUNTER albums in mesAlbums)
            {
                AffichageAbo.Items.Add( "Voici vos albums empruntés : "+ albums.CODE_ALBUM);
            }

        }

        private void prolongerEmprunt_Click(object sender, EventArgs e)
        {
            AffichageAbo.Items.Clear();
            Utils.prolongerEmprunt (codeAbonne, codeAlbumSelected);
         
        }

        private void prolongerToutEmprunt_Click(object sender, EventArgs e)
        {
            AffichageAbo.Items.Clear();
            Utils.prolongerTousEmprunts(codeAbonne);
        }

        private void suggestions_Click(object sender, EventArgs e)
        {
            AffichageAbo.Items.Clear();
            HashSet<ALBUMS> sugg = Utils.suggest(codeAbonne);
            foreach (ALBUMS s in sugg)
                {
                    AffichageAbo.Items.Add("Voici des albums qui devraient vous plairent : " + s.TITRE_ALBUM);
                }
            }
    }
}
