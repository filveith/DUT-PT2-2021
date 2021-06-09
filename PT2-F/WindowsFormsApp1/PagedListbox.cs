﻿using System;
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
        public int CurrentPage { get; set; } = 0;
        private List<object> allItems = new List<object>();
        private bool currentPageHandled = false;

        public object SelectedItem => page.SelectedItem;

        public PagedListbox(ListBox page)
        {
            this.page = page;
            ItemsPerPage = Height / page.Font.Height;
            page.Dock = DockStyle.Fill;
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

        public void AddItem(object o)
        {
            allItems.Add(o);
        }

        public bool NextPage()
        {
            if (ItemsPerPage * CurrentPage < allItems.Count)
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
                if (i < allItems.Count)
                {
                    page.Items.Add(allItems[i]);
                }
            }

        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            ItemsPerPage = Height / page.Font.Height;
            currentPageHandled = false;
        }
    }
}
