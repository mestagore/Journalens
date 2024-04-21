namespace PresseRESA
{
    partial class FormCreateArticle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateArticle));
            this.labTitleAddArticle = new System.Windows.Forms.Label();
            this.labTitre = new System.Windows.Forms.Label();
            this.labDescription = new System.Windows.Forms.Label();
            this.txtBDescription = new System.Windows.Forms.TextBox();
            this.txtBTitre = new System.Windows.Forms.TextBox();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnAjoutArticle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labTitleAddArticle
            // 
            this.labTitleAddArticle.AutoSize = true;
            this.labTitleAddArticle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.labTitleAddArticle.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitleAddArticle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.labTitleAddArticle.Location = new System.Drawing.Point(288, 19);
            this.labTitleAddArticle.Name = "labTitleAddArticle";
            this.labTitleAddArticle.Size = new System.Drawing.Size(209, 23);
            this.labTitleAddArticle.TabIndex = 15;
            this.labTitleAddArticle.Text = "Saississez votre article";
            // 
            // labTitre
            // 
            this.labTitre.AutoSize = true;
            this.labTitre.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitre.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labTitre.Location = new System.Drawing.Point(71, 58);
            this.labTitre.Name = "labTitre";
            this.labTitre.Size = new System.Drawing.Size(47, 18);
            this.labTitre.TabIndex = 16;
            this.labTitre.Text = "Titre :";
            // 
            // labDescription
            // 
            this.labDescription.AutoSize = true;
            this.labDescription.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDescription.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labDescription.Location = new System.Drawing.Point(27, 90);
            this.labDescription.Name = "labDescription";
            this.labDescription.Size = new System.Drawing.Size(91, 18);
            this.labDescription.TabIndex = 17;
            this.labDescription.Text = "Description :";
            // 
            // txtBDescription
            // 
            this.txtBDescription.Location = new System.Drawing.Point(124, 88);
            this.txtBDescription.Multiline = true;
            this.txtBDescription.Name = "txtBDescription";
            this.txtBDescription.Size = new System.Drawing.Size(585, 294);
            this.txtBDescription.TabIndex = 18;
            // 
            // txtBTitre
            // 
            this.txtBTitre.Location = new System.Drawing.Point(124, 56);
            this.txtBTitre.Name = "txtBTitre";
            this.txtBTitre.Size = new System.Drawing.Size(585, 20);
            this.txtBTitre.TabIndex = 19;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(124, 388);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(112, 23);
            this.btnAnnuler.TabIndex = 20;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnAjoutArticle
            // 
            this.btnAjoutArticle.Location = new System.Drawing.Point(587, 388);
            this.btnAjoutArticle.Name = "btnAjoutArticle";
            this.btnAjoutArticle.Size = new System.Drawing.Size(122, 23);
            this.btnAjoutArticle.TabIndex = 21;
            this.btnAjoutArticle.Text = "Confirmer";
            this.btnAjoutArticle.UseVisualStyleBackColor = true;
            this.btnAjoutArticle.Click += new System.EventHandler(this.btnAjoutArticle_Click);
            // 
            // FormCreateArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(730, 420);
            this.Controls.Add(this.btnAjoutArticle);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.txtBTitre);
            this.Controls.Add(this.txtBDescription);
            this.Controls.Add(this.labDescription);
            this.Controls.Add(this.labTitre);
            this.Controls.Add(this.labTitleAddArticle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCreateArticle";
            this.Text = "Saisie de votre article";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCreateArticle_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labTitleAddArticle;
        private System.Windows.Forms.Label labTitre;
        private System.Windows.Forms.Label labDescription;
        private System.Windows.Forms.TextBox txtBDescription;
        private System.Windows.Forms.TextBox txtBTitre;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnAjoutArticle;
    }
}