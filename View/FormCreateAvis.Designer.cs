namespace PresseRESA
{
    partial class FormCreateAvis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateAvis));
            this.txtBCommentaire = new System.Windows.Forms.TextBox();
            this.labTitleAddCommentaire = new System.Windows.Forms.Label();
            this.btnAjoutAvis = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBCommentaire
            // 
            this.txtBCommentaire.Location = new System.Drawing.Point(33, 64);
            this.txtBCommentaire.Multiline = true;
            this.txtBCommentaire.Name = "txtBCommentaire";
            this.txtBCommentaire.Size = new System.Drawing.Size(785, 274);
            this.txtBCommentaire.TabIndex = 0;
            // 
            // labTitleAddCommentaire
            // 
            this.labTitleAddCommentaire.AutoSize = true;
            this.labTitleAddCommentaire.BackColor = System.Drawing.Color.WhiteSmoke;
            this.labTitleAddCommentaire.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitleAddCommentaire.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.labTitleAddCommentaire.Location = new System.Drawing.Point(284, 22);
            this.labTitleAddCommentaire.Name = "labTitleAddCommentaire";
            this.labTitleAddCommentaire.Size = new System.Drawing.Size(272, 23);
            this.labTitleAddCommentaire.TabIndex = 14;
            this.labTitleAddCommentaire.Text = "Saississez votre commentaire";
            // 
            // btnAjoutAvis
            // 
            this.btnAjoutAvis.Location = new System.Drawing.Point(696, 347);
            this.btnAjoutAvis.Name = "btnAjoutAvis";
            this.btnAjoutAvis.Size = new System.Drawing.Size(122, 23);
            this.btnAjoutAvis.TabIndex = 15;
            this.btnAjoutAvis.Text = "Confirmer";
            this.btnAjoutAvis.UseVisualStyleBackColor = true;
            this.btnAjoutAvis.Click += new System.EventHandler(this.btnAjoutUser_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(33, 347);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(122, 23);
            this.btnAnnuler.TabIndex = 16;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // FormCreateAvis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(842, 382);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnAjoutAvis);
            this.Controls.Add(this.labTitleAddCommentaire);
            this.Controls.Add(this.txtBCommentaire);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormCreateAvis";
            this.Text = "Saisie de votre avis";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCreateAvis_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBCommentaire;
        private System.Windows.Forms.Label labTitleAddCommentaire;
        private System.Windows.Forms.Button btnAjoutAvis;
        private System.Windows.Forms.Button btnAnnuler;
    }
}