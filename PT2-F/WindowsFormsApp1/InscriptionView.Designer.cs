
namespace WindowsFormsApp1
{
    partial class InscriptionView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.textBoxPrenom = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxMdp = new System.Windows.Forms.TextBox();
            this.textBoxCoMdp = new System.Windows.Forms.TextBox();
            this.ValiderInscription = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(374, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inscription";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "nom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "prenom";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "identifiant";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "mot de passe";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(182, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "confirmation de mot de passe ";
            // 
            // textBoxNom
            // 
            this.textBoxNom.Location = new System.Drawing.Point(352, 102);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(100, 20);
            this.textBoxNom.TabIndex = 6;
            // 
            // textBoxPrenom
            // 
            this.textBoxPrenom.Location = new System.Drawing.Point(352, 148);
            this.textBoxPrenom.Name = "textBoxPrenom";
            this.textBoxPrenom.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrenom.TabIndex = 7;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(352, 192);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(100, 20);
            this.textBoxID.TabIndex = 8;
            // 
            // textBoxMdp
            // 
            this.textBoxMdp.Location = new System.Drawing.Point(352, 237);
            this.textBoxMdp.Name = "textBoxMdp";
            this.textBoxMdp.Size = new System.Drawing.Size(100, 20);
            this.textBoxMdp.TabIndex = 9;
            // 
            // textBoxCoMdp
            // 
            this.textBoxCoMdp.Location = new System.Drawing.Point(352, 282);
            this.textBoxCoMdp.Name = "textBoxCoMdp";
            this.textBoxCoMdp.Size = new System.Drawing.Size(100, 20);
            this.textBoxCoMdp.TabIndex = 10;
            // 
            // ValiderInscription
            // 
            this.ValiderInscription.Location = new System.Drawing.Point(368, 360);
            this.ValiderInscription.Name = "ValiderInscription";
            this.ValiderInscription.Size = new System.Drawing.Size(75, 23);
            this.ValiderInscription.TabIndex = 11;
            this.ValiderInscription.Text = "Valider";
            this.ValiderInscription.UseVisualStyleBackColor = true;
            this.ValiderInscription.Click += new System.EventHandler(this.ValiderInscription_Click);
            // 
            // InscriptionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ValiderInscription);
            this.Controls.Add(this.textBoxCoMdp);
            this.Controls.Add(this.textBoxMdp);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBoxPrenom);
            this.Controls.Add(this.textBoxNom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InscriptionView";
            this.Text = "inscription";
            this.Load += new System.EventHandler(this.InscriptionView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxNom;
        private System.Windows.Forms.TextBox textBoxPrenom;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxMdp;
        private System.Windows.Forms.TextBox textBoxCoMdp;
        private System.Windows.Forms.Button ValiderInscription;
    }
}