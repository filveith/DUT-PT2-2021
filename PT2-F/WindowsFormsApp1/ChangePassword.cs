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
    public partial class ChangePassword : Form
    {
        public ChangePassword(ABONNÉS a)
        {
            InitializeComponent();
            radioButton1.Image = Utils.ResizeImage(radioButton1.Image, radioButton1.Width, radioButton1.Height);
        }
    }
}
