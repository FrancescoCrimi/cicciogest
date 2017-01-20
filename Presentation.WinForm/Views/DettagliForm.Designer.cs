namespace Ciccio1.Presentation.WinForm.Views
{
    partial class DettagliForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nomeProdottoLabel;
            System.Windows.Forms.Label prezzoProdottoLabel;
            System.Windows.Forms.Label quantitàLabel;
            System.Windows.Forms.Label totaleLabel1;
            System.Windows.Forms.Label nomeLabel1;
            System.Windows.Forms.Label totaleLabel2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DettagliForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuovoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strumentiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selezProdottoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prodottiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categorieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dettagliDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeProdottoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoProdottoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantitàDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dettagliBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.totaleTextBox2 = new System.Windows.Forms.TextBox();
            this.fatturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nomeTextBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.totaleTextBox1 = new System.Windows.Forms.TextBox();
            this.dettaglioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quantitàTextBox = new System.Windows.Forms.TextBox();
            this.prezzoProdottoTextBox = new System.Windows.Forms.TextBox();
            this.nomeProdottoTextBox = new System.Windows.Forms.TextBox();
            nomeProdottoLabel = new System.Windows.Forms.Label();
            prezzoProdottoLabel = new System.Windows.Forms.Label();
            quantitàLabel = new System.Windows.Forms.Label();
            totaleLabel1 = new System.Windows.Forms.Label();
            nomeLabel1 = new System.Windows.Forms.Label();
            totaleLabel2 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dettagliDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dettagliBindingSource)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fatturaBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dettaglioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nomeProdottoLabel
            // 
            nomeProdottoLabel.AutoSize = true;
            nomeProdottoLabel.Location = new System.Drawing.Point(3, 0);
            nomeProdottoLabel.Name = "nomeProdottoLabel";
            nomeProdottoLabel.Size = new System.Drawing.Size(66, 17);
            nomeProdottoLabel.TabIndex = 0;
            nomeProdottoLabel.Text = "Prodotto:";
            // 
            // prezzoProdottoLabel
            // 
            prezzoProdottoLabel.AutoSize = true;
            prezzoProdottoLabel.Location = new System.Drawing.Point(181, 0);
            prezzoProdottoLabel.Name = "prezzoProdottoLabel";
            prezzoProdottoLabel.Size = new System.Drawing.Size(56, 17);
            prezzoProdottoLabel.TabIndex = 2;
            prezzoProdottoLabel.Text = "Prezzo:";
            // 
            // quantitàLabel
            // 
            quantitàLabel.AutoSize = true;
            quantitàLabel.Location = new System.Drawing.Point(3, 28);
            quantitàLabel.Name = "quantitàLabel";
            quantitàLabel.Size = new System.Drawing.Size(66, 17);
            quantitàLabel.TabIndex = 4;
            quantitàLabel.Text = "Quantità:";
            // 
            // totaleLabel1
            // 
            totaleLabel1.AutoSize = true;
            totaleLabel1.Location = new System.Drawing.Point(181, 28);
            totaleLabel1.Name = "totaleLabel1";
            totaleLabel1.Size = new System.Drawing.Size(52, 17);
            totaleLabel1.TabIndex = 6;
            totaleLabel1.Text = "Totale:";
            // 
            // nomeLabel1
            // 
            nomeLabel1.AutoSize = true;
            nomeLabel1.Location = new System.Drawing.Point(3, 0);
            nomeLabel1.Name = "nomeLabel1";
            nomeLabel1.Size = new System.Drawing.Size(49, 17);
            nomeLabel1.TabIndex = 0;
            nomeLabel1.Text = "Nome:";
            // 
            // totaleLabel2
            // 
            totaleLabel2.AutoSize = true;
            totaleLabel2.Location = new System.Drawing.Point(3, 28);
            totaleLabel2.Name = "totaleLabel2";
            totaleLabel2.Size = new System.Drawing.Size(52, 17);
            totaleLabel2.TabIndex = 2;
            totaleLabel2.Text = "Totale:";
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.strumentiToolStripMenuItem,
            this.toolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(502, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovoToolStripMenuItem,
            this.modificaToolStripMenuItem,
            this.salvaToolStripMenuItem,
            this.eliminaToolStripMenuItem,
            this.esciToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // nuovoToolStripMenuItem
            // 
            this.nuovoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuovoToolStripMenuItem.Image")));
            this.nuovoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuovoToolStripMenuItem.Name = "nuovoToolStripMenuItem";
            this.nuovoToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.nuovoToolStripMenuItem.Text = "Nuovo";
            this.nuovoToolStripMenuItem.Click += new System.EventHandler(this.nuovoToolStripMenuItem_Click);
            // 
            // modificaToolStripMenuItem
            // 
            this.modificaToolStripMenuItem.Image = global::Ciccio1.Presentation.WinForm.Properties.Resources.Copia;
            this.modificaToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.modificaToolStripMenuItem.Name = "modificaToolStripMenuItem";
            this.modificaToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.modificaToolStripMenuItem.Text = "Modifica";
            this.modificaToolStripMenuItem.Click += new System.EventHandler(this.modificaToolStripMenuItem_Click);
            // 
            // salvaToolStripMenuItem
            // 
            this.salvaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("salvaToolStripMenuItem.Image")));
            this.salvaToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salvaToolStripMenuItem.Name = "salvaToolStripMenuItem";
            this.salvaToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.salvaToolStripMenuItem.Text = "Salva";
            this.salvaToolStripMenuItem.Click += new System.EventHandler(this.salvaToolStripMenuItem_Click);
            // 
            // eliminaToolStripMenuItem
            // 
            this.eliminaToolStripMenuItem.Image = global::Ciccio1.Presentation.WinForm.Properties.Resources.Delete;
            this.eliminaToolStripMenuItem.Name = "eliminaToolStripMenuItem";
            this.eliminaToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.eliminaToolStripMenuItem.Text = "Elimina";
            this.eliminaToolStripMenuItem.Click += new System.EventHandler(this.eliminaToolStripMenuItem_Click);
            // 
            // esciToolStripMenuItem
            // 
            this.esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            this.esciToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.esciToolStripMenuItem.Text = "Esci";
            this.esciToolStripMenuItem.Click += new System.EventHandler(this.esciToolStripMenuItem_Click);
            // 
            // strumentiToolStripMenuItem
            // 
            this.strumentiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selezProdottoToolStripMenuItem,
            this.prodottiToolStripMenuItem,
            this.categorieToolStripMenuItem});
            this.strumentiToolStripMenuItem.Name = "strumentiToolStripMenuItem";
            this.strumentiToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.strumentiToolStripMenuItem.Text = "&Strumenti";
            // 
            // selezProdottoToolStripMenuItem
            // 
            this.selezProdottoToolStripMenuItem.Name = "selezProdottoToolStripMenuItem";
            this.selezProdottoToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.selezProdottoToolStripMenuItem.Text = "Selez. Prodotto";
            this.selezProdottoToolStripMenuItem.Click += new System.EventHandler(this.selezProdottoToolStripMenuItem_Click);
            // 
            // prodottiToolStripMenuItem
            // 
            this.prodottiToolStripMenuItem.Name = "prodottiToolStripMenuItem";
            this.prodottiToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.prodottiToolStripMenuItem.Text = "Prodotti";
            this.prodottiToolStripMenuItem.Click += new System.EventHandler(this.prodottiToolStripMenuItem_Click);
            // 
            // categorieToolStripMenuItem
            // 
            this.categorieToolStripMenuItem.Name = "categorieToolStripMenuItem";
            this.categorieToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.categorieToolStripMenuItem.Text = "Categorie";
            this.categorieToolStripMenuItem.Click += new System.EventHandler(this.categorieToolStripMenuItem_Click);
            // 
            // toolStripMenuItem
            // 
            this.toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem.Name = "toolStripMenuItem";
            this.toolStripMenuItem.Size = new System.Drawing.Size(28, 24);
            this.toolStripMenuItem.Text = "?";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::Ciccio1.Presentation.WinForm.Properties.Resources.About;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dettagliDataGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(502, 325);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dettagliDataGridView
            // 
            this.dettagliDataGridView.AllowUserToAddRows = false;
            this.dettagliDataGridView.AllowUserToDeleteRows = false;
            this.dettagliDataGridView.AllowUserToResizeRows = false;
            this.dettagliDataGridView.AutoGenerateColumns = false;
            this.dettagliDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dettagliDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nomeProdottoDataGridViewTextBoxColumn,
            this.prezzoProdottoDataGridViewTextBoxColumn,
            this.quantitàDataGridViewTextBoxColumn,
            this.totaleDataGridViewTextBoxColumn});
            this.dettagliDataGridView.DataSource = this.dettagliBindingSource;
            this.dettagliDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dettagliDataGridView.Location = new System.Drawing.Point(3, 91);
            this.dettagliDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dettagliDataGridView.MultiSelect = false;
            this.dettagliDataGridView.Name = "dettagliDataGridView";
            this.dettagliDataGridView.ReadOnly = true;
            this.dettagliDataGridView.RowHeadersVisible = false;
            this.dettagliDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dettagliDataGridView.Size = new System.Drawing.Size(496, 232);
            this.dettagliDataGridView.TabIndex = 6;
            this.dettagliDataGridView.TabStop = false;
            this.dettagliDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dettagliDataGridView_CellDoubleClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 48;
            // 
            // nomeProdottoDataGridViewTextBoxColumn
            // 
            this.nomeProdottoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeProdottoDataGridViewTextBoxColumn.DataPropertyName = "NomeProdotto";
            this.nomeProdottoDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeProdottoDataGridViewTextBoxColumn.Name = "nomeProdottoDataGridViewTextBoxColumn";
            this.nomeProdottoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prezzoProdottoDataGridViewTextBoxColumn
            // 
            this.prezzoProdottoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.prezzoProdottoDataGridViewTextBoxColumn.DataPropertyName = "PrezzoProdotto";
            this.prezzoProdottoDataGridViewTextBoxColumn.HeaderText = "Prezzo";
            this.prezzoProdottoDataGridViewTextBoxColumn.Name = "prezzoProdottoDataGridViewTextBoxColumn";
            this.prezzoProdottoDataGridViewTextBoxColumn.ReadOnly = true;
            this.prezzoProdottoDataGridViewTextBoxColumn.Width = 81;
            // 
            // quantitàDataGridViewTextBoxColumn
            // 
            this.quantitàDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.quantitàDataGridViewTextBoxColumn.DataPropertyName = "Quantità";
            this.quantitàDataGridViewTextBoxColumn.HeaderText = "Quantità";
            this.quantitàDataGridViewTextBoxColumn.Name = "quantitàDataGridViewTextBoxColumn";
            this.quantitàDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantitàDataGridViewTextBoxColumn.Width = 91;
            // 
            // totaleDataGridViewTextBoxColumn
            // 
            this.totaleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.totaleDataGridViewTextBoxColumn.DataPropertyName = "Totale";
            this.totaleDataGridViewTextBoxColumn.HeaderText = "Totale";
            this.totaleDataGridViewTextBoxColumn.Name = "totaleDataGridViewTextBoxColumn";
            this.totaleDataGridViewTextBoxColumn.ReadOnly = true;
            this.totaleDataGridViewTextBoxColumn.Width = 77;
            // 
            // dettagliBindingSource
            // 
            this.dettagliBindingSource.DataSource = typeof(Ciccio1.Domain.Dettaglio);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(496, 83);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fattura";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(totaleLabel2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.totaleTextBox2, 1, 1);
            this.tableLayoutPanel4.Controls.Add(nomeLabel1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.nomeTextBox1, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(164, 56);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // totaleTextBox2
            // 
            this.totaleTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fatturaBindingSource, "Totale", true));
            this.totaleTextBox2.Location = new System.Drawing.Point(61, 31);
            this.totaleTextBox2.Name = "totaleTextBox2";
            this.totaleTextBox2.ReadOnly = true;
            this.totaleTextBox2.Size = new System.Drawing.Size(100, 22);
            this.totaleTextBox2.TabIndex = 3;
            // 
            // fatturaBindingSource
            // 
            this.fatturaBindingSource.DataSource = typeof(Ciccio1.Domain.Fattura);
            // 
            // nomeTextBox1
            // 
            this.nomeTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fatturaBindingSource, "Nome", true));
            this.nomeTextBox1.Location = new System.Drawing.Point(61, 3);
            this.nomeTextBox1.Name = "nomeTextBox1";
            this.nomeTextBox1.ReadOnly = true;
            this.nomeTextBox1.Size = new System.Drawing.Size(100, 22);
            this.nomeTextBox1.TabIndex = 1;
            this.nomeTextBox1.TextChanged += new System.EventHandler(this.nomeTextBox1_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(179, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 77);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dettaglio";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(totaleLabel1, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.totaleTextBox1, 3, 1);
            this.tableLayoutPanel3.Controls.Add(quantitàLabel, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.quantitàTextBox, 1, 1);
            this.tableLayoutPanel3.Controls.Add(prezzoProdottoLabel, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.prezzoProdottoTextBox, 3, 0);
            this.tableLayoutPanel3.Controls.Add(nomeProdottoLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.nomeProdottoTextBox, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(308, 56);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // totaleTextBox1
            // 
            this.totaleTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dettaglioBindingSource, "Totale", true));
            this.totaleTextBox1.Location = new System.Drawing.Point(243, 31);
            this.totaleTextBox1.Name = "totaleTextBox1";
            this.totaleTextBox1.ReadOnly = true;
            this.totaleTextBox1.Size = new System.Drawing.Size(60, 22);
            this.totaleTextBox1.TabIndex = 7;
            // 
            // dettaglioBindingSource
            // 
            this.dettaglioBindingSource.DataSource = typeof(Ciccio1.Domain.Dettaglio);
            // 
            // quantitàTextBox
            // 
            this.quantitàTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dettaglioBindingSource, "Quantità", true));
            this.quantitàTextBox.Location = new System.Drawing.Point(75, 31);
            this.quantitàTextBox.Name = "quantitàTextBox";
            this.quantitàTextBox.Size = new System.Drawing.Size(100, 22);
            this.quantitàTextBox.TabIndex = 5;
            // 
            // prezzoProdottoTextBox
            // 
            this.prezzoProdottoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dettaglioBindingSource, "PrezzoProdotto", true));
            this.prezzoProdottoTextBox.Location = new System.Drawing.Point(243, 3);
            this.prezzoProdottoTextBox.Name = "prezzoProdottoTextBox";
            this.prezzoProdottoTextBox.ReadOnly = true;
            this.prezzoProdottoTextBox.Size = new System.Drawing.Size(60, 22);
            this.prezzoProdottoTextBox.TabIndex = 3;
            // 
            // nomeProdottoTextBox
            // 
            this.nomeProdottoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dettagliBindingSource, "NomeProdotto", true));
            this.nomeProdottoTextBox.Location = new System.Drawing.Point(75, 3);
            this.nomeProdottoTextBox.Name = "nomeProdottoTextBox";
            this.nomeProdottoTextBox.ReadOnly = true;
            this.nomeProdottoTextBox.Size = new System.Drawing.Size(100, 22);
            this.nomeProdottoTextBox.TabIndex = 1;
            this.nomeProdottoTextBox.DoubleClick += new System.EventHandler(this.nomeProdottoTextBox_DoubleClick);
            // 
            // DettagliForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 353);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "DettagliForm";
            this.Text = "Dettagli";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dettagliDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dettagliBindingSource)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fatturaBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dettaglioBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuovoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem strumentiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prodottiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selezProdottoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categorieToolStripMenuItem;
        private System.Windows.Forms.DataGridView dettagliDataGridView;
        private System.Windows.Forms.BindingSource dettagliBindingSource;
        private System.Windows.Forms.BindingSource dettaglioBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeProdottoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezzoProdottoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantitàDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource fatturaBindingSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox totaleTextBox1;
        private System.Windows.Forms.TextBox quantitàTextBox;
        private System.Windows.Forms.TextBox prezzoProdottoTextBox;
        private System.Windows.Forms.TextBox nomeProdottoTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox totaleTextBox2;
        private System.Windows.Forms.TextBox nomeTextBox1;
    }
}