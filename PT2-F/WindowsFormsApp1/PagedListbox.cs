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
        private ListBox page;
        private int ItemsPerPage;
        public int CurrentPage { get; private set; } = 0;
        private List<object> allItems = new List<object>();
        private bool currentPageHandled = false;
        public bool isOnLastPage { get; private set; } = false;

        public object SelectedItem => page.SelectedItem;

        public PagedListbox(ListBox page)
        {
            this.page = page;
            ItemsPerPage = Height / page.Font.Height;
            page.Dock = DockStyle.Fill;
            if (page.Parent != null)
            {
                Control parent = page.Parent;
                parent.Controls.Remove(page);
                parent.Controls.Add(this);
                this.Dock = page.Dock;

            }
            Controls.Add(page);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!currentPageHandled)
            {
                ResetItemsForCurrentPage();
                currentPageHandled = true;
            }
            base.OnPaint(e);
        }

        public void Clear()
        {
            allItems.Clear();
            ResetItemsForCurrentPage();
        }

        public void AddItem(object o)
        {
            allItems.Add(o);
            ResetItemsForCurrentPage();
        }

        public void RemoveItem(object o)
        {
            allItems.Remove(o);
            ResetItemsForCurrentPage();
        }

        public bool NextPage()
        {
            if (ItemsPerPage * (CurrentPage+1) < allItems.Count)
            {
                CurrentPage++;
                ResetItemsForCurrentPage();
                return true;
            }
            return false;
        }

        public bool PreviousPage()
        {
            if (CurrentPage - 1 >= 0)
            {
                CurrentPage--;
                ResetItemsForCurrentPage();

                return true;
            }
            return false;
        }

        private void ResetItemsForCurrentPage()
        {
            page.Items.Clear();
            int ItemsBeforePage = ItemsPerPage * CurrentPage;
            for (int i = ItemsBeforePage; (i - ItemsBeforePage) < ItemsPerPage; i++)
            {
                if (i < allItems.Count && i >= 0)
                {
                    page.Items.Add(allItems[i]);
                }
            }
            isOnLastPage = ItemsBeforePage + ItemsPerPage >= allItems.Count;

        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            ItemsPerPage = page.Height / page.Font.Height;
            ResetItemsForCurrentPage();
            if (allItems.Count > 0)
            {
                int ItemsInAllPages = ItemsPerPage * CurrentPage + ItemsPerPage;
                if (ItemsInAllPages >= allItems.Count)
                {
                    CurrentPage = ((allItems.Count - ItemsPerPage) / ItemsPerPage)+1;
                }
            }
        }
    }
}
