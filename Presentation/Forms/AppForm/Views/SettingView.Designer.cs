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
            this.dataAccessLabel = new System.Windows.Forms.Label();
            this.dataAccessComboBox = new System.Windows.Forms.ComboBox();
            this.databaseLabel = new System.Windows.Forms.Label();
            this.databaseComboBox = new System.Windows.Forms.ComboBox();
            this.uIComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.connectionStringTextBox = new System.Windows.Forms.TextBox();
            this.verifyDbButton = new System.Windows.Forms.Button();
            this.createDbButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.loadSampleButton = new System.Windows.Forms.Button();
            this.writeConfButton = new System.Windows.Forms.Button();
            this.loadConfButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dataAccessLabel
            // 
            this.dataAccessLabel.AutoSize = true;
            this.dataAccessLabel.Location = new System.Drawing.Point(16, 11);
            this.dataAccessLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dataAccessLabel.Name = "dataAccessLabel";
            this.dataAccessLabel.Size = new System.Drawing.Size(87, 17);
            this.dataAccessLabel.TabIndex = 0;
            this.dataAccessLabel.Text = "Data Access";
            // 
            // dataAccessComboBox
            // 
            this.dataAccessComboBox.FormattingEnabled = true;
            this.dataAccessComboBox.Location = new System.Drawing.Point(132, 7);
            this.dataAccessComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.dataAccessComboBox.Name = "dataAccessComboBox";
            this.dataAccessComboBox.Size = new System.Drawing.Size(160, 24);
            this.dataAccessComboBox.TabIndex = 1;
            // 
            // databaseLabel
            // 
            this.databaseLabel.AutoSize = true;
            this.databaseLabel.Location = new System.Drawing.Point(16, 44);
            this.databaseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.databaseLabel.Name = "databaseLabel";
            this.databaseLabel.Size = new System.Drawing.Size(69, 17);
            this.databaseLabel.TabIndex = 2;
            this.databaseLabel.Text = "Database";
            // 
            // databaseComboBox
            // 
            this.databaseComboBox.FormattingEnabled = true;
            this.databaseComboBox.Location = new System.Drawing.Point(132, 41);
            this.databaseComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.databaseComboBox.Name = "databaseComboBox";
            this.databaseComboBox.Size = new System.Drawing.Size(160, 24);
            this.databaseComboBox.TabIndex = 3;
            // 
            // uIComboBox
            // 
            this.uIComboBox.FormattingEnabled = true;
            this.uIComboBox.Location = new System.Drawing.Point(132, 74);
            this.uIComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.uIComboBox.Name = "uIComboBox";
            this.uIComboBox.Size = new System.Drawing.Size(160, 24);
            this.uIComboBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "U.I.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Connection String";
            // 
            // connectionStringTextBox
            // 
            this.connectionStringTextBox.Location = new System.Drawing.Point(16, 126);
            this.connectionStringTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.connectionStringTextBox.Name = "connectionStringTextBox";
            this.connectionStringTextBox.Size = new System.Drawing.Size(464, 22);
            this.connectionStringTextBox.TabIndex = 7;
            this.connectionStringTextBox.Text = "server=localhost;User Id=root;password=marco;database=prova";
            // 
            // verifyDbButton
            // 
            this.verifyDbButton.Location = new System.Drawing.Point(172, 155);
            this.verifyDbButton.Name = "verifyDbButton";
            this.verifyDbButton.Size = new System.Drawing.Size(150, 30);
            this.verifyDbButton.TabIndex = 8;
            this.verifyDbButton.Text = "Verifica Database";
            this.verifyDbButton.UseVisualStyleBackColor = true;
            this.verifyDbButton.Click += new System.EventHandler(this.VerifyDbButton_Click);
            // 
            // createDbButton
            // 
            this.createDbButton.Location = new System.Drawing.Point(172, 191);
            this.createDbButton.Name = "createDbButton";
            this.createDbButton.Size = new System.Drawing.Size(150, 30);
            this.createDbButton.TabIndex = 9;
            this.createDbButton.Text = "Crea Database";
            this.createDbButton.UseVisualStyleBackColor = true;
            this.createDbButton.Click += new System.EventHandler(this.CreateDbButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(330, 155);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(150, 30);
            this.startButton.TabIndex = 10;
            this.startButton.Text = "Avvia Programma";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // loadSampleButton
            // 
            this.loadSampleButton.Location = new System.Drawing.Point(330, 191);
            this.loadSampleButton.Name = "loadSampleButton";
            this.loadSampleButton.Size = new System.Drawing.Size(150, 30);
            this.loadSampleButton.TabIndex = 11;
            this.loadSampleButton.Text = "Carica dati esempio";
            this.loadSampleButton.UseVisualStyleBackColor = true;
            this.loadSampleButton.Click += new System.EventHandler(this.LoadSampleButton_Click);
            // 
            // writeConfButton
            // 
            this.writeConfButton.Location = new System.Drawing.Point(16, 191);
            this.writeConfButton.Name = "writeConfButton";
            this.writeConfButton.Size = new System.Drawing.Size(150, 30);
            this.writeConfButton.TabIndex = 12;
            this.writeConfButton.Text = "Scrivi conf.";
            this.writeConfButton.UseVisualStyleBackColor = true;
            this.writeConfButton.Click += new System.EventHandler(this.WriteConfButton_Click);
            // 
            // loadConfButton
            // 
            this.loadConfButton.Location = new System.Drawing.Point(16, 155);
            this.loadConfButton.Name = "loadConfButton";
            this.loadConfButton.Size = new System.Drawing.Size(150, 30);
            this.loadConfButton.TabIndex = 13;
            this.loadConfButton.Text = "Carica Conf";
            this.loadConfButton.UseVisualStyleBackColor = true;
            this.loadConfButton.Click += new System.EventHandler(this.LoadConfButton_Click);
            // 
            // SettingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 238);
            this.Controls.Add(this.loadConfButton);
            this.Controls.Add(this.writeConfButton);
            this.Controls.Add(this.loadSampleButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.createDbButton);
            this.Controls.Add(this.verifyDbButton);
            this.Controls.Add(this.connectionStringTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uIComboBox);
            this.Controls.Add(this.databaseComboBox);
            this.Controls.Add(this.databaseLabel);
            this.Controls.Add(this.dataAccessComboBox);
            this.Controls.Add(this.dataAccessLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingView";
            this.Text = "Impostazioni";
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
        private System.Windows.Forms.Button verifyDbButton;
        private System.Windows.Forms.Button createDbButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button loadSampleButton;
        private System.Windows.Forms.Button writeConfButton;
        private System.Windows.Forms.Button loadConfButton;
    }
}
