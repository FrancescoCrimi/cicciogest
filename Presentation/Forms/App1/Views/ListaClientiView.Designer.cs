namespace CiccioGest.Presentation.AppForm.Views
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
            this.clientiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NomeCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.societaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indirizzoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.nuovoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.apriToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.salvaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stampaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tagliaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copiaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.incollaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.nomeCompletoTextBox = new System.Windows.Forms.TextBox();
            nomeCompletoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clientiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // clientiBindingSource
            // 
            this.clientiBindingSource.AllowNew = false;
            this.clientiBindingSource.DataSource = typeof(CiccioGest.Domain.ClientiFornitori.Cliente);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NomeCompleto,
            this.societaDataGridViewTextBoxColumn,
            this.indirizzoDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.clientiBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 64);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(616, 366);
            this.dataGridView1.TabIndex = 0;
            // 
            // NomeCompleto
            // 
            this.NomeCompleto.DataPropertyName = "NomeCompleto";
            this.NomeCompleto.HeaderText = "Nome";
            this.NomeCompleto.MinimumWidth = 6;
            this.NomeCompleto.Name = "NomeCompleto";
            this.NomeCompleto.ReadOnly = true;
            this.NomeCompleto.Width = 125;
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
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            this.emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovoToolStripButton,
            this.apriToolStripButton,
            this.salvaToolStripButton,
            this.stampaToolStripButton,
            this.toolStripSeparator,
            this.tagliaToolStripButton,
            this.copiaToolStripButton,
            this.incollaToolStripButton,
            this.toolStripSeparator1,
            this.ToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(622, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // nuovoToolStripButton
            // 
            this.nuovoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nuovoToolStripButton.Image")));
            this.nuovoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuovoToolStripButton.Name = "nuovoToolStripButton";
            this.nuovoToolStripButton.Size = new System.Drawing.Size(77, 24);
            this.nuovoToolStripButton.Text = "&Nuovo";
            // 
            // apriToolStripButton
            // 
            this.apriToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("apriToolStripButton.Image")));
            this.apriToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.apriToolStripButton.Name = "apriToolStripButton";
            this.apriToolStripButton.Size = new System.Drawing.Size(61, 24);
            this.apriToolStripButton.Text = "&Apri";
            // 
            // salvaToolStripButton
            // 
            this.salvaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("salvaToolStripButton.Image")));
            this.salvaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salvaToolStripButton.Name = "salvaToolStripButton";
            this.salvaToolStripButton.Size = new System.Drawing.Size(68, 24);
            this.salvaToolStripButton.Text = "&Salva";
            // 
            // stampaToolStripButton
            // 
            this.stampaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("stampaToolStripButton.Image")));
            this.stampaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stampaToolStripButton.Name = "stampaToolStripButton";
            this.stampaToolStripButton.Size = new System.Drawing.Size(84, 24);
            this.stampaToolStripButton.Text = "&Stampa";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // tagliaToolStripButton
            // 
            this.tagliaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("tagliaToolStripButton.Image")));
            this.tagliaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tagliaToolStripButton.Name = "tagliaToolStripButton";
            this.tagliaToolStripButton.Size = new System.Drawing.Size(72, 24);
            this.tagliaToolStripButton.Text = "&Taglia";
            // 
            // copiaToolStripButton
            // 
            this.copiaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copiaToolStripButton.Image")));
            this.copiaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copiaToolStripButton.Name = "copiaToolStripButton";
            this.copiaToolStripButton.Size = new System.Drawing.Size(72, 24);
            this.copiaToolStripButton.Text = "&Copia";
            // 
            // incollaToolStripButton
            // 
            this.incollaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.incollaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("incollaToolStripButton.Image")));
            this.incollaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.incollaToolStripButton.Name = "incollaToolStripButton";
            this.incollaToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.incollaToolStripButton.Text = "&Incolla";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
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
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(622, 433);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(616, 28);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // nomeCompletoTextBox
            // 
            this.nomeCompletoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientiBindingSource, "NomeCompleto", true));
            this.nomeCompletoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nomeCompletoTextBox.Location = new System.Drawing.Point(58, 3);
            this.nomeCompletoTextBox.Name = "nomeCompletoTextBox";
            this.nomeCompletoTextBox.Size = new System.Drawing.Size(555, 22);
            this.nomeCompletoTextBox.TabIndex = 1;
            // 
            // ListaClientiView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 433);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ListaClientiView";
            this.Text = "Clienti";
            this.Load += new System.EventHandler(this.ListaClienti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn societaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indirizzoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton nuovoToolStripButton;
        private System.Windows.Forms.ToolStripButton apriToolStripButton;
        private System.Windows.Forms.ToolStripButton salvaToolStripButton;
        private System.Windows.Forms.ToolStripButton stampaToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton tagliaToolStripButton;
        private System.Windows.Forms.ToolStripButton copiaToolStripButton;
        private System.Windows.Forms.ToolStripButton incollaToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ToolStripButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox nomeCompletoTextBox;
    }
}