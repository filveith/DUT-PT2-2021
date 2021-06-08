using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class PagedListbox : Panel
    {
        private List<ListBox> listBoxes = new List<ListBox>();
        public int CurrentPage { get; set; } = 0;

        private List<object> allItems = new List<object>();

        protected override void OnPaint(PaintEventArgs e)
        {
            listBoxes[CurrentPage].BringToFront();
            base.OnPaint(e);
        }

        public void AddItem(object o)
        {
            AddItem(o, true);
        }

        private void AddItem(object o, bool addToList)
        {
            int p = 0;
            while (p < listBoxes.Count)
            {
                if ((listBoxes[p].Items.Count + 1) * listBoxes[p].Font.Height <= listBoxes[p].Height)
                {
                    listBoxes[p].Items.Add(o);
                    if (addToList)
                    {
                        allItems.Add(o);
                    }
                    break;
                }
                else
                {
                    p++;
                }
            }
        }

        public void AddListBox(ListBox l)
        {
            l.Dock = DockStyle.Fill;
            Controls.Add(l);
            listBoxes.Add(l);
        }

        public void RemoveListBox(ListBox l)
        {
            Controls.Remove(l);
            listBoxes.Remove(l);
        }

        public void NextPage()
        {
            if (CurrentPage + 1 <= listBoxes.Count - 1)
            {
                listBoxes[CurrentPage].SendToBack();
                CurrentPage++;
            }
        }

        public void PreviousPage()
        {
            if (CurrentPage - 1 >= 0)
            {
                listBoxes[CurrentPage].SendToBack();
                CurrentPage--;
            }
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            foreach (var l in listBoxes)
            {
                l.Items.Clear();
            }
            allItems.ForEach(o => AddItem(o, false));
        }
    }
}
