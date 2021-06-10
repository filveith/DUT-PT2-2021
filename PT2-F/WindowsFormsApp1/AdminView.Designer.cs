
namespace WindowsFormsApp1
{
    partial class AdminView
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
            this.buttons = new System.Windows.Forms.TableLayoutPanel();
            this.listEmpruntsProlongButton = new System.Windows.Forms.Button();
            this.listRetardButton = new System.Windows.Forms.Button();
            this.notEmprunterSinceAYear = new System.Windows.Forms.Button();
            this.top10Button = new System.Windows.Forms.Button();
            this.suppIdleUsersButton = new System.Windows.Forms.Button();
            this.listerAbonner = new System.Windows.Forms.Button();
            this.addAlbumButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.log = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.buttons.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.buttons, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 661F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(878, 657);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // buttons
            // 
            this.buttons.ColumnCount = 2;
            this.buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttons.Controls.Add(this.listEmpruntsProlongButton, 0, 0);
            this.buttons.Controls.Add(this.listRetardButton, 1, 0);
            this.buttons.Controls.Add(this.notEmprunterSinceAYear, 1, 1);
            this.buttons.Controls.Add(this.top10Button, 1, 2);
            this.buttons.Controls.Add(this.suppIdleUsersButton, 0, 3);
            this.buttons.Controls.Add(this.listEmpruntsProlongButton, 0, 2);
            this.buttons.Controls.Add(this.listRetardButton, 0, 1);
            this.buttons.Controls.Add(this.showLockersButton, 1, 0);
            this.buttons.Controls.Add(this.addAlbumButton, 0, 1);
            this.buttons.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttons.Location = new System.Drawing.Point(3, 3);
            this.buttons.Name = "buttons";
            this.buttons.RowCount = 4;
            this.buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttons.Size = new System.Drawing.Size(324, 655);
            this.buttons.TabIndex = 9;
            // 
            // listEmpruntsProlongButton
            // 
            this.listEmpruntsProlongButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listEmpruntsProlongButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(186)))), ((int)(((byte)(195)))));
            this.listEmpruntsProlongButton.FlatAppearance.BorderSize = 0;
            this.listEmpruntsProlongButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listEmpruntsProlongButton.Font = new System.Drawing.Font("Miriam Libre", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listEmpruntsProlongButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.listEmpruntsProlongButton.Location = new System.Drawing.Point(24, 73);
            this.listEmpruntsProlongButton.Name = "listEmpruntsProlongButton";
            this.listEmpruntsProlongButton.Size = new System.Drawing.Size(113, 100);
            this.listEmpruntsProlongButton.TabIndex = 1;
            this.listEmpruntsProlongButton.Text = "Lister Emprunts Prolongés";
            this.listEmpruntsProlongButton.UseVisualStyleBackColor = false;
            this.listEmpruntsProlongButton.Click += new System.EventHandler(this.listEmpruntsProlongButton_Click);
            // 
            // listRetardButton
            // 
            this.listRetardButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listRetardButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(186)))), ((int)(((byte)(195)))));
            this.listRetardButton.FlatAppearance.BorderSize = 0;
            this.listRetardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listRetardButton.Font = new System.Drawing.Font("Miriam Libre", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listRetardButton.ForeColor = System.Drawing.SystemColors.Control;
            this.listRetardButton.Location = new System.Drawing.Point(23, 193);
            this.listRetardButton.Name = "listRetardButton";
            this.listRetardButton.Size = new System.Drawing.Size(115, 102);
            this.listRetardButton.TabIndex = 2;
            this.listRetardButton.Text = "Lister Retards";
            this.listRetardButton.UseVisualStyleBackColor = false;
            this.listRetardButton.Click += new System.EventHandler(this.listRetardButton_Click);
            // 
            // notEmprunterSinceAYear
            // 
            this.notEmprunterSinceAYear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.notEmprunterSinceAYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(186)))), ((int)(((byte)(195)))));
            this.notEmprunterSinceAYear.FlatAppearance.BorderSize = 0;
            this.notEmprunterSinceAYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notEmprunterSinceAYear.Font = new System.Drawing.Font("Miriam Libre", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notEmprunterSinceAYear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.notEmprunterSinceAYear.Location = new System.Drawing.Point(183, 192);
            this.notEmprunterSinceAYear.Name = "notEmprunterSinceAYear";
            this.notEmprunterSinceAYear.Size = new System.Drawing.Size(120, 104);
            this.notEmprunterSinceAYear.TabIndex = 4;
            this.notEmprunterSinceAYear.Text = "Albums pas empruntés depuis 1 an";
            this.notEmprunterSinceAYear.UseVisualStyleBackColor = false;
            this.notEmprunterSinceAYear.Click += new System.EventHandler(this.notEmprunterSinceAYear_Click);
            // 
            // top10Button
            // 
            this.top10Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.top10Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(186)))), ((int)(((byte)(195)))));
            this.top10Button.FlatAppearance.BorderSize = 0;
            this.top10Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.top10Button.Font = new System.Drawing.Font("Miriam Libre", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.top10Button.ForeColor = System.Drawing.SystemColors.Control;
            this.top10Button.Location = new System.Drawing.Point(184, 357);
            this.top10Button.Name = "top10Button";
            this.top10Button.Size = new System.Drawing.Size(118, 101);
            this.top10Button.TabIndex = 6;
            this.top10Button.Text = "Top 10 Albums Empruntés";
            this.top10Button.UseVisualStyleBackColor = false;
            this.top10Button.Click += new System.EventHandler(this.top10Button_Click);
            // 
            // suppIdleUsersButton
            // 
            this.suppIdleUsersButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.suppIdleUsersButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(186)))), ((int)(((byte)(195)))));
            this.suppIdleUsersButton.FlatAppearance.BorderSize = 0;
            this.suppIdleUsersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suppIdleUsersButton.Font = new System.Drawing.Font("Miriam Libre", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppIdleUsersButton.ForeColor = System.Drawing.SystemColors.Control;
            this.suppIdleUsersButton.Location = new System.Drawing.Point(23, 524);
            this.suppIdleUsersButton.Name = "suppIdleUsersButton";
            this.suppIdleUsersButton.Size = new System.Drawing.Size(116, 95);
            this.suppIdleUsersButton.TabIndex = 7;
            this.suppIdleUsersButton.Text = "Supprimer Utilisateurs Inactifs";
            this.suppIdleUsersButton.UseVisualStyleBackColor = false;
            this.suppIdleUsersButton.Click += new System.EventHandler(this.suppIdleUsersButton_Click);
            // 
            // listerAbonner
            // 
            this.listerAbonner.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listerAbonner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(186)))), ((int)(((byte)(195)))));
            this.listerAbonner.FlatAppearance.BorderSize = 0;
            this.listerAbonner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listerAbonner.Font = new System.Drawing.Font("Miriam Libre", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listerAbonner.ForeColor = System.Drawing.SystemColors.Control;
            this.listerAbonner.Location = new System.Drawing.Point(185, 524);
            this.listerAbonner.Name = "listerAbonner";
            this.listerAbonner.Size = new System.Drawing.Size(115, 96);
            this.listerAbonner.TabIndex = 8;
            this.listerAbonner.Text = "Lister les abonnés";
            this.listerAbonner.UseVisualStyleBackColor = false;
            this.listerAbonner.Click += new System.EventHandler(this.listerAbonner_Click);
            // 
            // addAlbumButton
            // 
            this.addAlbumButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addAlbumButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(186)))), ((int)(((byte)(195)))));
            this.addAlbumButton.FlatAppearance.BorderSize = 0;
            this.addAlbumButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAlbumButton.Font = new System.Drawing.Font("Miriam Libre", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAlbumButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.addAlbumButton.Location = new System.Drawing.Point(23, 271);
            this.addAlbumButton.Name = "addAlbumButton";
            this.addAlbumButton.Size = new System.Drawing.Size(116, 102);
            this.addAlbumButton.TabIndex = 3;
            this.addAlbumButton.Text = "Ajouter Albums";
            this.addAlbumButton.UseVisualStyleBackColor = false;
            this.addAlbumButton.Click += new System.EventHandler(this.addAlbumButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.log, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(333, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.00188F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(542, 655);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // log
            // 
            this.log.BackColor = System.Drawing.SystemColors.Window;
            this.log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log.Font = new System.Drawing.Font("Miriam Libre", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log.FormattingEnabled = true;
            this.log.HorizontalScrollbar = true;
            this.log.ItemHeight = 21;
            this.log.Location = new System.Drawing.Point(3, 3);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(536, 485);
            this.log.TabIndex = 11;
            this.log.SelectedIndexChanged += new System.EventHandler(this.log_SelectedIndexChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.05224F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.94776F));
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 494);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(536, 158);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.previousPage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 152);
            this.panel1.TabIndex = 4;
            // 
            // previousPage
            // 
            this.previousPage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.previousPage.BackColor = System.Drawing.Color.Transparent;
            this.previousPage.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.buttonPagePrécédente;
            this.previousPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.previousPage.FlatAppearance.BorderSize = 0;
            this.previousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousPage.Font = new System.Drawing.Font("NSimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousPage.ForeColor = System.Drawing.SystemColors.Control;
            this.previousPage.Location = new System.Drawing.Point(-1, 44);
            this.previousPage.Name = "previousPage";
            this.previousPage.Size = new System.Drawing.Size(277, 64);
            this.previousPage.TabIndex = 5;
            this.previousPage.UseVisualStyleBackColor = false;
            this.previousPage.Click += new System.EventHandler(this.previousPage_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nextPage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(281, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 152);
            this.panel2.TabIndex = 5;
            // 
            // nextPage
            // 
            this.nextPage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nextPage.BackColor = System.Drawing.Color.Transparent;
            this.nextPage.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.buttonPageSuivante;
            this.nextPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.nextPage.FlatAppearance.BorderSize = 0;
            this.nextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextPage.Font = new System.Drawing.Font("NSimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextPage.ForeColor = System.Drawing.SystemColors.Control;
            this.nextPage.Location = new System.Drawing.Point(13, 44);
            this.nextPage.Name = "nextPage";
            this.nextPage.Size = new System.Drawing.Size(241, 64);
            this.nextPage.TabIndex = 4;
            this.nextPage.UseVisualStyleBackColor = false;
            this.nextPage.Click += new System.EventHandler(this.nextPage_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Miriam Libre", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(137)))));
            this.label1.Location = new System.Drawing.Point(532, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Espace administrateur";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(884, 701);
            this.tableLayoutPanel5.TabIndex = 10;
            this.tableLayoutPanel5.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel5_Paint);
            // 
            // previousPage
            // 
            this.previousPage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.previousPage.BackColor = System.Drawing.Color.Transparent;
            this.previousPage.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.buttonPagePrécédente;
            this.previousPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.previousPage.FlatAppearance.BorderSize = 0;
            this.previousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousPage.Font = new System.Drawing.Font("NSimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousPage.ForeColor = System.Drawing.SystemColors.Control;
            this.previousPage.Location = new System.Drawing.Point(-1, 44);
            this.previousPage.Name = "previousPage";
            this.previousPage.Size = new System.Drawing.Size(277, 64);
            this.previousPage.TabIndex = 5;
            this.previousPage.UseVisualStyleBackColor = false;
            this.previousPage.Click += new System.EventHandler(this.previousPage_Click);
            // 
            // nextPage
            // 
            this.nextPage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nextPage.BackColor = System.Drawing.Color.Transparent;
            this.nextPage.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.buttonPageSuivante;
            this.nextPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.nextPage.FlatAppearance.BorderSize = 0;
            this.nextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextPage.Font = new System.Drawing.Font("NSimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextPage.ForeColor = System.Drawing.SystemColors.Control;
            this.nextPage.Location = new System.Drawing.Point(13, 44);
            this.nextPage.Name = "nextPage";
            this.nextPage.Size = new System.Drawing.Size(241, 64);
            this.nextPage.TabIndex = 4;
            this.nextPage.UseVisualStyleBackColor = false;
            this.nextPage.Click += new System.EventHandler(this.nextPage_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Miriam Libre", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(137)))));
            this.label1.Location = new System.Drawing.Point(532, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Espace administrateur";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(884, 701);
            this.tableLayoutPanel5.TabIndex = 10;
            // 
            // afficheMiniature
            // 
            this.afficheMiniature.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.afficheMiniature.Location = new System.Drawing.Point(3, 19);
            this.afficheMiniature.Name = "afficheMiniature";
            this.afficheMiniature.Size = new System.Drawing.Size(156, 177);
            this.afficheMiniature.TabIndex = 9;
            // 
            // AdminView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScrollMargin = new System.Drawing.Size(1, 1);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(884, 701);
            this.Controls.Add(this.tableLayoutPanel5);
            this.MinimumSize = new System.Drawing.Size(900, 740);
            this.Name = "AdminView";
            this.Text = "AdminView";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.buttons.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel buttons;
        private System.Windows.Forms.Button listEmpruntsProlongButton;
        private System.Windows.Forms.Button listRetardButton;
        private System.Windows.Forms.Button addAlbumButton;
        private System.Windows.Forms.Button notEmprunterSinceAYear;
        private System.Windows.Forms.Button top10Button;
        private System.Windows.Forms.Button suppIdleUsersButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button listerAbonner;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListBox log;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button previousPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button nextPage;
        private System.Windows.Forms.Label afficheMiniature;
    }
}