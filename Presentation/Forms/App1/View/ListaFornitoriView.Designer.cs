namespace CiccioGest.Presentation.AppForm.View
{
    partial class ListaFornitoriView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaFornitoriView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
            this.fornitoriDataGridView = new System.Windows.Forms.DataGridView();
            this.nomeCompletoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indirizzoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partitaIvaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codiceFiscaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fornitoriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.nomeCompletoTextBox = new System.Windows.Forms.TextBox();
            nomeCompletoLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fornitoriDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornitoriBindingSource)).BeginInit();
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.fornitoriDataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 3;
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
            this.toolStrip1.Size = new System.Drawing.Size(800, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // nuovoToolStripButton
            // 
            this.nuovoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nuovoToolStripButton.Image")));
            this.nuovoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuovoToolStripButton.Name = "nuovoToolStripButton";
            this.nuovoToolStripButton.Size = new System.Drawing.Size(77, 28);
            this.nuovoToolStripButton.Text = "&Nuovo";
            // 
            // apriToolStripButton
            // 
            this.apriToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("apriToolStripButton.Image")));
            this.apriToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.apriToolStripButton.Name = "apriToolStripButton";
            this.apriToolStripButton.Size = new System.Drawing.Size(61, 28);
            this.apriToolStripButton.Text = "&Apri";
            // 
            // salvaToolStripButton
            // 
            this.salvaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("salvaToolStripButton.Image")));
            this.salvaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salvaToolStripButton.Name = "salvaToolStripButton";
            this.salvaToolStripButton.Size = new System.Drawing.Size(68, 28);
            this.salvaToolStripButton.Text = "&Salva";
            // 
            // stampaToolStripButton
            // 
            this.stampaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("stampaToolStripButton.Image")));
            this.stampaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stampaToolStripButton.Name = "stampaToolStripButton";
            this.stampaToolStripButton.Size = new System.Drawing.Size(84, 28);
            this.stampaToolStripButton.Text = "&Stampa";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 31);
            // 
            // tagliaToolStripButton
            // 
            this.tagliaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("tagliaToolStripButton.Image")));
            this.tagliaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tagliaToolStripButton.Name = "tagliaToolStripButton";
            this.tagliaToolStripButton.Size = new System.Drawing.Size(72, 28);
            this.tagliaToolStripButton.Text = "&Taglia";
            // 
            // copiaToolStripButton
            // 
            this.copiaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copiaToolStripButton.Image")));
            this.copiaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copiaToolStripButton.Name = "copiaToolStripButton";
            this.copiaToolStripButton.Size = new System.Drawing.Size(72, 28);
            this.copiaToolStripButton.Text = "&Copia";
            // 
            // incollaToolStripButton
            // 
            this.incollaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.incollaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("incollaToolStripButton.Image")));
            this.incollaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.incollaToolStripButton.Name = "incollaToolStripButton";
            this.incollaToolStripButton.Size = new System.Drawing.Size(29, 28);
            this.incollaToolStripButton.Text = "&Incolla";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // ToolStripButton
            // 
            this.ToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton.Image")));
            this.ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton.Name = "ToolStripButton";
            this.ToolStripButton.Size = new System.Drawing.Size(29, 28);
            this.ToolStripButton.Text = "&?";
            // 
            // fornitoriDataGridView
            // 
            this.fornitoriDataGridView.AllowUserToAddRows = false;
            this.fornitoriDataGridView.AllowUserToDeleteRows = false;
            this.fornitoriDataGridView.AutoGenerateColumns = false;
            this.fornitoriDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fornitoriDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomeCompletoDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.telefonoDataGridViewTextBoxColumn,
            this.indirizzoDataGridViewTextBoxColumn,
            this.partitaIvaDataGridViewTextBoxColumn,
            this.codiceFiscaleDataGridViewTextBoxColumn});
            this.fornitoriDataGridView.DataSource = this.fornitoriBindingSource;
            this.fornitoriDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fornitoriDataGridView.Location = new System.Drawing.Point(3, 68);
            this.fornitoriDataGridView.MultiSelect = false;
            this.fornitoriDataGridView.Name = "fornitoriDataGridView";
            this.fornitoriDataGridView.ReadOnly = true;
            this.fornitoriDataGridView.RowHeadersVisible = false;
            this.fornitoriDataGridView.RowHeadersWidth = 51;
            this.fornitoriDataGridView.RowTemplate.Height = 24;
            this.fornitoriDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fornitoriDataGridView.Size = new System.Drawing.Size(794, 379);
            this.fornitoriDataGridView.TabIndex = 0;
            this.fornitoriDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FornitoriDataGridView_CellDoubleClick);
            // 
            // nomeCompletoDataGridViewTextBoxColumn
            // 
            this.nomeCompletoDataGridViewTextBoxColumn.DataPropertyName = "NomeCompleto";
            this.nomeCompletoDataGridViewTextBoxColumn.HeaderText = "NomeCompleto";
            this.nomeCompletoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nomeCompletoDataGridViewTextBoxColumn.Name = "nomeCompletoDataGridViewTextBoxColumn";
            this.nomeCompletoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomeCompletoDataGridViewTextBoxColumn.Width = 125;
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
            // telefonoDataGridViewTextBoxColumn
            // 
            this.telefonoDataGridViewTextBoxColumn.DataPropertyName = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.HeaderText = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            this.telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            this.telefonoDataGridViewTextBoxColumn.Width = 125;
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
            // partitaIvaDataGridViewTextBoxColumn
            // 
            this.partitaIvaDataGridViewTextBoxColumn.DataPropertyName = "PartitaIva";
            this.partitaIvaDataGridViewTextBoxColumn.HeaderText = "PartitaIva";
            this.partitaIvaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.partitaIvaDataGridViewTextBoxColumn.Name = "partitaIvaDataGridViewTextBoxColumn";
            this.partitaIvaDataGridViewTextBoxColumn.ReadOnly = true;
            this.partitaIvaDataGridViewTextBoxColumn.Width = 125;
            // 
            // codiceFiscaleDataGridViewTextBoxColumn
            // 
            this.codiceFiscaleDataGridViewTextBoxColumn.DataPropertyName = "CodiceFiscale";
            this.codiceFiscaleDataGridViewTextBoxColumn.HeaderText = "CodiceFiscale";
            this.codiceFiscaleDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.codiceFiscaleDataGridViewTextBoxColumn.Name = "codiceFiscaleDataGridViewTextBoxColumn";
            this.codiceFiscaleDataGridViewTextBoxColumn.ReadOnly = true;
            this.codiceFiscaleDataGridViewTextBoxColumn.Width = 125;
            // 
            // fornitoriBindingSource
            // 
            this.fornitoriBindingSource.AllowNew = false;
            this.fornitoriBindingSource.DataSource = typeof(CiccioGest.Domain.ClientiFornitori.Fornitore);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 34);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 28);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // nomeCompletoTextBox
            // 
            this.nomeCompletoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nomeCompletoTextBox.Location = new System.Drawing.Point(58, 3);
            this.nomeCompletoTextBox.Name = "nomeCompletoTextBox";
            this.nomeCompletoTextBox.Size = new System.Drawing.Size(733, 22);
            this.nomeCompletoTextBox.TabIndex = 1;
            // 
            // ListaFornitoriView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ListaFornitoriView";
            this.Text = "ListaFornitoriView";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ListaFornitoriView_FormClosed);
            this.Load += new System.EventHandler(this.ListaFornitoriView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fornitoriDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornitoriBindingSource)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
        private System.Windows.Forms.DataGridView fornitoriDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox nomeCompletoTextBox;
        private System.Windows.Forms.BindingSource fornitoriBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeCompletoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indirizzoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partitaIvaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codiceFiscaleDataGridViewTextBoxColumn;
    }
}