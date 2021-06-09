
namespace WindowsFormsApp1
{
    partial class UserView2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AffichageAbo = new System.Windows.Forms.ListBox();
            this.MenuPrincipal = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.aboLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.prolongerAllEmpruntButton = new System.Windows.Forms.Button();
            this.prolongerEmpruntButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Silver;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.AffichageAbo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.MenuPrincipal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.47954F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.52046F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1260, 537);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // AffichageAbo
            // 
            this.AffichageAbo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AffichageAbo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AffichageAbo.Font = new System.Drawing.Font("Miriam CLM", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.AffichageAbo.FormattingEnabled = true;
            this.AffichageAbo.HorizontalScrollbar = true;
            this.AffichageAbo.ItemHeight = 21;
            this.AffichageAbo.Location = new System.Drawing.Point(3, 204);
            this.AffichageAbo.Margin = new System.Windows.Forms.Padding(3, 3, 20, 20);
            this.AffichageAbo.Name = "AffichageAbo";
            this.AffichageAbo.Size = new System.Drawing.Size(859, 294);
            this.AffichageAbo.TabIndex = 3;
            // 
            // MenuPrincipal
            // 
            this.MenuPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuPrincipal.BackColor = System.Drawing.Color.Black;
            this.MenuPrincipal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuPrincipal.FlatAppearance.BorderSize = 0;
            this.MenuPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuPrincipal.Font = new System.Drawing.Font("Miriam Libre", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuPrincipal.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MenuPrincipal.Location = new System.Drawing.Point(1045, 50);
            this.MenuPrincipal.Margin = new System.Windows.Forms.Padding(3, 50, 30, 3);
            this.MenuPrincipal.Name = "MenuPrincipal";
            this.MenuPrincipal.Size = new System.Drawing.Size(185, 83);
            this.MenuPrincipal.TabIndex = 1;
            this.MenuPrincipal.Text = "Menu principal";
            this.MenuPrincipal.UseVisualStyleBackColor = false;
            this.MenuPrincipal.Click += new System.EventHandler(this.mesAlbums_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(876, 195);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.Controls.Add(this.aboLabel, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(870, 111);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // aboLabel
            // 
            this.aboLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.aboLabel.AutoSize = true;
            this.aboLabel.Font = new System.Drawing.Font("Miriam Libre", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboLabel.Location = new System.Drawing.Point(401, 13);
            this.aboLabel.Name = "aboLabel";
            this.aboLabel.Size = new System.Drawing.Size(416, 84);
            this.aboLabel.TabIndex = 0;
            this.aboLabel.Text = "Mes Albums";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel4.Controls.Add(this.searchTextBox, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 120);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(870, 72);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTextBox.Font = new System.Drawing.Font("Miriam Libre", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.Location = new System.Drawing.Point(3, 18);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(451, 36);
            this.searchTextBox.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.Controls.Add(this.prolongerAllEmpruntButton, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.prolongerEmpruntButton, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(885, 204);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(372, 330);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // prolongerAllEmpruntButton
            // 
            this.prolongerAllEmpruntButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prolongerAllEmpruntButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.prolongerAllEmpruntButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prolongerAllEmpruntButton.FlatAppearance.BorderSize = 0;
            this.prolongerAllEmpruntButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prolongerAllEmpruntButton.Font = new System.Drawing.Font("Miriam Libre", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prolongerAllEmpruntButton.ForeColor = System.Drawing.Color.Black;
            this.prolongerAllEmpruntButton.Location = new System.Drawing.Point(45, 215);
            this.prolongerAllEmpruntButton.Margin = new System.Windows.Forms.Padding(3, 50, 30, 3);
            this.prolongerAllEmpruntButton.Name = "prolongerAllEmpruntButton";
            this.prolongerAllEmpruntButton.Size = new System.Drawing.Size(185, 83);
            this.prolongerAllEmpruntButton.TabIndex = 3;
            this.prolongerAllEmpruntButton.Text = "prolonger tout les emprunts";
            this.prolongerAllEmpruntButton.UseVisualStyleBackColor = false;
            this.prolongerAllEmpruntButton.Click += new System.EventHandler(this.prolongerToutEmprunt_Click);
            // 
            // prolongerEmpruntButton
            // 
            this.prolongerEmpruntButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prolongerEmpruntButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.prolongerEmpruntButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prolongerEmpruntButton.FlatAppearance.BorderSize = 0;
            this.prolongerEmpruntButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prolongerEmpruntButton.Font = new System.Drawing.Font("Miriam Libre", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prolongerEmpruntButton.ForeColor = System.Drawing.Color.Black;
            this.prolongerEmpruntButton.Location = new System.Drawing.Point(45, 50);
            this.prolongerEmpruntButton.Margin = new System.Windows.Forms.Padding(3, 50, 30, 3);
            this.prolongerEmpruntButton.Name = "prolongerEmpruntButton";
            this.prolongerEmpruntButton.Size = new System.Drawing.Size(185, 83);
            this.prolongerEmpruntButton.TabIndex = 2;
            this.prolongerEmpruntButton.Text = "prolonger un emprunt";
            this.prolongerEmpruntButton.UseVisualStyleBackColor = false;
            this.prolongerEmpruntButton.Click += new System.EventHandler(this.prolongerEmprunt_Click);
            // 
            // UserView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1284, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(1400, 700);
            this.MinimumSize = new System.Drawing.Size(1300, 600);
            this.Name = "UserView2";
            this.Text = "UserView2";
            this.Load += new System.EventHandler(this.UserView2_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox AffichageAbo;
        private System.Windows.Forms.Button MenuPrincipal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label aboLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button prolongerAllEmpruntButton;
        private System.Windows.Forms.Button prolongerEmpruntButton;
    }
}
