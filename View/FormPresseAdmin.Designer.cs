namespace PresseRESA
{
    partial class FormPresseAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPresseAdmin));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBOnglet = new System.Windows.Forms.ComboBox();
            this.tabControlAdmin = new System.Windows.Forms.TabControl();
            this.tabPUtilisateur = new System.Windows.Forms.TabPage();
            this.btnActualisationAdmin = new System.Windows.Forms.Button();
            this.btnAffichageUserMal = new System.Windows.Forms.Button();
            this.groupBModifUser = new System.Windows.Forms.GroupBox();
            this.btnAddAvertissement = new System.Windows.Forms.Button();
            this.labAddAvertissement = new System.Windows.Forms.Label();
            this.labFermetureCpte = new System.Windows.Forms.Label();
            this.btnFermetureCpte = new System.Windows.Forms.Button();
            this.groupBAjoutUser = new System.Windows.Forms.GroupBox();
            this.labTypeCpteUser = new System.Windows.Forms.Label();
            this.comboBTypeCpte = new System.Windows.Forms.ComboBox();
            this.labTitleAddUser = new System.Windows.Forms.Label();
            this.txtBPortableUser = new System.Windows.Forms.TextBox();
            this.txtBTelephoneUser = new System.Windows.Forms.TextBox();
            this.txtBPrenomUser = new System.Windows.Forms.TextBox();
            this.txtBNomUser = new System.Windows.Forms.TextBox();
            this.txtBAdrMailUser = new System.Windows.Forms.TextBox();
            this.labNumPortUser = new System.Windows.Forms.Label();
            this.labNumTelUser = new System.Windows.Forms.Label();
            this.labPrenomUser = new System.Windows.Forms.Label();
            this.labWarningMdp = new System.Windows.Forms.Label();
            this.labNomUser = new System.Windows.Forms.Label();
            this.labAdrMailUser = new System.Windows.Forms.Label();
            this.labWarningAsterisque = new System.Windows.Forms.Label();
            this.btnAjoutUser = new System.Windows.Forms.Button();
            this.labUsers = new System.Windows.Forms.Label();
            this.listBUsers = new System.Windows.Forms.ListBox();
            this.tabPArticle = new System.Windows.Forms.TabPage();
            this.groupBRubriqueArticle = new System.Windows.Forms.GroupBox();
            this.labRubriquesArticleSelect = new System.Windows.Forms.Label();
            this.labRubriquesDispo = new System.Windows.Forms.Label();
            this.listBRubriquesArticle = new System.Windows.Forms.ListBox();
            this.listBRubriquesDispo = new System.Windows.Forms.ListBox();
            this.btnResetRubrique = new System.Windows.Forms.Button();
            this.labTitleUpdateRubriqueArticle = new System.Windows.Forms.Label();
            this.btnAttribuerRubrique = new System.Windows.Forms.Button();
            this.groupBAffichageArticles = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioBArticleEnAttente = new System.Windows.Forms.RadioButton();
            this.labArticles = new System.Windows.Forms.Label();
            this.listBArticles = new System.Windows.Forms.ListBox();
            this.tabPAvis = new System.Windows.Forms.TabPage();
            this.tabPRubrique = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBNomRubrique = new System.Windows.Forms.TextBox();
            this.labNomRubrique = new System.Windows.Forms.Label();
            this.btnAddRubrique = new System.Windows.Forms.Button();
            this.labRubriques = new System.Windows.Forms.Label();
            this.listBRubriques = new System.Windows.Forms.ListBox();
            this.labCopyright = new System.Windows.Forms.Label();
            this.btnDecoAdmin = new System.Windows.Forms.Button();
            this.btnRechercheRubrique = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControlAdmin.SuspendLayout();
            this.tabPUtilisateur.SuspendLayout();
            this.groupBModifUser.SuspendLayout();
            this.groupBAjoutUser.SuspendLayout();
            this.tabPArticle.SuspendLayout();
            this.groupBRubriqueArticle.SuspendLayout();
            this.groupBAffichageArticles.SuspendLayout();
            this.tabPRubrique.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(324, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Onglet : ";
            // 
            // comboBOnglet
            // 
            this.comboBOnglet.FormattingEnabled = true;
            this.comboBOnglet.Items.AddRange(new object[] {
            "Gestion des utilisateurs",
            "Gestion des articles",
            "Gestion des avis",
            "Gestion des rubriques"});
            this.comboBOnglet.Location = new System.Drawing.Point(399, 12);
            this.comboBOnglet.Name = "comboBOnglet";
            this.comboBOnglet.Size = new System.Drawing.Size(245, 21);
            this.comboBOnglet.TabIndex = 5;
            this.comboBOnglet.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tabControlAdmin
            // 
            this.tabControlAdmin.Controls.Add(this.tabPUtilisateur);
            this.tabControlAdmin.Controls.Add(this.tabPArticle);
            this.tabControlAdmin.Controls.Add(this.tabPAvis);
            this.tabControlAdmin.Controls.Add(this.tabPRubrique);
            this.tabControlAdmin.Font = new System.Drawing.Font("Constantia", 9F);
            this.tabControlAdmin.Location = new System.Drawing.Point(12, 28);
            this.tabControlAdmin.Name = "tabControlAdmin";
            this.tabControlAdmin.SelectedIndex = 0;
            this.tabControlAdmin.Size = new System.Drawing.Size(1080, 476);
            this.tabControlAdmin.TabIndex = 4;
            // 
            // tabPUtilisateur
            // 
            this.tabPUtilisateur.Controls.Add(this.btnActualisationAdmin);
            this.tabPUtilisateur.Controls.Add(this.btnAffichageUserMal);
            this.tabPUtilisateur.Controls.Add(this.groupBModifUser);
            this.tabPUtilisateur.Controls.Add(this.groupBAjoutUser);
            this.tabPUtilisateur.Controls.Add(this.labUsers);
            this.tabPUtilisateur.Controls.Add(this.listBUsers);
            this.tabPUtilisateur.Location = new System.Drawing.Point(4, 23);
            this.tabPUtilisateur.Name = "tabPUtilisateur";
            this.tabPUtilisateur.Padding = new System.Windows.Forms.Padding(3);
            this.tabPUtilisateur.Size = new System.Drawing.Size(1072, 449);
            this.tabPUtilisateur.TabIndex = 0;
            this.tabPUtilisateur.Text = "Utilisateurs";
            this.tabPUtilisateur.UseVisualStyleBackColor = true;
            // 
            // btnActualisationAdmin
            // 
            this.btnActualisationAdmin.Location = new System.Drawing.Point(289, 4);
            this.btnActualisationAdmin.Name = "btnActualisationAdmin";
            this.btnActualisationAdmin.Size = new System.Drawing.Size(109, 23);
            this.btnActualisationAdmin.TabIndex = 9;
            this.btnActualisationAdmin.Text = "Actualiser la liste";
            this.btnActualisationAdmin.UseVisualStyleBackColor = true;
            this.btnActualisationAdmin.Click += new System.EventHandler(this.btnActualisationAdmin_Click);
            // 
            // btnAffichageUserMal
            // 
            this.btnAffichageUserMal.Location = new System.Drawing.Point(404, 4);
            this.btnAffichageUserMal.Name = "btnAffichageUserMal";
            this.btnAffichageUserMal.Size = new System.Drawing.Size(234, 23);
            this.btnAffichageUserMal.TabIndex = 10;
            this.btnAffichageUserMal.Text = "Voir les utilisateurs malveillants";
            this.btnAffichageUserMal.UseVisualStyleBackColor = true;
            this.btnAffichageUserMal.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBModifUser
            // 
            this.groupBModifUser.Controls.Add(this.btnAddAvertissement);
            this.groupBModifUser.Controls.Add(this.labAddAvertissement);
            this.groupBModifUser.Controls.Add(this.labFermetureCpte);
            this.groupBModifUser.Controls.Add(this.btnFermetureCpte);
            this.groupBModifUser.Location = new System.Drawing.Point(658, 340);
            this.groupBModifUser.Name = "groupBModifUser";
            this.groupBModifUser.Size = new System.Drawing.Size(388, 86);
            this.groupBModifUser.TabIndex = 5;
            this.groupBModifUser.TabStop = false;
            this.groupBModifUser.Text = "Sélection d\'un utilisateur";
            // 
            // btnAddAvertissement
            // 
            this.btnAddAvertissement.Location = new System.Drawing.Point(250, 48);
            this.btnAddAvertissement.Name = "btnAddAvertissement";
            this.btnAddAvertissement.Size = new System.Drawing.Size(122, 23);
            this.btnAddAvertissement.TabIndex = 6;
            this.btnAddAvertissement.Text = "Avertir";
            this.btnAddAvertissement.UseVisualStyleBackColor = true;
            this.btnAddAvertissement.Click += new System.EventHandler(this.btnAddAvertissement_Click);
            // 
            // labAddAvertissement
            // 
            this.labAddAvertissement.AutoSize = true;
            this.labAddAvertissement.Location = new System.Drawing.Point(35, 52);
            this.labAddAvertissement.Name = "labAddAvertissement";
            this.labAddAvertissement.Size = new System.Drawing.Size(215, 14);
            this.labAddAvertissement.TabIndex = 5;
            this.labAddAvertissement.Text = "Ajouter un avertissement à l\'utilisateur :";
            // 
            // labFermetureCpte
            // 
            this.labFermetureCpte.AutoSize = true;
            this.labFermetureCpte.Location = new System.Drawing.Point(6, 26);
            this.labFermetureCpte.Name = "labFermetureCpte";
            this.labFermetureCpte.Size = new System.Drawing.Size(244, 14);
            this.labFermetureCpte.TabIndex = 4;
            this.labFermetureCpte.Text = "Fermer le compte de l\'utilisateur selectionné :";
            // 
            // btnFermetureCpte
            // 
            this.btnFermetureCpte.Location = new System.Drawing.Point(250, 21);
            this.btnFermetureCpte.Name = "btnFermetureCpte";
            this.btnFermetureCpte.Size = new System.Drawing.Size(122, 24);
            this.btnFermetureCpte.TabIndex = 3;
            this.btnFermetureCpte.Text = "Clôturer";
            this.btnFermetureCpte.UseVisualStyleBackColor = true;
            this.btnFermetureCpte.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBAjoutUser
            // 
            this.groupBAjoutUser.Controls.Add(this.labTypeCpteUser);
            this.groupBAjoutUser.Controls.Add(this.comboBTypeCpte);
            this.groupBAjoutUser.Controls.Add(this.labTitleAddUser);
            this.groupBAjoutUser.Controls.Add(this.txtBPortableUser);
            this.groupBAjoutUser.Controls.Add(this.txtBTelephoneUser);
            this.groupBAjoutUser.Controls.Add(this.txtBPrenomUser);
            this.groupBAjoutUser.Controls.Add(this.txtBNomUser);
            this.groupBAjoutUser.Controls.Add(this.txtBAdrMailUser);
            this.groupBAjoutUser.Controls.Add(this.labNumPortUser);
            this.groupBAjoutUser.Controls.Add(this.labNumTelUser);
            this.groupBAjoutUser.Controls.Add(this.labPrenomUser);
            this.groupBAjoutUser.Controls.Add(this.labWarningMdp);
            this.groupBAjoutUser.Controls.Add(this.labNomUser);
            this.groupBAjoutUser.Controls.Add(this.labAdrMailUser);
            this.groupBAjoutUser.Controls.Add(this.labWarningAsterisque);
            this.groupBAjoutUser.Controls.Add(this.btnAjoutUser);
            this.groupBAjoutUser.Location = new System.Drawing.Point(659, 17);
            this.groupBAjoutUser.Name = "groupBAjoutUser";
            this.groupBAjoutUser.Size = new System.Drawing.Size(387, 307);
            this.groupBAjoutUser.TabIndex = 2;
            this.groupBAjoutUser.TabStop = false;
            this.groupBAjoutUser.Text = "Ajout d\'un utilisateur";
            this.groupBAjoutUser.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // labTypeCpteUser
            // 
            this.labTypeCpteUser.AutoSize = true;
            this.labTypeCpteUser.Location = new System.Drawing.Point(81, 204);
            this.labTypeCpteUser.Name = "labTypeCpteUser";
            this.labTypeCpteUser.Size = new System.Drawing.Size(96, 14);
            this.labTypeCpteUser.TabIndex = 14;
            this.labTypeCpteUser.Text = "Type de compte :";
            // 
            // comboBTypeCpte
            // 
            this.comboBTypeCpte.AutoCompleteCustomSource.AddRange(new string[] {
            "ADMIN",
            "USER"});
            this.comboBTypeCpte.FormattingEnabled = true;
            this.comboBTypeCpte.Items.AddRange(new object[] {
            "USER",
            "ADMIN"});
            this.comboBTypeCpte.Location = new System.Drawing.Point(178, 196);
            this.comboBTypeCpte.Name = "comboBTypeCpte";
            this.comboBTypeCpte.Size = new System.Drawing.Size(154, 22);
            this.comboBTypeCpte.TabIndex = 8;
            this.comboBTypeCpte.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // labTitleAddUser
            // 
            this.labTitleAddUser.AutoSize = true;
            this.labTitleAddUser.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitleAddUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.labTitleAddUser.Location = new System.Drawing.Point(121, 22);
            this.labTitleAddUser.Name = "labTitleAddUser";
            this.labTitleAddUser.Size = new System.Drawing.Size(174, 23);
            this.labTitleAddUser.TabIndex = 13;
            this.labTitleAddUser.Text = "Nouvel Utilisateur";
            // 
            // txtBPortableUser
            // 
            this.txtBPortableUser.Location = new System.Drawing.Point(178, 167);
            this.txtBPortableUser.Name = "txtBPortableUser";
            this.txtBPortableUser.Size = new System.Drawing.Size(154, 22);
            this.txtBPortableUser.TabIndex = 12;
            // 
            // txtBTelephoneUser
            // 
            this.txtBTelephoneUser.Location = new System.Drawing.Point(178, 139);
            this.txtBTelephoneUser.Name = "txtBTelephoneUser";
            this.txtBTelephoneUser.Size = new System.Drawing.Size(154, 22);
            this.txtBTelephoneUser.TabIndex = 11;
            // 
            // txtBPrenomUser
            // 
            this.txtBPrenomUser.Location = new System.Drawing.Point(178, 111);
            this.txtBPrenomUser.Name = "txtBPrenomUser";
            this.txtBPrenomUser.Size = new System.Drawing.Size(154, 22);
            this.txtBPrenomUser.TabIndex = 10;
            // 
            // txtBNomUser
            // 
            this.txtBNomUser.Location = new System.Drawing.Point(178, 82);
            this.txtBNomUser.Name = "txtBNomUser";
            this.txtBNomUser.Size = new System.Drawing.Size(154, 22);
            this.txtBNomUser.TabIndex = 9;
            // 
            // txtBAdrMailUser
            // 
            this.txtBAdrMailUser.Location = new System.Drawing.Point(178, 54);
            this.txtBAdrMailUser.Name = "txtBAdrMailUser";
            this.txtBAdrMailUser.Size = new System.Drawing.Size(154, 22);
            this.txtBAdrMailUser.TabIndex = 8;
            // 
            // labNumPortUser
            // 
            this.labNumPortUser.AutoSize = true;
            this.labNumPortUser.Location = new System.Drawing.Point(60, 175);
            this.labNumPortUser.Name = "labNumPortUser";
            this.labNumPortUser.Size = new System.Drawing.Size(119, 14);
            this.labNumPortUser.TabIndex = 7;
            this.labNumPortUser.Text = "Numéro de portable :";
            // 
            // labNumTelUser
            // 
            this.labNumTelUser.AutoSize = true;
            this.labNumTelUser.Location = new System.Drawing.Point(52, 147);
            this.labNumTelUser.Name = "labNumTelUser";
            this.labNumTelUser.Size = new System.Drawing.Size(127, 14);
            this.labNumTelUser.TabIndex = 6;
            this.labNumTelUser.Text = "Numéro de téléphone :";
            // 
            // labPrenomUser
            // 
            this.labPrenomUser.AutoSize = true;
            this.labPrenomUser.Location = new System.Drawing.Point(125, 118);
            this.labPrenomUser.Name = "labPrenomUser";
            this.labPrenomUser.Size = new System.Drawing.Size(54, 14);
            this.labPrenomUser.TabIndex = 5;
            this.labPrenomUser.Text = "Prénom :";
            // 
            // labWarningMdp
            // 
            this.labWarningMdp.AutoSize = true;
            this.labWarningMdp.Font = new System.Drawing.Font("Constantia", 9F, System.Drawing.FontStyle.Italic);
            this.labWarningMdp.ForeColor = System.Drawing.Color.Gray;
            this.labWarningMdp.Location = new System.Drawing.Point(96, 240);
            this.labWarningMdp.Name = "labWarningMdp";
            this.labWarningMdp.Size = new System.Drawing.Size(212, 14);
            this.labWarningMdp.TabIndex = 4;
            this.labWarningMdp.Text = "Un mot de passe provisoire sera attribué.";
            // 
            // labNomUser
            // 
            this.labNomUser.AutoSize = true;
            this.labNomUser.Location = new System.Drawing.Point(140, 90);
            this.labNomUser.Name = "labNomUser";
            this.labNomUser.Size = new System.Drawing.Size(38, 14);
            this.labNomUser.TabIndex = 3;
            this.labNomUser.Text = "Nom :";
            // 
            // labAdrMailUser
            // 
            this.labAdrMailUser.AutoSize = true;
            this.labAdrMailUser.Location = new System.Drawing.Point(96, 62);
            this.labAdrMailUser.Name = "labAdrMailUser";
            this.labAdrMailUser.Size = new System.Drawing.Size(81, 14);
            this.labAdrMailUser.TabIndex = 2;
            this.labAdrMailUser.Text = "Adresse Mail :";
            // 
            // labWarningAsterisque
            // 
            this.labWarningAsterisque.AutoSize = true;
            this.labWarningAsterisque.Font = new System.Drawing.Font("Constantia", 9F, System.Drawing.FontStyle.Italic);
            this.labWarningAsterisque.ForeColor = System.Drawing.Color.Gray;
            this.labWarningAsterisque.Location = new System.Drawing.Point(82, 253);
            this.labWarningAsterisque.Name = "labWarningAsterisque";
            this.labWarningAsterisque.Size = new System.Drawing.Size(250, 14);
            this.labWarningAsterisque.TabIndex = 1;
            this.labWarningAsterisque.Text = "Les champs avec un astérisque sont obligatoires.";
            // 
            // btnAjoutUser
            // 
            this.btnAjoutUser.Location = new System.Drawing.Point(143, 274);
            this.btnAjoutUser.Name = "btnAjoutUser";
            this.btnAjoutUser.Size = new System.Drawing.Size(122, 23);
            this.btnAjoutUser.TabIndex = 0;
            this.btnAjoutUser.Text = "Ajouter";
            this.btnAjoutUser.UseVisualStyleBackColor = true;
            this.btnAjoutUser.Click += new System.EventHandler(this.button2_Click);
            // 
            // labUsers
            // 
            this.labUsers.AutoSize = true;
            this.labUsers.Location = new System.Drawing.Point(14, 12);
            this.labUsers.Name = "labUsers";
            this.labUsers.Size = new System.Drawing.Size(174, 14);
            this.labUsers.TabIndex = 1;
            this.labUsers.Text = "Les utilisateurs de l\'application :";
            // 
            // listBUsers
            // 
            this.listBUsers.FormattingEnabled = true;
            this.listBUsers.ItemHeight = 14;
            this.listBUsers.Location = new System.Drawing.Point(16, 30);
            this.listBUsers.Name = "listBUsers";
            this.listBUsers.Size = new System.Drawing.Size(622, 396);
            this.listBUsers.TabIndex = 0;
            this.listBUsers.SelectedIndexChanged += new System.EventHandler(this.ListBUsers_DoubleClick);
            // 
            // tabPArticle
            // 
            this.tabPArticle.Controls.Add(this.groupBRubriqueArticle);
            this.tabPArticle.Controls.Add(this.groupBAffichageArticles);
            this.tabPArticle.Controls.Add(this.labArticles);
            this.tabPArticle.Controls.Add(this.listBArticles);
            this.tabPArticle.Location = new System.Drawing.Point(4, 23);
            this.tabPArticle.Name = "tabPArticle";
            this.tabPArticle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPArticle.Size = new System.Drawing.Size(1072, 449);
            this.tabPArticle.TabIndex = 1;
            this.tabPArticle.Text = "Articles";
            this.tabPArticle.UseVisualStyleBackColor = true;
            // 
            // groupBRubriqueArticle
            // 
            this.groupBRubriqueArticle.Controls.Add(this.labRubriquesArticleSelect);
            this.groupBRubriqueArticle.Controls.Add(this.labRubriquesDispo);
            this.groupBRubriqueArticle.Controls.Add(this.listBRubriquesArticle);
            this.groupBRubriqueArticle.Controls.Add(this.listBRubriquesDispo);
            this.groupBRubriqueArticle.Controls.Add(this.btnResetRubrique);
            this.groupBRubriqueArticle.Controls.Add(this.labTitleUpdateRubriqueArticle);
            this.groupBRubriqueArticle.Controls.Add(this.btnAttribuerRubrique);
            this.groupBRubriqueArticle.Location = new System.Drawing.Point(653, 31);
            this.groupBRubriqueArticle.Name = "groupBRubriqueArticle";
            this.groupBRubriqueArticle.Size = new System.Drawing.Size(398, 387);
            this.groupBRubriqueArticle.TabIndex = 4;
            this.groupBRubriqueArticle.TabStop = false;
            this.groupBRubriqueArticle.Text = "Attribution des rubriques";
            // 
            // labRubriquesArticleSelect
            // 
            this.labRubriquesArticleSelect.AutoSize = true;
            this.labRubriquesArticleSelect.Location = new System.Drawing.Point(17, 208);
            this.labRubriquesArticleSelect.Name = "labRubriquesArticleSelect";
            this.labRubriquesArticleSelect.Size = new System.Drawing.Size(205, 14);
            this.labRubriquesArticleSelect.TabIndex = 16;
            this.labRubriquesArticleSelect.Text = "Les rubriques de l\'article selectionné :";
            // 
            // labRubriquesDispo
            // 
            this.labRubriquesDispo.AutoSize = true;
            this.labRubriquesDispo.Location = new System.Drawing.Point(17, 56);
            this.labRubriquesDispo.Name = "labRubriquesDispo";
            this.labRubriquesDispo.Size = new System.Drawing.Size(148, 14);
            this.labRubriquesDispo.TabIndex = 5;
            this.labRubriquesDispo.Text = "Les rubriques disponibles :";
            // 
            // listBRubriquesArticle
            // 
            this.listBRubriquesArticle.FormattingEnabled = true;
            this.listBRubriquesArticle.ItemHeight = 14;
            this.listBRubriquesArticle.Location = new System.Drawing.Point(20, 225);
            this.listBRubriquesArticle.Name = "listBRubriquesArticle";
            this.listBRubriquesArticle.Size = new System.Drawing.Size(354, 116);
            this.listBRubriquesArticle.TabIndex = 15;
            this.listBRubriquesArticle.SelectedIndexChanged += new System.EventHandler(this.listBRubriquesArticle_SelectedIndexChanged);
            // 
            // listBRubriquesDispo
            // 
            this.listBRubriquesDispo.FormattingEnabled = true;
            this.listBRubriquesDispo.ItemHeight = 14;
            this.listBRubriquesDispo.Location = new System.Drawing.Point(20, 73);
            this.listBRubriquesDispo.Name = "listBRubriquesDispo";
            this.listBRubriquesDispo.Size = new System.Drawing.Size(354, 116);
            this.listBRubriquesDispo.TabIndex = 5;
            // 
            // btnResetRubrique
            // 
            this.btnResetRubrique.Location = new System.Drawing.Point(213, 354);
            this.btnResetRubrique.Name = "btnResetRubrique";
            this.btnResetRubrique.Size = new System.Drawing.Size(122, 23);
            this.btnResetRubrique.TabIndex = 14;
            this.btnResetRubrique.Text = "Réinitialiser";
            this.btnResetRubrique.UseVisualStyleBackColor = true;
            this.btnResetRubrique.Click += new System.EventHandler(this.btnResetRubrique_Click);
            // 
            // labTitleUpdateRubriqueArticle
            // 
            this.labTitleUpdateRubriqueArticle.AutoSize = true;
            this.labTitleUpdateRubriqueArticle.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitleUpdateRubriqueArticle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.labTitleUpdateRubriqueArticle.Location = new System.Drawing.Point(100, 24);
            this.labTitleUpdateRubriqueArticle.Name = "labTitleUpdateRubriqueArticle";
            this.labTitleUpdateRubriqueArticle.Size = new System.Drawing.Size(216, 23);
            this.labTitleUpdateRubriqueArticle.TabIndex = 13;
            this.labTitleUpdateRubriqueArticle.Text = "Rubrique(s) de l\'article";
            // 
            // btnAttribuerRubrique
            // 
            this.btnAttribuerRubrique.Location = new System.Drawing.Point(85, 354);
            this.btnAttribuerRubrique.Name = "btnAttribuerRubrique";
            this.btnAttribuerRubrique.Size = new System.Drawing.Size(122, 23);
            this.btnAttribuerRubrique.TabIndex = 0;
            this.btnAttribuerRubrique.Text = "Attribuer";
            this.btnAttribuerRubrique.UseVisualStyleBackColor = true;
            this.btnAttribuerRubrique.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // groupBAffichageArticles
            // 
            this.groupBAffichageArticles.Controls.Add(this.radioButton1);
            this.groupBAffichageArticles.Controls.Add(this.radioButton3);
            this.groupBAffichageArticles.Controls.Add(this.radioButton2);
            this.groupBAffichageArticles.Controls.Add(this.radioBArticleEnAttente);
            this.groupBAffichageArticles.Location = new System.Drawing.Point(368, 21);
            this.groupBAffichageArticles.Name = "groupBAffichageArticles";
            this.groupBAffichageArticles.Size = new System.Drawing.Size(270, 42);
            this.groupBAffichageArticles.TabIndex = 3;
            this.groupBAffichageArticles.TabStop = false;
            this.groupBAffichageArticles.Text = "Affichage des articles";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(201, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(66, 18);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.Text = "Réfusés";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(141, 19);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(62, 18);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Validés";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(49, 18);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Tous";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioBArticleEnAttente
            // 
            this.radioBArticleEnAttente.AutoSize = true;
            this.radioBArticleEnAttente.Location = new System.Drawing.Point(61, 19);
            this.radioBArticleEnAttente.Name = "radioBArticleEnAttente";
            this.radioBArticleEnAttente.Size = new System.Drawing.Size(79, 18);
            this.radioBArticleEnAttente.TabIndex = 0;
            this.radioBArticleEnAttente.Text = "En attente";
            this.radioBArticleEnAttente.UseVisualStyleBackColor = true;
            this.radioBArticleEnAttente.CheckedChanged += new System.EventHandler(this.radioBArticleEnAttente_CheckedChanged);
            // 
            // labArticles
            // 
            this.labArticles.AutoSize = true;
            this.labArticles.Location = new System.Drawing.Point(13, 54);
            this.labArticles.Name = "labArticles";
            this.labArticles.Size = new System.Drawing.Size(154, 14);
            this.labArticles.TabIndex = 2;
            this.labArticles.Text = "Les articles de l\'application :";
            // 
            // listBArticles
            // 
            this.listBArticles.FormattingEnabled = true;
            this.listBArticles.ItemHeight = 14;
            this.listBArticles.Location = new System.Drawing.Point(16, 70);
            this.listBArticles.Name = "listBArticles";
            this.listBArticles.Size = new System.Drawing.Size(622, 354);
            this.listBArticles.TabIndex = 0;
            this.listBArticles.SelectedIndexChanged += new System.EventHandler(this.listBArticles_SelectedIndexChanged_1);
            this.listBArticles.DoubleClick += new System.EventHandler(this.listBArticles_SelectedIndexChanged);
            // 
            // tabPAvis
            // 
            this.tabPAvis.Location = new System.Drawing.Point(4, 23);
            this.tabPAvis.Name = "tabPAvis";
            this.tabPAvis.Padding = new System.Windows.Forms.Padding(3);
            this.tabPAvis.Size = new System.Drawing.Size(1072, 449);
            this.tabPAvis.TabIndex = 2;
            this.tabPAvis.Text = "Avis";
            this.tabPAvis.UseVisualStyleBackColor = true;
            // 
            // tabPRubrique
            // 
            this.tabPRubrique.Controls.Add(this.groupBox1);
            this.tabPRubrique.Controls.Add(this.labRubriques);
            this.tabPRubrique.Controls.Add(this.listBRubriques);
            this.tabPRubrique.Location = new System.Drawing.Point(4, 23);
            this.tabPRubrique.Name = "tabPRubrique";
            this.tabPRubrique.Padding = new System.Windows.Forms.Padding(3);
            this.tabPRubrique.Size = new System.Drawing.Size(1072, 449);
            this.tabPRubrique.TabIndex = 3;
            this.tabPRubrique.Text = "Rubriques";
            this.tabPRubrique.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBNomRubrique);
            this.groupBox1.Controls.Add(this.btnRechercheRubrique);
            this.groupBox1.Controls.Add(this.labNomRubrique);
            this.groupBox1.Controls.Add(this.btnAddRubrique);
            this.groupBox1.Location = new System.Drawing.Point(160, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(698, 97);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestion des rubriques";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // txtBNomRubrique
            // 
            this.txtBNomRubrique.Location = new System.Drawing.Point(100, 48);
            this.txtBNomRubrique.Name = "txtBNomRubrique";
            this.txtBNomRubrique.Size = new System.Drawing.Size(154, 22);
            this.txtBNomRubrique.TabIndex = 9;
            // 
            // labNomRubrique
            // 
            this.labNomRubrique.AutoSize = true;
            this.labNomRubrique.Location = new System.Drawing.Point(56, 56);
            this.labNomRubrique.Name = "labNomRubrique";
            this.labNomRubrique.Size = new System.Drawing.Size(38, 14);
            this.labNomRubrique.TabIndex = 3;
            this.labNomRubrique.Text = "Nom :";
            // 
            // btnAddRubrique
            // 
            this.btnAddRubrique.Location = new System.Drawing.Point(276, 27);
            this.btnAddRubrique.Name = "btnAddRubrique";
            this.btnAddRubrique.Size = new System.Drawing.Size(122, 23);
            this.btnAddRubrique.TabIndex = 0;
            this.btnAddRubrique.Text = "Ajouter";
            this.btnAddRubrique.UseVisualStyleBackColor = true;
            this.btnAddRubrique.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // labRubriques
            // 
            this.labRubriques.AutoSize = true;
            this.labRubriques.Location = new System.Drawing.Point(19, 128);
            this.labRubriques.Name = "labRubriques";
            this.labRubriques.Size = new System.Drawing.Size(168, 14);
            this.labRubriques.TabIndex = 4;
            this.labRubriques.Text = "Les rubriques de l\'application :";
            // 
            // listBRubriques
            // 
            this.listBRubriques.FormattingEnabled = true;
            this.listBRubriques.ItemHeight = 14;
            this.listBRubriques.Location = new System.Drawing.Point(22, 145);
            this.listBRubriques.Name = "listBRubriques";
            this.listBRubriques.Size = new System.Drawing.Size(1021, 284);
            this.listBRubriques.TabIndex = 3;
            // 
            // labCopyright
            // 
            this.labCopyright.AutoSize = true;
            this.labCopyright.Font = new System.Drawing.Font("Constantia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCopyright.ForeColor = System.Drawing.Color.DimGray;
            this.labCopyright.Location = new System.Drawing.Point(1035, 513);
            this.labCopyright.Name = "labCopyright";
            this.labCopyright.Size = new System.Drawing.Size(57, 14);
            this.labCopyright.TabIndex = 7;
            this.labCopyright.Text = "copyright";
            // 
            // btnDecoAdmin
            // 
            this.btnDecoAdmin.Location = new System.Drawing.Point(924, 12);
            this.btnDecoAdmin.Name = "btnDecoAdmin";
            this.btnDecoAdmin.Size = new System.Drawing.Size(109, 23);
            this.btnDecoAdmin.TabIndex = 8;
            this.btnDecoAdmin.Text = "Déconnexion";
            this.btnDecoAdmin.UseVisualStyleBackColor = true;
            this.btnDecoAdmin.Click += new System.EventHandler(this.btnDecoAdmin_Click);
            // 
            // btnRechercheRubrique
            // 
            this.btnRechercheRubrique.Location = new System.Drawing.Point(276, 56);
            this.btnRechercheRubrique.Name = "btnRechercheRubrique";
            this.btnRechercheRubrique.Size = new System.Drawing.Size(202, 23);
            this.btnRechercheRubrique.TabIndex = 0;
            this.btnRechercheRubrique.Text = "Rechercher";
            this.btnRechercheRubrique.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(420, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Modifier";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.label3.Location = new System.Drawing.Point(120, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Rubrique";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(484, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(202, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Afficher toutes les rubriques";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(564, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Supprimer";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // FormPresseAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(1114, 534);
            this.ControlBox = false;
            this.Controls.Add(this.btnDecoAdmin);
            this.Controls.Add(this.labCopyright);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBOnglet);
            this.Controls.Add(this.tabControlAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPresseAdmin";
            this.Text = "Journal - Tableau de bord";
            this.tabControlAdmin.ResumeLayout(false);
            this.tabPUtilisateur.ResumeLayout(false);
            this.tabPUtilisateur.PerformLayout();
            this.groupBModifUser.ResumeLayout(false);
            this.groupBModifUser.PerformLayout();
            this.groupBAjoutUser.ResumeLayout(false);
            this.groupBAjoutUser.PerformLayout();
            this.tabPArticle.ResumeLayout(false);
            this.tabPArticle.PerformLayout();
            this.groupBRubriqueArticle.ResumeLayout(false);
            this.groupBRubriqueArticle.PerformLayout();
            this.groupBAffichageArticles.ResumeLayout(false);
            this.groupBAffichageArticles.PerformLayout();
            this.tabPRubrique.ResumeLayout(false);
            this.tabPRubrique.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBOnglet;
        private System.Windows.Forms.TabControl tabControlAdmin;
        private System.Windows.Forms.TabPage tabPUtilisateur;
        private System.Windows.Forms.TabPage tabPArticle;
        private System.Windows.Forms.TabPage tabPAvis;
        private System.Windows.Forms.TabPage tabPRubrique;
        private System.Windows.Forms.Label labCopyright;
        private System.Windows.Forms.Label labUsers;
        private System.Windows.Forms.ListBox listBUsers;
        private System.Windows.Forms.Button btnFermetureCpte;
        private System.Windows.Forms.GroupBox groupBAjoutUser;
        private System.Windows.Forms.Label labFermetureCpte;
        private System.Windows.Forms.Button btnAjoutUser;
        private System.Windows.Forms.Label labWarningMdp;
        private System.Windows.Forms.Label labNomUser;
        private System.Windows.Forms.Label labAdrMailUser;
        private System.Windows.Forms.Label labWarningAsterisque;
        private System.Windows.Forms.GroupBox groupBModifUser;
        private System.Windows.Forms.TextBox txtBPrenomUser;
        private System.Windows.Forms.TextBox txtBNomUser;
        private System.Windows.Forms.TextBox txtBAdrMailUser;
        private System.Windows.Forms.Label labNumPortUser;
        private System.Windows.Forms.Label labNumTelUser;
        private System.Windows.Forms.Label labPrenomUser;
        private System.Windows.Forms.Label labAddAvertissement;
        private System.Windows.Forms.Button btnAddAvertissement;
        private System.Windows.Forms.Label labTitleAddUser;
        private System.Windows.Forms.TextBox txtBPortableUser;
        private System.Windows.Forms.TextBox txtBTelephoneUser;
        private System.Windows.Forms.Label labTypeCpteUser;
        private System.Windows.Forms.ComboBox comboBTypeCpte;
        private System.Windows.Forms.Button btnDecoAdmin;
        private System.Windows.Forms.Button btnActualisationAdmin;
        private System.Windows.Forms.Button btnAffichageUserMal;
        private System.Windows.Forms.Label labArticles;
        private System.Windows.Forms.ListBox listBArticles;
        private System.Windows.Forms.GroupBox groupBAffichageArticles;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioBArticleEnAttente;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBRubriqueArticle;
        private System.Windows.Forms.Label labRubriquesArticleSelect;
        private System.Windows.Forms.Label labRubriquesDispo;
        private System.Windows.Forms.ListBox listBRubriquesArticle;
        private System.Windows.Forms.ListBox listBRubriquesDispo;
        private System.Windows.Forms.Button btnResetRubrique;
        private System.Windows.Forms.Label labTitleUpdateRubriqueArticle;
        private System.Windows.Forms.Button btnAttribuerRubrique;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBNomRubrique;
        private System.Windows.Forms.Label labNomRubrique;
        private System.Windows.Forms.Button btnAddRubrique;
        private System.Windows.Forms.Label labRubriques;
        private System.Windows.Forms.ListBox listBRubriques;
        private System.Windows.Forms.Button btnRechercheRubrique;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}