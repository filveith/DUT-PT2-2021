
namespace WindowsFormsApp1
{
    partial class AdminChangePassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.eyeButton = new System.Windows.Forms.Button();
            this.valider = new System.Windows.Forms.Button();
            this.confirmerPassBox = new System.Windows.Forms.TextBox();
            this.ancienPassBox = new System.Windows.Forms.TextBox();
            this.newPassBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.375F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.625F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.valider, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ancienPassBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.eyeButton, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.confirmerPassBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.newPassBox, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Miriam Libre", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(137)))));
            this.label1.Location = new System.Drawing.Point(342, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nouveau Mot de Passe";
            // 
            // eyeButton
            // 
            this.eyeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.eyeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.eyeButton.FlatAppearance.BorderSize = 0;
            this.eyeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.eyeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.eyeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eyeButton.Image = global::WindowsFormsApp1.Properties.Resources.eyeClosed_Icon;
            this.eyeButton.Location = new System.Drawing.Point(748, 393);
            this.eyeButton.Name = "eyeButton";
            this.eyeButton.Size = new System.Drawing.Size(23, 23);
            this.eyeButton.TabIndex = 5;
            this.eyeButton.TabStop = false;
            this.eyeButton.UseVisualStyleBackColor = true;
            this.eyeButton.Click += new System.EventHandler(this.eyeButton_Click);
            // 
            // valider
            // 
            this.valider.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.valider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(186)))), ((int)(((byte)(195)))));
            this.valider.FlatAppearance.BorderSize = 0;
            this.valider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.valider.Font = new System.Drawing.Font("Miriam Libre", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(235)))), ((int)(((byte)(237)))));
            this.valider.Location = new System.Drawing.Point(395, 376);
            this.valider.Name = "valider";
            this.valider.Size = new System.Drawing.Size(116, 57);
            this.valider.TabIndex = 2;
            this.valider.Text = "Valider";
            this.valider.UseVisualStyleBackColor = false;
            this.valider.Click += new System.EventHandler(this.valider_Click);
            // 
            // confirmerPassBox
            // 
            this.confirmerPassBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmerPassBox.Location = new System.Drawing.Point(190, 305);
            this.confirmerPassBox.Name = "confirmerPassBox";
            this.confirmerPassBox.Size = new System.Drawing.Size(527, 20);
            this.confirmerPassBox.TabIndex = 6;
            // 
            // ancienPassBox
            // 
            this.ancienPassBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ancienPassBox.Location = new System.Drawing.Point(190, 125);
            this.ancienPassBox.Name = "ancienPassBox";
            this.ancienPassBox.Size = new System.Drawing.Size(527, 20);
            this.ancienPassBox.TabIndex = 7;
            // 
            // newPassBox
            // 
            this.newPassBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.newPassBox.Location = new System.Drawing.Point(190, 215);
            this.newPassBox.Name = "newPassBox";
            this.newPassBox.Size = new System.Drawing.Size(527, 20);
            this.newPassBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Miriam Libre", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(137)))));
            this.label2.Location = new System.Drawing.Point(32, 127);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ancien mot de passe :";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Miriam Libre", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(137)))));
            this.label3.Location = new System.Drawing.Point(22, 217);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nouveau mot de passe :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Miriam Libre", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(137)))));
            this.label4.Location = new System.Drawing.Point(16, 299);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 32);
            this.label4.TabIndex = 10;
            this.label4.Text = "Confirmer nouveau mot de passe :\r\n";
            // 
            // AdminChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(235)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "AdminChangePassword";
            this.Text = "AdminChangePasswordcs";
            this.Load += new System.EventHandler(this.AdminChangePassword_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AdminChangePassword_KeyPress);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newPassBox;
        private System.Windows.Forms.Button valider;
        private System.Windows.Forms.Button eyeButton;
        private System.Windows.Forms.TextBox confirmerPassBox;
        private System.Windows.Forms.TextBox ancienPassBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}