namespace Ciccio1.Presentation.WinForm.Views
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
            System.Windows.Forms.Label nomeFatturaLabel;
            System.Windows.Forms.Label nomeDettaglioLabel;
            System.Windows.Forms.Label quantitàDettaglioLabel;
            System.Windows.Forms.Label prezzoDettaglioLabel;
            System.Windows.Forms.Label totaleDettaglioLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FatturaView));
            this.dettagliDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeProdotto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrezzoProdotto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totaleDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dettagliBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.nomeDettaglioTextBox = new System.Windows.Forms.TextBox();
            this.dettaglioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quantitàDettaglioTextBox = new System.Windows.Forms.TextBox();
            this.prezzoDettaglioTextBox = new System.Windows.Forms.TextBox();
            this.totaleDettaglioTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.nomeFatturaTextBox = new System.Windows.Forms.TextBox();
            this.fatturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.totaleFatturaLabel = new System.Windows.Forms.Label();
            this.totaleFatturaTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.nuovoDettaglioToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.aggiungiDettaglioToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.rimuoviDettaglioToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.prodottiToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.categorieToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.nuovaFatturaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.salvaFatturaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.cancellaFatturaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fattureDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fattureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            nomeFatturaLabel = new System.Windows.Forms.Label();
            nomeDettaglioLabel = new System.Windows.Forms.Label();
            quantitàDettaglioLabel = new System.Windows.Forms.Label();
            prezzoDettaglioLabel = new System.Windows.Forms.Label();
            totaleDettaglioLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dettagliDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dettagliBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dettaglioBindingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fatturaBindingSource)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fattureDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fattureBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nomeFatturaLabel
            // 
            nomeFatturaLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            nomeFatturaLabel.AutoSize = true;
            nomeFatturaLabel.Location = new System.Drawing.Point(4, 6);
            nomeFatturaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            nomeFatturaLabel.Name = "nomeFatturaLabel";
            nomeFatturaLabel.Size = new System.Drawing.Size(49, 17);
            nomeFatturaLabel.TabIndex = 0;
            nomeFatturaLabel.Text = "Nome:";
            // 
            // nomeDettaglioLabel
            // 
            nomeDettaglioLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            nomeDettaglioLabel.AutoSize = true;
            nomeDettaglioLabel.Location = new System.Drawing.Point(4, 6);
            nomeDettaglioLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            nomeDettaglioLabel.Name = "nomeDettaglioLabel";
            nomeDettaglioLabel.Size = new System.Drawing.Size(49, 17);
            nomeDettaglioLabel.TabIndex = 8;
            nomeDettaglioLabel.Text = "Nome:";
            // 
            // quantitàDettaglioLabel
            // 
            quantitàDettaglioLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            quantitàDettaglioLabel.AutoSize = true;
            quantitàDettaglioLabel.Location = new System.Drawing.Point(188, 6);
            quantitàDettaglioLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            quantitàDettaglioLabel.Name = "quantitàDettaglioLabel";
            quantitàDettaglioLabel.Size = new System.Drawing.Size(39, 17);
            quantitàDettaglioLabel.TabIndex = 9;
            quantitàDettaglioLabel.Text = "Q.tà:";
            // 
            // prezzoDettaglioLabel
            // 
            prezzoDettaglioLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            prezzoDettaglioLabel.AutoSize = true;
            prezzoDettaglioLabel.Location = new System.Drawing.Point(282, 6);
            prezzoDettaglioLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            prezzoDettaglioLabel.Name = "prezzoDettaglioLabel";
            prezzoDettaglioLabel.Size = new System.Drawing.Size(56, 17);
            prezzoDettaglioLabel.TabIndex = 10;
            prezzoDettaglioLabel.Text = "Prezzo:";
            // 
            // totaleDettaglioLabel
            // 
            totaleDettaglioLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            totaleDettaglioLabel.AutoSize = true;
            totaleDettaglioLabel.Location = new System.Drawing.Point(393, 6);
            totaleDettaglioLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            totaleDettaglioLabel.Name = "totaleDettaglioLabel";
            totaleDettaglioLabel.Size = new System.Drawing.Size(37, 17);
            totaleDettaglioLabel.TabIndex = 11;
            totaleDettaglioLabel.Text = "Tot.:";
            // 
            // dettagliDataGridView
            // 
            this.dettagliDataGridView.AllowUserToAddRows = false;
            this.dettagliDataGridView.AllowUserToDeleteRows = false;
            this.dettagliDataGridView.AllowUserToResizeRows = false;
            this.dettagliDataGridView.AutoGenerateColumns = false;
            this.dettagliDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dettagliDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn2,
            this.NomeProdotto,
            this.PrezzoProdotto,
            this.dataGridViewTextBoxColumn1,
            this.totaleDataGridViewTextBoxColumn2});
            this.dettagliDataGridView.DataSource = this.dettagliBindingSource;
            this.dettagliDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dettagliDataGridView.Location = new System.Drawing.Point(292, 69);
            this.dettagliDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dettagliDataGridView.MultiSelect = false;
            this.dettagliDataGridView.Name = "dettagliDataGridView";
            this.dettagliDataGridView.ReadOnly = true;
            this.dettagliDataGridView.RowHeadersVisible = false;
            this.dettagliDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dettagliDataGridView.Size = new System.Drawing.Size(485, 238);
            this.dettagliDataGridView.TabIndex = 0;
            this.dettagliDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dettagliDataGridView_CellClick);
            // 
            // idDataGridViewTextBoxColumn2
            // 
            this.idDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.idDataGridViewTextBoxColumn2.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn2.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn2.Name = "idDataGridViewTextBoxColumn2";
            this.idDataGridViewTextBoxColumn2.ReadOnly = true;
            this.idDataGridViewTextBoxColumn2.Width = 48;
            // 
            // NomeProdotto
            // 
            this.NomeProdotto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NomeProdotto.DataPropertyName = "NomeProdotto";
            this.NomeProdotto.HeaderText = "Nome";
            this.NomeProdotto.Name = "NomeProdotto";
            this.NomeProdotto.ReadOnly = true;
            // 
            // PrezzoProdotto
            // 
            this.PrezzoProdotto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PrezzoProdotto.DataPropertyName = "PrezzoProdotto";
            this.PrezzoProdotto.HeaderText = "Prezzo";
            this.PrezzoProdotto.Name = "PrezzoProdotto";
            this.PrezzoProdotto.ReadOnly = true;
            this.PrezzoProdotto.Width = 81;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Quantità";
            this.dataGridViewTextBoxColumn1.HeaderText = "Quantità";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 91;
            // 
            // totaleDataGridViewTextBoxColumn2
            // 
            this.totaleDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.totaleDataGridViewTextBoxColumn2.DataPropertyName = "Totale";
            this.totaleDataGridViewTextBoxColumn2.HeaderText = "Totale";
            this.totaleDataGridViewTextBoxColumn2.Name = "totaleDataGridViewTextBoxColumn2";
            this.totaleDataGridViewTextBoxColumn2.ReadOnly = true;
            this.totaleDataGridViewTextBoxColumn2.Width = 77;
            // 
            // dettagliBindingSource
            // 
            this.dettagliBindingSource.DataSource = typeof(Ciccio1.Domain.Dettaglio);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dettagliDataGridView, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.fattureDataGridView, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(781, 311);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(nomeDettaglioLabel);
            this.flowLayoutPanel2.Controls.Add(this.nomeDettaglioTextBox);
            this.flowLayoutPanel2.Controls.Add(quantitàDettaglioLabel);
            this.flowLayoutPanel2.Controls.Add(this.quantitàDettaglioTextBox);
            this.flowLayoutPanel2.Controls.Add(prezzoDettaglioLabel);
            this.flowLayoutPanel2.Controls.Add(this.prezzoDettaglioTextBox);
            this.flowLayoutPanel2.Controls.Add(totaleDettaglioLabel);
            this.flowLayoutPanel2.Controls.Add(this.totaleDettaglioTextBox);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(292, 31);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(485, 30);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // nomeDettaglioTextBox
            // 
            this.nomeDettaglioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dettaglioBindingSource, "NomeProdotto", true));
            this.nomeDettaglioTextBox.Location = new System.Drawing.Point(61, 4);
            this.nomeDettaglioTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nomeDettaglioTextBox.Name = "nomeDettaglioTextBox";
            this.nomeDettaglioTextBox.ReadOnly = true;
            this.nomeDettaglioTextBox.Size = new System.Drawing.Size(119, 22);
            this.nomeDettaglioTextBox.TabIndex = 0;
            this.nomeDettaglioTextBox.TabStop = false;
            // 
            // dettaglioBindingSource
            // 
            this.dettaglioBindingSource.DataSource = typeof(Ciccio1.Domain.Dettaglio);
            // 
            // quantitàDettaglioTextBox
            // 
            this.quantitàDettaglioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dettaglioBindingSource, "Quantità", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.quantitàDettaglioTextBox.Location = new System.Drawing.Point(235, 4);
            this.quantitàDettaglioTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.quantitàDettaglioTextBox.Name = "quantitàDettaglioTextBox";
            this.quantitàDettaglioTextBox.Size = new System.Drawing.Size(39, 22);
            this.quantitàDettaglioTextBox.TabIndex = 1;
            // 
            // prezzoDettaglioTextBox
            // 
            this.prezzoDettaglioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dettaglioBindingSource, "PrezzoProdotto", true));
            this.prezzoDettaglioTextBox.Location = new System.Drawing.Point(346, 4);
            this.prezzoDettaglioTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.prezzoDettaglioTextBox.Name = "prezzoDettaglioTextBox";
            this.prezzoDettaglioTextBox.ReadOnly = true;
            this.prezzoDettaglioTextBox.Size = new System.Drawing.Size(39, 22);
            this.prezzoDettaglioTextBox.TabIndex = 0;
            this.prezzoDettaglioTextBox.TabStop = false;
            // 
            // totaleDettaglioTextBox
            // 
            this.totaleDettaglioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dettaglioBindingSource, "Totale", true));
            this.totaleDettaglioTextBox.Location = new System.Drawing.Point(438, 4);
            this.totaleDettaglioTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.totaleDettaglioTextBox.Name = "totaleDettaglioTextBox";
            this.totaleDettaglioTextBox.ReadOnly = true;
            this.totaleDettaglioTextBox.Size = new System.Drawing.Size(39, 22);
            this.totaleDettaglioTextBox.TabIndex = 0;
            this.totaleDettaglioTextBox.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(nomeFatturaLabel);
            this.flowLayoutPanel1.Controls.Add(this.nomeFatturaTextBox);
            this.flowLayoutPanel1.Controls.Add(this.totaleFatturaLabel);
            this.flowLayoutPanel1.Controls.Add(this.totaleFatturaTextBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 31);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // nomeFatturaTextBox
            // 
            this.nomeFatturaTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nomeFatturaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fatturaBindingSource, "Nome", true));
            this.nomeFatturaTextBox.Location = new System.Drawing.Point(61, 4);
            this.nomeFatturaTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nomeFatturaTextBox.Name = "nomeFatturaTextBox";
            this.nomeFatturaTextBox.Size = new System.Drawing.Size(119, 22);
            this.nomeFatturaTextBox.TabIndex = 99;
            this.nomeFatturaTextBox.TabStop = false;
            // 
            // fatturaBindingSource
            // 
            this.fatturaBindingSource.DataSource = typeof(Ciccio1.Domain.Fattura);
            // 
            // totaleFatturaLabel
            // 
            this.totaleFatturaLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.totaleFatturaLabel.AutoSize = true;
            this.totaleFatturaLabel.Location = new System.Drawing.Point(188, 6);
            this.totaleFatturaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totaleFatturaLabel.Name = "totaleFatturaLabel";
            this.totaleFatturaLabel.Size = new System.Drawing.Size(33, 17);
            this.totaleFatturaLabel.TabIndex = 0;
            this.totaleFatturaLabel.Text = "Tot:";
            // 
            // totaleFatturaTextBox
            // 
            this.totaleFatturaTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.totaleFatturaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fatturaBindingSource, "Totale", true));
            this.totaleFatturaTextBox.Location = new System.Drawing.Point(229, 4);
            this.totaleFatturaTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.totaleFatturaTextBox.Name = "totaleFatturaTextBox";
            this.totaleFatturaTextBox.ReadOnly = true;
            this.totaleFatturaTextBox.Size = new System.Drawing.Size(39, 22);
            this.totaleFatturaTextBox.TabIndex = 0;
            this.totaleFatturaTextBox.TabStop = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovoDettaglioToolStripButton,
            this.aggiungiDettaglioToolStripButton,
            this.rimuoviDettaglioToolStripButton,
            this.prodottiToolStripButton,
            this.categorieToolStripButton,
            this.aboutToolStripButton});
            this.toolStrip2.Location = new System.Drawing.Point(288, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(493, 27);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // nuovoDettaglioToolStripButton
            // 
            this.nuovoDettaglioToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nuovoDettaglioToolStripButton.Image")));
            this.nuovoDettaglioToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuovoDettaglioToolStripButton.Name = "nuovoDettaglioToolStripButton";
            this.nuovoDettaglioToolStripButton.Size = new System.Drawing.Size(77, 24);
            this.nuovoDettaglioToolStripButton.Text = "Nuovo";
            this.nuovoDettaglioToolStripButton.Click += new System.EventHandler(this.NuovoDettaglioToolStripButton_Click);
            // 
            // aggiungiDettaglioToolStripButton
            // 
            this.aggiungiDettaglioToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("aggiungiDettaglioToolStripButton.Image")));
            this.aggiungiDettaglioToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aggiungiDettaglioToolStripButton.Name = "aggiungiDettaglioToolStripButton";
            this.aggiungiDettaglioToolStripButton.Size = new System.Drawing.Size(94, 24);
            this.aggiungiDettaglioToolStripButton.Text = "&Aggiungi";
            this.aggiungiDettaglioToolStripButton.Click += new System.EventHandler(this.AggiungiDettaglioToolStripButton_Click);
            // 
            // rimuoviDettaglioToolStripButton
            // 
            this.rimuoviDettaglioToolStripButton.Image = global::Ciccio1.Presentation.WinForm.Properties.Resources.Delete;
            this.rimuoviDettaglioToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rimuoviDettaglioToolStripButton.Name = "rimuoviDettaglioToolStripButton";
            this.rimuoviDettaglioToolStripButton.Size = new System.Drawing.Size(87, 24);
            this.rimuoviDettaglioToolStripButton.Text = "&Rimuovi";
            this.rimuoviDettaglioToolStripButton.Click += new System.EventHandler(this.RimuoviDettaglioToolStripButton_Click);
            // 
            // prodottiToolStripButton
            // 
            this.prodottiToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.prodottiToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("prodottiToolStripButton.Image")));
            this.prodottiToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.prodottiToolStripButton.Name = "prodottiToolStripButton";
            this.prodottiToolStripButton.Size = new System.Drawing.Size(67, 24);
            this.prodottiToolStripButton.Text = "&Prodotti";
            this.prodottiToolStripButton.Click += new System.EventHandler(this.ProdottiToolStripButton_Click);
            // 
            // categorieToolStripButton
            // 
            this.categorieToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.categorieToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("categorieToolStripButton.Image")));
            this.categorieToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.categorieToolStripButton.Name = "categorieToolStripButton";
            this.categorieToolStripButton.Size = new System.Drawing.Size(78, 24);
            this.categorieToolStripButton.Text = "&Categorie";
            this.categorieToolStripButton.Click += new System.EventHandler(this.CategorieToolStripButton_Click);
            // 
            // aboutToolStripButton
            // 
            this.aboutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aboutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripButton.Image")));
            this.aboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutToolStripButton.Name = "aboutToolStripButton";
            this.aboutToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.aboutToolStripButton.Text = "&?";
            this.aboutToolStripButton.Click += new System.EventHandler(this.AboutToolStripButton_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovaFatturaToolStripButton,
            this.salvaFatturaToolStripButton,
            this.cancellaFatturaToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(288, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // nuovaFatturaToolStripButton
            // 
            this.nuovaFatturaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nuovaFatturaToolStripButton.Image")));
            this.nuovaFatturaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuovaFatturaToolStripButton.Name = "nuovaFatturaToolStripButton";
            this.nuovaFatturaToolStripButton.Size = new System.Drawing.Size(76, 24);
            this.nuovaFatturaToolStripButton.Text = "&Nuova";
            this.nuovaFatturaToolStripButton.Click += new System.EventHandler(this.NuovaFatturaToolStripButton_Click);
            // 
            // salvaFatturaToolStripButton
            // 
            this.salvaFatturaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("salvaFatturaToolStripButton.Image")));
            this.salvaFatturaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salvaFatturaToolStripButton.Name = "salvaFatturaToolStripButton";
            this.salvaFatturaToolStripButton.Size = new System.Drawing.Size(68, 24);
            this.salvaFatturaToolStripButton.Text = "&Salva";
            this.salvaFatturaToolStripButton.Click += new System.EventHandler(this.SalvaFatturaToolStripButton_Click);
            // 
            // cancellaFatturaToolStripButton
            // 
            this.cancellaFatturaToolStripButton.Image = global::Ciccio1.Presentation.WinForm.Properties.Resources.Delete;
            this.cancellaFatturaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancellaFatturaToolStripButton.Name = "cancellaFatturaToolStripButton";
            this.cancellaFatturaToolStripButton.Size = new System.Drawing.Size(89, 24);
            this.cancellaFatturaToolStripButton.Text = "&Cancella";
            this.cancellaFatturaToolStripButton.Click += new System.EventHandler(this.CancellaFatturaToolStripButton_Click);
            // 
            // fattureDataGridView
            // 
            this.fattureDataGridView.AllowUserToAddRows = false;
            this.fattureDataGridView.AllowUserToDeleteRows = false;
            this.fattureDataGridView.AllowUserToResizeRows = false;
            this.fattureDataGridView.AutoGenerateColumns = false;
            this.fattureDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fattureDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn,
            this.totaleDataGridViewTextBoxColumn});
            this.fattureDataGridView.DataSource = this.fattureBindingSource;
            this.fattureDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fattureDataGridView.Location = new System.Drawing.Point(4, 69);
            this.fattureDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.fattureDataGridView.MultiSelect = false;
            this.fattureDataGridView.Name = "fattureDataGridView";
            this.fattureDataGridView.ReadOnly = true;
            this.fattureDataGridView.RowHeadersVisible = false;
            this.fattureDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fattureDataGridView.Size = new System.Drawing.Size(280, 238);
            this.fattureDataGridView.TabIndex = 5;
            this.fattureDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fattureDataGridView_CellClick);
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
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
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
            // fattureBindingSource
            // 
            this.fattureBindingSource.DataSource = typeof(Ciccio1.Domain.Fattura);
            // 
            // FatturaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 311);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FatturaView";
            this.Text = "Fattura";
            this.Load += new System.EventHandler(this.View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dettagliDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dettagliBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dettaglioBindingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fatturaBindingSource)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fattureDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fattureBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox nomeFatturaTextBox;
        private System.Windows.Forms.Label totaleFatturaLabel;
        private System.Windows.Forms.TextBox totaleFatturaTextBox;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TextBox nomeDettaglioTextBox;
        private System.Windows.Forms.TextBox quantitàDettaglioTextBox;
        private System.Windows.Forms.TextBox prezzoDettaglioTextBox;
        private System.Windows.Forms.TextBox totaleDettaglioTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeProdotto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrezzoProdotto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn totaleDataGridViewTextBoxColumn2;
        private System.Windows.Forms.ToolStripButton nuovoDettaglioToolStripButton;
        private System.Windows.Forms.ToolStripButton aggiungiDettaglioToolStripButton;
        private System.Windows.Forms.ToolStripButton rimuoviDettaglioToolStripButton;
        private System.Windows.Forms.ToolStripButton prodottiToolStripButton;
        private System.Windows.Forms.ToolStripButton categorieToolStripButton;
        private System.Windows.Forms.ToolStripButton aboutToolStripButton;
        private System.Windows.Forms.ToolStripButton nuovaFatturaToolStripButton;
        private System.Windows.Forms.ToolStripButton salvaFatturaToolStripButton;
        private System.Windows.Forms.ToolStripButton cancellaFatturaToolStripButton;
        private System.Windows.Forms.DataGridView fattureDataGridView;
        private System.Windows.Forms.DataGridView dettagliDataGridView;
        private System.Windows.Forms.BindingSource fattureBindingSource;
        private System.Windows.Forms.BindingSource fatturaBindingSource;
        private System.Windows.Forms.BindingSource dettagliBindingSource;
        private System.Windows.Forms.BindingSource dettaglioBindingSource;
    }
}