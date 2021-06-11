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
    public partial class EmpruntInfo : Form
    {
        public EmpruntInfo(EMPRUNTER e)
        {
            InitializeComponent();
            dateEmprunt.Text = e.DATE_EMPRUNT.ToString();
            dateRetour.Text = e.DATE_RETOUR_ATTENDUE.ToString();
            if(e.DATE_RETOUR == null)
            {
                yesNo.ForeColor = Color.Red;
                yesNo.Text = "NON";
            }
            else
            {
                yesNo.ForeColor = Color.Green;
                yesNo.Text = "OUI";
            }
            
        }
    }
}
