namespace CiccioGest.Presentation.AppForm.Views
{
    partial class ArticoloView
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticoloView));
            articoloBindingSource = new System.Windows.Forms.BindingSource(components);
            categorieBindingSource = new System.Windows.Forms.BindingSource(components);
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            toolStrip = new System.Windows.Forms.ToolStrip();
            salvaToolStripButton = new System.Windows.Forms.ToolStripButton();
            nuovoToolStripButton = new System.Windows.Forms.ToolStripButton();
            apriToolStripButton = new System.Windows.Forms.ToolStripButton();
            eliminaToolStripButton = new System.Windows.Forms.ToolStripButton();
            categorieDataGridView = new System.Windows.Forms.DataGridView();
            nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            aggiungiCategoriaToolStripButton = new System.Windows.Forms.ToolStripButton();
            rimuovCategoriaToolStripButton = new System.Windows.Forms.ToolStripButton();
            groupBox1 = new System.Windows.Forms.GroupBox();
            fornitoreTextBox = new System.Windows.Forms.TextBox();
            nomeLabel = new System.Windows.Forms.Label();
            fornitoreLabel = new System.Windows.Forms.Label();
            nomeTextBox = new System.Windows.Forms.TextBox();
            descrizioneTextBox = new System.Windows.Forms.TextBox();
            prezzoLabel = new System.Windows.Forms.Label();
            descrizioneLabel = new System.Windows.Forms.Label();
            prezzoTextBox = new System.Windows.Forms.TextBox();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)articoloBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categorieBindingSource).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)categorieDataGridView).BeginInit();
            toolStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // articoloBindingSource
            // 
            articoloBindingSource.DataSource = typeof(Domain.Magazzino.Articolo);
            // 
            // categorieBindingSource
            // 
            categorieBindingSource.DataSource = typeof(Domain.Magazzino.Categoria);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(menuStrip1, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.Size = new System.Drawing.Size(624, 281);
            tableLayoutPanel1.TabIndex = 12;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.47126F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.52874F));
            tableLayoutPanel2.Controls.Add(toolStrip, 0, 0);
            tableLayoutPanel2.Controls.Add(categorieDataGridView, 1, 1);
            tableLayoutPanel2.Controls.Add(toolStrip1, 1, 0);
            tableLayoutPanel2.Controls.Add(groupBox1, 0, 1);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(4, 35);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.Size = new System.Drawing.Size(616, 253);
            tableLayoutPanel2.TabIndex = 11;
            // 
            // toolStrip
            // 
            toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { nuovoToolStripButton, salvaToolStripButton, apriToolStripButton, eliminaToolStripButton });
            toolStrip.Location = new System.Drawing.Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new System.Drawing.Size(354, 27);
            toolStrip.TabIndex = 15;
            toolStrip.Text = "toolStrip1";
            // 
            // salvaToolStripButton
            // 
            salvaToolStripButton.Image = (System.Drawing.Image)resources.GetObject("salvaToolStripButton.Image");
            salvaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            salvaToolStripButton.Name = "salvaToolStripButton";
            salvaToolStripButton.Size = new System.Drawing.Size(58, 24);
            salvaToolStripButton.Text = "Salva";
            salvaToolStripButton.Click += Salva_Click;
            // 
            // nuovoToolStripButton
            // 
            nuovoToolStripButton.Image = (System.Drawing.Image)resources.GetObject("nuovoToolStripButton.Image");
            nuovoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            nuovoToolStripButton.Name = "nuovoToolStripButton";
            nuovoToolStripButton.Size = new System.Drawing.Size(67, 24);
            nuovoToolStripButton.Text = "Nuovo";
            nuovoToolStripButton.Click += NuovoToolStripButton_Click;
            // 
            // apriToolStripButton
            // 
            apriToolStripButton.Image = Properties.Resources.CaricaDefault;
            apriToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            apriToolStripButton.Name = "apriToolStripButton";
            apriToolStripButton.Size = new System.Drawing.Size(53, 24);
            apriToolStripButton.Text = "Apri";
            apriToolStripButton.Click += ApriToolStripButton_Click;
            // 
            // eliminaToolStripButton
            // 
            eliminaToolStripButton.Image = (System.Drawing.Image)resources.GetObject("eliminaToolStripButton.Image");
            eliminaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            eliminaToolStripButton.Name = "eliminaToolStripButton";
            eliminaToolStripButton.Size = new System.Drawing.Size(70, 24);
            eliminaToolStripButton.Text = "Elimina";
            eliminaToolStripButton.Click += Elimina_Click;
            // 
            // categorieDataGridView
            // 
            categorieDataGridView.AllowUserToAddRows = false;
            categorieDataGridView.AllowUserToDeleteRows = false;
            categorieDataGridView.AllowUserToResizeRows = false;
            categorieDataGridView.AutoGenerateColumns = false;
            categorieDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            categorieDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            categorieDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { nomeDataGridViewTextBoxColumn });
            categorieDataGridView.DataSource = categorieBindingSource;
            categorieDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            categorieDataGridView.Location = new System.Drawing.Point(358, 31);
            categorieDataGridView.Margin = new System.Windows.Forms.Padding(4);
            categorieDataGridView.MultiSelect = false;
            categorieDataGridView.Name = "categorieDataGridView";
            categorieDataGridView.ReadOnly = true;
            categorieDataGridView.RowHeadersVisible = false;
            categorieDataGridView.RowHeadersWidth = 51;
            categorieDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            categorieDataGridView.Size = new System.Drawing.Size(254, 218);
            categorieDataGridView.TabIndex = 14;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.MinimumWidth = 6;
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { aggiungiCategoriaToolStripButton, rimuovCategoriaToolStripButton });
            toolStrip1.Location = new System.Drawing.Point(354, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(262, 27);
            toolStrip1.TabIndex = 16;
            toolStrip1.Text = "toolStrip1";
            // 
            // aggiungiCategoriaToolStripButton
            // 
            aggiungiCategoriaToolStripButton.Image = Properties.Resources.AddNew;
            aggiungiCategoriaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            aggiungiCategoriaToolStripButton.Name = "aggiungiCategoriaToolStripButton";
            aggiungiCategoriaToolStripButton.Size = new System.Drawing.Size(80, 24);
            aggiungiCategoriaToolStripButton.Text = "Aggiungi";
            aggiungiCategoriaToolStripButton.Click += AggiungiCategoriaToolStripButton_Click;
            // 
            // rimuovCategoriaToolStripButton
            // 
            rimuovCategoriaToolStripButton.Image = Properties.Resources.Delete;
            rimuovCategoriaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            rimuovCategoriaToolStripButton.Name = "rimuovCategoriaToolStripButton";
            rimuovCategoriaToolStripButton.Size = new System.Drawing.Size(75, 24);
            rimuovCategoriaToolStripButton.Text = "Rimuovi";
            rimuovCategoriaToolStripButton.Click += RimuovCategoriaToolStripButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(fornitoreTextBox);
            groupBox1.Controls.Add(nomeLabel);
            groupBox1.Controls.Add(fornitoreLabel);
            groupBox1.Controls.Add(nomeTextBox);
            groupBox1.Controls.Add(descrizioneTextBox);
            groupBox1.Controls.Add(prezzoLabel);
            groupBox1.Controls.Add(descrizioneLabel);
            groupBox1.Controls.Add(prezzoTextBox);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Location = new System.Drawing.Point(9, 35);
            groupBox1.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox1.Size = new System.Drawing.Size(336, 210);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Articolo";
            // 
            // fornitoreTextBox
            // 
            fornitoreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", articoloBindingSource, "Fornitore.Nome", true));
            fornitoreTextBox.Location = new System.Drawing.Point(85, 94);
            fornitoreTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            fornitoreTextBox.Name = "fornitoreTextBox";
            fornitoreTextBox.ReadOnly = true;
            fornitoreTextBox.Size = new System.Drawing.Size(181, 23);
            fornitoreTextBox.TabIndex = 15;
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(5, 22);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(43, 15);
            nomeLabel.TabIndex = 2;
            nomeLabel.Text = "Nome:";
            // 
            // fornitoreLabel
            // 
            fornitoreLabel.AutoSize = true;
            fornitoreLabel.Location = new System.Drawing.Point(4, 96);
            fornitoreLabel.Name = "fornitoreLabel";
            fornitoreLabel.Size = new System.Drawing.Size(55, 15);
            fornitoreLabel.TabIndex = 14;
            fornitoreLabel.Text = "Fornitore";
            // 
            // nomeTextBox
            // 
            nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", articoloBindingSource, "Nome", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            nomeTextBox.Location = new System.Drawing.Point(85, 20);
            nomeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            nomeTextBox.Name = "nomeTextBox";
            nomeTextBox.Size = new System.Drawing.Size(181, 23);
            nomeTextBox.TabIndex = 3;
            // 
            // descrizioneTextBox
            // 
            descrizioneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", articoloBindingSource, "Descrizione", true));
            descrizioneTextBox.Location = new System.Drawing.Point(85, 69);
            descrizioneTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            descrizioneTextBox.Name = "descrizioneTextBox";
            descrizioneTextBox.Size = new System.Drawing.Size(181, 23);
            descrizioneTextBox.TabIndex = 13;
            // 
            // prezzoLabel
            // 
            prezzoLabel.AutoSize = true;
            prezzoLabel.Location = new System.Drawing.Point(5, 46);
            prezzoLabel.Name = "prezzoLabel";
            prezzoLabel.Size = new System.Drawing.Size(44, 15);
            prezzoLabel.TabIndex = 10;
            prezzoLabel.Text = "Prezzo:";
            // 
            // descrizioneLabel
            // 
            descrizioneLabel.AutoSize = true;
            descrizioneLabel.Location = new System.Drawing.Point(4, 71);
            descrizioneLabel.Name = "descrizioneLabel";
            descrizioneLabel.Size = new System.Drawing.Size(67, 15);
            descrizioneLabel.TabIndex = 12;
            descrizioneLabel.Text = "Descrizione";
            // 
            // prezzoTextBox
            // 
            prezzoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", articoloBindingSource, "Prezzo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            prezzoTextBox.Location = new System.Drawing.Point(85, 44);
            prezzoTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            prezzoTextBox.Name = "prezzoTextBox";
            prezzoTextBox.Size = new System.Drawing.Size(181, 23);
            prezzoTextBox.TabIndex = 11;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem, aboutToolStripButton });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(624, 31);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator1, printToolStripMenuItem, printPreviewToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 27);
            fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("newToolStripMenuItem.Image");
            newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N;
            newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("openToolStripMenuItem.Image");
            openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O;
            openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("saveToolStripMenuItem.Image");
            saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("printToolStripMenuItem.Image");
            printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P;
            printToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            printPreviewToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("printPreviewToolStripMenuItem.Image");
            printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            printPreviewToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, toolStripSeparator3, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, toolStripSeparator4, selectAllToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new System.Drawing.Size(39, 27);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z;
            undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y;
            redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("cutToolStripMenuItem.Image");
            cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X;
            cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("copyToolStripMenuItem.Image");
            copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C;
            copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("pasteToolStripMenuItem.Image");
            pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V;
            pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { customizeToolStripMenuItem, optionsToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 27);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            customizeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { contentsToolStripMenuItem, indexToolStripMenuItem, searchToolStripMenuItem, toolStripSeparator5, aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(44, 27);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            contentsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            indexToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(119, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            aboutToolStripMenuItem.Text = "&About...";
            // 
            // aboutToolStripButton
            // 
            aboutToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            aboutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            aboutToolStripButton.Image = (System.Drawing.Image)resources.GetObject("aboutToolStripButton.Image");
            aboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            aboutToolStripButton.Name = "aboutToolStripButton";
            aboutToolStripButton.Size = new System.Drawing.Size(24, 24);
            aboutToolStripButton.Text = "&?";
            aboutToolStripButton.Click += About_Click;
            // 
            // ArticoloView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(624, 281);
            Controls.Add(tableLayoutPanel1);
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "ArticoloView";
            Text = "Articolo";
            ((System.ComponentModel.ISupportInitialize)articoloBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)categorieBindingSource).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)categorieDataGridView).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.BindingSource articoloBindingSource;
        private System.Windows.Forms.BindingSource categorieBindingSource;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton nuovoToolStripButton;
        private System.Windows.Forms.ToolStripButton eliminaToolStripButton;
        private System.Windows.Forms.ToolStripButton salvaToolStripButton;
        private System.Windows.Forms.DataGridView categorieDataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton aggiungiCategoriaToolStripButton;
        private System.Windows.Forms.ToolStripButton rimuovCategoriaToolStripButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton apriToolStripButton;
        private System.Windows.Forms.ToolStripButton aboutToolStripButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox fornitoreTextBox;
        private System.Windows.Forms.Label nomeLabel;
        private System.Windows.Forms.Label fornitoreLabel;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.TextBox descrizioneTextBox;
        private System.Windows.Forms.Label prezzoLabel;
        private System.Windows.Forms.Label descrizioneLabel;
        private System.Windows.Forms.TextBox prezzoTextBox;
    }
}
