namespace CiccioGest.Presentation.AppForm.View
{
    partial class SettingView
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
            System.Windows.Forms.Label cSLabel;
            System.Windows.Forms.Label dataAccessLabel;
            System.Windows.Forms.Label databaseLabel;
            System.Windows.Forms.Label nameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingView));
            this.appConfDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appConfsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cSTextBox = new System.Windows.Forms.TextBox();
            this.appConfBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataAccessComboBox = new System.Windows.Forms.ComboBox();
            this.databaseComboBox = new System.Windows.Forms.ComboBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.nuovoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.aggiungiToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.salvaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.rimuoviToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.defaultToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.caricaDefaultToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verificaDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creaDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.popolaDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informazionisuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            cSLabel = new System.Windows.Forms.Label();
            dataAccessLabel = new System.Windows.Forms.Label();
            databaseLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.appConfDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appConfsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appConfBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cSLabel
            // 
            cSLabel.AutoSize = true;
            cSLabel.Location = new System.Drawing.Point(9, 52);
            cSLabel.Name = "cSLabel";
            cSLabel.Size = new System.Drawing.Size(29, 20);
            cSLabel.TabIndex = 29;
            cSLabel.Text = "CS:";
            // 
            // dataAccessLabel
            // 
            dataAccessLabel.AutoSize = true;
            dataAccessLabel.Location = new System.Drawing.Point(397, 16);
            dataAccessLabel.Name = "dataAccessLabel";
            dataAccessLabel.Size = new System.Drawing.Size(92, 20);
            dataAccessLabel.TabIndex = 31;
            dataAccessLabel.Text = "Data Access:";
            // 
            // databaseLabel
            // 
            databaseLabel.AutoSize = true;
            databaseLabel.Location = new System.Drawing.Point(191, 16);
            databaseLabel.Name = "databaseLabel";
            databaseLabel.Size = new System.Drawing.Size(75, 20);
            databaseLabel.TabIndex = 33;
            databaseLabel.Text = "Database:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(9, 16);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(52, 20);
            nameLabel.TabIndex = 35;
            nameLabel.Text = "Name:";
            // 
            // appConfDataGridView
            // 
            this.appConfDataGridView.AllowUserToAddRows = false;
            this.appConfDataGridView.AllowUserToDeleteRows = false;
            this.appConfDataGridView.AllowUserToResizeRows = false;
            this.appConfDataGridView.AutoGenerateColumns = false;
            this.appConfDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appConfDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.appConfDataGridView.DataSource = this.appConfsBindingSource;
            this.appConfDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appConfDataGridView.Location = new System.Drawing.Point(3, 147);
            this.appConfDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.appConfDataGridView.MultiSelect = false;
            this.appConfDataGridView.Name = "appConfDataGridView";
            this.appConfDataGridView.ReadOnly = true;
            this.appConfDataGridView.RowHeadersVisible = false;
            this.appConfDataGridView.RowHeadersWidth = 51;
            this.appConfDataGridView.RowTemplate.Height = 24;
            this.appConfDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appConfDataGridView.Size = new System.Drawing.Size(876, 402);
            this.appConfDataGridView.TabIndex = 29;
            this.appConfDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AppConfDataGridView_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn5.HeaderText = "Name";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 78;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DataAccess";
            this.dataGridViewTextBoxColumn2.HeaderText = "DataAccess";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 114;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Database";
            this.dataGridViewTextBoxColumn3.HeaderText = "Database";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 101;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CS";
            this.dataGridViewTextBoxColumn4.HeaderText = "CS";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // appConfsBindingSource
            // 
            this.appConfsBindingSource.DataSource = typeof(CiccioGest.Infrastructure.Conf.CiccioGestConf);
            // 
            // cSTextBox
            // 
            this.cSTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appConfBindingSource, "CS", true));
            this.cSTextBox.Location = new System.Drawing.Point(45, 49);
            this.cSTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cSTextBox.Name = "cSTextBox";
            this.cSTextBox.Size = new System.Drawing.Size(822, 27);
            this.cSTextBox.TabIndex = 30;
            // 
            // appConfBindingSource
            // 
            this.appConfBindingSource.DataSource = typeof(CiccioGest.Infrastructure.Conf.CiccioGestConf);
            // 
            // dataAccessComboBox
            // 
            this.dataAccessComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appConfBindingSource, "DataAccess", true));
            this.dataAccessComboBox.FormattingEnabled = true;
            this.dataAccessComboBox.Location = new System.Drawing.Point(494, 12);
            this.dataAccessComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataAccessComboBox.Name = "dataAccessComboBox";
            this.dataAccessComboBox.Size = new System.Drawing.Size(121, 28);
            this.dataAccessComboBox.TabIndex = 32;
            // 
            // databaseComboBox
            // 
            this.databaseComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appConfBindingSource, "Database", true));
            this.databaseComboBox.FormattingEnabled = true;
            this.databaseComboBox.Location = new System.Drawing.Point(270, 12);
            this.databaseComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.databaseComboBox.Name = "databaseComboBox";
            this.databaseComboBox.Size = new System.Drawing.Size(121, 28);
            this.databaseComboBox.TabIndex = 34;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appConfBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(64, 12);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(121, 27);
            this.nameTextBox.TabIndex = 36;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.appConfDataGridView, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(882, 553);
            this.tableLayoutPanel1.TabIndex = 40;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovoToolStripButton,
            this.aggiungiToolStripButton,
            this.salvaToolStripButton,
            this.rimuoviToolStripButton,
            this.defaultToolStripButton,
            this.caricaDefaultToolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(882, 27);
            this.toolStrip1.TabIndex = 32;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // nuovoToolStripButton
            // 
            this.nuovoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nuovoToolStripButton.Image")));
            this.nuovoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuovoToolStripButton.Name = "nuovoToolStripButton";
            this.nuovoToolStripButton.Size = new System.Drawing.Size(77, 24);
            this.nuovoToolStripButton.Text = "&Nuovo";
            this.nuovoToolStripButton.Click += new System.EventHandler(this.NuovoToolStripButton_Click);
            // 
            // aggiungiToolStripButton
            // 
            this.aggiungiToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("aggiungiToolStripButton.Image")));
            this.aggiungiToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aggiungiToolStripButton.Name = "aggiungiToolStripButton";
            this.aggiungiToolStripButton.Size = new System.Drawing.Size(94, 24);
            this.aggiungiToolStripButton.Text = "&Aggiungi";
            this.aggiungiToolStripButton.Click += new System.EventHandler(this.AggiungiToolStripButton_Click);
            // 
            // salvaToolStripButton
            // 
            this.salvaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("salvaToolStripButton.Image")));
            this.salvaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salvaToolStripButton.Name = "salvaToolStripButton";
            this.salvaToolStripButton.Size = new System.Drawing.Size(68, 24);
            this.salvaToolStripButton.Text = "&Salva";
            this.salvaToolStripButton.Click += new System.EventHandler(this.SalvaToolStripButton_Click);
            // 
            // rimuoviToolStripButton
            // 
            this.rimuoviToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("rimuoviToolStripButton.Image")));
            this.rimuoviToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rimuoviToolStripButton.Name = "rimuoviToolStripButton";
            this.rimuoviToolStripButton.Size = new System.Drawing.Size(87, 24);
            this.rimuoviToolStripButton.Text = "&Rimuovi";
            this.rimuoviToolStripButton.Click += new System.EventHandler(this.RimuoviToolStripButton_Click);
            // 
            // defaultToolStripButton
            // 
            this.defaultToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("defaultToolStripButton.Image")));
            this.defaultToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.defaultToolStripButton.Name = "defaultToolStripButton";
            this.defaultToolStripButton.Size = new System.Drawing.Size(140, 24);
            this.defaultToolStripButton.Text = "&Imposta Default";
            this.defaultToolStripButton.Click += new System.EventHandler(this.DefaultToolStripButton_Click);
            // 
            // caricaDefaultToolStripButton1
            // 
            this.caricaDefaultToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("caricaDefaultToolStripButton1.Image")));
            this.caricaDefaultToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.caricaDefaultToolStripButton1.Name = "caricaDefaultToolStripButton1";
            this.caricaDefaultToolStripButton1.Size = new System.Drawing.Size(127, 24);
            this.caricaDefaultToolStripButton1.Text = "Carica Default";
            this.caricaDefaultToolStripButton1.Click += new System.EventHandler(this.CaricaDefaultToolStripButton1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.databaseToolStripMenuItem,
            this.ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 28);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.esciToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // esciToolStripMenuItem
            // 
            this.esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            this.esciToolStripMenuItem.Size = new System.Drawing.Size(117, 26);
            this.esciToolStripMenuItem.Text = "&Esci";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verificaDatabaseToolStripMenuItem,
            this.creaDatabaseToolStripMenuItem,
            this.popolaDatabaseToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // verificaDatabaseToolStripMenuItem
            // 
            this.verificaDatabaseToolStripMenuItem.Name = "verificaDatabaseToolStripMenuItem";
            this.verificaDatabaseToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.verificaDatabaseToolStripMenuItem.Text = "Verifica";
            this.verificaDatabaseToolStripMenuItem.Click += new System.EventHandler(this.VerificaDatabaseToolStripMenuItem_Click);
            // 
            // creaDatabaseToolStripMenuItem
            // 
            this.creaDatabaseToolStripMenuItem.Name = "creaDatabaseToolStripMenuItem";
            this.creaDatabaseToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.creaDatabaseToolStripMenuItem.Text = "Crea";
            this.creaDatabaseToolStripMenuItem.Click += new System.EventHandler(this.CreaDatabaseToolStripMenuItem_Click);
            // 
            // popolaDatabaseToolStripMenuItem
            // 
            this.popolaDatabaseToolStripMenuItem.Name = "popolaDatabaseToolStripMenuItem";
            this.popolaDatabaseToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.popolaDatabaseToolStripMenuItem.Text = "Popola";
            this.popolaDatabaseToolStripMenuItem.Click += new System.EventHandler(this.PopolaDatabaseToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informazionisuToolStripMenuItem});
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(30, 24);
            this.ToolStripMenuItem.Text = "&?";
            // 
            // informazionisuToolStripMenuItem
            // 
            this.informazionisuToolStripMenuItem.Name = "informazionisuToolStripMenuItem";
            this.informazionisuToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.informazionisuToolStripMenuItem.Text = "&Informazioni su...";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(nameLabel);
            this.panel1.Controls.Add(cSLabel);
            this.panel1.Controls.Add(this.cSTextBox);
            this.panel1.Controls.Add(dataAccessLabel);
            this.panel1.Controls.Add(this.dataAccessComboBox);
            this.panel1.Controls.Add(databaseLabel);
            this.panel1.Controls.Add(this.nameTextBox);
            this.panel1.Controls.Add(this.databaseComboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 59);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 80);
            this.panel1.TabIndex = 31;
            // 
            // SettingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SettingView";
            this.Text = "Impostazioni";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingView_FormClosing);
            this.Load += new System.EventHandler(this.SettingView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.appConfDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appConfsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appConfBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource appConfsBindingSource;
        private System.Windows.Forms.DataGridView appConfDataGridView;
        private System.Windows.Forms.TextBox cSTextBox;
        private System.Windows.Forms.ComboBox dataAccessComboBox;
        private System.Windows.Forms.ComboBox databaseComboBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.BindingSource appConfBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informazionisuToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verificaDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creaDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem popolaDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton nuovoToolStripButton;
        private System.Windows.Forms.ToolStripButton aggiungiToolStripButton;
        private System.Windows.Forms.ToolStripButton salvaToolStripButton;
        private System.Windows.Forms.ToolStripButton rimuoviToolStripButton;
        private System.Windows.Forms.ToolStripButton defaultToolStripButton;
        private System.Windows.Forms.ToolStripButton caricaDefaultToolStripButton1;
    }
}
