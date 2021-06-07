
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
            this.AffichageAbo = new System.Windows.Forms.ListBox();
            this.mesAlbums = new System.Windows.Forms.Button();
            this.suggestions = new System.Windows.Forms.Button();
            this.prolongerEmprunt = new System.Windows.Forms.Button();
            this.prolongerToutEmprunt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AffichageAbo
            // 
            this.AffichageAbo.FormattingEnabled = true;
            this.AffichageAbo.Location = new System.Drawing.Point(39, 133);
            this.AffichageAbo.Name = "AffichageAbo";
            this.AffichageAbo.Size = new System.Drawing.Size(317, 277);
            this.AffichageAbo.TabIndex = 0;
            // 
            // mesAlbums
            // 
            this.mesAlbums.Location = new System.Drawing.Point(48, 61);
            this.mesAlbums.Name = "mesAlbums";
            this.mesAlbums.Size = new System.Drawing.Size(111, 45);
            this.mesAlbums.TabIndex = 1;
            this.mesAlbums.Text = "Mes albums";
            this.mesAlbums.UseVisualStyleBackColor = true;
            this.mesAlbums.Click += new System.EventHandler(this.mesAlbums_Click);
            // 
            // suggestions
            // 
            this.suggestions.Location = new System.Drawing.Point(213, 61);
            this.suggestions.Name = "suggestions";
            this.suggestions.Size = new System.Drawing.Size(103, 45);
            this.suggestions.TabIndex = 2;
            this.suggestions.Text = "Suggestions";
            this.suggestions.UseVisualStyleBackColor = true;
            this.suggestions.Click += new System.EventHandler(this.suggestions_Click);
            // 
            // prolongerEmprunt
            // 
            this.prolongerEmprunt.Location = new System.Drawing.Point(436, 208);
            this.prolongerEmprunt.Name = "prolongerEmprunt";
            this.prolongerEmprunt.Size = new System.Drawing.Size(134, 53);
            this.prolongerEmprunt.TabIndex = 3;
            this.prolongerEmprunt.Text = "Prolonger un emprunt";
            this.prolongerEmprunt.UseVisualStyleBackColor = true;
            this.prolongerEmprunt.Click += new System.EventHandler(this.prolongerEmprunt_Click);
            // 
            // prolongerToutEmprunt
            // 
            this.prolongerToutEmprunt.Location = new System.Drawing.Point(436, 290);
            this.prolongerToutEmprunt.Name = "prolongerToutEmprunt";
            this.prolongerToutEmprunt.Size = new System.Drawing.Size(134, 53);
            this.prolongerToutEmprunt.TabIndex = 4;
            this.prolongerToutEmprunt.Text = "Prolonger tout les emprunts";
            this.prolongerToutEmprunt.UseVisualStyleBackColor = true;
            this.prolongerToutEmprunt.Click += new System.EventHandler(this.prolongerToutEmprunt_Click);
            // 
            // UserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.prolongerToutEmprunt);
            this.Controls.Add(this.prolongerEmprunt);
            this.Controls.Add(this.suggestions);
            this.Controls.Add(this.mesAlbums);
            this.Controls.Add(this.AffichageAbo);
            this.Name = "UserView";
            this.Text = "UserView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox AffichageAbo;
        private System.Windows.Forms.Button mesAlbums;
        private System.Windows.Forms.Button suggestions;
        private System.Windows.Forms.Button prolongerEmprunt;
        private System.Windows.Forms.Button prolongerToutEmprunt;
    }
}