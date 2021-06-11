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
    public partial class AlbumInfo : Form
    {
        public AlbumInfo(ALBUMS a)
        {
            InitializeComponent();
            formattedEditeur.Text = a.EDITEURS.ToString();
            casierNumber.Text = a.CASIER_ALBUM.ToString();
            annee.Text = a.ANNÉE_ALBUM != null ? a.ANNÉE_ALBUM.ToString() : "Aucune année d'édition trouvée";
            rangeeLetter.Text = a.ALLÉE_ALBUM;
            genre.Text = a.GENRES.LIBELLÉ_GENRE.Trim();
            prix.Text = a.PRIX_ALBUM.ToString();
        }
    }
}
