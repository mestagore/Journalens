namespace PresseRESA
{
    partial class FormPresseUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPresseUser));
            this.tabControlUser = new System.Windows.Forms.TabControl();
            this.tabPAccueil = new System.Windows.Forms.TabPage();
            this.tabPDashboard = new System.Windows.Forms.TabPage();
            this.tabPProfil = new System.Windows.Forms.TabPage();
            this.labCopyright = new System.Windows.Forms.Label();
            this.btnDecoAdmin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBOnglet = new System.Windows.Forms.ComboBox();
            this.groupBInfoProfil = new System.Windows.Forms.GroupBox();
            this.labNumPortUser = new System.Windows.Forms.Label();
            this.labNumTelUser = new System.Windows.Forms.Label();
            this.labNbAvertissementUser = new System.Windows.Forms.Label();
            this.labDateInscriptionUser = new System.Windows.Forms.Label();
            this.labPrenomUser = new System.Windows.Forms.Label();
            this.labNomUser = new System.Windows.Forms.Label();
            this.labMailUser = new System.Windows.Forms.Label();
            this.labNbAvertissement = new System.Windows.Forms.Label();
            this.labNumTel = new System.Windows.Forms.Label();
            this.labNumPort = new System.Windows.Forms.Label();
            this.labPrenom = new System.Windows.Forms.Label();
            this.labDateInscription = new System.Windows.Forms.Label();
            this.labNom = new System.Windows.Forms.Label();
            this.labMel = new System.Windows.Forms.Label();
            this.labStatusAvertissement = new System.Windows.Forms.Label();
            this.btnModifRubrique = new System.Windows.Forms.Button();
            this.labWarning = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBModifInfoProfil = new System.Windows.Forms.GroupBox();
            this.txtBPortableUser = new System.Windows.Forms.TextBox();
            this.txtBTelephoneUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAjoutUser = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.listBAvis = new System.Windows.Forms.ListBox();
            this.labArticles = new System.Windows.Forms.Label();
            this.listBArticles = new System.Windows.Forms.ListBox();
            this.tabControlUser.SuspendLayout();
            this.tabPDashboard.SuspendLayout();
            this.tabPProfil.SuspendLayout();
            this.groupBInfoProfil.SuspendLayout();
            this.groupBModifInfoProfil.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlUser
            // 
            this.tabControlUser.Controls.Add(this.tabPAccueil);
            this.tabControlUser.Controls.Add(this.tabPDashboard);
            this.tabControlUser.Controls.Add(this.tabPProfil);
            this.tabControlUser.Location = new System.Drawing.Point(12, 34);
            this.tabControlUser.Name = "tabControlUser";
            this.tabControlUser.SelectedIndex = 0;
            this.tabControlUser.Size = new System.Drawing.Size(958, 422);
            this.tabControlUser.TabIndex = 7;
            // 
            // tabPAccueil
            // 
            this.tabPAccueil.Location = new System.Drawing.Point(4, 22);
            this.tabPAccueil.Name = "tabPAccueil";
            this.tabPAccueil.Padding = new System.Windows.Forms.Padding(3);
            this.tabPAccueil.Size = new System.Drawing.Size(950, 396);
            this.tabPAccueil.TabIndex = 1;
            this.tabPAccueil.Text = "Accueil";
            this.tabPAccueil.UseVisualStyleBackColor = true;
            // 
            // tabPDashboard
            // 
            this.tabPDashboard.Controls.Add(this.label5);
            this.tabPDashboard.Controls.Add(this.listBAvis);
            this.tabPDashboard.Controls.Add(this.labArticles);
            this.tabPDashboard.Controls.Add(this.listBArticles);
            this.tabPDashboard.Location = new System.Drawing.Point(4, 22);
            this.tabPDashboard.Name = "tabPDashboard";
            this.tabPDashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabPDashboard.Size = new System.Drawing.Size(950, 396);
            this.tabPDashboard.TabIndex = 2;
            this.tabPDashboard.Text = "Mon tableau de bord";
            this.tabPDashboard.UseVisualStyleBackColor = true;
            // 
            // tabPProfil
            // 
            this.tabPProfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.tabPProfil.Controls.Add(this.groupBModifInfoProfil);
            this.tabPProfil.Controls.Add(this.label2);
            this.tabPProfil.Controls.Add(this.btnModifRubrique);
            this.tabPProfil.Controls.Add(this.groupBInfoProfil);
            this.tabPProfil.Location = new System.Drawing.Point(4, 22);
            this.tabPProfil.Name = "tabPProfil";
            this.tabPProfil.Padding = new System.Windows.Forms.Padding(3);
            this.tabPProfil.Size = new System.Drawing.Size(950, 396);
            this.tabPProfil.TabIndex = 3;
            this.tabPProfil.Text = "Profil";
            this.tabPProfil.Click += new System.EventHandler(this.tabPProfil_Click);
            // 
            // labCopyright
            // 
            this.labCopyright.AutoSize = true;
            this.labCopyright.Font = new System.Drawing.Font("Constantia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCopyright.ForeColor = System.Drawing.Color.DimGray;
            this.labCopyright.Location = new System.Drawing.Point(906, 464);
            this.labCopyright.Name = "labCopyright";
            this.labCopyright.Size = new System.Drawing.Size(57, 14);
            this.labCopyright.TabIndex = 8;
            this.labCopyright.Text = "copyright";
            this.labCopyright.Click += new System.EventHandler(this.labCopyright_Click);
            // 
            // btnDecoAdmin
            // 
            this.btnDecoAdmin.Location = new System.Drawing.Point(847, 13);
            this.btnDecoAdmin.Name = "btnDecoAdmin";
            this.btnDecoAdmin.Size = new System.Drawing.Size(116, 33);
            this.btnDecoAdmin.TabIndex = 9;
            this.btnDecoAdmin.Text = "Déconnexion";
            this.btnDecoAdmin.UseVisualStyleBackColor = true;
            this.btnDecoAdmin.Click += new System.EventHandler(this.btnDecoAdmin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(331, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Onglet : ";
            // 
            // comboBOnglet
            // 
            this.comboBOnglet.FormattingEnabled = true;
            this.comboBOnglet.Items.AddRange(new object[] {
            "Accueil",
            "Tableau de bord",
            "Mon profil"});
            this.comboBOnglet.Location = new System.Drawing.Point(406, 20);
            this.comboBOnglet.Name = "comboBOnglet";
            this.comboBOnglet.Size = new System.Drawing.Size(167, 21);
            this.comboBOnglet.TabIndex = 13;
            this.comboBOnglet.SelectedIndexChanged += new System.EventHandler(this.comboBOnglet_SelectedIndexChanged);
            // 
            // groupBInfoProfil
            // 
            this.groupBInfoProfil.BackColor = System.Drawing.Color.Transparent;
            this.groupBInfoProfil.Controls.Add(this.labStatusAvertissement);
            this.groupBInfoProfil.Controls.Add(this.labNumPortUser);
            this.groupBInfoProfil.Controls.Add(this.labNumTelUser);
            this.groupBInfoProfil.Controls.Add(this.labNbAvertissementUser);
            this.groupBInfoProfil.Controls.Add(this.labDateInscriptionUser);
            this.groupBInfoProfil.Controls.Add(this.labPrenomUser);
            this.groupBInfoProfil.Controls.Add(this.labNomUser);
            this.groupBInfoProfil.Controls.Add(this.labMailUser);
            this.groupBInfoProfil.Controls.Add(this.labNbAvertissement);
            this.groupBInfoProfil.Controls.Add(this.labNumTel);
            this.groupBInfoProfil.Controls.Add(this.labNumPort);
            this.groupBInfoProfil.Controls.Add(this.labPrenom);
            this.groupBInfoProfil.Controls.Add(this.labDateInscription);
            this.groupBInfoProfil.Controls.Add(this.labNom);
            this.groupBInfoProfil.Controls.Add(this.labMel);
            this.groupBInfoProfil.ForeColor = System.Drawing.Color.Black;
            this.groupBInfoProfil.Location = new System.Drawing.Point(70, 100);
            this.groupBInfoProfil.Name = "groupBInfoProfil";
            this.groupBInfoProfil.Size = new System.Drawing.Size(409, 152);
            this.groupBInfoProfil.TabIndex = 8;
            this.groupBInfoProfil.TabStop = false;
            this.groupBInfoProfil.Text = "Mes informations";
            this.groupBInfoProfil.Enter += new System.EventHandler(this.groupBInfoProfil_Enter);
            // 
            // labNumPortUser
            // 
            this.labNumPortUser.AutoSize = true;
            this.labNumPortUser.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNumPortUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labNumPortUser.Location = new System.Drawing.Point(150, 124);
            this.labNumPortUser.Name = "labNumPortUser";
            this.labNumPortUser.Size = new System.Drawing.Size(103, 18);
            this.labNumPortUser.TabIndex = 22;
            this.labNumPortUser.Text = "Non renseigné";
            // 
            // labNumTelUser
            // 
            this.labNumTelUser.AutoSize = true;
            this.labNumTelUser.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNumTelUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labNumTelUser.Location = new System.Drawing.Point(163, 106);
            this.labNumTelUser.Name = "labNumTelUser";
            this.labNumTelUser.Size = new System.Drawing.Size(103, 18);
            this.labNumTelUser.TabIndex = 21;
            this.labNumTelUser.Text = "Non renseigné";
            // 
            // labNbAvertissementUser
            // 
            this.labNbAvertissementUser.AutoSize = true;
            this.labNbAvertissementUser.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNbAvertissementUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labNbAvertissementUser.Location = new System.Drawing.Point(197, 88);
            this.labNbAvertissementUser.Name = "labNbAvertissementUser";
            this.labNbAvertissementUser.Size = new System.Drawing.Size(18, 18);
            this.labNbAvertissementUser.TabIndex = 20;
            this.labNbAvertissementUser.Text = "-1";
            // 
            // labDateInscriptionUser
            // 
            this.labDateInscriptionUser.AutoSize = true;
            this.labDateInscriptionUser.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDateInscriptionUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labDateInscriptionUser.Location = new System.Drawing.Point(137, 70);
            this.labDateInscriptionUser.Name = "labDateInscriptionUser";
            this.labDateInscriptionUser.Size = new System.Drawing.Size(103, 18);
            this.labDateInscriptionUser.TabIndex = 18;
            this.labDateInscriptionUser.Text = "Non renseigné";
            // 
            // labPrenomUser
            // 
            this.labPrenomUser.AutoSize = true;
            this.labPrenomUser.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPrenomUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labPrenomUser.Location = new System.Drawing.Point(72, 52);
            this.labPrenomUser.Name = "labPrenomUser";
            this.labPrenomUser.Size = new System.Drawing.Size(103, 18);
            this.labPrenomUser.TabIndex = 17;
            this.labPrenomUser.Text = "Non renseigné";
            // 
            // labNomUser
            // 
            this.labNomUser.AutoSize = true;
            this.labNomUser.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNomUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labNomUser.Location = new System.Drawing.Point(122, 34);
            this.labNomUser.Name = "labNomUser";
            this.labNomUser.Size = new System.Drawing.Size(103, 18);
            this.labNomUser.TabIndex = 16;
            this.labNomUser.Text = "Non renseigné";
            // 
            // labMailUser
            // 
            this.labMailUser.AutoSize = true;
            this.labMailUser.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMailUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labMailUser.Location = new System.Drawing.Point(138, 16);
            this.labMailUser.Name = "labMailUser";
            this.labMailUser.Size = new System.Drawing.Size(103, 18);
            this.labMailUser.TabIndex = 15;
            this.labMailUser.Text = "Non renseigné";
            // 
            // labNbAvertissement
            // 
            this.labNbAvertissement.AutoSize = true;
            this.labNbAvertissement.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNbAvertissement.ForeColor = System.Drawing.Color.Black;
            this.labNbAvertissement.Location = new System.Drawing.Point(6, 88);
            this.labNbAvertissement.Name = "labNbAvertissement";
            this.labNbAvertissement.Size = new System.Drawing.Size(192, 18);
            this.labNbAvertissement.TabIndex = 14;
            this.labNbAvertissement.Text = "Nombre d\'avertissement(s) :";
            // 
            // labNumTel
            // 
            this.labNumTel.AutoSize = true;
            this.labNumTel.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNumTel.ForeColor = System.Drawing.Color.Black;
            this.labNumTel.Location = new System.Drawing.Point(6, 106);
            this.labNumTel.Name = "labNumTel";
            this.labNumTel.Size = new System.Drawing.Size(158, 18);
            this.labNumTel.TabIndex = 13;
            this.labNumTel.Text = "Numéro de téléphone :";
            // 
            // labNumPort
            // 
            this.labNumPort.AutoSize = true;
            this.labNumPort.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNumPort.ForeColor = System.Drawing.Color.Black;
            this.labNumPort.Location = new System.Drawing.Point(6, 124);
            this.labNumPort.Name = "labNumPort";
            this.labNumPort.Size = new System.Drawing.Size(147, 18);
            this.labNumPort.TabIndex = 12;
            this.labNumPort.Text = "Numéro de portable :";
            // 
            // labPrenom
            // 
            this.labPrenom.AutoSize = true;
            this.labPrenom.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPrenom.ForeColor = System.Drawing.Color.Black;
            this.labPrenom.Location = new System.Drawing.Point(6, 52);
            this.labPrenom.Name = "labPrenom";
            this.labPrenom.Size = new System.Drawing.Size(68, 18);
            this.labPrenom.TabIndex = 10;
            this.labPrenom.Text = "Prénom :";
            // 
            // labDateInscription
            // 
            this.labDateInscription.AutoSize = true;
            this.labDateInscription.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDateInscription.ForeColor = System.Drawing.Color.Black;
            this.labDateInscription.Location = new System.Drawing.Point(6, 70);
            this.labDateInscription.Name = "labDateInscription";
            this.labDateInscription.Size = new System.Drawing.Size(132, 18);
            this.labDateInscription.TabIndex = 9;
            this.labDateInscription.Text = "Date d\'inscription :";
            // 
            // labNom
            // 
            this.labNom.AutoSize = true;
            this.labNom.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNom.ForeColor = System.Drawing.Color.Black;
            this.labNom.Location = new System.Drawing.Point(6, 34);
            this.labNom.Name = "labNom";
            this.labNom.Size = new System.Drawing.Size(116, 18);
            this.labNom.TabIndex = 7;
            this.labNom.Text = "Nom de famille :";
            // 
            // labMel
            // 
            this.labMel.AutoSize = true;
            this.labMel.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMel.ForeColor = System.Drawing.Color.Black;
            this.labMel.Location = new System.Drawing.Point(6, 16);
            this.labMel.Name = "labMel";
            this.labMel.Size = new System.Drawing.Size(131, 18);
            this.labMel.TabIndex = 6;
            this.labMel.Text = "Mon adresse mail :";
            // 
            // labStatusAvertissement
            // 
            this.labStatusAvertissement.AutoSize = true;
            this.labStatusAvertissement.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labStatusAvertissement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labStatusAvertissement.Location = new System.Drawing.Point(221, 88);
            this.labStatusAvertissement.Name = "labStatusAvertissement";
            this.labStatusAvertissement.Size = new System.Drawing.Size(103, 18);
            this.labStatusAvertissement.TabIndex = 24;
            this.labStatusAvertissement.Text = "Non renseigné";
            // 
            // btnModifRubrique
            // 
            this.btnModifRubrique.Location = new System.Drawing.Point(325, 260);
            this.btnModifRubrique.Name = "btnModifRubrique";
            this.btnModifRubrique.Size = new System.Drawing.Size(154, 23);
            this.btnModifRubrique.TabIndex = 15;
            this.btnModifRubrique.Text = "Modifier mes informations";
            this.btnModifRubrique.UseVisualStyleBackColor = true;
            this.btnModifRubrique.Click += new System.EventHandler(this.btnModifRubrique_Click);
            // 
            // labWarning
            // 
            this.labWarning.AutoSize = true;
            this.labWarning.Font = new System.Drawing.Font("Constantia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labWarning.ForeColor = System.Drawing.Color.DimGray;
            this.labWarning.Location = new System.Drawing.Point(78, 100);
            this.labWarning.MaximumSize = new System.Drawing.Size(250, 0);
            this.labWarning.Name = "labWarning";
            this.labWarning.Size = new System.Drawing.Size(250, 42);
            this.labWarning.TabIndex = 16;
            this.labWarning.Text = "ATTENTION : vous ne pouvez modifier uniquement vos numéros de téléphone et de mob" +
    "ile !";
            this.labWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labWarning.Click += new System.EventHandler(this.labWarning_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Constantia", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(76, 260);
            this.label2.MaximumSize = new System.Drawing.Size(250, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 42);
            this.label2.TabIndex = 17;
            this.label2.Text = "Si vous remarquez une erreur dans vos informations, signaler le directement à l\'a" +
    "ccueil du village.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBModifInfoProfil
            // 
            this.groupBModifInfoProfil.BackColor = System.Drawing.Color.White;
            this.groupBModifInfoProfil.Controls.Add(this.txtBPortableUser);
            this.groupBModifInfoProfil.Controls.Add(this.labWarning);
            this.groupBModifInfoProfil.Controls.Add(this.txtBTelephoneUser);
            this.groupBModifInfoProfil.Controls.Add(this.label3);
            this.groupBModifInfoProfil.Controls.Add(this.label4);
            this.groupBModifInfoProfil.Controls.Add(this.btnAjoutUser);
            this.groupBModifInfoProfil.Location = new System.Drawing.Point(523, 100);
            this.groupBModifInfoProfil.Name = "groupBModifInfoProfil";
            this.groupBModifInfoProfil.Size = new System.Drawing.Size(387, 183);
            this.groupBModifInfoProfil.TabIndex = 18;
            this.groupBModifInfoProfil.TabStop = false;
            this.groupBModifInfoProfil.Text = "Modification de mes informations";
            this.groupBModifInfoProfil.Enter += new System.EventHandler(this.groupBModifInfoProfil_Enter);
            // 
            // txtBPortableUser
            // 
            this.txtBPortableUser.Location = new System.Drawing.Point(174, 55);
            this.txtBPortableUser.Name = "txtBPortableUser";
            this.txtBPortableUser.Size = new System.Drawing.Size(154, 20);
            this.txtBPortableUser.TabIndex = 12;
            // 
            // txtBTelephoneUser
            // 
            this.txtBTelephoneUser.Location = new System.Drawing.Point(174, 27);
            this.txtBTelephoneUser.Name = "txtBTelephoneUser";
            this.txtBTelephoneUser.Size = new System.Drawing.Size(154, 20);
            this.txtBTelephoneUser.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Numéro de portable :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Numéro de téléphone :";
            // 
            // btnAjoutUser
            // 
            this.btnAjoutUser.Location = new System.Drawing.Point(143, 148);
            this.btnAjoutUser.Name = "btnAjoutUser";
            this.btnAjoutUser.Size = new System.Drawing.Size(122, 23);
            this.btnAjoutUser.TabIndex = 0;
            this.btnAjoutUser.Text = "Modifier";
            this.btnAjoutUser.UseVisualStyleBackColor = true;
            this.btnAjoutUser.Click += new System.EventHandler(this.btnAjoutUser_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(482, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Les avis liés à l\'article selectionné :";
            // 
            // listBAvis
            // 
            this.listBAvis.FormattingEnabled = true;
            this.listBAvis.Location = new System.Drawing.Point(17, 134);
            this.listBAvis.Name = "listBAvis";
            this.listBAvis.Size = new System.Drawing.Size(430, 173);
            this.listBAvis.TabIndex = 11;
            this.listBAvis.SelectedIndexChanged += new System.EventHandler(this.listBAvis_SelectedIndexChanged);
            this.listBAvis.DoubleClick += new System.EventHandler(this.listBAvis_DoubleClick);
            // 
            // labArticles
            // 
            this.labArticles.AutoSize = true;
            this.labArticles.Location = new System.Drawing.Point(14, 118);
            this.labArticles.Name = "labArticles";
            this.labArticles.Size = new System.Drawing.Size(139, 13);
            this.labArticles.TabIndex = 10;
            this.labArticles.Text = "Les articles de l\'application :";
            // 
            // listBArticles
            // 
            this.listBArticles.FormattingEnabled = true;
            this.listBArticles.Location = new System.Drawing.Point(485, 134);
            this.listBArticles.Name = "listBArticles";
            this.listBArticles.Size = new System.Drawing.Size(442, 173);
            this.listBArticles.TabIndex = 9;
            this.listBArticles.DoubleClick += new System.EventHandler(this.listBArticles_DoubleClick);
            // 
            // FormPresseUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(982, 480);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDecoAdmin);
            this.Controls.Add(this.labCopyright);
            this.Controls.Add(this.comboBOnglet);
            this.Controls.Add(this.tabControlUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPresseUser";
            this.Text = "Journal - Tableau de bord";
            this.Load += new System.EventHandler(this.FormPresseUser_Load);
            this.tabControlUser.ResumeLayout(false);
            this.tabPDashboard.ResumeLayout(false);
            this.tabPDashboard.PerformLayout();
            this.tabPProfil.ResumeLayout(false);
            this.tabPProfil.PerformLayout();
            this.groupBInfoProfil.ResumeLayout(false);
            this.groupBInfoProfil.PerformLayout();
            this.groupBModifInfoProfil.ResumeLayout(false);
            this.groupBModifInfoProfil.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControlUser;
        private System.Windows.Forms.TabPage tabPAccueil;
        private System.Windows.Forms.TabPage tabPDashboard;
        private System.Windows.Forms.TabPage tabPProfil;
        private System.Windows.Forms.Label labCopyright;
        private System.Windows.Forms.Button btnDecoAdmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBOnglet;
        private System.Windows.Forms.GroupBox groupBInfoProfil;
        private System.Windows.Forms.Label labStatusAvertissement;
        private System.Windows.Forms.Label labNumPortUser;
        private System.Windows.Forms.Label labNumTelUser;
        private System.Windows.Forms.Label labNbAvertissementUser;
        private System.Windows.Forms.Label labDateInscriptionUser;
        private System.Windows.Forms.Label labPrenomUser;
        private System.Windows.Forms.Label labNomUser;
        private System.Windows.Forms.Label labMailUser;
        private System.Windows.Forms.Label labNbAvertissement;
        private System.Windows.Forms.Label labNumTel;
        private System.Windows.Forms.Label labNumPort;
        private System.Windows.Forms.Label labPrenom;
        private System.Windows.Forms.Label labDateInscription;
        private System.Windows.Forms.Label labNom;
        private System.Windows.Forms.Label labMel;
        private System.Windows.Forms.Button btnModifRubrique;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labWarning;
        private System.Windows.Forms.GroupBox groupBModifInfoProfil;
        private System.Windows.Forms.TextBox txtBPortableUser;
        private System.Windows.Forms.TextBox txtBTelephoneUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAjoutUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBAvis;
        private System.Windows.Forms.Label labArticles;
        private System.Windows.Forms.ListBox listBArticles;
    }
}