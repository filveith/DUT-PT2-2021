
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
            this.log = new System.Windows.Forms.ListBox();
            this.listEmpruntsProlongButton = new System.Windows.Forms.Button();
            this.listRetardButton = new System.Windows.Forms.Button();
            this.addAlbumButton = new System.Windows.Forms.Button();
            this.notEmprunterSinceAYear = new System.Windows.Forms.Button();
            this.removeAlbumButton = new System.Windows.Forms.Button();
            this.top10Button = new System.Windows.Forms.Button();
            this.suppIdleUsersButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttons = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // log
            // 
            this.log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log.FormattingEnabled = true;
            this.log.Location = new System.Drawing.Point(403, 3);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(394, 444);
            this.log.TabIndex = 0;
            // 
            // listEmpruntsProlongButton
            // 
            this.listEmpruntsProlongButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listEmpruntsProlongButton.Location = new System.Drawing.Point(46, 27);
            this.listEmpruntsProlongButton.Name = "listEmpruntsProlongButton";
            this.listEmpruntsProlongButton.Size = new System.Drawing.Size(104, 56);
            this.listEmpruntsProlongButton.TabIndex = 1;
            this.listEmpruntsProlongButton.Text = "Lister Emprunts Prolongés";
            this.listEmpruntsProlongButton.UseVisualStyleBackColor = true;
            this.listEmpruntsProlongButton.Click += new System.EventHandler(this.listEmpruntsProlongButton_Click);
            // 
            // listRetardButton
            // 
            this.listRetardButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listRetardButton.Location = new System.Drawing.Point(243, 27);
            this.listRetardButton.Name = "listRetardButton";
            this.listRetardButton.Size = new System.Drawing.Size(104, 56);
            this.listRetardButton.TabIndex = 2;
            this.listRetardButton.Text = "Lister Retards";
            this.listRetardButton.UseVisualStyleBackColor = true;
            this.listRetardButton.Click += new System.EventHandler(this.listRetardButton_Click);
            // 
            // addAlbumButton
            // 
            this.addAlbumButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addAlbumButton.Location = new System.Drawing.Point(46, 137);
            this.addAlbumButton.Name = "addAlbumButton";
            this.addAlbumButton.Size = new System.Drawing.Size(104, 56);
            this.addAlbumButton.TabIndex = 3;
            this.addAlbumButton.Text = "Ajouter Albums";
            this.addAlbumButton.UseVisualStyleBackColor = true;
            this.addAlbumButton.Click += new System.EventHandler(this.addAlbumButton_Click);
            // 
            // notEmprunterSinceAYear
            // 
            this.notEmprunterSinceAYear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.notEmprunterSinceAYear.Location = new System.Drawing.Point(243, 137);
            this.notEmprunterSinceAYear.Name = "notEmprunterSinceAYear";
            this.notEmprunterSinceAYear.Size = new System.Drawing.Size(104, 56);
            this.notEmprunterSinceAYear.TabIndex = 4;
            this.notEmprunterSinceAYear.Text = "Albums pas empruntés depuis 1 an";
            this.notEmprunterSinceAYear.UseVisualStyleBackColor = true;
            this.notEmprunterSinceAYear.Click += new System.EventHandler(this.notEmprunterSinceAYear_Click);
            // 
            // removeAlbumButton
            // 
            this.removeAlbumButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.removeAlbumButton.Location = new System.Drawing.Point(46, 250);
            this.removeAlbumButton.Name = "removeAlbumButton";
            this.removeAlbumButton.Size = new System.Drawing.Size(104, 56);
            this.removeAlbumButton.TabIndex = 5;
            this.removeAlbumButton.Text = "Supprimer Albums";
            this.removeAlbumButton.UseVisualStyleBackColor = true;
            this.removeAlbumButton.Click += new System.EventHandler(this.removeAlbumButton_Click);
            // 
            // top10Button
            // 
            this.top10Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.top10Button.Location = new System.Drawing.Point(243, 250);
            this.top10Button.Name = "top10Button";
            this.top10Button.Size = new System.Drawing.Size(104, 56);
            this.top10Button.TabIndex = 6;
            this.top10Button.Text = "Top 10 Albums Empruntés";
            this.top10Button.UseVisualStyleBackColor = true;
            this.top10Button.Click += new System.EventHandler(this.top10Button_Click);
            // 
            // suppIdleUsersButton
            // 
            this.suppIdleUsersButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.suppIdleUsersButton.Location = new System.Drawing.Point(46, 362);
            this.suppIdleUsersButton.Name = "suppIdleUsersButton";
            this.suppIdleUsersButton.Size = new System.Drawing.Size(104, 56);
            this.suppIdleUsersButton.TabIndex = 7;
            this.suppIdleUsersButton.Text = "Supprimer Utilisateurs Inactifs";
            this.suppIdleUsersButton.UseVisualStyleBackColor = true;
            this.suppIdleUsersButton.Click += new System.EventHandler(this.suppIdleUsersButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttons, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.log, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // buttons
            // 
            this.buttons.ColumnCount = 2;
            this.buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttons.Controls.Add(this.listEmpruntsProlongButton, 0, 0);
            this.buttons.Controls.Add(this.listRetardButton, 1, 0);
            this.buttons.Controls.Add(this.addAlbumButton, 0, 1);
            this.buttons.Controls.Add(this.notEmprunterSinceAYear, 1, 1);
            this.buttons.Controls.Add(this.removeAlbumButton, 0, 2);
            this.buttons.Controls.Add(this.top10Button, 1, 2);
            this.buttons.Controls.Add(this.suppIdleUsersButton, 0, 3);
            this.buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttons.Location = new System.Drawing.Point(3, 3);
            this.buttons.Name = "buttons";
            this.buttons.RowCount = 4;
            this.buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.buttons.Size = new System.Drawing.Size(394, 444);
            this.buttons.TabIndex = 9;
            // 
            // AdminView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AdminView";
            this.Text = "AdminView";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox log;
        private System.Windows.Forms.Button listEmpruntsProlongButton;
        private System.Windows.Forms.Button listRetardButton;
        private System.Windows.Forms.Button addAlbumButton;
        private System.Windows.Forms.Button notEmprunterSinceAYear;
        private System.Windows.Forms.Button removeAlbumButton;
        private System.Windows.Forms.Button top10Button;
        private System.Windows.Forms.Button suppIdleUsersButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel buttons;
    }
}