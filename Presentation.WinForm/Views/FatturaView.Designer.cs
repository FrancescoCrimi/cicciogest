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
            this.DettagliDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totaleDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DettagliBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FatturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FattureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.nomeDettaglioTextBox = new System.Windows.Forms.TextBox();
            this.DettaglioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quantitàDettaglioTextBox = new System.Windows.Forms.TextBox();
            this.prezzoDettaglioTextBox = new System.Windows.Forms.TextBox();
            this.totaleDettaglioTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.nomeFatturaTextBox = new System.Windows.Forms.TextBox();
            this.totaleFatturaLabel = new System.Windows.Forms.Label();
            this.totaleFatturaTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.NuovoDettaglioToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.AggiungiDettaglioToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.RimuoviDettaglioToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ProdottiToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.CategorieToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.AboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.NuovaFatturaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SalvaFatturaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.CancellaFatturaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.FattureDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            nomeFatturaLabel = new System.Windows.Forms.Label();
            nomeDettaglioLabel = new System.Windows.Forms.Label();
            quantitàDettaglioLabel = new System.Windows.Forms.Label();
            prezzoDettaglioLabel = new System.Windows.Forms.Label();
            totaleDettaglioLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DettagliDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DettagliBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FatturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FattureBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DettaglioBindingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FattureDataGridView)).BeginInit();
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
            // DettagliDataGridView
            // 
            this.DettagliDataGridView.AllowUserToAddRows = false;
            this.DettagliDataGridView.AllowUserToDeleteRows = false;
            this.DettagliDataGridView.AllowUserToResizeRows = false;
            this.DettagliDataGridView.AutoGenerateColumns = false;
            this.DettagliDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DettagliDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DettagliDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn2,
            this.nomeDataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.totaleDataGridViewTextBoxColumn2});
            this.DettagliDataGridView.DataSource = this.DettagliBindingSource;
            this.DettagliDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DettagliDataGridView.Location = new System.Drawing.Point(296, 67);
            this.DettagliDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DettagliDataGridView.MultiSelect = false;
            this.DettagliDataGridView.Name = "DettagliDataGridView";
            this.DettagliDataGridView.ReadOnly = true;
            this.DettagliDataGridView.RowHeadersVisible = false;
            this.DettagliDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DettagliDataGridView.Size = new System.Drawing.Size(493, 237);
            this.DettagliDataGridView.TabIndex = 0;
            this.DettagliDataGridView.TabStop = false;
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
            // nomeDataGridViewTextBoxColumn2
            // 
            this.nomeDataGridViewTextBoxColumn2.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn2.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn2.Name = "nomeDataGridViewTextBoxColumn2";
            this.nomeDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Prezzo";
            this.dataGridViewTextBoxColumn2.HeaderText = "Prezzo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Quantità";
            this.dataGridViewTextBoxColumn1.HeaderText = "Quantità";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // totaleDataGridViewTextBoxColumn2
            // 
            this.totaleDataGridViewTextBoxColumn2.DataPropertyName = "Totale";
            this.totaleDataGridViewTextBoxColumn2.HeaderText = "Totale";
            this.totaleDataGridViewTextBoxColumn2.Name = "totaleDataGridViewTextBoxColumn2";
            this.totaleDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // DettagliBindingSource
            // 
            this.DettagliBindingSource.DataSource = typeof(Ciccio1.Domain.Dettaglio);
            // 
            // FatturaBindingSource
            // 
            this.FatturaBindingSource.DataSource = typeof(Ciccio1.Domain.Fattura);
            // 
            // FattureBindingSource
            // 
            this.FattureBindingSource.DataSource = typeof(Ciccio1.Domain.Fattura);
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
            this.tableLayoutPanel1.Controls.Add(this.DettagliDataGridView, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.FattureDataGridView, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(792, 304);
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
            this.flowLayoutPanel2.Location = new System.Drawing.Point(297, 31);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(491, 30);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // nomeDettaglioTextBox
            // 
            this.nomeDettaglioTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.nomeDettaglioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DettaglioBindingSource, "Nome", true));
            this.nomeDettaglioTextBox.Location = new System.Drawing.Point(61, 4);
            this.nomeDettaglioTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nomeDettaglioTextBox.Name = "nomeDettaglioTextBox";
            this.nomeDettaglioTextBox.ReadOnly = true;
            this.nomeDettaglioTextBox.Size = new System.Drawing.Size(119, 22);
            this.nomeDettaglioTextBox.TabIndex = 0;
            this.nomeDettaglioTextBox.TabStop = false;
            // 
            // DettaglioBindingSource
            // 
            this.DettaglioBindingSource.DataSource = typeof(Ciccio1.Domain.Dettaglio);
            // 
            // quantitàDettaglioTextBox
            // 
            this.quantitàDettaglioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DettaglioBindingSource, "Quantità", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.quantitàDettaglioTextBox.Location = new System.Drawing.Point(235, 4);
            this.quantitàDettaglioTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.quantitàDettaglioTextBox.Name = "quantitàDettaglioTextBox";
            this.quantitàDettaglioTextBox.Size = new System.Drawing.Size(39, 22);
            this.quantitàDettaglioTextBox.TabIndex = 1;
            // 
            // prezzoDettaglioTextBox
            // 
            this.prezzoDettaglioTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.prezzoDettaglioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DettaglioBindingSource, "Prezzo", true));
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
            this.totaleDettaglioTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.totaleDettaglioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DettaglioBindingSource, "Totale", true));
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(285, 30);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // nomeFatturaTextBox
            // 
            this.nomeFatturaTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nomeFatturaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.FatturaBindingSource, "Nome", true));
            this.nomeFatturaTextBox.Location = new System.Drawing.Point(61, 4);
            this.nomeFatturaTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nomeFatturaTextBox.Name = "nomeFatturaTextBox";
            this.nomeFatturaTextBox.Size = new System.Drawing.Size(119, 22);
            this.nomeFatturaTextBox.TabIndex = 99;
            this.nomeFatturaTextBox.TabStop = false;
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
            this.totaleFatturaTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.totaleFatturaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.FatturaBindingSource, "Totale", true));
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
            this.NuovoDettaglioToolStripButton,
            this.AggiungiDettaglioToolStripButton,
            this.RimuoviDettaglioToolStripButton,
            this.ProdottiToolStripButton,
            this.CategorieToolStripButton,
            this.AboutToolStripButton});
            this.toolStrip2.Location = new System.Drawing.Point(293, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(499, 27);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // NuovoDettaglioToolStripButton
            // 
            this.NuovoDettaglioToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("NuovoDettaglioToolStripButton.Image")));
            this.NuovoDettaglioToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NuovoDettaglioToolStripButton.Name = "NuovoDettaglioToolStripButton";
            this.NuovoDettaglioToolStripButton.Size = new System.Drawing.Size(77, 24);
            this.NuovoDettaglioToolStripButton.Text = "&Nuovo";
            // 
            // AggiungiDettaglioToolStripButton
            // 
            this.AggiungiDettaglioToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AggiungiDettaglioToolStripButton.Image")));
            this.AggiungiDettaglioToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AggiungiDettaglioToolStripButton.Name = "AggiungiDettaglioToolStripButton";
            this.AggiungiDettaglioToolStripButton.Size = new System.Drawing.Size(94, 24);
            this.AggiungiDettaglioToolStripButton.Text = "&Aggiungi";
            // 
            // RimuoviDettaglioToolStripButton
            // 
            this.RimuoviDettaglioToolStripButton.Image = global::Ciccio1.Presentation.WinForm.Properties.Resources.Delete;
            this.RimuoviDettaglioToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RimuoviDettaglioToolStripButton.Name = "RimuoviDettaglioToolStripButton";
            this.RimuoviDettaglioToolStripButton.Size = new System.Drawing.Size(87, 24);
            this.RimuoviDettaglioToolStripButton.Text = "&Rimuovi";
            // 
            // ProdottiToolStripButton
            // 
            this.ProdottiToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ProdottiToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ProdottiToolStripButton.Image")));
            this.ProdottiToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ProdottiToolStripButton.Name = "ProdottiToolStripButton";
            this.ProdottiToolStripButton.Size = new System.Drawing.Size(67, 24);
            this.ProdottiToolStripButton.Text = "&Prodotti";
            // 
            // CategorieToolStripButton
            // 
            this.CategorieToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CategorieToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("CategorieToolStripButton.Image")));
            this.CategorieToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CategorieToolStripButton.Name = "CategorieToolStripButton";
            this.CategorieToolStripButton.Size = new System.Drawing.Size(78, 24);
            this.CategorieToolStripButton.Text = "&Categorie";
            // 
            // AboutToolStripButton
            // 
            this.AboutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AboutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AboutToolStripButton.Image")));
            this.AboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutToolStripButton.Name = "AboutToolStripButton";
            this.AboutToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.AboutToolStripButton.Text = "&?";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NuovaFatturaToolStripButton,
            this.SalvaFatturaToolStripButton,
            this.CancellaFatturaToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(293, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // NuovaFatturaToolStripButton
            // 
            this.NuovaFatturaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("NuovaFatturaToolStripButton.Image")));
            this.NuovaFatturaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NuovaFatturaToolStripButton.Name = "NuovaFatturaToolStripButton";
            this.NuovaFatturaToolStripButton.Size = new System.Drawing.Size(76, 24);
            this.NuovaFatturaToolStripButton.Text = "&Nuova";
            // 
            // SalvaFatturaToolStripButton
            // 
            this.SalvaFatturaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SalvaFatturaToolStripButton.Image")));
            this.SalvaFatturaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SalvaFatturaToolStripButton.Name = "SalvaFatturaToolStripButton";
            this.SalvaFatturaToolStripButton.Size = new System.Drawing.Size(68, 24);
            this.SalvaFatturaToolStripButton.Text = "&Salva";
            // 
            // CancellaFatturaToolStripButton
            // 
            this.CancellaFatturaToolStripButton.Image = global::Ciccio1.Presentation.WinForm.Properties.Resources.Delete;
            this.CancellaFatturaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancellaFatturaToolStripButton.Name = "CancellaFatturaToolStripButton";
            this.CancellaFatturaToolStripButton.Size = new System.Drawing.Size(89, 24);
            this.CancellaFatturaToolStripButton.Text = "&Cancella";
            // 
            // FattureDataGridView
            // 
            this.FattureDataGridView.AllowUserToAddRows = false;
            this.FattureDataGridView.AllowUserToDeleteRows = false;
            this.FattureDataGridView.AllowUserToResizeRows = false;
            this.FattureDataGridView.AutoGenerateColumns = false;
            this.FattureDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FattureDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FattureDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn,
            this.totaleDataGridViewTextBoxColumn});
            this.FattureDataGridView.DataSource = this.FattureBindingSource;
            this.FattureDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FattureDataGridView.Location = new System.Drawing.Point(4, 69);
            this.FattureDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.FattureDataGridView.MultiSelect = false;
            this.FattureDataGridView.Name = "FattureDataGridView";
            this.FattureDataGridView.ReadOnly = true;
            this.FattureDataGridView.RowHeadersVisible = false;
            this.FattureDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FattureDataGridView.Size = new System.Drawing.Size(285, 233);
            this.FattureDataGridView.TabIndex = 5;
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
            // FatturaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 304);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FatturaView";
            this.Text = "Fattura";
            ((System.ComponentModel.ISupportInitialize)(this.DettagliDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DettagliBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FatturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FattureBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DettaglioBindingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FattureDataGridView)).EndInit();
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
        internal System.Windows.Forms.DataGridView DettagliDataGridView;
        internal System.Windows.Forms.ToolStripButton NuovoDettaglioToolStripButton;
        internal System.Windows.Forms.ToolStripButton AggiungiDettaglioToolStripButton;
        internal System.Windows.Forms.ToolStripButton RimuoviDettaglioToolStripButton;
        internal System.Windows.Forms.ToolStripButton ProdottiToolStripButton;
        internal System.Windows.Forms.ToolStripButton NuovaFatturaToolStripButton;
        internal System.Windows.Forms.ToolStripButton SalvaFatturaToolStripButton;
        internal System.Windows.Forms.ToolStripButton CancellaFatturaToolStripButton;
        internal System.Windows.Forms.DataGridView FattureDataGridView;
        internal System.Windows.Forms.ToolStripButton AboutToolStripButton;
        internal System.Windows.Forms.ToolStripButton CategorieToolStripButton;
        internal System.Windows.Forms.BindingSource FattureBindingSource;
        internal System.Windows.Forms.BindingSource FatturaBindingSource;
        internal System.Windows.Forms.BindingSource DettagliBindingSource;
        internal System.Windows.Forms.BindingSource DettaglioBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn totaleDataGridViewTextBoxColumn2;
    }
}