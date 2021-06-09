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
        private Dictionary<ListBox, int> listBoxesWithItemsPerPage = new Dictionary<ListBox, int>();
        private List<ListBox> listBoxes = new List<ListBox>();
        public int CurrentPage { get; set; } = 0;
        private List<object> allItems = new List<object>();
        private bool currentPageHandled = false;

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!currentPageHandled)
            {
                ResetItemsForCurrentPage();
                currentPageHandled = true;
            }
            base.OnPaint(e);
        }

        public void AddItem(object o)
        {
            allItems.Add(o);
        }

        public void AddListBox(ListBox l)
        {
            l.Dock = DockStyle.Fill;
            Controls.Add(l);
            listBoxesWithItemsPerPage.Add(l, Height / l.Font.Height);
            listBoxes.Add(l);
            l.Visible = listBoxes.Count == 1;
        }

        public void RemoveListBox(ListBox l)
        {
            Controls.Remove(l);
            if (listBoxes[CurrentPage] == l)
            {
                if (!NextPage())
                {
                    PreviousPage();
                }
                currentPageHandled = false;
            }
            listBoxes.Remove(l);
            listBoxesWithItemsPerPage.Remove(l);
        }

        public bool NextPage()
        {
            if (CurrentPage + 1 <= listBoxes.Count - 1)
            {
                listBoxes[CurrentPage].Visible = false;
                CurrentPage++;
                listBoxes[CurrentPage].Visible = true;
                ResetItemsForCurrentPage();
                return true;
            }
            return false;
        }

        private void ResetItemsForCurrentPage()
        {
            if (CurrentPage < listBoxes.Count() && CurrentPage >= 0)
            {
                listBoxes[CurrentPage].Items.Clear();
                int ItemsBeforePage = NumberOfItemsBeforePage(CurrentPage);
                for (int i = ItemsBeforePage; (i - ItemsBeforePage) < listBoxesWithItemsPerPage[listBoxes[CurrentPage]]; i++)
                {
                    if (i < allItems.Count)
                    {
                        listBoxes[CurrentPage].Items.Add(allItems[i]);
                    }
                }
            }
        }

        public bool PreviousPage()
        {
            if (CurrentPage - 1 >= 0)
            {
                listBoxes[CurrentPage].Visible = false;
                CurrentPage--;
                listBoxes[CurrentPage].Visible = true;
                ResetItemsForCurrentPage();

                return true;
            }
            return false;
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            foreach (var v in listBoxes)
            {
                listBoxesWithItemsPerPage[v] = Height / v.Font.Height;
            }
            currentPageHandled = false;
        }

        private int NumberOfItemsBeforePage(int pageNumber)
        {
            int sum = 0;
            for (int i = 0; i < pageNumber; i++)
            {
                sum += listBoxesWithItemsPerPage[listBoxes[i]];
            }
            return sum;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            ResetItemsForCurrentPage();
        }
    }
}
