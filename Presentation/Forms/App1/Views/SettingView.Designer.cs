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
            System.Windows.Forms.Label dataAccessLabel;
            System.Windows.Forms.Label databaseLabel;
            System.Windows.Forms.Label nameLabel;
            this.verifyDbButton = new System.Windows.Forms.Button();
            this.createDbButton = new System.Windows.Forms.Button();
            this.loadSampleButton = new System.Windows.Forms.Button();
            this.aggiungiButton = new System.Windows.Forms.Button();
            this.rimuoviButton = new System.Windows.Forms.Button();
            this.setDefaultButton = new System.Windows.Forms.Button();
            this.appConfDataGridView = new System.Windows.Forms.DataGridView();
            this.cSTextBox = new System.Windows.Forms.TextBox();
            this.dataAccessComboBox = new System.Windows.Forms.ComboBox();
            this.databaseComboBox = new System.Windows.Forms.ComboBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.SalvaButton = new System.Windows.Forms.Button();
            this.appConfsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appConfBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nuovoButton = new System.Windows.Forms.Button();
            cSLabel = new System.Windows.Forms.Label();
            dataAccessLabel = new System.Windows.Forms.Label();
            databaseLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.appConfDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appConfsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appConfBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // verifyDbButton
            // 
            this.verifyDbButton.AutoSize = true;
            this.verifyDbButton.Location = new System.Drawing.Point(300, 15);
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
            this.createDbButton.Location = new System.Drawing.Point(722, 15);
            this.createDbButton.Name = "createDbButton";
            this.createDbButton.Size = new System.Drawing.Size(113, 27);
            this.createDbButton.TabIndex = 9;
            this.createDbButton.Text = "Crea Database";
            this.createDbButton.UseVisualStyleBackColor = true;
            this.createDbButton.Click += new System.EventHandler(this.CreateDbButton_Click);
            // 
            // loadSampleButton
            // 
            this.loadSampleButton.AutoSize = true;
            this.loadSampleButton.Location = new System.Drawing.Point(505, 15);
            this.loadSampleButton.Name = "loadSampleButton";
            this.loadSampleButton.Size = new System.Drawing.Size(142, 27);
            this.loadSampleButton.TabIndex = 11;
            this.loadSampleButton.Text = "Carica dati esempio";
            this.loadSampleButton.UseVisualStyleBackColor = true;
            this.loadSampleButton.Click += new System.EventHandler(this.LoadSampleButton_Click);
            // 
            // aggiungiButton
            // 
            this.aggiungiButton.AutoSize = true;
            this.aggiungiButton.Location = new System.Drawing.Point(412, 63);
            this.aggiungiButton.Name = "aggiungiButton";
            this.aggiungiButton.Size = new System.Drawing.Size(75, 27);
            this.aggiungiButton.TabIndex = 25;
            this.aggiungiButton.Text = "Aggiungi";
            this.aggiungiButton.UseVisualStyleBackColor = true;
            this.aggiungiButton.Click += new System.EventHandler(this.AggiungiButton_Click);
            // 
            // rimuoviButton
            // 
            this.rimuoviButton.AutoSize = true;
            this.rimuoviButton.Location = new System.Drawing.Point(524, 63);
            this.rimuoviButton.Name = "rimuoviButton";
            this.rimuoviButton.Size = new System.Drawing.Size(75, 27);
            this.rimuoviButton.TabIndex = 27;
            this.rimuoviButton.Text = "Rimuovi";
            this.rimuoviButton.UseVisualStyleBackColor = true;
            this.rimuoviButton.Click += new System.EventHandler(this.RimuoviButton_Click);
            // 
            // setDefaultButton
            // 
            this.setDefaultButton.AutoSize = true;
            this.setDefaultButton.Location = new System.Drawing.Point(748, 63);
            this.setDefaultButton.Name = "setDefaultButton";
            this.setDefaultButton.Size = new System.Drawing.Size(88, 27);
            this.setDefaultButton.TabIndex = 28;
            this.setDefaultButton.Text = "Set Default";
            this.setDefaultButton.UseVisualStyleBackColor = true;
            this.setDefaultButton.Click += new System.EventHandler(this.SetDefaultButton_Click);
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
            this.appConfDataGridView.Location = new System.Drawing.Point(16, 127);
            this.appConfDataGridView.MultiSelect = false;
            this.appConfDataGridView.Name = "appConfDataGridView";
            this.appConfDataGridView.ReadOnly = true;
            this.appConfDataGridView.RowHeadersVisible = false;
            this.appConfDataGridView.RowHeadersWidth = 51;
            this.appConfDataGridView.RowTemplate.Height = 24;
            this.appConfDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appConfDataGridView.Size = new System.Drawing.Size(823, 255);
            this.appConfDataGridView.TabIndex = 29;
            this.appConfDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AppConfDataGridView_CellDoubleClick);
            // 
            // cSLabel
            // 
            cSLabel.AutoSize = true;
            cSLabel.Location = new System.Drawing.Point(13, 102);
            cSLabel.Name = "cSLabel";
            cSLabel.Size = new System.Drawing.Size(30, 17);
            cSLabel.TabIndex = 29;
            cSLabel.Text = "CS:";
            // 
            // cSTextBox
            // 
            this.cSTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appConfBindingSource, "CS", true));
            this.cSTextBox.Location = new System.Drawing.Point(110, 99);
            this.cSTextBox.Name = "cSTextBox";
            this.cSTextBox.Size = new System.Drawing.Size(729, 22);
            this.cSTextBox.TabIndex = 30;
            // 
            // dataAccessLabel
            // 
            dataAccessLabel.AutoSize = true;
            dataAccessLabel.Location = new System.Drawing.Point(13, 73);
            dataAccessLabel.Name = "dataAccessLabel";
            dataAccessLabel.Size = new System.Drawing.Size(91, 17);
            dataAccessLabel.TabIndex = 31;
            dataAccessLabel.Text = "Data Access:";
            // 
            // dataAccessComboBox
            // 
            this.dataAccessComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appConfBindingSource, "DataAccess", true));
            this.dataAccessComboBox.FormattingEnabled = true;
            this.dataAccessComboBox.Location = new System.Drawing.Point(110, 70);
            this.dataAccessComboBox.Name = "dataAccessComboBox";
            this.dataAccessComboBox.Size = new System.Drawing.Size(121, 24);
            this.dataAccessComboBox.TabIndex = 32;
            // 
            // databaseLabel
            // 
            databaseLabel.AutoSize = true;
            databaseLabel.Location = new System.Drawing.Point(13, 43);
            databaseLabel.Name = "databaseLabel";
            databaseLabel.Size = new System.Drawing.Size(73, 17);
            databaseLabel.TabIndex = 33;
            databaseLabel.Text = "Database:";
            // 
            // databaseComboBox
            // 
            this.databaseComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appConfBindingSource, "Database", true));
            this.databaseComboBox.FormattingEnabled = true;
            this.databaseComboBox.Location = new System.Drawing.Point(110, 40);
            this.databaseComboBox.Name = "databaseComboBox";
            this.databaseComboBox.Size = new System.Drawing.Size(121, 24);
            this.databaseComboBox.TabIndex = 34;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(13, 15);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(49, 17);
            nameLabel.TabIndex = 35;
            nameLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appConfBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(110, 12);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(121, 22);
            this.nameTextBox.TabIndex = 36;
            // 
            // SalvaButton
            // 
            this.SalvaButton.AutoSize = true;
            this.SalvaButton.Location = new System.Drawing.Point(636, 63);
            this.SalvaButton.Name = "SalvaButton";
            this.SalvaButton.Size = new System.Drawing.Size(75, 27);
            this.SalvaButton.TabIndex = 37;
            this.SalvaButton.Text = "Salva";
            this.SalvaButton.UseVisualStyleBackColor = true;
            this.SalvaButton.Click += new System.EventHandler(this.SalvaButton_Click);
            // 
            // appConfsBindingSource
            // 
            this.appConfsBindingSource.DataSource = typeof(CiccioGest.Infrastructure.Conf.AppConf);
            // 
            // appConfBindingSource
            // 
            this.appConfBindingSource.DataSource = typeof(CiccioGest.Infrastructure.Conf.AppConf);
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
            // nuovoButton
            // 
            this.nuovoButton.AutoSize = true;
            this.nuovoButton.Location = new System.Drawing.Point(300, 63);
            this.nuovoButton.Name = "nuovoButton";
            this.nuovoButton.Size = new System.Drawing.Size(75, 27);
            this.nuovoButton.TabIndex = 38;
            this.nuovoButton.Text = "Nuovo";
            this.nuovoButton.UseVisualStyleBackColor = true;
            this.nuovoButton.Click += new System.EventHandler(this.NuovoButton_Click);
            // 
            // SettingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 404);
            this.Controls.Add(this.nuovoButton);
            this.Controls.Add(this.SalvaButton);
            this.Controls.Add(cSLabel);
            this.Controls.Add(this.cSTextBox);
            this.Controls.Add(dataAccessLabel);
            this.Controls.Add(this.dataAccessComboBox);
            this.Controls.Add(databaseLabel);
            this.Controls.Add(this.databaseComboBox);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.appConfDataGridView);
            this.Controls.Add(this.setDefaultButton);
            this.Controls.Add(this.rimuoviButton);
            this.Controls.Add(this.aggiungiButton);
            this.Controls.Add(this.loadSampleButton);
            this.Controls.Add(this.createDbButton);
            this.Controls.Add(this.verifyDbButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingView";
            this.Text = "Impostazioni";
            ((System.ComponentModel.ISupportInitialize)(this.appConfDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appConfsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appConfBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button verifyDbButton;
        private System.Windows.Forms.Button createDbButton;
        private System.Windows.Forms.Button loadSampleButton;
        private System.Windows.Forms.Button aggiungiButton;
        private System.Windows.Forms.Button rimuoviButton;
        private System.Windows.Forms.Button setDefaultButton;
        private System.Windows.Forms.BindingSource appConfsBindingSource;
        private System.Windows.Forms.DataGridView appConfDataGridView;
        private System.Windows.Forms.TextBox cSTextBox;
        private System.Windows.Forms.ComboBox dataAccessComboBox;
        private System.Windows.Forms.ComboBox databaseComboBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.BindingSource appConfBindingSource;
        private System.Windows.Forms.Button SalvaButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button nuovoButton;
    }
}
