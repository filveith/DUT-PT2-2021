﻿using System;
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

        /// <summary>
        /// Lorsque le texte de la box change, teste, l'US correspondante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    var liste = Utils.SupprimerAbosPasEmpruntDepuisUnAn();
                    foreach (var v in liste)
                    {
                        listBox1.Items.Add(v);
                    }
                    break;
                case "US7":
                    Utils.AvoirTopAlbum().ForEach(v => listBox1.Items.Add(v));
                    break;
                case "US8":
                    foreach (var v in Utils.AvoirAlbumsPasEmprunteDepuisUnAn())
                    {
                        listBox1.Items.Add(v);
                    }
                    break;
                case "US9":
                    Utils.GetABONNÉ(65).ProlongerTousEmprunts().ForEach(v => listBox1.Items.Add(v));
                    break;
                case "US10":
                    foreach (ALBUMS al in Utils.GetABONNÉ(65).AvoirSuggestions())
                    {
                        listBox1.Items.Add(al);
                    }
                    break;
                case "US16":
                    Utils.GetABONNÉ(2381).ChangePassword("admin");
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
