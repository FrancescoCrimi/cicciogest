namespace CiccioGest.Presentation.AppForm.Views
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
            System.Windows.Forms.Label cSLabel;
            System.Windows.Forms.Label dataAccessLabel;
            System.Windows.Forms.Label databaseLabel;
            System.Windows.Forms.Label nameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingView));
            appConfDataGridView = new System.Windows.Forms.DataGridView();
            cSTextBox = new System.Windows.Forms.TextBox();
            dataAccessComboBox = new System.Windows.Forms.ComboBox();
            databaseComboBox = new System.Windows.Forms.ComboBox();
            nameTextBox = new System.Windows.Forms.TextBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            nuovoToolStripButton = new System.Windows.Forms.ToolStripButton();
            aggiungiToolStripButton = new System.Windows.Forms.ToolStripButton();
            salvaToolStripButton = new System.Windows.Forms.ToolStripButton();
            rimuoviToolStripButton = new System.Windows.Forms.ToolStripButton();
            defaultToolStripButton = new System.Windows.Forms.ToolStripButton();
            caricaDefaultToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            esciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            verificaDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            creaDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            popolaDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            informazionisuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panel1 = new System.Windows.Forms.Panel();
            cSLabel = new System.Windows.Forms.Label();
            dataAccessLabel = new System.Windows.Forms.Label();
            databaseLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)appConfDataGridView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cSLabel
            // 
            cSLabel.AutoSize = true;
            cSLabel.Location = new System.Drawing.Point(8, 39);
            cSLabel.Name = "cSLabel";
            cSLabel.Size = new System.Drawing.Size(24, 15);
            cSLabel.TabIndex = 29;
            cSLabel.Text = "CS:";
            // 
            // dataAccessLabel
            // 
            dataAccessLabel.AutoSize = true;
            dataAccessLabel.Location = new System.Drawing.Point(347, 12);
            dataAccessLabel.Name = "dataAccessLabel";
            dataAccessLabel.Size = new System.Drawing.Size(73, 15);
            dataAccessLabel.TabIndex = 31;
            dataAccessLabel.Text = "Data Access:";
            // 
            // databaseLabel
            // 
            databaseLabel.AutoSize = true;
            databaseLabel.Location = new System.Drawing.Point(167, 12);
            databaseLabel.Name = "databaseLabel";
            databaseLabel.Size = new System.Drawing.Size(58, 15);
            databaseLabel.TabIndex = 33;
            databaseLabel.Text = "Database:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(8, 12);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(42, 15);
            nameLabel.TabIndex = 35;
            nameLabel.Text = "Name:";
            // 
            // appConfDataGridView
            // 
            appConfDataGridView.AllowUserToAddRows = false;
            appConfDataGridView.AllowUserToDeleteRows = false;
            appConfDataGridView.AllowUserToResizeRows = false;
            appConfDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            appConfDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            appConfDataGridView.Location = new System.Drawing.Point(3, 123);
            appConfDataGridView.MultiSelect = false;
            appConfDataGridView.Name = "appConfDataGridView";
            appConfDataGridView.ReadOnly = true;
            appConfDataGridView.RowHeadersVisible = false;
            appConfDataGridView.RowHeadersWidth = 51;
            appConfDataGridView.RowTemplate.Height = 24;
            appConfDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            appConfDataGridView.Size = new System.Drawing.Size(766, 289);
            appConfDataGridView.TabIndex = 29;
            appConfDataGridView.CellDoubleClick += AppConfDataGridView_CellDoubleClick;
            // 
            // cSTextBox
            // 
            cSTextBox.Location = new System.Drawing.Point(39, 37);
            cSTextBox.Name = "cSTextBox";
            cSTextBox.Size = new System.Drawing.Size(720, 23);
            cSTextBox.TabIndex = 30;
            // 
            // dataAccessComboBox
            // 
            dataAccessComboBox.FormattingEnabled = true;
            dataAccessComboBox.Location = new System.Drawing.Point(432, 9);
            dataAccessComboBox.Name = "dataAccessComboBox";
            dataAccessComboBox.Size = new System.Drawing.Size(106, 23);
            dataAccessComboBox.TabIndex = 32;
            // 
            // databaseComboBox
            // 
            databaseComboBox.FormattingEnabled = true;
            databaseComboBox.Location = new System.Drawing.Point(236, 9);
            databaseComboBox.Name = "databaseComboBox";
            databaseComboBox.Size = new System.Drawing.Size(106, 23);
            databaseComboBox.TabIndex = 34;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new System.Drawing.Point(56, 9);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new System.Drawing.Size(106, 23);
            nameTextBox.TabIndex = 36;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(toolStrip1, 0, 1);
            tableLayoutPanel1.Controls.Add(appConfDataGridView, 0, 3);
            tableLayoutPanel1.Controls.Add(menuStrip1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 2);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(772, 415);
            tableLayoutPanel1.TabIndex = 40;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { nuovoToolStripButton, aggiungiToolStripButton, salvaToolStripButton, rimuoviToolStripButton, defaultToolStripButton, caricaDefaultToolStripButton1 });
            toolStrip1.Location = new System.Drawing.Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(772, 27);
            toolStrip1.TabIndex = 32;
            toolStrip1.Text = "toolStrip1";
            // 
            // nuovoToolStripButton
            // 
            nuovoToolStripButton.Image = (System.Drawing.Image)resources.GetObject("nuovoToolStripButton.Image");
            nuovoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            nuovoToolStripButton.Name = "nuovoToolStripButton";
            nuovoToolStripButton.Size = new System.Drawing.Size(67, 24);
            nuovoToolStripButton.Text = "&Nuovo";
            nuovoToolStripButton.Click += NuovoToolStripButton_Click;
            // 
            // aggiungiToolStripButton
            // 
            aggiungiToolStripButton.Image = (System.Drawing.Image)resources.GetObject("aggiungiToolStripButton.Image");
            aggiungiToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            aggiungiToolStripButton.Name = "aggiungiToolStripButton";
            aggiungiToolStripButton.Size = new System.Drawing.Size(80, 24);
            aggiungiToolStripButton.Text = "&Aggiungi";
            aggiungiToolStripButton.Click += AggiungiToolStripButton_Click;
            // 
            // salvaToolStripButton
            // 
            salvaToolStripButton.Image = (System.Drawing.Image)resources.GetObject("salvaToolStripButton.Image");
            salvaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            salvaToolStripButton.Name = "salvaToolStripButton";
            salvaToolStripButton.Size = new System.Drawing.Size(58, 24);
            salvaToolStripButton.Text = "&Salva";
            salvaToolStripButton.Click += SalvaToolStripButton_Click;
            // 
            // rimuoviToolStripButton
            // 
            rimuoviToolStripButton.Image = (System.Drawing.Image)resources.GetObject("rimuoviToolStripButton.Image");
            rimuoviToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            rimuoviToolStripButton.Name = "rimuoviToolStripButton";
            rimuoviToolStripButton.Size = new System.Drawing.Size(75, 24);
            rimuoviToolStripButton.Text = "&Rimuovi";
            rimuoviToolStripButton.Click += RimuoviToolStripButton_Click;
            // 
            // defaultToolStripButton
            // 
            defaultToolStripButton.Image = (System.Drawing.Image)resources.GetObject("defaultToolStripButton.Image");
            defaultToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            defaultToolStripButton.Name = "defaultToolStripButton";
            defaultToolStripButton.Size = new System.Drawing.Size(115, 24);
            defaultToolStripButton.Text = "&Imposta Default";
            defaultToolStripButton.Click += DefaultToolStripButton_Click;
            // 
            // caricaDefaultToolStripButton1
            // 
            caricaDefaultToolStripButton1.Image = (System.Drawing.Image)resources.GetObject("caricaDefaultToolStripButton1.Image");
            caricaDefaultToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            caricaDefaultToolStripButton1.Name = "caricaDefaultToolStripButton1";
            caricaDefaultToolStripButton1.Size = new System.Drawing.Size(105, 24);
            caricaDefaultToolStripButton1.Text = "Carica Default";
            caricaDefaultToolStripButton1.Click += CaricaDefaultToolStripButton1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, databaseToolStripMenuItem, ToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(772, 24);
            menuStrip1.TabIndex = 30;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { esciToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // esciToolStripMenuItem
            // 
            esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            esciToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            esciToolStripMenuItem.Text = "&Esci";
            // 
            // databaseToolStripMenuItem
            // 
            databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { verificaDatabaseToolStripMenuItem, creaDatabaseToolStripMenuItem, popolaDatabaseToolStripMenuItem });
            databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            databaseToolStripMenuItem.Text = "Database";
            // 
            // verificaDatabaseToolStripMenuItem
            // 
            verificaDatabaseToolStripMenuItem.Name = "verificaDatabaseToolStripMenuItem";
            verificaDatabaseToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            verificaDatabaseToolStripMenuItem.Text = "Verifica";
            verificaDatabaseToolStripMenuItem.Click += VerificaDatabaseToolStripMenuItem_Click;
            // 
            // creaDatabaseToolStripMenuItem
            // 
            creaDatabaseToolStripMenuItem.Name = "creaDatabaseToolStripMenuItem";
            creaDatabaseToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            creaDatabaseToolStripMenuItem.Text = "Crea";
            creaDatabaseToolStripMenuItem.Click += CreaDatabaseToolStripMenuItem_Click;
            // 
            // popolaDatabaseToolStripMenuItem
            // 
            popolaDatabaseToolStripMenuItem.Name = "popolaDatabaseToolStripMenuItem";
            popolaDatabaseToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            popolaDatabaseToolStripMenuItem.Text = "Popola";
            popolaDatabaseToolStripMenuItem.Click += PopolaDatabaseToolStripMenuItem_Click;
            // 
            // ToolStripMenuItem
            // 
            ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { informazionisuToolStripMenuItem });
            ToolStripMenuItem.Name = "ToolStripMenuItem";
            ToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            ToolStripMenuItem.Text = "&?";
            // 
            // informazionisuToolStripMenuItem
            // 
            informazionisuToolStripMenuItem.Name = "informazionisuToolStripMenuItem";
            informazionisuToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            informazionisuToolStripMenuItem.Text = "&Informazioni su...";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(nameLabel);
            panel1.Controls.Add(cSLabel);
            panel1.Controls.Add(cSTextBox);
            panel1.Controls.Add(dataAccessLabel);
            panel1.Controls.Add(dataAccessComboBox);
            panel1.Controls.Add(databaseLabel);
            panel1.Controls.Add(nameTextBox);
            panel1.Controls.Add(databaseComboBox);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 54);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(766, 63);
            panel1.TabIndex = 31;
            // 
            // SettingView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(772, 415);
            Controls.Add(tableLayoutPanel1);
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            Name = "SettingView";
            Text = "Impostazioni";
            FormClosing += SettingView_FormClosing;
            Load += SettingView_Load;
            ((System.ComponentModel.ISupportInitialize)appConfDataGridView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView appConfDataGridView;
        private System.Windows.Forms.TextBox cSTextBox;
        private System.Windows.Forms.ComboBox dataAccessComboBox;
        private System.Windows.Forms.ComboBox databaseComboBox;
        private System.Windows.Forms.TextBox nameTextBox;
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
