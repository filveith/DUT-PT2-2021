
namespace WindowsFormsApp1
{
    partial class ConnexionView
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
            this.validerButton = new System.Windows.Forms.Button();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.ConnexionText = new System.Windows.Forms.Label();
            this.IdLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // validerButton
            // 
            this.validerButton.Location = new System.Drawing.Point(336, 324);
            this.validerButton.Name = "validerButton";
            this.validerButton.Size = new System.Drawing.Size(102, 33);
            this.validerButton.TabIndex = 0;
            this.validerButton.Text = "Valider";
            this.validerButton.UseVisualStyleBackColor = true;
            this.validerButton.Click += new System.EventHandler(this.validerButton_Click);
            this.validerButton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(288, 148);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(212, 20);
            this.idTextBox.TabIndex = 1;
            this.idTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            // 
            // passTextBox
            // 
            this.passTextBox.Location = new System.Drawing.Point(288, 212);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.PasswordChar = '*';
            this.passTextBox.Size = new System.Drawing.Size(212, 20);
            this.passTextBox.TabIndex = 2;
            this.passTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            // 
            // ConnexionText
            // 
            this.ConnexionText.AutoSize = true;
            this.ConnexionText.Location = new System.Drawing.Point(361, 106);
            this.ConnexionText.Name = "ConnexionText";
            this.ConnexionText.Size = new System.Drawing.Size(57, 13);
            this.ConnexionText.TabIndex = 3;
            this.ConnexionText.Text = "Connexion";
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(215, 151);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(53, 13);
            this.IdLabel.TabIndex = 4;
            this.IdLabel.Text = "Identifiant";
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Location = new System.Drawing.Point(197, 215);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(71, 13);
            this.passLabel.TabIndex = 5;
            this.passLabel.Text = "Mot de passe";
            // 
            // ConnexionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.ConnexionText);
            this.Controls.Add(this.passTextBox);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.validerButton);
            this.Name = "ConnexionView";
            this.Text = "ConnexionView";
            this.Load += new System.EventHandler(this.ConnexionView_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button validerButton;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.Label ConnexionText;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.Label passLabel;
    }
}