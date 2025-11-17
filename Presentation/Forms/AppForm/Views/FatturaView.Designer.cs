namespace CiccioGest.Presentation.AppForm.Views
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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nomeProdottoLabel;
            System.Windows.Forms.Label prezzoProdottoLabel;
            System.Windows.Forms.Label quantitàLabel;
            System.Windows.Forms.Label totaleLabel1;
            System.Windows.Forms.Label nomeLabel1;
            System.Windows.Forms.Label totaleLabel2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FatturaView));
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            dettagliDataGridView = new System.Windows.Forms.DataGridView();
            Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            nomeProdottoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Quantita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            prezzoProdottoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            totaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dettagliBindingSource = new System.Windows.Forms.BindingSource(components);
            fatturaBindingSource = new System.Windows.Forms.BindingSource(components);
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            totaleTextBox2 = new System.Windows.Forms.TextBox();
            nomeTextBox = new System.Windows.Forms.TextBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            totaleTextBox1 = new System.Windows.Forms.TextBox();
            dettaglioBindingSource = new System.Windows.Forms.BindingSource(components);
            quantitàTextBox = new System.Windows.Forms.TextBox();
            prezzoProdottoTextBox = new System.Windows.Forms.TextBox();
            nomeProdottoTextBox = new System.Windows.Forms.TextBox();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            salvaToolStripButton = new System.Windows.Forms.ToolStripButton();
            nuovaToolStripButton = new System.Windows.Forms.ToolStripButton();
            apriToolStripButton = new System.Windows.Forms.ToolStripButton();
            eliminaToolStripButton = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            nuovoDettaglioToolStripButton = new System.Windows.Forms.ToolStripButton();
            aggiungiDettaglioToolStripButton = new System.Windows.Forms.ToolStripButton();
            rimuoviDettaglioToolStripButton = new System.Windows.Forms.ToolStripButton();
            aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            nomeProdottoLabel = new System.Windows.Forms.Label();
            prezzoProdottoLabel = new System.Windows.Forms.Label();
            quantitàLabel = new System.Windows.Forms.Label();
            totaleLabel1 = new System.Windows.Forms.Label();
            nomeLabel1 = new System.Windows.Forms.Label();
            totaleLabel2 = new System.Windows.Forms.Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dettagliDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dettagliBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fatturaBindingSource).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dettaglioBindingSource).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // nomeProdottoLabel
            // 
            nomeProdottoLabel.AutoSize = true;
            nomeProdottoLabel.Location = new System.Drawing.Point(3, 0);
            nomeProdottoLabel.Name = "nomeProdottoLabel";
            nomeProdottoLabel.Size = new System.Drawing.Size(57, 15);
            nomeProdottoLabel.TabIndex = 0;
            nomeProdottoLabel.Text = "Prodotto:";
            // 
            // prezzoProdottoLabel
            // 
            prezzoProdottoLabel.AutoSize = true;
            prezzoProdottoLabel.Location = new System.Drawing.Point(160, 0);
            prezzoProdottoLabel.Name = "prezzoProdottoLabel";
            prezzoProdottoLabel.Size = new System.Drawing.Size(44, 15);
            prezzoProdottoLabel.TabIndex = 2;
            prezzoProdottoLabel.Text = "Prezzo:";
            // 
            // quantitàLabel
            // 
            quantitàLabel.AutoSize = true;
            quantitàLabel.Location = new System.Drawing.Point(3, 29);
            quantitàLabel.Name = "quantitàLabel";
            quantitàLabel.Size = new System.Drawing.Size(56, 15);
            quantitàLabel.TabIndex = 4;
            quantitàLabel.Text = "Quantità:";
            // 
            // totaleLabel1
            // 
            totaleLabel1.AutoSize = true;
            totaleLabel1.Location = new System.Drawing.Point(160, 29);
            totaleLabel1.Name = "totaleLabel1";
            totaleLabel1.Size = new System.Drawing.Size(42, 15);
            totaleLabel1.TabIndex = 6;
            totaleLabel1.Text = "Totale:";
            // 
            // nomeLabel1
            // 
            nomeLabel1.AutoSize = true;
            nomeLabel1.Location = new System.Drawing.Point(3, 0);
            nomeLabel1.Name = "nomeLabel1";
            nomeLabel1.Size = new System.Drawing.Size(43, 15);
            nomeLabel1.TabIndex = 0;
            nomeLabel1.Text = "Nome:";
            // 
            // totaleLabel2
            // 
            totaleLabel2.AutoSize = true;
            totaleLabel2.Location = new System.Drawing.Point(3, 29);
            totaleLabel2.Name = "totaleLabel2";
            totaleLabel2.Size = new System.Drawing.Size(42, 15);
            totaleLabel2.TabIndex = 2;
            totaleLabel2.Text = "Totale:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.Controls.Add(dettagliDataGridView, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(toolStrip1, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(624, 406);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // dettagliDataGridView
            // 
            dettagliDataGridView.AllowUserToAddRows = false;
            dettagliDataGridView.AllowUserToDeleteRows = false;
            dettagliDataGridView.AllowUserToResizeRows = false;
            dettagliDataGridView.AutoGenerateColumns = false;
            dettagliDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dettagliDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Id, nomeProdottoDataGridViewTextBoxColumn, Quantita, prezzoProdottoDataGridViewTextBoxColumn, totaleDataGridViewTextBoxColumn });
            dettagliDataGridView.DataSource = dettagliBindingSource;
            dettagliDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            dettagliDataGridView.Location = new System.Drawing.Point(3, 121);
            dettagliDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dettagliDataGridView.MultiSelect = false;
            dettagliDataGridView.Name = "dettagliDataGridView";
            dettagliDataGridView.ReadOnly = true;
            dettagliDataGridView.RowHeadersVisible = false;
            dettagliDataGridView.RowHeadersWidth = 51;
            dettagliDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dettagliDataGridView.Size = new System.Drawing.Size(618, 283);
            dettagliDataGridView.TabIndex = 6;
            dettagliDataGridView.TabStop = false;
            dettagliDataGridView.CellClick += DettagliDataGridViewCellClick;
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
            // nomeProdottoDataGridViewTextBoxColumn
            // 
            nomeProdottoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            nomeProdottoDataGridViewTextBoxColumn.DataPropertyName = "NomeProdotto";
            nomeProdottoDataGridViewTextBoxColumn.HeaderText = "Prodotto";
            nomeProdottoDataGridViewTextBoxColumn.MinimumWidth = 6;
            nomeProdottoDataGridViewTextBoxColumn.Name = "nomeProdottoDataGridViewTextBoxColumn";
            nomeProdottoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Quantita
            // 
            Quantita.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            Quantita.DataPropertyName = "Quantita";
            Quantita.HeaderText = "Quantita";
            Quantita.MinimumWidth = 6;
            Quantita.Name = "Quantita";
            Quantita.ReadOnly = true;
            Quantita.Width = 78;
            // 
            // prezzoProdottoDataGridViewTextBoxColumn
            // 
            prezzoProdottoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            prezzoProdottoDataGridViewTextBoxColumn.DataPropertyName = "PrezzoProdotto";
            prezzoProdottoDataGridViewTextBoxColumn.HeaderText = "Prezzo";
            prezzoProdottoDataGridViewTextBoxColumn.MinimumWidth = 6;
            prezzoProdottoDataGridViewTextBoxColumn.Name = "prezzoProdottoDataGridViewTextBoxColumn";
            prezzoProdottoDataGridViewTextBoxColumn.ReadOnly = true;
            prezzoProdottoDataGridViewTextBoxColumn.Width = 66;
            // 
            // totaleDataGridViewTextBoxColumn
            // 
            totaleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            totaleDataGridViewTextBoxColumn.DataPropertyName = "Totale";
            totaleDataGridViewTextBoxColumn.HeaderText = "Totale";
            totaleDataGridViewTextBoxColumn.MinimumWidth = 6;
            totaleDataGridViewTextBoxColumn.Name = "totaleDataGridViewTextBoxColumn";
            totaleDataGridViewTextBoxColumn.ReadOnly = true;
            totaleDataGridViewTextBoxColumn.Width = 64;
            // 
            // dettagliBindingSource
            // 
            dettagliBindingSource.AllowNew = false;
            dettagliBindingSource.DataMember = "Dettagli";
            dettagliBindingSource.DataSource = fatturaBindingSource;
            // 
            // fatturaBindingSource
            // 
            fatturaBindingSource.DataSource = typeof(Domain.Documenti.Fattura);
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            tableLayoutPanel2.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel2.Controls.Add(groupBox2, 1, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(3, 30);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.Size = new System.Drawing.Size(618, 86);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(tableLayoutPanel4);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Location = new System.Drawing.Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(199, 80);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Fattura";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.AutoSize = true;
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel4.Controls.Add(totaleLabel2, 0, 1);
            tableLayoutPanel4.Controls.Add(totaleTextBox2, 1, 1);
            tableLayoutPanel4.Controls.Add(nomeLabel1, 0, 0);
            tableLayoutPanel4.Controls.Add(nomeTextBox, 1, 0);
            tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel4.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel4.Size = new System.Drawing.Size(193, 58);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // totaleTextBox2
            // 
            totaleTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", fatturaBindingSource, "Totale", true));
            totaleTextBox2.Location = new System.Drawing.Point(52, 32);
            totaleTextBox2.Name = "totaleTextBox2";
            totaleTextBox2.ReadOnly = true;
            totaleTextBox2.Size = new System.Drawing.Size(113, 23);
            totaleTextBox2.TabIndex = 3;
            // 
            // nomeTextBox
            // 
            nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", fatturaBindingSource, "Nome", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            nomeTextBox.Location = new System.Drawing.Point(52, 3);
            nomeTextBox.Name = "nomeTextBox";
            nomeTextBox.Size = new System.Drawing.Size(113, 23);
            nomeTextBox.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(tableLayoutPanel3);
            groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox2.Location = new System.Drawing.Point(208, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(407, 80);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dettaglio";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.ColumnCount = 4;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel3.Controls.Add(totaleLabel1, 2, 1);
            tableLayoutPanel3.Controls.Add(totaleTextBox1, 3, 1);
            tableLayoutPanel3.Controls.Add(quantitàLabel, 0, 1);
            tableLayoutPanel3.Controls.Add(quantitàTextBox, 1, 1);
            tableLayoutPanel3.Controls.Add(prezzoProdottoLabel, 2, 0);
            tableLayoutPanel3.Controls.Add(prezzoProdottoTextBox, 3, 0);
            tableLayoutPanel3.Controls.Add(nomeProdottoLabel, 0, 0);
            tableLayoutPanel3.Controls.Add(nomeProdottoTextBox, 1, 0);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel3.Size = new System.Drawing.Size(401, 58);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // totaleTextBox1
            // 
            totaleTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", dettaglioBindingSource, "Totale", true));
            totaleTextBox1.Location = new System.Drawing.Point(210, 32);
            totaleTextBox1.Name = "totaleTextBox1";
            totaleTextBox1.ReadOnly = true;
            totaleTextBox1.Size = new System.Drawing.Size(53, 23);
            totaleTextBox1.TabIndex = 7;
            // 
            // dettaglioBindingSource
            // 
            dettaglioBindingSource.DataSource = typeof(Domain.Documenti.Dettaglio);
            // 
            // quantitàTextBox
            // 
            quantitàTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", dettaglioBindingSource, "Quantita", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            quantitàTextBox.Location = new System.Drawing.Point(66, 32);
            quantitàTextBox.Name = "quantitàTextBox";
            quantitàTextBox.Size = new System.Drawing.Size(88, 23);
            quantitàTextBox.TabIndex = 5;
            // 
            // prezzoProdottoTextBox
            // 
            prezzoProdottoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", dettaglioBindingSource, "PrezzoProdotto", true));
            prezzoProdottoTextBox.Location = new System.Drawing.Point(210, 3);
            prezzoProdottoTextBox.Name = "prezzoProdottoTextBox";
            prezzoProdottoTextBox.ReadOnly = true;
            prezzoProdottoTextBox.Size = new System.Drawing.Size(53, 23);
            prezzoProdottoTextBox.TabIndex = 3;
            // 
            // nomeProdottoTextBox
            // 
            nomeProdottoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", dettaglioBindingSource, "NomeProdotto", true));
            nomeProdottoTextBox.Location = new System.Drawing.Point(66, 3);
            nomeProdottoTextBox.Name = "nomeProdottoTextBox";
            nomeProdottoTextBox.ReadOnly = true;
            nomeProdottoTextBox.Size = new System.Drawing.Size(88, 23);
            nomeProdottoTextBox.TabIndex = 1;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { nuovaToolStripButton, salvaToolStripButton, apriToolStripButton, eliminaToolStripButton, toolStripSeparator, nuovoDettaglioToolStripButton, aggiungiDettaglioToolStripButton, rimuoviDettaglioToolStripButton, aboutToolStripButton });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(624, 27);
            toolStrip1.TabIndex = 8;
            toolStrip1.Text = "toolStrip1";
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
            // nuovaToolStripButton
            // 
            nuovaToolStripButton.Image = (System.Drawing.Image)resources.GetObject("nuovaToolStripButton.Image");
            nuovaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            nuovaToolStripButton.Name = "nuovaToolStripButton";
            nuovaToolStripButton.Size = new System.Drawing.Size(66, 24);
            nuovaToolStripButton.Text = "Nuova";
            nuovaToolStripButton.Click += Nuova_Click;
            // 
            // apriToolStripButton
            // 
            apriToolStripButton.Image = Properties.Resources.CaricaDefault;
            apriToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            apriToolStripButton.Name = "apriToolStripButton";
            apriToolStripButton.Size = new System.Drawing.Size(53, 24);
            apriToolStripButton.Text = "Apri";
            apriToolStripButton.ToolTipText = "Apri Fattura\r\n";
            apriToolStripButton.Click += Apri_Click;
            // 
            // eliminaToolStripButton
            // 
            eliminaToolStripButton.Image = Properties.Resources.Delete;
            eliminaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            eliminaToolStripButton.Name = "eliminaToolStripButton";
            eliminaToolStripButton.Size = new System.Drawing.Size(70, 24);
            eliminaToolStripButton.Text = "Elimina";
            eliminaToolStripButton.ToolTipText = "Elimina";
            eliminaToolStripButton.Click += Elimina_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // nuovoDettaglioToolStripButton
            // 
            nuovoDettaglioToolStripButton.Image = (System.Drawing.Image)resources.GetObject("nuovoDettaglioToolStripButton.Image");
            nuovoDettaglioToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            nuovoDettaglioToolStripButton.Name = "nuovoDettaglioToolStripButton";
            nuovoDettaglioToolStripButton.Size = new System.Drawing.Size(67, 24);
            nuovoDettaglioToolStripButton.Text = "Nuovo";
            nuovoDettaglioToolStripButton.Click += NuovoDettaglio_Click;
            // 
            // aggiungiDettaglioToolStripButton
            // 
            aggiungiDettaglioToolStripButton.Image = Properties.Resources.AddNew;
            aggiungiDettaglioToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            aggiungiDettaglioToolStripButton.Name = "aggiungiDettaglioToolStripButton";
            aggiungiDettaglioToolStripButton.Size = new System.Drawing.Size(80, 24);
            aggiungiDettaglioToolStripButton.Text = "Aggiungi";
            aggiungiDettaglioToolStripButton.Click += AggiungiDettaglio_Click;
            // 
            // rimuoviDettaglioToolStripButton
            // 
            rimuoviDettaglioToolStripButton.Image = Properties.Resources.Delete;
            rimuoviDettaglioToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            rimuoviDettaglioToolStripButton.Name = "rimuoviDettaglioToolStripButton";
            rimuoviDettaglioToolStripButton.Size = new System.Drawing.Size(75, 24);
            rimuoviDettaglioToolStripButton.Text = "Rimuovi";
            rimuoviDettaglioToolStripButton.Click += RimuoviDettaglio_Click;
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
            // FatturaView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(624, 406);
            Controls.Add(tableLayoutPanel1);
            Name = "FatturaView";
            Text = "Fattura";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dettagliDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)dettagliBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)fatturaBindingSource).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dettaglioBindingSource).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.ToolStripButton nuovaToolStripButton;
        private System.Windows.Forms.ToolStripButton salvaToolStripButton;
        private System.Windows.Forms.ToolStripButton apriToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton nuovoDettaglioToolStripButton;
        private System.Windows.Forms.ToolStripButton aggiungiDettaglioToolStripButton;
        private System.Windows.Forms.ToolStripButton rimuoviDettaglioToolStripButton;
        private System.Windows.Forms.ToolStripButton aboutToolStripButton;
        private System.Windows.Forms.ToolStripButton eliminaToolStripButton;
    }
}
