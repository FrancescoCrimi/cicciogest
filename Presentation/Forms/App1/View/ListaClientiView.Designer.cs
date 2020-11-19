namespace CiccioGest.Presentation.AppForm.View
{
    partial class ListaClientiView
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
            System.Windows.Forms.Label nomeCompletoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaClientiView));
            this.clientiDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.societaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indirizzoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodiceFiscale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartitaIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.nuovoClienteTSB = new System.Windows.Forms.ToolStripButton();
            this.apriClienteTSB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.nuovaFatturaClienteTSB = new System.Windows.Forms.ToolStripButton();
            this.apriFattureClienteTSB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.esciTSB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutTSB = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.nomeCompletoTextBox = new System.Windows.Forms.TextBox();
            nomeCompletoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clientiDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientiBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nomeCompletoLabel
            // 
            nomeCompletoLabel.AutoSize = true;
            nomeCompletoLabel.Location = new System.Drawing.Point(3, 0);
            nomeCompletoLabel.Name = "nomeCompletoLabel";
            nomeCompletoLabel.Size = new System.Drawing.Size(49, 17);
            nomeCompletoLabel.TabIndex = 0;
            nomeCompletoLabel.Text = "Cerca:";
            // 
            // clientiDataGridView
            // 
            this.clientiDataGridView.AllowUserToAddRows = false;
            this.clientiDataGridView.AllowUserToDeleteRows = false;
            this.clientiDataGridView.AutoGenerateColumns = false;
            this.clientiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientiDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.NomeCompleto,
            this.societaDataGridViewTextBoxColumn,
            this.indirizzoDataGridViewTextBoxColumn,
            this.CodiceFiscale,
            this.PartitaIva});
            this.clientiDataGridView.DataSource = this.clientiBindingSource;
            this.clientiDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientiDataGridView.Location = new System.Drawing.Point(3, 64);
            this.clientiDataGridView.MultiSelect = false;
            this.clientiDataGridView.Name = "clientiDataGridView";
            this.clientiDataGridView.ReadOnly = true;
            this.clientiDataGridView.RowHeadersVisible = false;
            this.clientiDataGridView.RowHeadersWidth = 51;
            this.clientiDataGridView.RowTemplate.Height = 24;
            this.clientiDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clientiDataGridView.Size = new System.Drawing.Size(696, 366);
            this.clientiDataGridView.TabIndex = 0;
            this.clientiDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClientiDataGridView_CellDoubleClick);
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
            // NomeCompleto
            // 
            this.NomeCompleto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NomeCompleto.DataPropertyName = "NomeCompleto";
            this.NomeCompleto.HeaderText = "Nome";
            this.NomeCompleto.MinimumWidth = 6;
            this.NomeCompleto.Name = "NomeCompleto";
            this.NomeCompleto.ReadOnly = true;
            // 
            // societaDataGridViewTextBoxColumn
            // 
            this.societaDataGridViewTextBoxColumn.DataPropertyName = "Societa";
            this.societaDataGridViewTextBoxColumn.HeaderText = "Societa";
            this.societaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.societaDataGridViewTextBoxColumn.Name = "societaDataGridViewTextBoxColumn";
            this.societaDataGridViewTextBoxColumn.ReadOnly = true;
            this.societaDataGridViewTextBoxColumn.Width = 125;
            // 
            // indirizzoDataGridViewTextBoxColumn
            // 
            this.indirizzoDataGridViewTextBoxColumn.DataPropertyName = "Indirizzo";
            this.indirizzoDataGridViewTextBoxColumn.HeaderText = "Indirizzo";
            this.indirizzoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.indirizzoDataGridViewTextBoxColumn.Name = "indirizzoDataGridViewTextBoxColumn";
            this.indirizzoDataGridViewTextBoxColumn.ReadOnly = true;
            this.indirizzoDataGridViewTextBoxColumn.Width = 125;
            // 
            // CodiceFiscale
            // 
            this.CodiceFiscale.DataPropertyName = "CodiceFiscale";
            this.CodiceFiscale.HeaderText = "CodiceFiscale";
            this.CodiceFiscale.MinimumWidth = 6;
            this.CodiceFiscale.Name = "CodiceFiscale";
            this.CodiceFiscale.ReadOnly = true;
            this.CodiceFiscale.Width = 125;
            // 
            // PartitaIva
            // 
            this.PartitaIva.DataPropertyName = "PartitaIva";
            this.PartitaIva.HeaderText = "PartitaIva";
            this.PartitaIva.MinimumWidth = 6;
            this.PartitaIva.Name = "PartitaIva";
            this.PartitaIva.ReadOnly = true;
            this.PartitaIva.Width = 125;
            // 
            // clientiBindingSource
            // 
            this.clientiBindingSource.AllowNew = false;
            this.clientiBindingSource.DataSource = typeof(CiccioGest.Domain.ClientiFornitori.Cliente);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovoClienteTSB,
            this.apriClienteTSB,
            this.toolStripSeparator,
            this.nuovaFatturaClienteTSB,
            this.apriFattureClienteTSB,
            this.toolStripSeparator1,
            this.esciTSB,
            this.toolStripSeparator2,
            this.AboutTSB});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(702, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // nuovoClienteTSB
            // 
            this.nuovoClienteTSB.Image = ((System.Drawing.Image)(resources.GetObject("nuovoClienteTSB.Image")));
            this.nuovoClienteTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuovoClienteTSB.Name = "nuovoClienteTSB";
            this.nuovoClienteTSB.Size = new System.Drawing.Size(77, 24);
            this.nuovoClienteTSB.Text = "&Nuovo";
            // 
            // apriClienteTSB
            // 
            this.apriClienteTSB.Image = ((System.Drawing.Image)(resources.GetObject("apriClienteTSB.Image")));
            this.apriClienteTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.apriClienteTSB.Name = "apriClienteTSB";
            this.apriClienteTSB.Size = new System.Drawing.Size(61, 24);
            this.apriClienteTSB.Text = "&Apri";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // nuovaFatturaClienteTSB
            // 
            this.nuovaFatturaClienteTSB.Image = ((System.Drawing.Image)(resources.GetObject("nuovaFatturaClienteTSB.Image")));
            this.nuovaFatturaClienteTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuovaFatturaClienteTSB.Name = "nuovaFatturaClienteTSB";
            this.nuovaFatturaClienteTSB.Size = new System.Drawing.Size(125, 24);
            this.nuovaFatturaClienteTSB.Text = "Nuova Fattura";
            // 
            // apriFattureClienteTSB
            // 
            this.apriFattureClienteTSB.Image = ((System.Drawing.Image)(resources.GetObject("apriFattureClienteTSB.Image")));
            this.apriFattureClienteTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.apriFattureClienteTSB.Name = "apriFattureClienteTSB";
            this.apriFattureClienteTSB.Size = new System.Drawing.Size(110, 24);
            this.apriFattureClienteTSB.Text = "Apri Fatture";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // esciTSB
            // 
            this.esciTSB.Image = ((System.Drawing.Image)(resources.GetObject("esciTSB.Image")));
            this.esciTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.esciTSB.Name = "esciTSB";
            this.esciTSB.Size = new System.Drawing.Size(58, 24);
            this.esciTSB.Text = "Esci";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // AboutTSB
            // 
            this.AboutTSB.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.AboutTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AboutTSB.Image = ((System.Drawing.Image)(resources.GetObject("AboutTSB.Image")));
            this.AboutTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutTSB.Name = "AboutTSB";
            this.AboutTSB.Size = new System.Drawing.Size(29, 24);
            this.AboutTSB.Text = "&?";
            this.AboutTSB.Click += new System.EventHandler(this.AboutTSB_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.clientiDataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(702, 433);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(nomeCompletoLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.nomeCompletoTextBox, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 30);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(696, 28);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // nomeCompletoTextBox
            // 
            this.nomeCompletoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientiBindingSource, "NomeCompleto", true));
            this.nomeCompletoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nomeCompletoTextBox.Location = new System.Drawing.Point(58, 3);
            this.nomeCompletoTextBox.Name = "nomeCompletoTextBox";
            this.nomeCompletoTextBox.Size = new System.Drawing.Size(635, 22);
            this.nomeCompletoTextBox.TabIndex = 1;
            // 
            // ListaClientiView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 433);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ListaClientiView";
            this.Text = "Clienti";
            this.Load += new System.EventHandler(this.ListaClientiView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientiDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientiBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource clientiBindingSource;
        private System.Windows.Forms.DataGridView clientiDataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton nuovoClienteTSB;
        private System.Windows.Forms.ToolStripButton apriClienteTSB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton AboutTSB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox nomeCompletoTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn societaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indirizzoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodiceFiscale;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartitaIva;
        private System.Windows.Forms.ToolStripButton nuovaFatturaClienteTSB;
        private System.Windows.Forms.ToolStripButton apriFattureClienteTSB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton esciTSB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}