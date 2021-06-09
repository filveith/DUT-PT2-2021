
namespace WindowsFormsApp1
{
    partial class UserView
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.aboLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.filtres = new System.Windows.Forms.ComboBox();
            this.TAffichageAbo = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.mesAlbums = new System.Windows.Forms.Button();
            this.suggest = new System.Windows.Forms.Button();
            this.emprunter = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TAffichageAbo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.mesAlbums, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.47954F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.52046F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1260, 537);
            this.tableLayoutPanel1.TabIndex = 2;
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
            this.aboLabel.BackColor = System.Drawing.Color.Transparent;
            this.aboLabel.Font = new System.Drawing.Font("NSimSun", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(48)))), ((int)(((byte)(15)))));
            this.aboLabel.Location = new System.Drawing.Point(387, 23);
            this.aboLabel.Name = "aboLabel";
            this.aboLabel.Size = new System.Drawing.Size(444, 64);
            this.aboLabel.TabIndex = 0;
            this.aboLabel.Text = "Espace Abonné";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel4.Controls.Add(this.searchBox, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.filtres, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 120);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(870, 72);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // searchBox
            // 
            this.searchBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchBox.Font = new System.Drawing.Font("NSimSun", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(48)))), ((int)(((byte)(15)))));
            this.searchBox.Location = new System.Drawing.Point(3, 20);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(451, 31);
            this.searchBox.TabIndex = 1;
            this.searchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.userView_KeyPress);
            // 
            // filtres
            // 
            this.filtres.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.filtres.Font = new System.Drawing.Font("NSimSun", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(48)))), ((int)(((byte)(15)))));
            this.filtres.FormattingEnabled = true;
            this.filtres.Location = new System.Drawing.Point(525, 25);
            this.filtres.Name = "filtres";
            this.filtres.Size = new System.Drawing.Size(154, 21);
            this.filtres.TabIndex = 2;
            this.filtres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.userView_KeyPress);
            // 
            // TAffichageAbo
            // 
            this.TAffichageAbo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TAffichageAbo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TAffichageAbo.Font = new System.Drawing.Font("NSimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAffichageAbo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(48)))), ((int)(((byte)(15)))));
            this.TAffichageAbo.FormattingEnabled = true;
            this.TAffichageAbo.ItemHeight = 19;
            this.TAffichageAbo.Location = new System.Drawing.Point(3, 204);
            this.TAffichageAbo.Margin = new System.Windows.Forms.Padding(3, 3, 20, 20);
            this.TAffichageAbo.Name = "TAffichageAbo";
            this.TAffichageAbo.Size = new System.Drawing.Size(859, 304);
            this.TAffichageAbo.TabIndex = 3;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.suggest, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.emprunter, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(885, 204);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(372, 330);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // mesAlbums
            // 
            this.mesAlbums.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mesAlbums.BackColor = System.Drawing.Color.Transparent;
            this.mesAlbums.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.buttonAlbums;
            this.mesAlbums.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mesAlbums.FlatAppearance.BorderSize = 0;
            this.mesAlbums.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mesAlbums.Font = new System.Drawing.Font("NSimSun", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesAlbums.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.mesAlbums.Location = new System.Drawing.Point(1018, 50);
            this.mesAlbums.Margin = new System.Windows.Forms.Padding(3, 50, 30, 3);
            this.mesAlbums.Name = "mesAlbums";
            this.mesAlbums.Size = new System.Drawing.Size(212, 83);
            this.mesAlbums.TabIndex = 1;
            this.mesAlbums.UseVisualStyleBackColor = false;
            this.mesAlbums.Click += new System.EventHandler(this.mesAlbums_Click);
            // 
            // suggest
            // 
            this.suggest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.suggest.BackColor = System.Drawing.Color.Transparent;
            this.suggest.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.buttonSuggestions;
            this.suggest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.suggest.FlatAppearance.BorderSize = 0;
            this.suggest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suggest.Font = new System.Drawing.Font("NSimSun", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suggest.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.suggest.Location = new System.Drawing.Point(60, 217);
            this.suggest.Margin = new System.Windows.Forms.Padding(0);
            this.suggest.Name = "suggest";
            this.suggest.Size = new System.Drawing.Size(252, 60);
            this.suggest.TabIndex = 6;
            this.suggest.UseVisualStyleBackColor = false;
            this.suggest.Click += new System.EventHandler(this.suggest_Click);
            // 
            // emprunter
            // 
            this.emprunter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.emprunter.BackColor = System.Drawing.Color.Transparent;
            this.emprunter.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.buttonEmprunté;
            this.emprunter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.emprunter.FlatAppearance.BorderSize = 0;
            this.emprunter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emprunter.Font = new System.Drawing.Font("NSimSun", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emprunter.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.emprunter.Location = new System.Drawing.Point(93, 41);
            this.emprunter.Margin = new System.Windows.Forms.Padding(0);
            this.emprunter.Name = "emprunter";
            this.emprunter.Size = new System.Drawing.Size(185, 83);
            this.emprunter.TabIndex = 5;
            this.emprunter.UseVisualStyleBackColor = false;
            this.emprunter.Click += new System.EventHandler(this.emprunter_Click);
            // 
            // UserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1284, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(1400, 700);
            this.MinimumSize = new System.Drawing.Size(1300, 600);
            this.Name = "UserView";
            this.Text = "UserView";
            this.Load += new System.EventHandler(this.UserView_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.userView_KeyPress);
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
        private System.Windows.Forms.Button mesAlbums;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label aboLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ListBox TAffichageAbo;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ComboBox filtres;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button suggest;
        private System.Windows.Forms.Button emprunter;
    }
}
