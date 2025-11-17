namespace CiccioGest.Presentation.AppForm.Views
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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nomeCompletoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientiView));
            clientiDataGridView = new System.Windows.Forms.DataGridView();
            Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            NomeCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            societaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            indirizzoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CodiceFiscale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            PartitaIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clientiBindingSource = new System.Windows.Forms.BindingSource(components);
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            apriClienteToolStripButton = new System.Windows.Forms.ToolStripButton();
            aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            nomeCompletoTextBox = new System.Windows.Forms.TextBox();
            nomeCompletoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)clientiDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clientiBindingSource).BeginInit();
            toolStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // nomeCompletoLabel
            // 
            nomeCompletoLabel.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nomeCompletoLabel.AutoSize = true;
            nomeCompletoLabel.Location = new System.Drawing.Point(3, 7);
            nomeCompletoLabel.Name = "nomeCompletoLabel";
            nomeCompletoLabel.Size = new System.Drawing.Size(40, 15);
            nomeCompletoLabel.TabIndex = 0;
            nomeCompletoLabel.Text = "Cerca:";
            // 
            // clientiDataGridView
            // 
            clientiDataGridView.AllowUserToAddRows = false;
            clientiDataGridView.AllowUserToDeleteRows = false;
            clientiDataGridView.AutoGenerateColumns = false;
            clientiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientiDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Id, NomeCompleto, societaDataGridViewTextBoxColumn, indirizzoDataGridViewTextBoxColumn, CodiceFiscale, PartitaIva });
            clientiDataGridView.DataSource = clientiBindingSource;
            clientiDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            clientiDataGridView.Location = new System.Drawing.Point(3, 65);
            clientiDataGridView.MultiSelect = false;
            clientiDataGridView.Name = "clientiDataGridView";
            clientiDataGridView.ReadOnly = true;
            clientiDataGridView.RowHeadersVisible = false;
            clientiDataGridView.RowHeadersWidth = 51;
            clientiDataGridView.RowTemplate.Height = 24;
            clientiDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            clientiDataGridView.Size = new System.Drawing.Size(678, 347);
            clientiDataGridView.TabIndex = 0;
            clientiDataGridView.CellDoubleClick += Clienti_CellDoubleClick;
            // 
            // Id
            // 
            Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 42;
            // 
            // NomeCompleto
            // 
            NomeCompleto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            NomeCompleto.DataPropertyName = "NomeCompleto";
            NomeCompleto.HeaderText = "Nome";
            NomeCompleto.MinimumWidth = 6;
            NomeCompleto.Name = "NomeCompleto";
            NomeCompleto.ReadOnly = true;
            // 
            // societaDataGridViewTextBoxColumn
            // 
            societaDataGridViewTextBoxColumn.DataPropertyName = "Societa";
            societaDataGridViewTextBoxColumn.HeaderText = "Societa";
            societaDataGridViewTextBoxColumn.MinimumWidth = 6;
            societaDataGridViewTextBoxColumn.Name = "societaDataGridViewTextBoxColumn";
            societaDataGridViewTextBoxColumn.ReadOnly = true;
            societaDataGridViewTextBoxColumn.Width = 125;
            // 
            // indirizzoDataGridViewTextBoxColumn
            // 
            indirizzoDataGridViewTextBoxColumn.DataPropertyName = "Indirizzo";
            indirizzoDataGridViewTextBoxColumn.HeaderText = "Indirizzo";
            indirizzoDataGridViewTextBoxColumn.MinimumWidth = 6;
            indirizzoDataGridViewTextBoxColumn.Name = "indirizzoDataGridViewTextBoxColumn";
            indirizzoDataGridViewTextBoxColumn.ReadOnly = true;
            indirizzoDataGridViewTextBoxColumn.Width = 125;
            // 
            // CodiceFiscale
            // 
            CodiceFiscale.DataPropertyName = "CodiceFiscale";
            CodiceFiscale.HeaderText = "CodiceFiscale";
            CodiceFiscale.MinimumWidth = 6;
            CodiceFiscale.Name = "CodiceFiscale";
            CodiceFiscale.ReadOnly = true;
            CodiceFiscale.Width = 125;
            // 
            // PartitaIva
            // 
            PartitaIva.DataPropertyName = "PartitaIva";
            PartitaIva.HeaderText = "PartitaIva";
            PartitaIva.MinimumWidth = 6;
            PartitaIva.Name = "PartitaIva";
            PartitaIva.ReadOnly = true;
            PartitaIva.Width = 125;
            // 
            // clientiBindingSource
            // 
            clientiBindingSource.AllowNew = false;
            clientiBindingSource.DataSource = typeof(Domain.Anagrafica.Cliente);
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { apriClienteToolStripButton, aboutToolStripButton });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(684, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // apriClienteToolStripButton
            // 
            apriClienteToolStripButton.Image = (System.Drawing.Image)resources.GetObject("apriClienteToolStripButton.Image");
            apriClienteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            apriClienteToolStripButton.Name = "apriClienteToolStripButton";
            apriClienteToolStripButton.Size = new System.Drawing.Size(53, 24);
            apriClienteToolStripButton.Text = "&Apri";
            apriClienteToolStripButton.Click += ApriCliente_Click;
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
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(toolStrip1, 0, 0);
            tableLayoutPanel1.Controls.Add(clientiDataGridView, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(684, 415);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(nomeCompletoLabel, 0, 0);
            tableLayoutPanel2.Controls.Add(nomeCompletoTextBox, 1, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(3, 30);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new System.Drawing.Size(678, 29);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // nomeCompletoTextBox
            // 
            nomeCompletoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", clientiBindingSource, "NomeCompleto", true));
            nomeCompletoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            nomeCompletoTextBox.Location = new System.Drawing.Point(49, 3);
            nomeCompletoTextBox.Name = "nomeCompletoTextBox";
            nomeCompletoTextBox.Size = new System.Drawing.Size(626, 23);
            nomeCompletoTextBox.TabIndex = 1;
            // 
            // ClientiView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(684, 415);
            Controls.Add(tableLayoutPanel1);
            Name = "ClientiView";
            Text = "Clienti";
            ((System.ComponentModel.ISupportInitialize)clientiDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)clientiBindingSource).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource clientiBindingSource;
        private System.Windows.Forms.DataGridView clientiDataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
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
    }
}