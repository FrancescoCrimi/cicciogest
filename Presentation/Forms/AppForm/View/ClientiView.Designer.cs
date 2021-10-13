namespace CiccioGest.Presentation.AppForm.View
{
    partial class ClientiView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientiView));
            this.clientiDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.societaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indirizzoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodiceFiscale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartitaIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.nuovoClienteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.apriClienteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.nuovaFatturaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
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
            nomeCompletoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            nomeCompletoLabel.AutoSize = true;
            nomeCompletoLabel.Location = new System.Drawing.Point(3, 7);
            nomeCompletoLabel.Name = "nomeCompletoLabel";
            nomeCompletoLabel.Size = new System.Drawing.Size(49, 20);
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
            this.clientiDataGridView.Location = new System.Drawing.Point(3, 74);
            this.clientiDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clientiDataGridView.MultiSelect = false;
            this.clientiDataGridView.Name = "clientiDataGridView";
            this.clientiDataGridView.ReadOnly = true;
            this.clientiDataGridView.RowHeadersVisible = false;
            this.clientiDataGridView.RowHeadersWidth = 51;
            this.clientiDataGridView.RowTemplate.Height = 24;
            this.clientiDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clientiDataGridView.Size = new System.Drawing.Size(776, 475);
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
            this.Id.Width = 51;
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
            this.nuovoClienteToolStripButton,
            this.apriClienteToolStripButton,
            this.nuovaFatturaToolStripButton,
            this.aboutToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(782, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // nuovoClienteToolStripButton
            // 
            this.nuovoClienteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nuovoClienteToolStripButton.Image")));
            this.nuovoClienteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuovoClienteToolStripButton.Name = "nuovoClienteToolStripButton";
            this.nuovoClienteToolStripButton.Size = new System.Drawing.Size(77, 24);
            this.nuovoClienteToolStripButton.Text = "&Nuovo";
            this.nuovoClienteToolStripButton.Click += new System.EventHandler(this.NuovoClienteToolStripButton_Click);
            // 
            // apriClienteToolStripButton
            // 
            this.apriClienteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("apriClienteToolStripButton.Image")));
            this.apriClienteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.apriClienteToolStripButton.Name = "apriClienteToolStripButton";
            this.apriClienteToolStripButton.Size = new System.Drawing.Size(61, 24);
            this.apriClienteToolStripButton.Text = "&Apri";
            this.apriClienteToolStripButton.Click += new System.EventHandler(this.ApriClienteToolStripButton_Click);
            // 
            // nuovaFatturaToolStripButton
            // 
            this.nuovaFatturaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nuovaFatturaToolStripButton.Image")));
            this.nuovaFatturaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuovaFatturaToolStripButton.Name = "nuovaFatturaToolStripButton";
            this.nuovaFatturaToolStripButton.Size = new System.Drawing.Size(125, 24);
            this.nuovaFatturaToolStripButton.Text = "Nuova Fattura";
            this.nuovaFatturaToolStripButton.Click += new System.EventHandler(this.NuovaFatturaToolStripButton_Click);
            // 
            // aboutToolStripButton
            // 
            this.aboutToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.aboutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aboutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripButton.Image")));
            this.aboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutToolStripButton.Name = "aboutToolStripButton";
            this.aboutToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.aboutToolStripButton.Text = "&?";
            this.aboutToolStripButton.Click += new System.EventHandler(this.AboutToolStripButton_Click);
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(782, 553);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 31);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(776, 35);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // nomeCompletoTextBox
            // 
            this.nomeCompletoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientiBindingSource, "NomeCompleto", true));
            this.nomeCompletoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nomeCompletoTextBox.Location = new System.Drawing.Point(58, 4);
            this.nomeCompletoTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nomeCompletoTextBox.Name = "nomeCompletoTextBox";
            this.nomeCompletoTextBox.Size = new System.Drawing.Size(715, 27);
            this.nomeCompletoTextBox.TabIndex = 1;
            // 
            // ListaClientiView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ListaClientiView";
            this.Text = "Clienti";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListaClientiView_FormClosing);
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
        private System.Windows.Forms.ToolStripButton nuovoClienteToolStripButton;
        private System.Windows.Forms.ToolStripButton apriClienteToolStripButton;
        private System.Windows.Forms.ToolStripButton aboutToolStripButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox nomeCompletoTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn societaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indirizzoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodiceFiscale;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartitaIva;
        private System.Windows.Forms.ToolStripButton nuovaFatturaToolStripButton;
    }
}