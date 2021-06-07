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
            listBox1.Items.Clear();
            switch (s)
            {
                case "US2":
                    foreach(EMPRUNTER em in Utils.ConsulterEmprunts(64).Keys)
                    {
                        listBox1.Items.Add(em);
                    }
                    break;
                case "US3":
                    
                    listBox1.Items.Add(Utils.ProlongerEmprunt(71, 377));
                    break;
                case "US4":
                    Utils.AvoirLesEmpruntProlonger().ForEach(v => listBox1.Items.Add(v));
                    break;
                case "US5":
                    Utils.AvoirAbonneAvecEmpruntRetardDe10Jours().ForEach(v => listBox1.Items.Add(v));
                    break;
                case "US6":
                    Utils.SupprimerAbosPasEmpruntDepuisUnAn().ForEach(v => listBox1.Items.Add(v));
                    break;
                case "US7":
                    Utils.AvoirTopAlbum().ForEach(v => listBox1.Items.Add(v));
                    break;
                case "US8":
                    Utils.AvoirAlbumsPasEmprunteDepuisUnAn().ForEach(v => listBox1.Items.Add(v));
                    break;
                case "US9":
                    Utils.ProlongerTousEmprunts(65).ForEach(v => listBox1.Items.Add(v));
                    break;
                case "US10":
                    foreach(ALBUMS al in Utils.AvoirSuggestions(64))
                    {
                        listBox1.Items.Add(al);
                    }
                    break;

            }
        }
    }
}
