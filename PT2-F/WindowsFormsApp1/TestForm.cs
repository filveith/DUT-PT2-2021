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
    public partial class TestForm : Form
    {
        private PagedListbox pagedListbox;
        public TestForm()
        {
            InitializeComponent();
            pagedListbox = new PagedListbox { Parent = this, Dock = DockStyle.Fill };
            for(int i = 0; i<20; i++)
            {
                pagedListbox.AddListBox(new ListBox());
            }
            tableLayoutPanel1.Controls.Add(pagedListbox);
            for(int i = 0; i<1000; i++)
            {
                pagedListbox.AddItem(i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pagedListbox.NextPage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pagedListbox.PreviousPage();
        }
    }
}
