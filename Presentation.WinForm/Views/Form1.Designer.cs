namespace Ciccio1.Presentation.WinForm.Views
{
    partial class Form1
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
            System.Windows.Forms.Label nomeLabel1;
            System.Windows.Forms.Label quantitàLabel;
            System.Windows.Forms.Label prezzoLabel;
            System.Windows.Forms.Label totaleLabel1;
            System.Windows.Forms.Label nomeLabel;
            System.Windows.Forms.Label totaleLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fattureDataGridView = new System.Windows.Forms.DataGridView();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fattureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dettagliDataGridView = new System.Windows.Forms.DataGridView();
            this.nomeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantitàDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totaleDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dettagliBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.nuovoDettaglioToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.aggiungiDettaglioToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.rimuoviDettaglioToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.prodottiToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tipoProdottoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.nomeTextBox1 = new System.Windows.Forms.TextBox();
            this.dettaglioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quantitàTextBox = new System.Windows.Forms.TextBox();
            this.prezzoTextBox = new System.Windows.Forms.TextBox();
            this.totaleTextBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.nuovaFatturaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.salvaFatturaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.cancellaFatturaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.fatturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.totaleTextBox = new System.Windows.Forms.TextBox();
            nomeLabel1 = new System.Windows.Forms.Label();
            quantitàLabel = new System.Windows.Forms.Label();
            prezzoLabel = new System.Windows.Forms.Label();
            totaleLabel1 = new System.Windows.Forms.Label();
            nomeLabel = new System.Windows.Forms.Label();
            totaleLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fattureDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fattureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dettagliDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dettagliBindingSource)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dettaglioBindingSource)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fatturaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nomeLabel1
            // 
            nomeLabel1.AutoSize = true;
            nomeLabel1.Location = new System.Drawing.Point(3, 0);
            nomeLabel1.Name = "nomeLabel1";
            nomeLabel1.Size = new System.Drawing.Size(38, 13);
            nomeLabel1.TabIndex = 0;
            nomeLabel1.Text = "Nome:";
            // 
            // quantitàLabel
            // 
            quantitàLabel.AutoSize = true;
            quantitàLabel.Location = new System.Drawing.Point(3, 39);
            quantitàLabel.Name = "quantitàLabel";
            quantitàLabel.Size = new System.Drawing.Size(50, 13);
            quantitàLabel.TabIndex = 2;
            quantitàLabel.Text = "Quantità:";
            // 
            // prezzoLabel
            // 
            prezzoLabel.AutoSize = true;
            prezzoLabel.Location = new System.Drawing.Point(3, 78);
            prezzoLabel.Name = "prezzoLabel";
            prezzoLabel.Size = new System.Drawing.Size(42, 13);
            prezzoLabel.TabIndex = 4;
            prezzoLabel.Text = "Prezzo:";
            // 
            // totaleLabel1
            // 
            totaleLabel1.AutoSize = true;
            totaleLabel1.Location = new System.Drawing.Point(3, 117);
            totaleLabel1.Name = "totaleLabel1";
            totaleLabel1.Size = new System.Drawing.Size(40, 13);
            totaleLabel1.TabIndex = 6;
            totaleLabel1.Text = "Totale:";
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(3, 0);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(38, 13);
            nomeLabel.TabIndex = 0;
            nomeLabel.Text = "Nome:";
            // 
            // totaleLabel
            // 
            totaleLabel.AutoSize = true;
            totaleLabel.Location = new System.Drawing.Point(3, 39);
            totaleLabel.Name = "totaleLabel";
            totaleLabel.Size = new System.Drawing.Size(40, 13);
            totaleLabel.TabIndex = 2;
            totaleLabel.Text = "Totale:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.fattureDataGridView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dettagliDataGridView, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(684, 261);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // fattureDataGridView
            // 
            this.fattureDataGridView.AllowUserToAddRows = false;
            this.fattureDataGridView.AllowUserToDeleteRows = false;
            this.fattureDataGridView.AllowUserToResizeRows = false;
            this.fattureDataGridView.AutoGenerateColumns = false;
            this.fattureDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fattureDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fattureDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomeDataGridViewTextBoxColumn,
            this.totaleDataGridViewTextBoxColumn});
            this.fattureDataGridView.DataSource = this.fattureBindingSource;
            this.fattureDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fattureDataGridView.Location = new System.Drawing.Point(3, 3);
            this.fattureDataGridView.MultiSelect = false;
            this.fattureDataGridView.Name = "fattureDataGridView";
            this.fattureDataGridView.ReadOnly = true;
            this.fattureDataGridView.RowHeadersVisible = false;
            this.fattureDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fattureDataGridView.Size = new System.Drawing.Size(130, 255);
            this.fattureDataGridView.TabIndex = 0;
            this.fattureDataGridView.SelectionChanged += new System.EventHandler(this.fattureDataGridView_SelectionChanged);
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totaleDataGridViewTextBoxColumn
            // 
            this.totaleDataGridViewTextBoxColumn.DataPropertyName = "Totale";
            this.totaleDataGridViewTextBoxColumn.HeaderText = "Totale";
            this.totaleDataGridViewTextBoxColumn.Name = "totaleDataGridViewTextBoxColumn";
            this.totaleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fattureBindingSource
            // 
            this.fattureBindingSource.DataSource = typeof(Ciccio1.Domain.Fattura);
            // 
            // dettagliDataGridView
            // 
            this.dettagliDataGridView.AllowUserToAddRows = false;
            this.dettagliDataGridView.AllowUserToDeleteRows = false;
            this.dettagliDataGridView.AllowUserToResizeRows = false;
            this.dettagliDataGridView.AutoGenerateColumns = false;
            this.dettagliDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dettagliDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dettagliDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomeDataGridViewTextBoxColumn1,
            this.quantitàDataGridViewTextBoxColumn,
            this.prezzoDataGridViewTextBoxColumn,
            this.totaleDataGridViewTextBoxColumn1});
            this.dettagliDataGridView.DataSource = this.dettagliBindingSource;
            this.dettagliDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dettagliDataGridView.Location = new System.Drawing.Point(275, 3);
            this.dettagliDataGridView.MultiSelect = false;
            this.dettagliDataGridView.Name = "dettagliDataGridView";
            this.dettagliDataGridView.ReadOnly = true;
            this.dettagliDataGridView.RowHeadersVisible = false;
            this.dettagliDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dettagliDataGridView.Size = new System.Drawing.Size(233, 255);
            this.dettagliDataGridView.TabIndex = 1;
            this.dettagliDataGridView.SelectionChanged += new System.EventHandler(this.dettagliDataGridView_SelectionChanged);
            // 
            // nomeDataGridViewTextBoxColumn1
            // 
            this.nomeDataGridViewTextBoxColumn1.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn1.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn1.Name = "nomeDataGridViewTextBoxColumn1";
            this.nomeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // quantitàDataGridViewTextBoxColumn
            // 
            this.quantitàDataGridViewTextBoxColumn.DataPropertyName = "Quantità";
            this.quantitàDataGridViewTextBoxColumn.HeaderText = "Quantità";
            this.quantitàDataGridViewTextBoxColumn.Name = "quantitàDataGridViewTextBoxColumn";
            this.quantitàDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prezzoDataGridViewTextBoxColumn
            // 
            this.prezzoDataGridViewTextBoxColumn.DataPropertyName = "Prezzo";
            this.prezzoDataGridViewTextBoxColumn.HeaderText = "Prezzo";
            this.prezzoDataGridViewTextBoxColumn.Name = "prezzoDataGridViewTextBoxColumn";
            this.prezzoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totaleDataGridViewTextBoxColumn1
            // 
            this.totaleDataGridViewTextBoxColumn1.DataPropertyName = "Totale";
            this.totaleDataGridViewTextBoxColumn1.HeaderText = "Totale";
            this.totaleDataGridViewTextBoxColumn1.Name = "totaleDataGridViewTextBoxColumn1";
            this.totaleDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dettagliBindingSource
            // 
            this.dettagliBindingSource.DataSource = typeof(Ciccio1.Domain.Dettaglio);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.toolStrip2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(514, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(167, 255);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovoDettaglioToolStripButton,
            this.aggiungiDettaglioToolStripButton,
            this.rimuoviDettaglioToolStripButton,
            this.prodottiToolStripButton,
            this.tipoProdottoToolStripButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(167, 27);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // nuovoDettaglioToolStripButton
            // 
            this.nuovoDettaglioToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nuovoDettaglioToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nuovoDettaglioToolStripButton.Image")));
            this.nuovoDettaglioToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuovoDettaglioToolStripButton.Name = "nuovoDettaglioToolStripButton";
            this.nuovoDettaglioToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.nuovoDettaglioToolStripButton.Text = "&Nuovo";
            this.nuovoDettaglioToolStripButton.Click += new System.EventHandler(this.nuovoDettaglioToolStripButton_Click);
            // 
            // aggiungiDettaglioToolStripButton
            // 
            this.aggiungiDettaglioToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aggiungiDettaglioToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("aggiungiDettaglioToolStripButton.Image")));
            this.aggiungiDettaglioToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aggiungiDettaglioToolStripButton.Name = "aggiungiDettaglioToolStripButton";
            this.aggiungiDettaglioToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.aggiungiDettaglioToolStripButton.Text = "&Aggiungi";
            this.aggiungiDettaglioToolStripButton.Click += new System.EventHandler(this.aggiungiDettaglioToolStripButton_Click);
            // 
            // rimuoviDettaglioToolStripButton
            // 
            this.rimuoviDettaglioToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rimuoviDettaglioToolStripButton.Image = global::Ciccio1.Presentation.WinForm.Properties.Resources.Delete;
            this.rimuoviDettaglioToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rimuoviDettaglioToolStripButton.Name = "rimuoviDettaglioToolStripButton";
            this.rimuoviDettaglioToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.rimuoviDettaglioToolStripButton.Text = "&Rimuovi";
            this.rimuoviDettaglioToolStripButton.Click += new System.EventHandler(this.rimuoviDettaglioToolStripButton_Click);
            // 
            // prodottiToolStripButton
            // 
            this.prodottiToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.prodottiToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("prodottiToolStripButton.Image")));
            this.prodottiToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.prodottiToolStripButton.Name = "prodottiToolStripButton";
            this.prodottiToolStripButton.Size = new System.Drawing.Size(39, 24);
            this.prodottiToolStripButton.Text = "&Prod.";
            this.prodottiToolStripButton.Click += new System.EventHandler(this.prodottiToolStripButton_Click);
            // 
            // tipoProdottoToolStripButton
            // 
            this.tipoProdottoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tipoProdottoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("tipoProdottoToolStripButton.Image")));
            this.tipoProdottoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tipoProdottoToolStripButton.Name = "tipoProdottoToolStripButton";
            this.tipoProdottoToolStripButton.Size = new System.Drawing.Size(35, 19);
            this.tipoProdottoToolStripButton.Text = "&Tipo";
            this.tipoProdottoToolStripButton.Click += new System.EventHandler(this.tipoProdottoToolStripButton_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(nomeLabel1);
            this.flowLayoutPanel2.Controls.Add(this.nomeTextBox1);
            this.flowLayoutPanel2.Controls.Add(quantitàLabel);
            this.flowLayoutPanel2.Controls.Add(this.quantitàTextBox);
            this.flowLayoutPanel2.Controls.Add(prezzoLabel);
            this.flowLayoutPanel2.Controls.Add(this.prezzoTextBox);
            this.flowLayoutPanel2.Controls.Add(totaleLabel1);
            this.flowLayoutPanel2.Controls.Add(this.totaleTextBox1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 30);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(161, 222);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // nomeTextBox1
            // 
            this.nomeTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dettaglioBindingSource, "Nome", true));
            this.nomeTextBox1.Location = new System.Drawing.Point(3, 16);
            this.nomeTextBox1.Name = "nomeTextBox1";
            this.nomeTextBox1.Size = new System.Drawing.Size(100, 20);
            this.nomeTextBox1.TabIndex = 1;
            // 
            // dettaglioBindingSource
            // 
            this.dettaglioBindingSource.DataSource = typeof(Ciccio1.Domain.Dettaglio);
            // 
            // quantitàTextBox
            // 
            this.quantitàTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dettaglioBindingSource, "Quantità", true));
            this.quantitàTextBox.Location = new System.Drawing.Point(3, 55);
            this.quantitàTextBox.Name = "quantitàTextBox";
            this.quantitàTextBox.Size = new System.Drawing.Size(100, 20);
            this.quantitàTextBox.TabIndex = 3;
            // 
            // prezzoTextBox
            // 
            this.prezzoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dettaglioBindingSource, "Prezzo", true));
            this.prezzoTextBox.Location = new System.Drawing.Point(3, 94);
            this.prezzoTextBox.Name = "prezzoTextBox";
            this.prezzoTextBox.Size = new System.Drawing.Size(100, 20);
            this.prezzoTextBox.TabIndex = 5;
            // 
            // totaleTextBox1
            // 
            this.totaleTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dettaglioBindingSource, "Totale", true));
            this.totaleTextBox1.Location = new System.Drawing.Point(3, 133);
            this.totaleTextBox1.Name = "totaleTextBox1";
            this.totaleTextBox1.Size = new System.Drawing.Size(100, 20);
            this.totaleTextBox1.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(139, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(130, 255);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovaFatturaToolStripButton,
            this.salvaFatturaToolStripButton,
            this.cancellaFatturaToolStripButton,
            this.aboutToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(130, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // nuovaFatturaToolStripButton
            // 
            this.nuovaFatturaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nuovaFatturaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nuovaFatturaToolStripButton.Image")));
            this.nuovaFatturaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuovaFatturaToolStripButton.Name = "nuovaFatturaToolStripButton";
            this.nuovaFatturaToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.nuovaFatturaToolStripButton.Text = "&Nuova";
            this.nuovaFatturaToolStripButton.Click += new System.EventHandler(this.nuovaFatturaToolStripButton_Click);
            // 
            // salvaFatturaToolStripButton
            // 
            this.salvaFatturaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.salvaFatturaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("salvaFatturaToolStripButton.Image")));
            this.salvaFatturaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salvaFatturaToolStripButton.Name = "salvaFatturaToolStripButton";
            this.salvaFatturaToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.salvaFatturaToolStripButton.Text = "&Salva";
            this.salvaFatturaToolStripButton.Click += new System.EventHandler(this.salvaFatturaToolStripButton_Click);
            // 
            // cancellaFatturaToolStripButton
            // 
            this.cancellaFatturaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cancellaFatturaToolStripButton.Image = global::Ciccio1.Presentation.WinForm.Properties.Resources.Delete;
            this.cancellaFatturaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancellaFatturaToolStripButton.Name = "cancellaFatturaToolStripButton";
            this.cancellaFatturaToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.cancellaFatturaToolStripButton.Text = "&Cancella";
            this.cancellaFatturaToolStripButton.Click += new System.EventHandler(this.cancellaFatturaToolStripButton_Click);
            // 
            // aboutToolStripButton
            // 
            this.aboutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aboutToolStripButton.Image = global::Ciccio1.Presentation.WinForm.Properties.Resources.About;
            this.aboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutToolStripButton.Name = "aboutToolStripButton";
            this.aboutToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.aboutToolStripButton.Text = "toolStripButton1";
            this.aboutToolStripButton.Click += new System.EventHandler(this.aboutToolStripButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(nomeLabel);
            this.flowLayoutPanel1.Controls.Add(this.nomeTextBox);
            this.flowLayoutPanel1.Controls.Add(totaleLabel);
            this.flowLayoutPanel1.Controls.Add(this.totaleTextBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 30);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(124, 222);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fatturaBindingSource, "Nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(3, 16);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(100, 20);
            this.nomeTextBox.TabIndex = 1;
            // 
            // fatturaBindingSource
            // 
            this.fatturaBindingSource.DataSource = typeof(Ciccio1.Domain.Fattura);
            // 
            // totaleTextBox
            // 
            this.totaleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fatturaBindingSource, "Totale", true));
            this.totaleTextBox.Location = new System.Drawing.Point(3, 55);
            this.totaleTextBox.Name = "totaleTextBox";
            this.totaleTextBox.Size = new System.Drawing.Size(100, 20);
            this.totaleTextBox.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fattureDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fattureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dettagliDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dettagliBindingSource)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dettaglioBindingSource)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fatturaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView fattureDataGridView;
        private System.Windows.Forms.DataGridView dettagliDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton nuovoDettaglioToolStripButton;
        private System.Windows.Forms.ToolStripButton aggiungiDettaglioToolStripButton;
        private System.Windows.Forms.ToolStripButton rimuoviDettaglioToolStripButton;
        private System.Windows.Forms.ToolStripButton prodottiToolStripButton;
        private System.Windows.Forms.ToolStripButton tipoProdottoToolStripButton;
        private System.Windows.Forms.BindingSource fatturaBindingSource;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox nomeTextBox1;
        private System.Windows.Forms.BindingSource dettaglioBindingSource;
        private System.Windows.Forms.TextBox quantitàTextBox;
        private System.Windows.Forms.TextBox prezzoTextBox;
        private System.Windows.Forms.TextBox totaleTextBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton nuovaFatturaToolStripButton;
        private System.Windows.Forms.ToolStripButton salvaFatturaToolStripButton;
        private System.Windows.Forms.ToolStripButton cancellaFatturaToolStripButton;
        private System.Windows.Forms.ToolStripButton aboutToolStripButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.TextBox totaleTextBox;
        private System.Windows.Forms.BindingSource fattureBindingSource;
        private System.Windows.Forms.BindingSource dettagliBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantitàDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezzoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totaleDataGridViewTextBoxColumn1;
    }
}