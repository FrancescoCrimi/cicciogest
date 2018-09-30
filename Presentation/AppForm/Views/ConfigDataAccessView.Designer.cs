namespace CiccioGest.Presentation.AppForm.Views
{
    partial class ConfigDataAccessView
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
            this.dataAccessLabel = new System.Windows.Forms.Label();
            this.dataAccessComboBox = new System.Windows.Forms.ComboBox();
            this.databaseLabel = new System.Windows.Forms.Label();
            this.databaseComboBox = new System.Windows.Forms.ComboBox();
            this.uIComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.connectionStringTextBox = new System.Windows.Forms.TextBox();
            this.verificaButton = new System.Windows.Forms.Button();
            this.creaButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dataAccessLabel
            // 
            this.dataAccessLabel.AutoSize = true;
            this.dataAccessLabel.Location = new System.Drawing.Point(12, 9);
            this.dataAccessLabel.Name = "dataAccessLabel";
            this.dataAccessLabel.Size = new System.Drawing.Size(68, 13);
            this.dataAccessLabel.TabIndex = 0;
            this.dataAccessLabel.Text = "Data Access";
            // 
            // dataAccessComboBox
            // 
            this.dataAccessComboBox.FormattingEnabled = true;
            this.dataAccessComboBox.Location = new System.Drawing.Point(99, 6);
            this.dataAccessComboBox.Name = "dataAccessComboBox";
            this.dataAccessComboBox.Size = new System.Drawing.Size(121, 21);
            this.dataAccessComboBox.TabIndex = 1;
            // 
            // databaseLabel
            // 
            this.databaseLabel.AutoSize = true;
            this.databaseLabel.Location = new System.Drawing.Point(12, 36);
            this.databaseLabel.Name = "databaseLabel";
            this.databaseLabel.Size = new System.Drawing.Size(53, 13);
            this.databaseLabel.TabIndex = 2;
            this.databaseLabel.Text = "Database";
            // 
            // databaseComboBox
            // 
            this.databaseComboBox.FormattingEnabled = true;
            this.databaseComboBox.Location = new System.Drawing.Point(99, 33);
            this.databaseComboBox.Name = "databaseComboBox";
            this.databaseComboBox.Size = new System.Drawing.Size(121, 21);
            this.databaseComboBox.TabIndex = 3;
            // 
            // uIComboBox
            // 
            this.uIComboBox.FormattingEnabled = true;
            this.uIComboBox.Location = new System.Drawing.Point(99, 60);
            this.uIComboBox.Name = "uIComboBox";
            this.uIComboBox.Size = new System.Drawing.Size(121, 21);
            this.uIComboBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "U.I.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Connection String";
            // 
            // connectionStringTextBox
            // 
            this.connectionStringTextBox.Location = new System.Drawing.Point(12, 102);
            this.connectionStringTextBox.Name = "connectionStringTextBox";
            this.connectionStringTextBox.Size = new System.Drawing.Size(360, 20);
            this.connectionStringTextBox.TabIndex = 7;
            this.connectionStringTextBox.Text = "server=localhost;User Id=root;password=marco;database=prova";
            // 
            // verificaButton
            // 
            this.verificaButton.Location = new System.Drawing.Point(12, 127);
            this.verificaButton.Name = "verificaButton";
            this.verificaButton.Size = new System.Drawing.Size(100, 23);
            this.verificaButton.TabIndex = 8;
            this.verificaButton.Text = "Verifica Database";
            this.verificaButton.UseVisualStyleBackColor = true;
            this.verificaButton.Click += new System.EventHandler(this.verificaButton_Click);
            // 
            // creaButton
            // 
            this.creaButton.Location = new System.Drawing.Point(142, 127);
            this.creaButton.Name = "creaButton";
            this.creaButton.Size = new System.Drawing.Size(100, 23);
            this.creaButton.TabIndex = 9;
            this.creaButton.Text = "Crea Database";
            this.creaButton.UseVisualStyleBackColor = true;
            this.creaButton.Click += new System.EventHandler(this.creaButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(272, 127);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(100, 23);
            this.startButton.TabIndex = 10;
            this.startButton.Text = "Avvia Programma";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // ConfigDataAccessView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 162);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.creaButton);
            this.Controls.Add(this.verificaButton);
            this.Controls.Add(this.connectionStringTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uIComboBox);
            this.Controls.Add(this.databaseComboBox);
            this.Controls.Add(this.databaseLabel);
            this.Controls.Add(this.dataAccessComboBox);
            this.Controls.Add(this.dataAccessLabel);
            this.Name = "ConfigDataAccessView";
            this.Text = "Configurazione Accesso Dati";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dataAccessLabel;
        private System.Windows.Forms.ComboBox dataAccessComboBox;
        private System.Windows.Forms.Label databaseLabel;
        private System.Windows.Forms.ComboBox databaseComboBox;
        private System.Windows.Forms.ComboBox uIComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox connectionStringTextBox;
        private System.Windows.Forms.Button verificaButton;
        private System.Windows.Forms.Button creaButton;
        private System.Windows.Forms.Button startButton;
    }
}