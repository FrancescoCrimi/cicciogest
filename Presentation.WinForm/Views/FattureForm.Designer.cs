namespace Ciccio1.Presentation.WinForm.Views
{
    partial class FattureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FattureForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuovoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strumentiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dettagliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prodottiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categorieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fattureDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fattureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.nomeFatturaTextBox = new System.Windows.Forms.TextBox();
            this.fatturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.totaleFatturaLabel = new System.Windows.Forms.Label();
            this.totaleFatturaTextBox = new System.Windows.Forms.TextBox();
            nomeFatturaLabel = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fattureDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fattureBindingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fatturaBindingSource)).BeginInit();
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
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.strumentiToolStripMenuItem,
            this.toolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(282, 28);
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
            this.fileToolStripMenuItem.Text = "File";
            // 
            // nuovoToolStripMenuItem
            // 
            this.nuovoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuovoToolStripMenuItem.Image")));
            this.nuovoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuovoToolStripMenuItem.Name = "nuovoToolStripMenuItem";
            this.nuovoToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.nuovoToolStripMenuItem.Text = "Nuovo";
            this.nuovoToolStripMenuItem.Click += new System.EventHandler(this.nuovoToolStripMenuItem_Click);
            // 
            // modificaToolStripMenuItem
            // 
            this.modificaToolStripMenuItem.Image = global::Ciccio1.Presentation.WinForm.Properties.Resources.Copia;
            this.modificaToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.modificaToolStripMenuItem.Name = "modificaToolStripMenuItem";
            this.modificaToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.modificaToolStripMenuItem.Text = "Modifica";
            this.modificaToolStripMenuItem.Click += new System.EventHandler(this.modificaToolStripMenuItem_Click);
            // 
            // salvaToolStripMenuItem
            // 
            this.salvaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("salvaToolStripMenuItem.Image")));
            this.salvaToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salvaToolStripMenuItem.Name = "salvaToolStripMenuItem";
            this.salvaToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.salvaToolStripMenuItem.Text = "Salva";
            this.salvaToolStripMenuItem.Click += new System.EventHandler(this.salvaToolStripMenuItem_Click);
            // 
            // eliminaToolStripMenuItem
            // 
            this.eliminaToolStripMenuItem.Image = global::Ciccio1.Presentation.WinForm.Properties.Resources.Delete;
            this.eliminaToolStripMenuItem.Name = "eliminaToolStripMenuItem";
            this.eliminaToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.eliminaToolStripMenuItem.Text = "Elimina";
            this.eliminaToolStripMenuItem.Click += new System.EventHandler(this.eliminaToolStripMenuItem_Click);
            // 
            // esciToolStripMenuItem
            // 
            this.esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            this.esciToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.esciToolStripMenuItem.Text = "Esci";
            this.esciToolStripMenuItem.Click += new System.EventHandler(this.esciToolStripMenuItem_Click);
            // 
            // strumentiToolStripMenuItem
            // 
            this.strumentiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dettagliToolStripMenuItem,
            this.prodottiToolStripMenuItem,
            this.categorieToolStripMenuItem});
            this.strumentiToolStripMenuItem.Name = "strumentiToolStripMenuItem";
            this.strumentiToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.strumentiToolStripMenuItem.Text = "Strumenti";
            // 
            // dettagliToolStripMenuItem
            // 
            this.dettagliToolStripMenuItem.Name = "dettagliToolStripMenuItem";
            this.dettagliToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.dettagliToolStripMenuItem.Text = "Dettagli";
            this.dettagliToolStripMenuItem.Click += new System.EventHandler(this.dettagliToolStripMenuItem_Click);
            // 
            // prodottiToolStripMenuItem
            // 
            this.prodottiToolStripMenuItem.Name = "prodottiToolStripMenuItem";
            this.prodottiToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.prodottiToolStripMenuItem.Text = "Prodotti";
            this.prodottiToolStripMenuItem.Click += new System.EventHandler(this.prodottiToolStripMenuItem_Click);
            // 
            // categorieToolStripMenuItem
            // 
            this.categorieToolStripMenuItem.Name = "categorieToolStripMenuItem";
            this.categorieToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
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
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.fattureDataGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(282, 275);
            this.tableLayoutPanel1.TabIndex = 1;
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
            this.idDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn,
            this.totaleDataGridViewTextBoxColumn});
            this.fattureDataGridView.DataSource = this.fattureBindingSource;
            this.fattureDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fattureDataGridView.Location = new System.Drawing.Point(4, 42);
            this.fattureDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.fattureDataGridView.MultiSelect = false;
            this.fattureDataGridView.Name = "fattureDataGridView";
            this.fattureDataGridView.ReadOnly = true;
            this.fattureDataGridView.RowHeadersVisible = false;
            this.fattureDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fattureDataGridView.Size = new System.Drawing.Size(274, 233);
            this.fattureDataGridView.TabIndex = 6;
            this.fattureDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FattureDataGridView_CellDoubleClick);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(nomeFatturaLabel);
            this.flowLayoutPanel1.Controls.Add(this.nomeFatturaTextBox);
            this.flowLayoutPanel1.Controls.Add(this.totaleFatturaLabel);
            this.flowLayoutPanel1.Controls.Add(this.totaleFatturaTextBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(274, 30);
            this.flowLayoutPanel1.TabIndex = 3;
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
            this.fatturaBindingSource.AllowNew = false;
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
            this.totaleFatturaTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.totaleFatturaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fatturaBindingSource, "Totale", true));
            this.totaleFatturaTextBox.Location = new System.Drawing.Point(229, 4);
            this.totaleFatturaTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.totaleFatturaTextBox.Name = "totaleFatturaTextBox";
            this.totaleFatturaTextBox.ReadOnly = true;
            this.totaleFatturaTextBox.Size = new System.Drawing.Size(39, 22);
            this.totaleFatturaTextBox.TabIndex = 0;
            this.totaleFatturaTextBox.TabStop = false;
            // 
            // Fatture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 303);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Fatture";
            this.Text = "Fatture";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Fatture_FormClosed);
            this.Load += new System.EventHandler(this.Fatture_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fattureDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fattureBindingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fatturaBindingSource)).EndInit();
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox nomeFatturaTextBox;
        private System.Windows.Forms.Label totaleFatturaLabel;
        private System.Windows.Forms.TextBox totaleFatturaTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView fattureDataGridView;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dettagliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prodottiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categorieToolStripMenuItem;
        private System.Windows.Forms.BindingSource fattureBindingSource;
        private System.Windows.Forms.BindingSource fatturaBindingSource;
    }
}