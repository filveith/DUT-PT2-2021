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
            Task.Factory.StartNew(() => CachedElements.RefreshCache());
        }

        private void DebugWindow_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string s = (string)comboBox1.Text;
            listBox1.Items.Clear();
            switch (s)
            {
                case "US2":
                    foreach (EMPRUNTER em in Utils.GetABONNÉ(65).ConsulterEmprunts().Keys)
                    {
                        listBox1.Items.Add(em);
                    }
                    break;
                case "US3":

                    listBox1.Items.Add(Utils.GetABONNÉ(71).ProlongerEmprunt(Utils.GetALBUM(377)));
                    break;
                case "US4":
                    foreach (var v in Utils.AvoirLesEmpruntProlonger())
                    {
                        listBox1.Items.Add(v);
                    }
                    break;
                case "US5":
                    foreach (var v in Utils.AvoirAbonneAvecEmpruntRetardDe10Jours())
                    {
                        listBox1.Items.Add(v);
                    }
                    break;
                case "US6":
                    foreach (var v in Utils.SupprimerAbosPasEmpruntDepuisUnAn().GetAwaiter().GetResult())
                    {
                        listBox1.Items.Add(v);
                    }
                    break;
                case "US7":
                    Utils.AvoirTopAlbum().ForEach(v => listBox1.Items.Add(v));
                    break;
                case "US8":
                    foreach (var v in CachedElements.albumsPasEmpruntes)
                    {
                        listBox1.Items.Add(v);
                    }
                    break;
                case "US9":
                    Utils.GetABONNÉ(65).ProlongerTousEmprunts().GetAwaiter().GetResult().ForEach(v => listBox1.Items.Add(v));
                    break;
                case "US10":
                    foreach (ALBUMS al in CachedElements.suggestionsParAbo[Utils.GetABONNÉ(65)])
                    {
                        listBox1.Items.Add(al);
                    }
                    Task.Factory.StartNew(() => CachedElements.RefreshSuggestions(Utils.GetABONNÉ(65)));
                    break;
                default:
                    if (s != null && s.Count() > 0)
                    {
                        string[] strings = s.Split(' ');
                        if (strings.Count() > 1 && strings[0] == "test")
                        {
                            flowLayoutPanel1.Controls.Clear();
                            int.TryParse(strings[1], out int id);
                            ALBUMS a = Utils.GetALBUM(id);
                            if (a != null)
                            {
                                Image test = a.getPochette();
                                flowLayoutPanel1.Controls.Add(new Label { Image = test, Size = test.Size });
                            }
                        }
                        break;
                    }
                    break;

            }
        }
    }
}
