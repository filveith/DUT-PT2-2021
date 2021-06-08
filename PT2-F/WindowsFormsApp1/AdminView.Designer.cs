﻿
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
            this.addAlbumButton = new System.Windows.Forms.Button();
            this.notEmprunterSinceAYear = new System.Windows.Forms.Button();
            this.removeAlbumButton = new System.Windows.Forms.Button();
            this.top10Button = new System.Windows.Forms.Button();
            this.suppIdleUsersButton = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.buttons.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.84488F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.15512F));
            this.tableLayoutPanel1.Controls.Add(this.buttons, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.log, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 79);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(867, 570);
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
            this.buttons.Location = new System.Drawing.Point(3, 3);
            this.buttons.Name = "buttons";
            this.buttons.RowCount = 4;
            this.buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.buttons.Size = new System.Drawing.Size(424, 496);
            this.buttons.TabIndex = 9;
            // 
            // listEmpruntsProlongButton
            // 
            this.listEmpruntsProlongButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listEmpruntsProlongButton.BackColor = System.Drawing.Color.Black;
            this.listEmpruntsProlongButton.FlatAppearance.BorderSize = 0;
            this.listEmpruntsProlongButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listEmpruntsProlongButton.Font = new System.Drawing.Font("Miriam Libre", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listEmpruntsProlongButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.listEmpruntsProlongButton.Location = new System.Drawing.Point(54, 40);
            this.listEmpruntsProlongButton.Name = "listEmpruntsProlongButton";
            this.listEmpruntsProlongButton.Size = new System.Drawing.Size(104, 56);
            this.listEmpruntsProlongButton.TabIndex = 1;
            this.listEmpruntsProlongButton.Text = "Lister Emprunts Prolongés";
            this.listEmpruntsProlongButton.UseVisualStyleBackColor = false;
            this.listEmpruntsProlongButton.Click += new System.EventHandler(this.listEmpruntsProlongButton_Click);
            // 
            // listRetardButton
            // 
            this.listRetardButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listRetardButton.BackColor = System.Drawing.Color.Black;
            this.listRetardButton.FlatAppearance.BorderSize = 0;
            this.listRetardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listRetardButton.Font = new System.Drawing.Font("Miriam Libre", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listRetardButton.ForeColor = System.Drawing.SystemColors.Control;
            this.listRetardButton.Location = new System.Drawing.Point(266, 40);
            this.listRetardButton.Name = "listRetardButton";
            this.listRetardButton.Size = new System.Drawing.Size(104, 56);
            this.listRetardButton.TabIndex = 2;
            this.listRetardButton.Text = "Lister Retards";
            this.listRetardButton.UseVisualStyleBackColor = false;
            this.listRetardButton.Click += new System.EventHandler(this.listRetardButton_Click);
            // 
            // addAlbumButton
            // 
            this.addAlbumButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addAlbumButton.BackColor = System.Drawing.Color.Black;
            this.addAlbumButton.FlatAppearance.BorderSize = 0;
            this.addAlbumButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAlbumButton.Font = new System.Drawing.Font("Miriam Libre", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.addAlbumButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.addAlbumButton.Location = new System.Drawing.Point(54, 176);
            this.addAlbumButton.Name = "addAlbumButton";
            this.addAlbumButton.Size = new System.Drawing.Size(104, 56);
            this.addAlbumButton.TabIndex = 3;
            this.addAlbumButton.Text = "Ajouter Albums";
            this.addAlbumButton.UseVisualStyleBackColor = false;
            this.addAlbumButton.Click += new System.EventHandler(this.addAlbumButton_Click);
            // 
            // notEmprunterSinceAYear
            // 
            this.notEmprunterSinceAYear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.notEmprunterSinceAYear.BackColor = System.Drawing.Color.Black;
            this.notEmprunterSinceAYear.FlatAppearance.BorderSize = 0;
            this.notEmprunterSinceAYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notEmprunterSinceAYear.Font = new System.Drawing.Font("Miriam Libre", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notEmprunterSinceAYear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.notEmprunterSinceAYear.Location = new System.Drawing.Point(266, 176);
            this.notEmprunterSinceAYear.Name = "notEmprunterSinceAYear";
            this.notEmprunterSinceAYear.Size = new System.Drawing.Size(104, 56);
            this.notEmprunterSinceAYear.TabIndex = 4;
            this.notEmprunterSinceAYear.Text = "Albums pas empruntés depuis 1 an";
            this.notEmprunterSinceAYear.UseVisualStyleBackColor = false;
            this.notEmprunterSinceAYear.Click += new System.EventHandler(this.notEmprunterSinceAYear_Click);
            // 
            // removeAlbumButton
            // 
            this.removeAlbumButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.removeAlbumButton.BackColor = System.Drawing.Color.Black;
            this.removeAlbumButton.FlatAppearance.BorderSize = 0;
            this.removeAlbumButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeAlbumButton.Font = new System.Drawing.Font("Miriam Libre", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeAlbumButton.ForeColor = System.Drawing.SystemColors.Control;
            this.removeAlbumButton.Location = new System.Drawing.Point(54, 302);
            this.removeAlbumButton.Name = "removeAlbumButton";
            this.removeAlbumButton.Size = new System.Drawing.Size(104, 56);
            this.removeAlbumButton.TabIndex = 5;
            this.removeAlbumButton.Text = "Supprimer Albums";
            this.removeAlbumButton.UseVisualStyleBackColor = false;
            this.removeAlbumButton.Click += new System.EventHandler(this.removeAlbumButton_Click);
            // 
            // top10Button
            // 
            this.top10Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.top10Button.BackColor = System.Drawing.Color.Black;
            this.top10Button.FlatAppearance.BorderSize = 0;
            this.top10Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.top10Button.Font = new System.Drawing.Font("Miriam Libre", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.top10Button.ForeColor = System.Drawing.SystemColors.Control;
            this.top10Button.Location = new System.Drawing.Point(266, 302);
            this.top10Button.Name = "top10Button";
            this.top10Button.Size = new System.Drawing.Size(104, 56);
            this.top10Button.TabIndex = 6;
            this.top10Button.Text = "Top 10 Albums Empruntés";
            this.top10Button.UseVisualStyleBackColor = false;
            this.top10Button.Click += new System.EventHandler(this.top10Button_Click);
            // 
            // suppIdleUsersButton
            // 
            this.suppIdleUsersButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.suppIdleUsersButton.BackColor = System.Drawing.Color.Black;
            this.suppIdleUsersButton.FlatAppearance.BorderSize = 0;
            this.suppIdleUsersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suppIdleUsersButton.Font = new System.Drawing.Font("Miriam Libre", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppIdleUsersButton.ForeColor = System.Drawing.SystemColors.Control;
            this.suppIdleUsersButton.Location = new System.Drawing.Point(54, 414);
            this.suppIdleUsersButton.Name = "suppIdleUsersButton";
            this.suppIdleUsersButton.Size = new System.Drawing.Size(104, 56);
            this.suppIdleUsersButton.TabIndex = 7;
            this.suppIdleUsersButton.Text = "Supprimer Utilisateurs Inactifs";
            this.suppIdleUsersButton.UseVisualStyleBackColor = false;
            this.suppIdleUsersButton.Click += new System.EventHandler(this.suppIdleUsersButton_Click);
            // 
            // log
            // 
            this.log.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.log.BackColor = System.Drawing.SystemColors.Window;
            this.log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.log.FormattingEnabled = true;
            this.log.Location = new System.Drawing.Point(436, 3);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(427, 455);
            this.log.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Miriam Libre", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(224, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Espace administrateur";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(867, 61);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // AdminView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScrollMargin = new System.Drawing.Size(1, 1);
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(891, 661);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(1100, 1100);
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Name = "AdminView";
            this.Text = "AdminView";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.buttons.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel buttons;
        private System.Windows.Forms.Button listEmpruntsProlongButton;
        private System.Windows.Forms.Button listRetardButton;
        private System.Windows.Forms.Button addAlbumButton;
        private System.Windows.Forms.Button notEmprunterSinceAYear;
        private System.Windows.Forms.Button removeAlbumButton;
        private System.Windows.Forms.Button top10Button;
        private System.Windows.Forms.Button suppIdleUsersButton;
        private System.Windows.Forms.ListBox log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}