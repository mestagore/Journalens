namespace PresseRESA
{
    partial class FormDetailsAvis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetailsAvis));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddAvertissement = new System.Windows.Forms.Button();
            this.labAuteurAvis = new System.Windows.Forms.Label();
            this.labCommentaireAvis = new System.Windows.Forms.Label();
            this.labCreaAvis = new System.Windows.Forms.Label();
            this.labIdAvis = new System.Windows.Forms.Label();
            this.labAuteur = new System.Windows.Forms.Label();
            this.labCrea = new System.Windows.Forms.Label();
            this.labCommentaire = new System.Windows.Forms.Label();
            this.labId = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddAvertissement);
            this.groupBox1.Controls.Add(this.labAuteurAvis);
            this.groupBox1.Controls.Add(this.labCommentaireAvis);
            this.groupBox1.Controls.Add(this.labCreaAvis);
            this.groupBox1.Controls.Add(this.labIdAvis);
            this.groupBox1.Controls.Add(this.labAuteur);
            this.groupBox1.Controls.Add(this.labCrea);
            this.groupBox1.Controls.Add(this.labCommentaire);
            this.groupBox1.Controls.Add(this.labId);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(746, 354);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informations";
            // 
            // btnAddAvertissement
            // 
            this.btnAddAvertissement.Location = new System.Drawing.Point(593, 321);
            this.btnAddAvertissement.Name = "btnAddAvertissement";
            this.btnAddAvertissement.Size = new System.Drawing.Size(141, 23);
            this.btnAddAvertissement.TabIndex = 21;
            this.btnAddAvertissement.Text = "Supprimer l\'avis";
            this.btnAddAvertissement.UseVisualStyleBackColor = true;
            this.btnAddAvertissement.Click += new System.EventHandler(this.btnAddAvertissement_Click);
            // 
            // labAuteurAvis
            // 
            this.labAuteurAvis.AutoSize = true;
            this.labAuteurAvis.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAuteurAvis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labAuteurAvis.Location = new System.Drawing.Point(186, 52);
            this.labAuteurAvis.Name = "labAuteurAvis";
            this.labAuteurAvis.Size = new System.Drawing.Size(103, 18);
            this.labAuteurAvis.TabIndex = 20;
            this.labAuteurAvis.Text = "Non renseigné";
            // 
            // labCommentaireAvis
            // 
            this.labCommentaireAvis.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCommentaireAvis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labCommentaireAvis.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labCommentaireAvis.Location = new System.Drawing.Point(108, 70);
            this.labCommentaireAvis.Name = "labCommentaireAvis";
            this.labCommentaireAvis.Size = new System.Drawing.Size(632, 248);
            this.labCommentaireAvis.TabIndex = 18;
            this.labCommentaireAvis.Text = "Non renseigné";
            this.labCommentaireAvis.Click += new System.EventHandler(this.labDescriptionArticle_Click);
            // 
            // labCreaAvis
            // 
            this.labCreaAvis.AutoSize = true;
            this.labCreaAvis.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCreaAvis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labCreaAvis.Location = new System.Drawing.Point(186, 34);
            this.labCreaAvis.Name = "labCreaAvis";
            this.labCreaAvis.Size = new System.Drawing.Size(103, 18);
            this.labCreaAvis.TabIndex = 17;
            this.labCreaAvis.Text = "Non renseigné";
            // 
            // labIdAvis
            // 
            this.labIdAvis.AutoSize = true;
            this.labIdAvis.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labIdAvis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labIdAvis.Location = new System.Drawing.Point(186, 16);
            this.labIdAvis.Name = "labIdAvis";
            this.labIdAvis.Size = new System.Drawing.Size(103, 18);
            this.labIdAvis.TabIndex = 15;
            this.labIdAvis.Text = "Non renseigné";
            // 
            // labAuteur
            // 
            this.labAuteur.AutoSize = true;
            this.labAuteur.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAuteur.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labAuteur.Location = new System.Drawing.Point(127, 52);
            this.labAuteur.Name = "labAuteur";
            this.labAuteur.Size = new System.Drawing.Size(61, 18);
            this.labAuteur.TabIndex = 14;
            this.labAuteur.Text = "Auteur :";
            // 
            // labCrea
            // 
            this.labCrea.AutoSize = true;
            this.labCrea.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCrea.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labCrea.Location = new System.Drawing.Point(127, 34);
            this.labCrea.Name = "labCrea";
            this.labCrea.Size = new System.Drawing.Size(61, 18);
            this.labCrea.TabIndex = 10;
            this.labCrea.Text = "Crée le :";
            // 
            // labCommentaire
            // 
            this.labCommentaire.AutoSize = true;
            this.labCommentaire.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCommentaire.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labCommentaire.Location = new System.Drawing.Point(6, 70);
            this.labCommentaire.Name = "labCommentaire";
            this.labCommentaire.Size = new System.Drawing.Size(105, 18);
            this.labCommentaire.TabIndex = 9;
            this.labCommentaire.Text = "Commentaire :";
            this.labCommentaire.Click += new System.EventHandler(this.labDescription_Click);
            // 
            // labId
            // 
            this.labId.AutoSize = true;
            this.labId.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labId.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labId.Location = new System.Drawing.Point(49, 16);
            this.labId.Name = "labId";
            this.labId.Size = new System.Drawing.Size(140, 18);
            this.labId.TabIndex = 6;
            this.labId.Text = "Identifiant de l\'avis :";
            // 
            // FormDetailsAvis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(770, 380);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormDetailsAvis";
            this.Text = "Détails de l\'avis";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDetailsAvis_FormClosed);
            this.Load += new System.EventHandler(this.FormDetailsAvis_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labAuteurAvis;
        private System.Windows.Forms.Label labCommentaireAvis;
        private System.Windows.Forms.Label labCreaAvis;
        private System.Windows.Forms.Label labIdAvis;
        private System.Windows.Forms.Label labAuteur;
        private System.Windows.Forms.Label labCrea;
        private System.Windows.Forms.Label labCommentaire;
        private System.Windows.Forms.Label labId;
        private System.Windows.Forms.Button btnAddAvertissement;
    }
}