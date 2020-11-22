namespace CiccioGest.Presentation.AppForm.View
{
    partial class FatturaView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FatturaView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dettagliDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeProdottoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoProdottoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dettagliBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fatturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.totaleTextBox2 = new System.Windows.Forms.TextBox();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.totaleTextBox1 = new System.Windows.Forms.TextBox();
            this.dettaglioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quantitàTextBox = new System.Windows.Forms.TextBox();
            this.prezzoProdottoTextBox = new System.Windows.Forms.TextBox();
            this.nomeProdottoTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.esciToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.salvaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.eliminaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.nuovoDettaglioToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.aggiungiDettaglioToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.rimuoviDettaglioToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton = new System.Windows.Forms.ToolStripButton();
            nomeProdottoLabel = new System.Windows.Forms.Label();
            prezzoProdottoLabel = new System.Windows.Forms.Label();
            quantitàLabel = new System.Windows.Forms.Label();
            totaleLabel1 = new System.Windows.Forms.Label();
            nomeLabel1 = new System.Windows.Forms.Label();
            totaleLabel2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dettagliDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dettagliBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fatturaBindingSource)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dettaglioBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dettagliDataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(622, 433);
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
            this.Id,
            this.nomeProdottoDataGridViewTextBoxColumn,
            this.Quantita,
            this.prezzoProdottoDataGridViewTextBoxColumn,
            this.totaleDataGridViewTextBoxColumn});
            this.dettagliDataGridView.DataSource = this.dettagliBindingSource;
            this.dettagliDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dettagliDataGridView.Location = new System.Drawing.Point(3, 118);
            this.dettagliDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dettagliDataGridView.MultiSelect = false;
            this.dettagliDataGridView.Name = "dettagliDataGridView";
            this.dettagliDataGridView.ReadOnly = true;
            this.dettagliDataGridView.RowHeadersVisible = false;
            this.dettagliDataGridView.RowHeadersWidth = 51;
            this.dettagliDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dettagliDataGridView.Size = new System.Drawing.Size(616, 313);
            this.dettagliDataGridView.TabIndex = 6;
            this.dettagliDataGridView.TabStop = false;
            this.dettagliDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DettagliDataGridViewCellClick);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 48;
            // 
            // nomeProdottoDataGridViewTextBoxColumn
            // 
            this.nomeProdottoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeProdottoDataGridViewTextBoxColumn.DataPropertyName = "NomeProdotto";
            this.nomeProdottoDataGridViewTextBoxColumn.HeaderText = "Prodotto";
            this.nomeProdottoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nomeProdottoDataGridViewTextBoxColumn.Name = "nomeProdottoDataGridViewTextBoxColumn";
            this.nomeProdottoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Quantita
            // 
            this.Quantita.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Quantita.DataPropertyName = "Quantita";
            this.Quantita.HeaderText = "Quantita";
            this.Quantita.MinimumWidth = 6;
            this.Quantita.Name = "Quantita";
            this.Quantita.ReadOnly = true;
            this.Quantita.Width = 91;
            // 
            // prezzoProdottoDataGridViewTextBoxColumn
            // 
            this.prezzoProdottoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.prezzoProdottoDataGridViewTextBoxColumn.DataPropertyName = "PrezzoProdotto";
            this.prezzoProdottoDataGridViewTextBoxColumn.HeaderText = "Prezzo";
            this.prezzoProdottoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.prezzoProdottoDataGridViewTextBoxColumn.Name = "prezzoProdottoDataGridViewTextBoxColumn";
            this.prezzoProdottoDataGridViewTextBoxColumn.ReadOnly = true;
            this.prezzoProdottoDataGridViewTextBoxColumn.Width = 81;
            // 
            // totaleDataGridViewTextBoxColumn
            // 
            this.totaleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.totaleDataGridViewTextBoxColumn.DataPropertyName = "Totale";
            this.totaleDataGridViewTextBoxColumn.HeaderText = "Totale";
            this.totaleDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totaleDataGridViewTextBoxColumn.Name = "totaleDataGridViewTextBoxColumn";
            this.totaleDataGridViewTextBoxColumn.ReadOnly = true;
            this.totaleDataGridViewTextBoxColumn.Width = 77;
            // 
            // dettagliBindingSource
            // 
            this.dettagliBindingSource.AllowNew = false;
            this.dettagliBindingSource.DataMember = "Dettagli";
            this.dettagliBindingSource.DataSource = this.fatturaBindingSource;
            // 
            // fatturaBindingSource
            // 
            this.fatturaBindingSource.DataSource = typeof(CiccioGest.Domain.Documenti.Fattura);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 30);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(616, 83);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 77);
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
            this.tableLayoutPanel4.Controls.Add(this.nomeTextBox, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(193, 56);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // totaleTextBox2
            // 
            this.totaleTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fatturaBindingSource, "Totale", true));
            this.totaleTextBox2.Location = new System.Drawing.Point(61, 31);
            this.totaleTextBox2.Name = "totaleTextBox2";
            this.totaleTextBox2.ReadOnly = true;
            this.totaleTextBox2.Size = new System.Drawing.Size(129, 22);
            this.totaleTextBox2.TabIndex = 3;
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fatturaBindingSource, "Nome", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nomeTextBox.Location = new System.Drawing.Point(61, 3);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(129, 22);
            this.nomeTextBox.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(208, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 77);
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(399, 56);
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
            this.dettaglioBindingSource.DataSource = typeof(CiccioGest.Domain.Documenti.Dettaglio);
            // 
            // quantitàTextBox
            // 
            this.quantitàTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dettaglioBindingSource, "Quantita", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.nomeProdottoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dettaglioBindingSource, "NomeProdotto", true));
            this.nomeProdottoTextBox.Location = new System.Drawing.Point(75, 3);
            this.nomeProdottoTextBox.Name = "nomeProdottoTextBox";
            this.nomeProdottoTextBox.ReadOnly = true;
            this.nomeProdottoTextBox.Size = new System.Drawing.Size(100, 22);
            this.nomeProdottoTextBox.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.esciToolStripButton,
            this.salvaToolStripButton,
            this.eliminaToolStripButton,
            this.toolStripSeparator,
            this.nuovoDettaglioToolStripButton,
            this.aggiungiDettaglioToolStripButton,
            this.rimuoviDettaglioToolStripButton1,
            this.ToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(622, 27);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // esciToolStripButton
            // 
            this.esciToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("esciToolStripButton.Image")));
            this.esciToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.esciToolStripButton.Name = "esciToolStripButton";
            this.esciToolStripButton.Size = new System.Drawing.Size(58, 24);
            this.esciToolStripButton.Text = "Esci";
            this.esciToolStripButton.Click += new System.EventHandler(this.EsciClick);
            // 
            // salvaToolStripButton
            // 
            this.salvaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("salvaToolStripButton.Image")));
            this.salvaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salvaToolStripButton.Name = "salvaToolStripButton";
            this.salvaToolStripButton.Size = new System.Drawing.Size(68, 24);
            this.salvaToolStripButton.Text = "Salva";
            this.salvaToolStripButton.Click += new System.EventHandler(this.SalvaClick);
            // 
            // eliminaToolStripButton
            // 
            this.eliminaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("eliminaToolStripButton.Image")));
            this.eliminaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eliminaToolStripButton.Name = "eliminaToolStripButton";
            this.eliminaToolStripButton.Size = new System.Drawing.Size(82, 24);
            this.eliminaToolStripButton.Text = "Elimina";
            this.eliminaToolStripButton.Click += new System.EventHandler(this.EliminaClick);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // nuovoDettaglioToolStripButton
            // 
            this.nuovoDettaglioToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nuovoDettaglioToolStripButton.Image")));
            this.nuovoDettaglioToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuovoDettaglioToolStripButton.Name = "nuovoDettaglioToolStripButton";
            this.nuovoDettaglioToolStripButton.Size = new System.Drawing.Size(77, 24);
            this.nuovoDettaglioToolStripButton.Text = "Nuovo";
            this.nuovoDettaglioToolStripButton.Click += new System.EventHandler(this.NuovoDettaglioClick);
            // 
            // aggiungiDettaglioToolStripButton
            // 
            this.aggiungiDettaglioToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("aggiungiDettaglioToolStripButton.Image")));
            this.aggiungiDettaglioToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aggiungiDettaglioToolStripButton.Name = "aggiungiDettaglioToolStripButton";
            this.aggiungiDettaglioToolStripButton.Size = new System.Drawing.Size(94, 24);
            this.aggiungiDettaglioToolStripButton.Text = "Aggiungi";
            this.aggiungiDettaglioToolStripButton.Click += new System.EventHandler(this.AggiungiDettaglioClick);
            // 
            // rimuoviDettaglioToolStripButton1
            // 
            this.rimuoviDettaglioToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("rimuoviDettaglioToolStripButton1.Image")));
            this.rimuoviDettaglioToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rimuoviDettaglioToolStripButton1.Name = "rimuoviDettaglioToolStripButton1";
            this.rimuoviDettaglioToolStripButton1.Size = new System.Drawing.Size(87, 24);
            this.rimuoviDettaglioToolStripButton1.Text = "Rimuovi";
            this.rimuoviDettaglioToolStripButton1.Click += new System.EventHandler(this.RimuoviDettaglioClick);
            // 
            // ToolStripButton
            // 
            this.ToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton.Image")));
            this.ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton.Name = "ToolStripButton";
            this.ToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.ToolStripButton.Text = "&?";
            this.ToolStripButton.Click += new System.EventHandler(this.ToolStripButton_Click);
            // 
            // FatturaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 433);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FatturaView";
            this.Text = "Fattura";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FatturaView_FormClosed);
            this.Load += new System.EventHandler(this.FatturaViewLoad);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dettagliDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dettagliBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fatturaBindingSource)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dettaglioBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dettagliDataGridView;
        private System.Windows.Forms.BindingSource dettagliBindingSource;
        private System.Windows.Forms.BindingSource dettaglioBindingSource;
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
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeProdottoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantita;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezzoProdottoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton esciToolStripButton;
        private System.Windows.Forms.ToolStripButton salvaToolStripButton;
        private System.Windows.Forms.ToolStripButton eliminaToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton nuovoDettaglioToolStripButton;
        private System.Windows.Forms.ToolStripButton aggiungiDettaglioToolStripButton;
        private System.Windows.Forms.ToolStripButton rimuoviDettaglioToolStripButton1;
        private System.Windows.Forms.ToolStripButton ToolStripButton;
    }
}
