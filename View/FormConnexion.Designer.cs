namespace PresseRESA
{
    partial class FormConnexion
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConnexion));
            this.labConnexion = new System.Windows.Forms.Label();
            this.labMDP = new System.Windows.Forms.Label();
            this.labMel = new System.Windows.Forms.Label();
            this.labWarning = new System.Windows.Forms.Label();
            this.labCopyright = new System.Windows.Forms.Label();
            this.txtBoxMel = new System.Windows.Forms.TextBox();
            this.txtBoxMDP = new System.Windows.Forms.TextBox();
            this.btnConnexion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labConnexion
            // 
            this.labConnexion.AutoSize = true;
            this.labConnexion.Font = new System.Drawing.Font("Constantia", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labConnexion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labConnexion.Location = new System.Drawing.Point(48, 13);
            this.labConnexion.Name = "labConnexion";
            this.labConnexion.Size = new System.Drawing.Size(230, 33);
            this.labConnexion.TabIndex = 0;
            this.labConnexion.Text = "Connectez-vous !";
            // 
            // labMDP
            // 
            this.labMDP.AutoSize = true;
            this.labMDP.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMDP.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labMDP.Location = new System.Drawing.Point(48, 118);
            this.labMDP.Name = "labMDP";
            this.labMDP.Size = new System.Drawing.Size(93, 18);
            this.labMDP.TabIndex = 4;
            this.labMDP.Text = "Mot de passe";
            // 
            // labMel
            // 
            this.labMel.AutoSize = true;
            this.labMel.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labMel.Location = new System.Drawing.Point(48, 57);
            this.labMel.Name = "labMel";
            this.labMel.Size = new System.Drawing.Size(91, 18);
            this.labMel.TabIndex = 5;
            this.labMel.Text = "Adresse mail";
            // 
            // labWarning
            // 
            this.labWarning.AutoSize = true;
            this.labWarning.Font = new System.Drawing.Font("Constantia", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labWarning.ForeColor = System.Drawing.Color.Gray;
            this.labWarning.Location = new System.Drawing.Point(36, 217);
            this.labWarning.MaximumSize = new System.Drawing.Size(300, 0);
            this.labWarning.Name = "labWarning";
            this.labWarning.Size = new System.Drawing.Size(257, 28);
            this.labWarning.TabIndex = 0;
            this.labWarning.Text = "Connectez vous avec vos identifiants pour profiter pleinement de notre service de" +
    " presse ! ";
            this.labWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labCopyright
            // 
            this.labCopyright.AutoSize = true;
            this.labCopyright.Font = new System.Drawing.Font("Constantia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCopyright.ForeColor = System.Drawing.Color.DimGray;
            this.labCopyright.Location = new System.Drawing.Point(250, 250);
            this.labCopyright.Name = "labCopyright";
            this.labCopyright.Size = new System.Drawing.Size(57, 14);
            this.labCopyright.TabIndex = 4;
            this.labCopyright.Text = "copyright";
            // 
            // txtBoxMel
            // 
            this.txtBoxMel.Location = new System.Drawing.Point(48, 78);
            this.txtBoxMel.Name = "txtBoxMel";
            this.txtBoxMel.Size = new System.Drawing.Size(236, 27);
            this.txtBoxMel.TabIndex = 6;
            // 
            // txtBoxMDP
            // 
            this.txtBoxMDP.Location = new System.Drawing.Point(48, 139);
            this.txtBoxMDP.Name = "txtBoxMDP";
            this.txtBoxMDP.PasswordChar = '*';
            this.txtBoxMDP.Size = new System.Drawing.Size(236, 27);
            this.txtBoxMDP.TabIndex = 7;
            // 
            // btnConnexion
            // 
            this.btnConnexion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnConnexion.Location = new System.Drawing.Point(95, 174);
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(132, 27);
            this.btnConnexion.TabIndex = 8;
            this.btnConnexion.Text = "Connexion";
            this.btnConnexion.UseVisualStyleBackColor = false;
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);
            // 
            // FormConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(326, 267);
            this.Controls.Add(this.btnConnexion);
            this.Controls.Add(this.txtBoxMDP);
            this.Controls.Add(this.txtBoxMel);
            this.Controls.Add(this.labCopyright);
            this.Controls.Add(this.labWarning);
            this.Controls.Add(this.labMel);
            this.Controls.Add(this.labMDP);
            this.Controls.Add(this.labConnexion);
            this.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormConnexion";
            this.Text = "Connexion";
            this.Load += new System.EventHandler(this.FormConnexion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labConnexion;
        private System.Windows.Forms.Label labMDP;
        private System.Windows.Forms.Label labMel;
        private System.Windows.Forms.Label labWarning;
        private System.Windows.Forms.Label labCopyright;
        private System.Windows.Forms.TextBox txtBoxMel;
        private System.Windows.Forms.TextBox txtBoxMDP;
        private System.Windows.Forms.Button btnConnexion;
    }
}

