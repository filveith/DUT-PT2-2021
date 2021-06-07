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
    public partial class DebugWindow : Form
    {
        public DebugWindow()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = (string)comboBox1.SelectedItem;
            switch (s)
            {
                case "US2":
                    Utils.ConsulterEmprunts(8);
                    break;
                case "US3":
                    Utils.ProlongerEmprunt(8, 1);
                    break;
                case "US4":
                    Utils.AvoirLesEmpruntProlonger();
                    break;
                case "US5":
                    Utils.AvoirAbonneAvecEmpruntRetardDe10Jours();
                    break;
                case "US6":
                    Utils.SupprimerAbosPasEmpruntDepuisUnAn();
                    break;
                case "US7":
                    Utils.AvoirTopAlbum();
                    break;
                case "US8":
                    Utils.AvoirAlbumsPasEmprunteDepuisUnAn();
                    break;
                case "US9":
                    Utils.ProlongerTousEmprunts(8);
                    break;
                case "US10":
                    Utils.AvoirSuggestions(8);
                    break;

            }
        }
    }
}
