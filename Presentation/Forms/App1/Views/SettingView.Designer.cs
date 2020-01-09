namespace CiccioGest.Presentation.Forms.App1.Views
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
            System.Windows.Forms.Label dataAccessLabel1;
            System.Windows.Forms.Label databaseLabel1;
            System.Windows.Forms.Label nameLabel;
            this.verifyDbButton = new System.Windows.Forms.Button();
            this.createDbButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.loadSampleButton = new System.Windows.Forms.Button();
            this.writeConfButton = new System.Windows.Forms.Button();
            this.loadConfButton = new System.Windows.Forms.Button();
            this.appConfBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appConfDataGridView = new System.Windows.Forms.DataGridView();
            this.cSTextBox = new System.Windows.Forms.TextBox();
            this.dataAccessComboBox1 = new System.Windows.Forms.ComboBox();
            this.databaseComboBox1 = new System.Windows.Forms.ComboBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.appConfsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nuovaButton = new System.Windows.Forms.Button();
            this.aggiungiButton = new System.Windows.Forms.Button();
            this.modificaButton = new System.Windows.Forms.Button();
            this.rimuoviButton = new System.Windows.Forms.Button();
            this.setDefaultButton = new System.Windows.Forms.Button();
            cSLabel = new System.Windows.Forms.Label();
            dataAccessLabel1 = new System.Windows.Forms.Label();
            databaseLabel1 = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.appConfBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appConfDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appConfsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // verifyDbButton
            // 
            this.verifyDbButton.AutoSize = true;
            this.verifyDbButton.Location = new System.Drawing.Point(401, 12);
            this.verifyDbButton.Name = "verifyDbButton";
            this.verifyDbButton.Size = new System.Drawing.Size(130, 27);
            this.verifyDbButton.TabIndex = 8;
            this.verifyDbButton.Text = "Verifica Database";
            this.verifyDbButton.UseVisualStyleBackColor = true;
            this.verifyDbButton.Click += new System.EventHandler(this.VerifyDbButton_Click);
            // 
            // createDbButton
            // 
            this.createDbButton.AutoSize = true;
            this.createDbButton.Location = new System.Drawing.Point(401, 48);
            this.createDbButton.Name = "createDbButton";
            this.createDbButton.Size = new System.Drawing.Size(113, 27);
            this.createDbButton.TabIndex = 9;
            this.createDbButton.Text = "Crea Database";
            this.createDbButton.UseVisualStyleBackColor = true;
            this.createDbButton.Click += new System.EventHandler(this.CreateDbButton_Click);
            // 
            // startButton
            // 
            this.startButton.AutoSize = true;
            this.startButton.Location = new System.Drawing.Point(634, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(129, 27);
            this.startButton.TabIndex = 10;
            this.startButton.Text = "Avvia Programma";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // loadSampleButton
            // 
            this.loadSampleButton.AutoSize = true;
            this.loadSampleButton.Location = new System.Drawing.Point(634, 48);
            this.loadSampleButton.Name = "loadSampleButton";
            this.loadSampleButton.Size = new System.Drawing.Size(142, 27);
            this.loadSampleButton.TabIndex = 11;
            this.loadSampleButton.Text = "Carica dati esempio";
            this.loadSampleButton.UseVisualStyleBackColor = true;
            this.loadSampleButton.Click += new System.EventHandler(this.LoadSampleButton_Click);
            // 
            // writeConfButton
            // 
            this.writeConfButton.AutoSize = true;
            this.writeConfButton.Location = new System.Drawing.Point(274, 48);
            this.writeConfButton.Name = "writeConfButton";
            this.writeConfButton.Size = new System.Drawing.Size(87, 27);
            this.writeConfButton.TabIndex = 12;
            this.writeConfButton.Text = "Scrivi conf.";
            this.writeConfButton.UseVisualStyleBackColor = true;
            this.writeConfButton.Click += new System.EventHandler(this.WriteConfButton_Click);
            // 
            // loadConfButton
            // 
            this.loadConfButton.AutoSize = true;
            this.loadConfButton.Location = new System.Drawing.Point(274, 12);
            this.loadConfButton.Name = "loadConfButton";
            this.loadConfButton.Size = new System.Drawing.Size(91, 27);
            this.loadConfButton.TabIndex = 13;
            this.loadConfButton.Text = "Carica Conf";
            this.loadConfButton.UseVisualStyleBackColor = true;
            this.loadConfButton.Click += new System.EventHandler(this.LoadConfButton_Click);
            // 
            // appConfBindingSource
            // 
            this.appConfBindingSource.AllowNew = false;
            this.appConfBindingSource.DataSource = typeof(CiccioGest.Infrastructure.Conf.AppConf);
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
            this.appConfDataGridView.Location = new System.Drawing.Point(15, 159);
            this.appConfDataGridView.MultiSelect = false;
            this.appConfDataGridView.Name = "appConfDataGridView";
            this.appConfDataGridView.ReadOnly = true;
            this.appConfDataGridView.RowHeadersVisible = false;
            this.appConfDataGridView.RowHeadersWidth = 51;
            this.appConfDataGridView.RowTemplate.Height = 24;
            this.appConfDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appConfDataGridView.Size = new System.Drawing.Size(814, 220);
            this.appConfDataGridView.TabIndex = 15;
            // 
            // cSLabel
            // 
            cSLabel.AutoSize = true;
            cSLabel.Location = new System.Drawing.Point(12, 102);
            cSLabel.Name = "cSLabel";
            cSLabel.Size = new System.Drawing.Size(124, 17);
            cSLabel.TabIndex = 16;
            cSLabel.Text = "Connection String:";
            // 
            // cSTextBox
            // 
            this.cSTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appConfBindingSource, "CS", true));
            this.cSTextBox.Location = new System.Drawing.Point(15, 131);
            this.cSTextBox.Name = "cSTextBox";
            this.cSTextBox.Size = new System.Drawing.Size(814, 22);
            this.cSTextBox.TabIndex = 17;
            // 
            // dataAccessLabel1
            // 
            dataAccessLabel1.AutoSize = true;
            dataAccessLabel1.Location = new System.Drawing.Point(12, 9);
            dataAccessLabel1.Name = "dataAccessLabel1";
            dataAccessLabel1.Size = new System.Drawing.Size(91, 17);
            dataAccessLabel1.TabIndex = 18;
            dataAccessLabel1.Text = "Data Access:";
            // 
            // dataAccessComboBox1
            // 
            this.dataAccessComboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appConfBindingSource, "DataAccess", true));
            this.dataAccessComboBox1.FormattingEnabled = true;
            this.dataAccessComboBox1.Location = new System.Drawing.Point(109, 6);
            this.dataAccessComboBox1.Name = "dataAccessComboBox1";
            this.dataAccessComboBox1.Size = new System.Drawing.Size(121, 24);
            this.dataAccessComboBox1.TabIndex = 19;
            // 
            // databaseLabel1
            // 
            databaseLabel1.AutoSize = true;
            databaseLabel1.Location = new System.Drawing.Point(12, 40);
            databaseLabel1.Name = "databaseLabel1";
            databaseLabel1.Size = new System.Drawing.Size(73, 17);
            databaseLabel1.TabIndex = 20;
            databaseLabel1.Text = "Database:";
            // 
            // databaseComboBox1
            // 
            this.databaseComboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appConfBindingSource, "Database", true));
            this.databaseComboBox1.FormattingEnabled = true;
            this.databaseComboBox1.Location = new System.Drawing.Point(109, 37);
            this.databaseComboBox1.Name = "databaseComboBox1";
            this.databaseComboBox1.Size = new System.Drawing.Size(121, 24);
            this.databaseComboBox1.TabIndex = 21;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(12, 71);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(49, 17);
            nameLabel.TabIndex = 22;
            nameLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appConfBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(109, 68);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(121, 22);
            this.nameTextBox.TabIndex = 23;
            // 
            // appConfsBindingSource
            // 
            this.appConfsBindingSource.AllowNew = false;
            this.appConfsBindingSource.DataSource = typeof(CiccioGest.Infrastructure.Conf.AppConf);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn5.HeaderText = "Name";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 74;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DataAccess";
            this.dataGridViewTextBoxColumn2.HeaderText = "DataAccess";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 112;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Database";
            this.dataGridViewTextBoxColumn3.HeaderText = "Database";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 98;
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
            // nuovaButton
            // 
            this.nuovaButton.AutoSize = true;
            this.nuovaButton.Location = new System.Drawing.Point(274, 81);
            this.nuovaButton.Name = "nuovaButton";
            this.nuovaButton.Size = new System.Drawing.Size(75, 27);
            this.nuovaButton.TabIndex = 24;
            this.nuovaButton.Text = "Nuova";
            this.nuovaButton.UseVisualStyleBackColor = true;
            this.nuovaButton.Click += new System.EventHandler(this.nuovaButton_Click);
            // 
            // aggiungiButton
            // 
            this.aggiungiButton.AutoSize = true;
            this.aggiungiButton.Location = new System.Drawing.Point(456, 81);
            this.aggiungiButton.Name = "aggiungiButton";
            this.aggiungiButton.Size = new System.Drawing.Size(75, 27);
            this.aggiungiButton.TabIndex = 25;
            this.aggiungiButton.Text = "Aggiungi";
            this.aggiungiButton.UseVisualStyleBackColor = true;
            this.aggiungiButton.Click += new System.EventHandler(this.aggiungiButton_Click);
            // 
            // modificaButton
            // 
            this.modificaButton.AutoSize = true;
            this.modificaButton.Location = new System.Drawing.Point(366, 81);
            this.modificaButton.Name = "modificaButton";
            this.modificaButton.Size = new System.Drawing.Size(75, 27);
            this.modificaButton.TabIndex = 26;
            this.modificaButton.Text = "Modifica";
            this.modificaButton.UseVisualStyleBackColor = true;
            this.modificaButton.Click += new System.EventHandler(this.modificaButton_Click);
            // 
            // rimuoviButton
            // 
            this.rimuoviButton.AutoSize = true;
            this.rimuoviButton.Location = new System.Drawing.Point(553, 81);
            this.rimuoviButton.Name = "rimuoviButton";
            this.rimuoviButton.Size = new System.Drawing.Size(75, 27);
            this.rimuoviButton.TabIndex = 27;
            this.rimuoviButton.Text = "Rimuovi";
            this.rimuoviButton.UseVisualStyleBackColor = true;
            this.rimuoviButton.Click += new System.EventHandler(this.rimuoviButton_Click);
            // 
            // setDefaultButton
            // 
            this.setDefaultButton.AutoSize = true;
            this.setDefaultButton.Location = new System.Drawing.Point(650, 81);
            this.setDefaultButton.Name = "setDefaultButton";
            this.setDefaultButton.Size = new System.Drawing.Size(88, 27);
            this.setDefaultButton.TabIndex = 28;
            this.setDefaultButton.Text = "Set Default";
            this.setDefaultButton.UseVisualStyleBackColor = true;
            this.setDefaultButton.Click += new System.EventHandler(this.setDefaultButton_Click);
            // 
            // SettingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 396);
            this.Controls.Add(this.setDefaultButton);
            this.Controls.Add(this.rimuoviButton);
            this.Controls.Add(this.modificaButton);
            this.Controls.Add(this.aggiungiButton);
            this.Controls.Add(this.nuovaButton);
            this.Controls.Add(cSLabel);
            this.Controls.Add(this.cSTextBox);
            this.Controls.Add(dataAccessLabel1);
            this.Controls.Add(this.dataAccessComboBox1);
            this.Controls.Add(databaseLabel1);
            this.Controls.Add(this.databaseComboBox1);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.appConfDataGridView);
            this.Controls.Add(this.loadConfButton);
            this.Controls.Add(this.writeConfButton);
            this.Controls.Add(this.loadSampleButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.createDbButton);
            this.Controls.Add(this.verifyDbButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingView";
            this.Text = "Impostazioni";
            ((System.ComponentModel.ISupportInitialize)(this.appConfBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appConfDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appConfsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button verifyDbButton;
        private System.Windows.Forms.Button createDbButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button loadSampleButton;
        private System.Windows.Forms.Button writeConfButton;
        private System.Windows.Forms.Button loadConfButton;
        private System.Windows.Forms.BindingSource appConfBindingSource;
        private System.Windows.Forms.DataGridView appConfDataGridView;
        private System.Windows.Forms.TextBox cSTextBox;
        private System.Windows.Forms.ComboBox dataAccessComboBox1;
        private System.Windows.Forms.ComboBox databaseComboBox1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.BindingSource appConfsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button nuovaButton;
        private System.Windows.Forms.Button aggiungiButton;
        private System.Windows.Forms.Button modificaButton;
        private System.Windows.Forms.Button rimuoviButton;
        private System.Windows.Forms.Button setDefaultButton;
    }
}
