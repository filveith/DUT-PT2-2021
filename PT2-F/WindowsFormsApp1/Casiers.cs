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
    public partial class Casiers : Form
    {
        int numCasier = 1;
        public Casiers()
        {
            InitializeComponent();
        }
        private  List<ALBUMS> avoirAlbumsSelonCasier(int numéroDeCasier)
        {
            List<ALBUMS> albumsManquantsParCasier = (from alb in Utils.Connexion.ALBUMS
                                                    join emp in Utils.Connexion.EMPRUNTER on alb.CODE_ALBUM equals emp.CODE_ALBUM
                                                    where alb.CASIER_ALBUM == numéroDeCasier && emp.DATE_EMPRUNT != null
                                                    select alb).ToList();
                                                    
                                                    


            return albumsManquantsParCasier;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numCasier = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numCasier = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numCasier = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numCasier = 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numCasier = 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            numCasier = 6;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            numCasier = 7;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            numCasier = 8;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            numCasier = 9;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            numCasier = 10;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            numCasier = 11;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            numCasier = 12;
        }

        
    }

        
    }
