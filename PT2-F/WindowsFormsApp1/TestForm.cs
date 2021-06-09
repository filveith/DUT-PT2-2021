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
            pagedListbox = new PagedListbox(new ListBox()) { Parent = this, Dock = DockStyle.Fill };
            tableLayoutPanel1.Controls.Add(pagedListbox);
            for(int i = 0; i<1000; i++)
            {
                pagedListbox.Add(i);
            }
            button1.Visible = !pagedListbox.isOnLastPage;
            button2.Visible = pagedListbox.CurrentPage > 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pagedListbox.NextPage();
            button1.Visible = !pagedListbox.isOnLastPage;
            button2.Visible = pagedListbox.CurrentPage > 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pagedListbox.PreviousPage();
            button1.Visible = !pagedListbox.isOnLastPage;
            button2.Visible = pagedListbox.CurrentPage > 0;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            button1.Visible = pagedListbox?.isOnLastPage == false;
            button2.Visible = pagedListbox?.CurrentPage > 0;
        }
    }
}
