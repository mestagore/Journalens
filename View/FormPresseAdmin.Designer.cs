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
            this.labCopyright = new System.Windows.Forms.Label();
            this.btnDecoAdmin = new System.Windows.Forms.Button();
            this.tabPRubrique = new System.Windows.Forms.TabPage();
            this.groupBRubriques = new System.Windows.Forms.GroupBox();
            this.btnDeleteRubrique = new System.Windows.Forms.Button();
            this.btnModifRubrique = new System.Windows.Forms.Button();
            this.labTitleRubrique = new System.Windows.Forms.Label();
            this.txtBNomRubrique = new System.Windows.Forms.TextBox();
            this.btnRechercheRubrique = new System.Windows.Forms.Button();
            this.labNomRubrique = new System.Windows.Forms.Label();
            this.btnAddRubrique = new System.Windows.Forms.Button();
            this.labRubriques = new System.Windows.Forms.Label();
            this.listBRubriques = new System.Windows.Forms.ListBox();
            this.tabPArticle = new System.Windows.Forms.TabPage();
            this.groupBFiltrageArticle = new System.Windows.Forms.GroupBox();
            this.btnFiltrageArticle = new System.Windows.Forms.Button();
            this.txtBAuteurArticle = new System.Windows.Forms.TextBox();
            this.labAuteurArticle = new System.Windows.Forms.Label();
            this.txtBIdArticle = new System.Windows.Forms.TextBox();
            this.labIdArticle = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBAvis = new System.Windows.Forms.ListBox();
            this.groupBRubriqueArticle = new System.Windows.Forms.GroupBox();
            this.btnRecherche = new System.Windows.Forms.Button();
            this.txtBNomRechercheRubrique = new System.Windows.Forms.TextBox();
            this.labNomRechercheRubrique = new System.Windows.Forms.Label();
            this.labRubriquesArticleSelect = new System.Windows.Forms.Label();
            this.labRubriquesDispo = new System.Windows.Forms.Label();
            this.listBRubriquesArticle = new System.Windows.Forms.ListBox();
            this.listBRubriquesDispo = new System.Windows.Forms.ListBox();
            this.btnResetRubrique = new System.Windows.Forms.Button();
            this.labTitleUpdateRubriqueArticle = new System.Windows.Forms.Label();
            this.btnAttribuerRubrique = new System.Windows.Forms.Button();
            this.groupBAffichageArticles = new System.Windows.Forms.GroupBox();
            this.radioBArticleRefus = new System.Windows.Forms.RadioButton();
            this.radioBArticleValide = new System.Windows.Forms.RadioButton();
            this.radioBAllArticle = new System.Windows.Forms.RadioButton();
            this.radioBArticleEnAttente = new System.Windows.Forms.RadioButton();
            this.labArticles = new System.Windows.Forms.Label();
            this.listBArticles = new System.Windows.Forms.ListBox();
            this.tabPUtilisateur = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBUsersAvertissement = new System.Windows.Forms.RadioButton();
            this.radioBUsersBloque = new System.Windows.Forms.RadioButton();
            this.radioBAllUsers = new System.Windows.Forms.RadioButton();
            this.radioBGoodUsers = new System.Windows.Forms.RadioButton();
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
            this.tabControlAdmin = new System.Windows.Forms.TabControl();
            this.tabPRubrique.SuspendLayout();
            this.groupBRubriques.SuspendLayout();
            this.tabPArticle.SuspendLayout();
            this.groupBFiltrageArticle.SuspendLayout();
            this.groupBRubriqueArticle.SuspendLayout();
            this.groupBAffichageArticles.SuspendLayout();
            this.tabPUtilisateur.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBAjoutUser.SuspendLayout();
            this.tabControlAdmin.SuspendLayout();
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
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBOnglet
            // 
            this.comboBOnglet.FormattingEnabled = true;
            this.comboBOnglet.Items.AddRange(new object[] {
            "Gestion des utilisateurs",
            "Gestion des articles",
            "Gestion des rubriques"});
            this.comboBOnglet.Location = new System.Drawing.Point(399, 12);
            this.comboBOnglet.Name = "comboBOnglet";
            this.comboBOnglet.Size = new System.Drawing.Size(245, 21);
            this.comboBOnglet.TabIndex = 5;
            this.comboBOnglet.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
            this.btnDecoAdmin.Location = new System.Drawing.Point(967, 9);
            this.btnDecoAdmin.Name = "btnDecoAdmin";
            this.btnDecoAdmin.Size = new System.Drawing.Size(116, 33);
            this.btnDecoAdmin.TabIndex = 8;
            this.btnDecoAdmin.Text = "Déconnexion";
            this.btnDecoAdmin.UseVisualStyleBackColor = true;
            this.btnDecoAdmin.Click += new System.EventHandler(this.btnDecoAdmin_Click);
            // 
            // tabPRubrique
            // 
            this.tabPRubrique.Controls.Add(this.groupBRubriques);
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
            // groupBRubriques
            // 
            this.groupBRubriques.Controls.Add(this.btnDeleteRubrique);
            this.groupBRubriques.Controls.Add(this.btnModifRubrique);
            this.groupBRubriques.Controls.Add(this.labTitleRubrique);
            this.groupBRubriques.Controls.Add(this.txtBNomRubrique);
            this.groupBRubriques.Controls.Add(this.btnRechercheRubrique);
            this.groupBRubriques.Controls.Add(this.labNomRubrique);
            this.groupBRubriques.Controls.Add(this.btnAddRubrique);
            this.groupBRubriques.Location = new System.Drawing.Point(280, 288);
            this.groupBRubriques.Name = "groupBRubriques";
            this.groupBRubriques.Size = new System.Drawing.Size(526, 141);
            this.groupBRubriques.TabIndex = 5;
            this.groupBRubriques.TabStop = false;
            this.groupBRubriques.Text = "Gestion des rubriques";
            this.groupBRubriques.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // btnDeleteRubrique
            // 
            this.btnDeleteRubrique.Location = new System.Drawing.Point(350, 74);
            this.btnDeleteRubrique.Name = "btnDeleteRubrique";
            this.btnDeleteRubrique.Size = new System.Drawing.Size(122, 23);
            this.btnDeleteRubrique.TabIndex = 16;
            this.btnDeleteRubrique.Text = "Supprimer";
            this.btnDeleteRubrique.UseVisualStyleBackColor = true;
            this.btnDeleteRubrique.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnModifRubrique
            // 
            this.btnModifRubrique.Location = new System.Drawing.Point(206, 74);
            this.btnModifRubrique.Name = "btnModifRubrique";
            this.btnModifRubrique.Size = new System.Drawing.Size(122, 23);
            this.btnModifRubrique.TabIndex = 14;
            this.btnModifRubrique.Text = "Modifier";
            this.btnModifRubrique.UseVisualStyleBackColor = true;
            this.btnModifRubrique.Click += new System.EventHandler(this.button1_Click_4);
            // 
            // labTitleRubrique
            // 
            this.labTitleRubrique.AutoSize = true;
            this.labTitleRubrique.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitleRubrique.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.labTitleRubrique.Location = new System.Drawing.Point(226, 20);
            this.labTitleRubrique.Name = "labTitleRubrique";
            this.labTitleRubrique.Size = new System.Drawing.Size(95, 23);
            this.labTitleRubrique.TabIndex = 13;
            this.labTitleRubrique.Text = "Rubrique";
            // 
            // txtBNomRubrique
            // 
            this.txtBNomRubrique.Location = new System.Drawing.Point(230, 46);
            this.txtBNomRubrique.Name = "txtBNomRubrique";
            this.txtBNomRubrique.Size = new System.Drawing.Size(200, 22);
            this.txtBNomRubrique.TabIndex = 9;
            // 
            // btnRechercheRubrique
            // 
            this.btnRechercheRubrique.Location = new System.Drawing.Point(170, 103);
            this.btnRechercheRubrique.Name = "btnRechercheRubrique";
            this.btnRechercheRubrique.Size = new System.Drawing.Size(202, 23);
            this.btnRechercheRubrique.TabIndex = 0;
            this.btnRechercheRubrique.Text = "Rechercher";
            this.btnRechercheRubrique.UseVisualStyleBackColor = true;
            this.btnRechercheRubrique.Click += new System.EventHandler(this.btnRechercheRubrique_Click);
            // 
            // labNomRubrique
            // 
            this.labNomRubrique.AutoSize = true;
            this.labNomRubrique.Location = new System.Drawing.Point(108, 49);
            this.labNomRubrique.Name = "labNomRubrique";
            this.labNomRubrique.Size = new System.Drawing.Size(116, 14);
            this.labNomRubrique.TabIndex = 3;
            this.labNomRubrique.Text = "Nom de la rubrique :";
            // 
            // btnAddRubrique
            // 
            this.btnAddRubrique.Location = new System.Drawing.Point(62, 74);
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
            this.labRubriques.Location = new System.Drawing.Point(277, 25);
            this.labRubriques.Name = "labRubriques";
            this.labRubriques.Size = new System.Drawing.Size(168, 14);
            this.labRubriques.TabIndex = 4;
            this.labRubriques.Text = "Les rubriques de l\'application :";
            // 
            // listBRubriques
            // 
            this.listBRubriques.FormattingEnabled = true;
            this.listBRubriques.ItemHeight = 14;
            this.listBRubriques.Location = new System.Drawing.Point(280, 42);
            this.listBRubriques.Name = "listBRubriques";
            this.listBRubriques.Size = new System.Drawing.Size(526, 228);
            this.listBRubriques.TabIndex = 3;
            this.listBRubriques.SelectedIndexChanged += new System.EventHandler(this.listBRubriques_SelectedIndexChanged);
            // 
            // tabPArticle
            // 
            this.tabPArticle.Controls.Add(this.groupBFiltrageArticle);
            this.tabPArticle.Controls.Add(this.label4);
            this.tabPArticle.Controls.Add(this.listBAvis);
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
            // groupBFiltrageArticle
            // 
            this.groupBFiltrageArticle.Controls.Add(this.btnFiltrageArticle);
            this.groupBFiltrageArticle.Controls.Add(this.txtBAuteurArticle);
            this.groupBFiltrageArticle.Controls.Add(this.labAuteurArticle);
            this.groupBFiltrageArticle.Controls.Add(this.txtBIdArticle);
            this.groupBFiltrageArticle.Controls.Add(this.labIdArticle);
            this.groupBFiltrageArticle.Location = new System.Drawing.Point(383, 6);
            this.groupBFiltrageArticle.Name = "groupBFiltrageArticle";
            this.groupBFiltrageArticle.Size = new System.Drawing.Size(669, 45);
            this.groupBFiltrageArticle.TabIndex = 4;
            this.groupBFiltrageArticle.TabStop = false;
            this.groupBFiltrageArticle.Text = "Filtrage des articles";
            // 
            // btnFiltrageArticle
            // 
            this.btnFiltrageArticle.Location = new System.Drawing.Point(527, 15);
            this.btnFiltrageArticle.Name = "btnFiltrageArticle";
            this.btnFiltrageArticle.Size = new System.Drawing.Size(122, 23);
            this.btnFiltrageArticle.TabIndex = 20;
            this.btnFiltrageArticle.Text = "Filtrer";
            this.btnFiltrageArticle.UseVisualStyleBackColor = true;
            this.btnFiltrageArticle.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // txtBAuteurArticle
            // 
            this.txtBAuteurArticle.Location = new System.Drawing.Point(304, 15);
            this.txtBAuteurArticle.Name = "txtBAuteurArticle";
            this.txtBAuteurArticle.Size = new System.Drawing.Size(154, 22);
            this.txtBAuteurArticle.TabIndex = 12;
            // 
            // labAuteurArticle
            // 
            this.labAuteurArticle.AutoSize = true;
            this.labAuteurArticle.Location = new System.Drawing.Point(248, 19);
            this.labAuteurArticle.Name = "labAuteurArticle";
            this.labAuteurArticle.Size = new System.Drawing.Size(50, 14);
            this.labAuteurArticle.TabIndex = 11;
            this.labAuteurArticle.Text = "Auteur :";
            // 
            // txtBIdArticle
            // 
            this.txtBIdArticle.Location = new System.Drawing.Point(80, 15);
            this.txtBIdArticle.Name = "txtBIdArticle";
            this.txtBIdArticle.Size = new System.Drawing.Size(154, 22);
            this.txtBIdArticle.TabIndex = 10;
            // 
            // labIdArticle
            // 
            this.labIdArticle.AutoSize = true;
            this.labIdArticle.Location = new System.Drawing.Point(12, 21);
            this.labIdArticle.Name = "labIdArticle";
            this.labIdArticle.Size = new System.Drawing.Size(62, 14);
            this.labIdArticle.TabIndex = 9;
            this.labIdArticle.Text = "Article n° :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Les avis liés à l\'article selectionné :";
            // 
            // listBAvis
            // 
            this.listBAvis.FormattingEnabled = true;
            this.listBAvis.ItemHeight = 14;
            this.listBAvis.Location = new System.Drawing.Point(240, 70);
            this.listBAvis.Name = "listBAvis";
            this.listBAvis.Size = new System.Drawing.Size(408, 354);
            this.listBAvis.TabIndex = 7;
            this.listBAvis.SelectedIndexChanged += new System.EventHandler(this.listBAvis_SelectedIndexChanged);
            this.listBAvis.DoubleClick += new System.EventHandler(this.listBAvis_DoubleClick);
            // 
            // groupBRubriqueArticle
            // 
            this.groupBRubriqueArticle.Controls.Add(this.btnRecherche);
            this.groupBRubriqueArticle.Controls.Add(this.txtBNomRechercheRubrique);
            this.groupBRubriqueArticle.Controls.Add(this.labNomRechercheRubrique);
            this.groupBRubriqueArticle.Controls.Add(this.labRubriquesArticleSelect);
            this.groupBRubriqueArticle.Controls.Add(this.labRubriquesDispo);
            this.groupBRubriqueArticle.Controls.Add(this.listBRubriquesArticle);
            this.groupBRubriqueArticle.Controls.Add(this.listBRubriquesDispo);
            this.groupBRubriqueArticle.Controls.Add(this.btnResetRubrique);
            this.groupBRubriqueArticle.Controls.Add(this.labTitleUpdateRubriqueArticle);
            this.groupBRubriqueArticle.Controls.Add(this.btnAttribuerRubrique);
            this.groupBRubriqueArticle.Location = new System.Drawing.Point(660, 54);
            this.groupBRubriqueArticle.Name = "groupBRubriqueArticle";
            this.groupBRubriqueArticle.Size = new System.Drawing.Size(398, 380);
            this.groupBRubriqueArticle.TabIndex = 4;
            this.groupBRubriqueArticle.TabStop = false;
            this.groupBRubriqueArticle.Text = "Attribution des rubriques à un article";
            this.groupBRubriqueArticle.Enter += new System.EventHandler(this.groupBRubriqueArticle_Enter);
            // 
            // btnRecherche
            // 
            this.btnRecherche.Location = new System.Drawing.Point(217, 46);
            this.btnRecherche.Name = "btnRecherche";
            this.btnRecherche.Size = new System.Drawing.Size(161, 23);
            this.btnRecherche.TabIndex = 19;
            this.btnRecherche.Text = "Rechercher";
            this.btnRecherche.UseVisualStyleBackColor = true;
            this.btnRecherche.Click += new System.EventHandler(this.btnRecherche_Click);
            // 
            // txtBNomRechercheRubrique
            // 
            this.txtBNomRechercheRubrique.Location = new System.Drawing.Point(57, 46);
            this.txtBNomRechercheRubrique.Name = "txtBNomRechercheRubrique";
            this.txtBNomRechercheRubrique.Size = new System.Drawing.Size(154, 22);
            this.txtBNomRechercheRubrique.TabIndex = 18;
            // 
            // labNomRechercheRubrique
            // 
            this.labNomRechercheRubrique.AutoSize = true;
            this.labNomRechercheRubrique.Location = new System.Drawing.Point(21, 54);
            this.labNomRechercheRubrique.Name = "labNomRechercheRubrique";
            this.labNomRechercheRubrique.Size = new System.Drawing.Size(38, 14);
            this.labNomRechercheRubrique.TabIndex = 17;
            this.labNomRechercheRubrique.Text = "Nom :";
            // 
            // labRubriquesArticleSelect
            // 
            this.labRubriquesArticleSelect.AutoSize = true;
            this.labRubriquesArticleSelect.Location = new System.Drawing.Point(21, 215);
            this.labRubriquesArticleSelect.Name = "labRubriquesArticleSelect";
            this.labRubriquesArticleSelect.Size = new System.Drawing.Size(205, 14);
            this.labRubriquesArticleSelect.TabIndex = 16;
            this.labRubriquesArticleSelect.Text = "Les rubriques de l\'article selectionné :";
            // 
            // labRubriquesDispo
            // 
            this.labRubriquesDispo.AutoSize = true;
            this.labRubriquesDispo.Location = new System.Drawing.Point(21, 75);
            this.labRubriquesDispo.Name = "labRubriquesDispo";
            this.labRubriquesDispo.Size = new System.Drawing.Size(148, 14);
            this.labRubriquesDispo.TabIndex = 5;
            this.labRubriquesDispo.Text = "Les rubriques disponibles :";
            // 
            // listBRubriquesArticle
            // 
            this.listBRubriquesArticle.FormattingEnabled = true;
            this.listBRubriquesArticle.ItemHeight = 14;
            this.listBRubriquesArticle.Location = new System.Drawing.Point(24, 232);
            this.listBRubriquesArticle.Name = "listBRubriquesArticle";
            this.listBRubriquesArticle.Size = new System.Drawing.Size(354, 116);
            this.listBRubriquesArticle.TabIndex = 15;
            this.listBRubriquesArticle.SelectedIndexChanged += new System.EventHandler(this.listBRubriquesArticle_SelectedIndexChanged);
            // 
            // listBRubriquesDispo
            // 
            this.listBRubriquesDispo.FormattingEnabled = true;
            this.listBRubriquesDispo.ItemHeight = 14;
            this.listBRubriquesDispo.Location = new System.Drawing.Point(24, 92);
            this.listBRubriquesDispo.Name = "listBRubriquesDispo";
            this.listBRubriquesDispo.Size = new System.Drawing.Size(354, 116);
            this.listBRubriquesDispo.TabIndex = 5;
            // 
            // btnResetRubrique
            // 
            this.btnResetRubrique.Location = new System.Drawing.Point(217, 352);
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
            this.labTitleUpdateRubriqueArticle.Location = new System.Drawing.Point(100, 20);
            this.labTitleUpdateRubriqueArticle.Name = "labTitleUpdateRubriqueArticle";
            this.labTitleUpdateRubriqueArticle.Size = new System.Drawing.Size(216, 23);
            this.labTitleUpdateRubriqueArticle.TabIndex = 13;
            this.labTitleUpdateRubriqueArticle.Text = "Rubrique(s) de l\'article";
            // 
            // btnAttribuerRubrique
            // 
            this.btnAttribuerRubrique.Location = new System.Drawing.Point(89, 352);
            this.btnAttribuerRubrique.Name = "btnAttribuerRubrique";
            this.btnAttribuerRubrique.Size = new System.Drawing.Size(122, 23);
            this.btnAttribuerRubrique.TabIndex = 0;
            this.btnAttribuerRubrique.Text = "Attribuer";
            this.btnAttribuerRubrique.UseVisualStyleBackColor = true;
            this.btnAttribuerRubrique.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // groupBAffichageArticles
            // 
            this.groupBAffichageArticles.Controls.Add(this.radioBArticleRefus);
            this.groupBAffichageArticles.Controls.Add(this.radioBArticleValide);
            this.groupBAffichageArticles.Controls.Add(this.radioBAllArticle);
            this.groupBAffichageArticles.Controls.Add(this.radioBArticleEnAttente);
            this.groupBAffichageArticles.Location = new System.Drawing.Point(16, 6);
            this.groupBAffichageArticles.Name = "groupBAffichageArticles";
            this.groupBAffichageArticles.Size = new System.Drawing.Size(361, 45);
            this.groupBAffichageArticles.TabIndex = 3;
            this.groupBAffichageArticles.TabStop = false;
            this.groupBAffichageArticles.Text = "Affichage des articles";
            // 
            // radioBArticleRefus
            // 
            this.radioBArticleRefus.AutoSize = true;
            this.radioBArticleRefus.Location = new System.Drawing.Point(219, 19);
            this.radioBArticleRefus.Name = "radioBArticleRefus";
            this.radioBArticleRefus.Size = new System.Drawing.Size(66, 18);
            this.radioBArticleRefus.TabIndex = 3;
            this.radioBArticleRefus.Text = "Réfusés";
            this.radioBArticleRefus.UseVisualStyleBackColor = true;
            this.radioBArticleRefus.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioBArticleValide
            // 
            this.radioBArticleValide.AutoSize = true;
            this.radioBArticleValide.Location = new System.Drawing.Point(149, 19);
            this.radioBArticleValide.Name = "radioBArticleValide";
            this.radioBArticleValide.Size = new System.Drawing.Size(62, 18);
            this.radioBArticleValide.TabIndex = 2;
            this.radioBArticleValide.Text = "Validés";
            this.radioBArticleValide.UseVisualStyleBackColor = true;
            this.radioBArticleValide.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioBAllArticle
            // 
            this.radioBAllArticle.AutoSize = true;
            this.radioBAllArticle.Checked = true;
            this.radioBAllArticle.Location = new System.Drawing.Point(6, 19);
            this.radioBAllArticle.Name = "radioBAllArticle";
            this.radioBAllArticle.Size = new System.Drawing.Size(49, 18);
            this.radioBAllArticle.TabIndex = 1;
            this.radioBAllArticle.TabStop = true;
            this.radioBAllArticle.Text = "Tous";
            this.radioBAllArticle.UseVisualStyleBackColor = true;
            this.radioBAllArticle.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioBArticleEnAttente
            // 
            this.radioBArticleEnAttente.AutoSize = true;
            this.radioBArticleEnAttente.Location = new System.Drawing.Point(65, 19);
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
            this.listBArticles.Size = new System.Drawing.Size(212, 354);
            this.listBArticles.TabIndex = 0;
            this.listBArticles.SelectedIndexChanged += new System.EventHandler(this.listBArticles_SelectedIndexChanged_1);
            this.listBArticles.DoubleClick += new System.EventHandler(this.listBArticles_SelectedIndexChanged);
            // 
            // tabPUtilisateur
            // 
            this.tabPUtilisateur.Controls.Add(this.groupBox1);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBUsersAvertissement);
            this.groupBox1.Controls.Add(this.radioBUsersBloque);
            this.groupBox1.Controls.Add(this.radioBAllUsers);
            this.groupBox1.Controls.Add(this.radioBGoodUsers);
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 45);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Affichage des utilisateurs";
            // 
            // radioBUsersAvertissement
            // 
            this.radioBUsersAvertissement.AutoSize = true;
            this.radioBUsersAvertissement.Location = new System.Drawing.Point(217, 19);
            this.radioBUsersAvertissement.Name = "radioBUsersAvertissement";
            this.radioBUsersAvertissement.Size = new System.Drawing.Size(242, 18);
            this.radioBUsersAvertissement.TabIndex = 3;
            this.radioBUsersAvertissement.Text = "Nombre maximal d\'avertissements atteint";
            this.radioBUsersAvertissement.UseVisualStyleBackColor = true;
            this.radioBUsersAvertissement.CheckedChanged += new System.EventHandler(this.radioBUsersAvertissement_CheckedChanged);
            // 
            // radioBUsersBloque
            // 
            this.radioBUsersBloque.AutoSize = true;
            this.radioBUsersBloque.Location = new System.Drawing.Point(465, 19);
            this.radioBUsersBloque.Name = "radioBUsersBloque";
            this.radioBUsersBloque.Size = new System.Drawing.Size(105, 18);
            this.radioBUsersBloque.TabIndex = 2;
            this.radioBUsersBloque.Text = "Compte bloqué";
            this.radioBUsersBloque.UseVisualStyleBackColor = true;
            this.radioBUsersBloque.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged_1);
            // 
            // radioBAllUsers
            // 
            this.radioBAllUsers.AutoSize = true;
            this.radioBAllUsers.Checked = true;
            this.radioBAllUsers.Location = new System.Drawing.Point(6, 19);
            this.radioBAllUsers.Name = "radioBAllUsers";
            this.radioBAllUsers.Size = new System.Drawing.Size(49, 18);
            this.radioBAllUsers.TabIndex = 1;
            this.radioBAllUsers.TabStop = true;
            this.radioBAllUsers.Text = "Tous";
            this.radioBAllUsers.UseVisualStyleBackColor = true;
            this.radioBAllUsers.CheckedChanged += new System.EventHandler(this.radioBAllUsers_CheckedChanged);
            // 
            // radioBGoodUsers
            // 
            this.radioBGoodUsers.AutoSize = true;
            this.radioBGoodUsers.Location = new System.Drawing.Point(61, 19);
            this.radioBGoodUsers.Name = "radioBGoodUsers";
            this.radioBGoodUsers.Size = new System.Drawing.Size(150, 18);
            this.radioBGoodUsers.TabIndex = 0;
            this.radioBGoodUsers.Text = "Utilisateur(s) régulier(s)";
            this.radioBGoodUsers.UseVisualStyleBackColor = true;
            this.radioBGoodUsers.CheckedChanged += new System.EventHandler(this.radioBGoodUsers_CheckedChanged);
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
            this.groupBAjoutUser.Location = new System.Drawing.Point(661, 76);
            this.groupBAjoutUser.Name = "groupBAjoutUser";
            this.groupBAjoutUser.Size = new System.Drawing.Size(387, 350);
            this.groupBAjoutUser.TabIndex = 2;
            this.groupBAjoutUser.TabStop = false;
            this.groupBAjoutUser.Text = "Ajout d\'un utilisateur";
            this.groupBAjoutUser.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // labTypeCpteUser
            // 
            this.labTypeCpteUser.AutoSize = true;
            this.labTypeCpteUser.Location = new System.Drawing.Point(75, 221);
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
            this.comboBTypeCpte.Location = new System.Drawing.Point(172, 213);
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
            this.labTitleAddUser.Location = new System.Drawing.Point(107, 25);
            this.labTitleAddUser.Name = "labTitleAddUser";
            this.labTitleAddUser.Size = new System.Drawing.Size(174, 23);
            this.labTitleAddUser.TabIndex = 13;
            this.labTitleAddUser.Text = "Nouvel Utilisateur";
            // 
            // txtBPortableUser
            // 
            this.txtBPortableUser.Location = new System.Drawing.Point(172, 184);
            this.txtBPortableUser.Name = "txtBPortableUser";
            this.txtBPortableUser.Size = new System.Drawing.Size(154, 22);
            this.txtBPortableUser.TabIndex = 12;
            // 
            // txtBTelephoneUser
            // 
            this.txtBTelephoneUser.Location = new System.Drawing.Point(172, 156);
            this.txtBTelephoneUser.Name = "txtBTelephoneUser";
            this.txtBTelephoneUser.Size = new System.Drawing.Size(154, 22);
            this.txtBTelephoneUser.TabIndex = 11;
            // 
            // txtBPrenomUser
            // 
            this.txtBPrenomUser.Location = new System.Drawing.Point(172, 128);
            this.txtBPrenomUser.Name = "txtBPrenomUser";
            this.txtBPrenomUser.Size = new System.Drawing.Size(154, 22);
            this.txtBPrenomUser.TabIndex = 10;
            // 
            // txtBNomUser
            // 
            this.txtBNomUser.Location = new System.Drawing.Point(172, 99);
            this.txtBNomUser.Name = "txtBNomUser";
            this.txtBNomUser.Size = new System.Drawing.Size(154, 22);
            this.txtBNomUser.TabIndex = 9;
            // 
            // txtBAdrMailUser
            // 
            this.txtBAdrMailUser.Location = new System.Drawing.Point(172, 71);
            this.txtBAdrMailUser.Name = "txtBAdrMailUser";
            this.txtBAdrMailUser.Size = new System.Drawing.Size(154, 22);
            this.txtBAdrMailUser.TabIndex = 8;
            // 
            // labNumPortUser
            // 
            this.labNumPortUser.AutoSize = true;
            this.labNumPortUser.Location = new System.Drawing.Point(54, 192);
            this.labNumPortUser.Name = "labNumPortUser";
            this.labNumPortUser.Size = new System.Drawing.Size(119, 14);
            this.labNumPortUser.TabIndex = 7;
            this.labNumPortUser.Text = "Numéro de portable :";
            // 
            // labNumTelUser
            // 
            this.labNumTelUser.AutoSize = true;
            this.labNumTelUser.Location = new System.Drawing.Point(46, 164);
            this.labNumTelUser.Name = "labNumTelUser";
            this.labNumTelUser.Size = new System.Drawing.Size(127, 14);
            this.labNumTelUser.TabIndex = 6;
            this.labNumTelUser.Text = "Numéro de téléphone :";
            // 
            // labPrenomUser
            // 
            this.labPrenomUser.AutoSize = true;
            this.labPrenomUser.Location = new System.Drawing.Point(119, 135);
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
            this.labWarningMdp.Location = new System.Drawing.Point(90, 257);
            this.labWarningMdp.Name = "labWarningMdp";
            this.labWarningMdp.Size = new System.Drawing.Size(212, 14);
            this.labWarningMdp.TabIndex = 4;
            this.labWarningMdp.Text = "Un mot de passe provisoire sera attribué.";
            // 
            // labNomUser
            // 
            this.labNomUser.AutoSize = true;
            this.labNomUser.Location = new System.Drawing.Point(134, 107);
            this.labNomUser.Name = "labNomUser";
            this.labNomUser.Size = new System.Drawing.Size(38, 14);
            this.labNomUser.TabIndex = 3;
            this.labNomUser.Text = "Nom :";
            // 
            // labAdrMailUser
            // 
            this.labAdrMailUser.AutoSize = true;
            this.labAdrMailUser.Location = new System.Drawing.Point(90, 79);
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
            this.labWarningAsterisque.Location = new System.Drawing.Point(76, 270);
            this.labWarningAsterisque.Name = "labWarningAsterisque";
            this.labWarningAsterisque.Size = new System.Drawing.Size(250, 14);
            this.labWarningAsterisque.TabIndex = 1;
            this.labWarningAsterisque.Text = "Les champs avec un astérisque sont obligatoires.";
            // 
            // btnAjoutUser
            // 
            this.btnAjoutUser.Location = new System.Drawing.Point(137, 291);
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
            this.labUsers.Location = new System.Drawing.Point(13, 67);
            this.labUsers.Name = "labUsers";
            this.labUsers.Size = new System.Drawing.Size(174, 14);
            this.labUsers.TabIndex = 1;
            this.labUsers.Text = "Les utilisateurs de l\'application :";
            // 
            // listBUsers
            // 
            this.listBUsers.FormattingEnabled = true;
            this.listBUsers.ItemHeight = 14;
            this.listBUsers.Location = new System.Drawing.Point(16, 84);
            this.listBUsers.Name = "listBUsers";
            this.listBUsers.Size = new System.Drawing.Size(622, 340);
            this.listBUsers.TabIndex = 0;
            this.listBUsers.SelectedIndexChanged += new System.EventHandler(this.ListBUsers_DoubleClick);
            // 
            // tabControlAdmin
            // 
            this.tabControlAdmin.Controls.Add(this.tabPUtilisateur);
            this.tabControlAdmin.Controls.Add(this.tabPArticle);
            this.tabControlAdmin.Controls.Add(this.tabPRubrique);
            this.tabControlAdmin.Font = new System.Drawing.Font("Constantia", 9F);
            this.tabControlAdmin.Location = new System.Drawing.Point(12, 28);
            this.tabControlAdmin.Name = "tabControlAdmin";
            this.tabControlAdmin.SelectedIndex = 0;
            this.tabControlAdmin.Size = new System.Drawing.Size(1080, 476);
            this.tabControlAdmin.TabIndex = 4;
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormPresseAdmin";
            this.Text = "Journal - Tableau de bord";
            this.tabPRubrique.ResumeLayout(false);
            this.tabPRubrique.PerformLayout();
            this.groupBRubriques.ResumeLayout(false);
            this.groupBRubriques.PerformLayout();
            this.tabPArticle.ResumeLayout(false);
            this.tabPArticle.PerformLayout();
            this.groupBFiltrageArticle.ResumeLayout(false);
            this.groupBFiltrageArticle.PerformLayout();
            this.groupBRubriqueArticle.ResumeLayout(false);
            this.groupBRubriqueArticle.PerformLayout();
            this.groupBAffichageArticles.ResumeLayout(false);
            this.groupBAffichageArticles.PerformLayout();
            this.tabPUtilisateur.ResumeLayout(false);
            this.tabPUtilisateur.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBAjoutUser.ResumeLayout(false);
            this.groupBAjoutUser.PerformLayout();
            this.tabControlAdmin.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBOnglet;
        private System.Windows.Forms.Label labCopyright;
        private System.Windows.Forms.Button btnDecoAdmin;
        private System.Windows.Forms.TabPage tabPRubrique;
        private System.Windows.Forms.GroupBox groupBRubriques;
        private System.Windows.Forms.Button btnDeleteRubrique;
        private System.Windows.Forms.Button btnModifRubrique;
        private System.Windows.Forms.Label labTitleRubrique;
        private System.Windows.Forms.TextBox txtBNomRubrique;
        private System.Windows.Forms.Button btnRechercheRubrique;
        private System.Windows.Forms.Label labNomRubrique;
        private System.Windows.Forms.Button btnAddRubrique;
        private System.Windows.Forms.Label labRubriques;
        private System.Windows.Forms.ListBox listBRubriques;
        private System.Windows.Forms.TabPage tabPArticle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBAvis;
        private System.Windows.Forms.GroupBox groupBRubriqueArticle;
        private System.Windows.Forms.Label labRubriquesArticleSelect;
        private System.Windows.Forms.Label labRubriquesDispo;
        private System.Windows.Forms.ListBox listBRubriquesArticle;
        private System.Windows.Forms.ListBox listBRubriquesDispo;
        private System.Windows.Forms.Button btnResetRubrique;
        private System.Windows.Forms.Label labTitleUpdateRubriqueArticle;
        private System.Windows.Forms.Button btnAttribuerRubrique;
        private System.Windows.Forms.GroupBox groupBAffichageArticles;
        private System.Windows.Forms.RadioButton radioBArticleRefus;
        private System.Windows.Forms.RadioButton radioBArticleValide;
        private System.Windows.Forms.RadioButton radioBAllArticle;
        private System.Windows.Forms.RadioButton radioBArticleEnAttente;
        private System.Windows.Forms.Label labArticles;
        private System.Windows.Forms.ListBox listBArticles;
        private System.Windows.Forms.TabPage tabPUtilisateur;
        private System.Windows.Forms.GroupBox groupBAjoutUser;
        private System.Windows.Forms.Label labTypeCpteUser;
        private System.Windows.Forms.ComboBox comboBTypeCpte;
        private System.Windows.Forms.Label labTitleAddUser;
        private System.Windows.Forms.TextBox txtBPortableUser;
        private System.Windows.Forms.TextBox txtBTelephoneUser;
        private System.Windows.Forms.TextBox txtBPrenomUser;
        private System.Windows.Forms.TextBox txtBNomUser;
        private System.Windows.Forms.TextBox txtBAdrMailUser;
        private System.Windows.Forms.Label labNumPortUser;
        private System.Windows.Forms.Label labNumTelUser;
        private System.Windows.Forms.Label labPrenomUser;
        private System.Windows.Forms.Label labWarningMdp;
        private System.Windows.Forms.Label labNomUser;
        private System.Windows.Forms.Label labAdrMailUser;
        private System.Windows.Forms.Label labWarningAsterisque;
        private System.Windows.Forms.Button btnAjoutUser;
        private System.Windows.Forms.Label labUsers;
        private System.Windows.Forms.ListBox listBUsers;
        private System.Windows.Forms.TabControl tabControlAdmin;
        private System.Windows.Forms.GroupBox groupBFiltrageArticle;
        private System.Windows.Forms.TextBox txtBIdArticle;
        private System.Windows.Forms.Label labIdArticle;
        private System.Windows.Forms.TextBox txtBAuteurArticle;
        private System.Windows.Forms.Label labAuteurArticle;
        private System.Windows.Forms.Button btnRecherche;
        private System.Windows.Forms.TextBox txtBNomRechercheRubrique;
        private System.Windows.Forms.Label labNomRechercheRubrique;
        private System.Windows.Forms.Button btnFiltrageArticle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBUsersAvertissement;
        private System.Windows.Forms.RadioButton radioBUsersBloque;
        private System.Windows.Forms.RadioButton radioBAllUsers;
        private System.Windows.Forms.RadioButton radioBGoodUsers;
    }
}