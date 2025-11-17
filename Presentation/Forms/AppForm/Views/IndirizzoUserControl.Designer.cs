
namespace CiccioGest.Presentation.AppForm.Views
{
    partial class IndirizzoUserControl
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.indirizzoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.capLabel = new System.Windows.Forms.Label();
            this.viaTextBox = new System.Windows.Forms.TextBox();
            this.viaLabel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.statoTextBox = new System.Windows.Forms.TextBox();
            this.statoLabel = new System.Windows.Forms.Label();
            this.cittaTextBox = new System.Windows.Forms.TextBox();
            this.cittaLabel = new System.Windows.Forms.Label();
            this.civicoTextBox = new System.Windows.Forms.TextBox();
            this.civicoLabel = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indirizzoBindingSource)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.tableLayoutPanel4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(747, 139);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Indirizzo";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(741, 113);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBox7);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.textBox6);
            this.panel4.Controls.Add(this.capLabel);
            this.panel4.Controls.Add(this.viaTextBox);
            this.panel4.Controls.Add(this.viaLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(364, 107);
            this.panel4.TabIndex = 0;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(120, 69);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(200, 27);
            this.textBox7.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "label7";
            // 
            // textBox6
            // 
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.indirizzoBindingSource, "CAP", true));
            this.textBox6.Location = new System.Drawing.Point(120, 36);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(200, 27);
            this.textBox6.TabIndex = 11;
            // 
            // indirizzoBindingSource
            // 
            this.indirizzoBindingSource.AllowNew = false;
            this.indirizzoBindingSource.DataSource = typeof(CiccioGest.Domain.Anagrafica.Indirizzo);
            // 
            // capLabel
            // 
            this.capLabel.AutoSize = true;
            this.capLabel.Location = new System.Drawing.Point(3, 39);
            this.capLabel.Name = "capLabel";
            this.capLabel.Size = new System.Drawing.Size(39, 20);
            this.capLabel.TabIndex = 10;
            this.capLabel.Text = "CAP:";
            // 
            // viaTextBox
            // 
            this.viaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.indirizzoBindingSource, "Via", true));
            this.viaTextBox.Location = new System.Drawing.Point(120, 3);
            this.viaTextBox.Name = "viaTextBox";
            this.viaTextBox.Size = new System.Drawing.Size(200, 27);
            this.viaTextBox.TabIndex = 9;
            // 
            // viaLabel
            // 
            this.viaLabel.AutoSize = true;
            this.viaLabel.Location = new System.Drawing.Point(3, 6);
            this.viaLabel.Name = "viaLabel";
            this.viaLabel.Size = new System.Drawing.Size(33, 20);
            this.viaLabel.TabIndex = 8;
            this.viaLabel.Text = "Via:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.statoTextBox);
            this.panel5.Controls.Add(this.statoLabel);
            this.panel5.Controls.Add(this.cittaTextBox);
            this.panel5.Controls.Add(this.cittaLabel);
            this.panel5.Controls.Add(this.civicoTextBox);
            this.panel5.Controls.Add(this.civicoLabel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(373, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(365, 107);
            this.panel5.TabIndex = 1;
            // 
            // statoTextBox
            // 
            this.statoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.indirizzoBindingSource, "Stato", true));
            this.statoTextBox.Location = new System.Drawing.Point(120, 69);
            this.statoTextBox.Name = "statoTextBox";
            this.statoTextBox.Size = new System.Drawing.Size(200, 27);
            this.statoTextBox.TabIndex = 13;
            // 
            // statoLabel
            // 
            this.statoLabel.AutoSize = true;
            this.statoLabel.Location = new System.Drawing.Point(3, 72);
            this.statoLabel.Name = "statoLabel";
            this.statoLabel.Size = new System.Drawing.Size(47, 20);
            this.statoLabel.TabIndex = 12;
            this.statoLabel.Text = "Stato:";
            // 
            // cittaTextBox
            // 
            this.cittaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.indirizzoBindingSource, "Citta", true));
            this.cittaTextBox.Location = new System.Drawing.Point(120, 36);
            this.cittaTextBox.Name = "cittaTextBox";
            this.cittaTextBox.Size = new System.Drawing.Size(200, 27);
            this.cittaTextBox.TabIndex = 11;
            // 
            // cittaLabel
            // 
            this.cittaLabel.AutoSize = true;
            this.cittaLabel.Location = new System.Drawing.Point(3, 39);
            this.cittaLabel.Name = "cittaLabel";
            this.cittaLabel.Size = new System.Drawing.Size(43, 20);
            this.cittaLabel.TabIndex = 10;
            this.cittaLabel.Text = "Città:";
            // 
            // civicoTextBox
            // 
            this.civicoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.indirizzoBindingSource, "Civico", true));
            this.civicoTextBox.Location = new System.Drawing.Point(120, 3);
            this.civicoTextBox.Name = "civicoTextBox";
            this.civicoTextBox.Size = new System.Drawing.Size(200, 27);
            this.civicoTextBox.TabIndex = 9;
            // 
            // civicoLabel
            // 
            this.civicoLabel.AutoSize = true;
            this.civicoLabel.Location = new System.Drawing.Point(3, 6);
            this.civicoLabel.Name = "civicoLabel";
            this.civicoLabel.Size = new System.Drawing.Size(52, 20);
            this.civicoLabel.TabIndex = 8;
            this.civicoLabel.Text = "Civico:";
            // 
            // IndirizzoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "IndirizzoUserControl";
            this.Size = new System.Drawing.Size(747, 139);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indirizzoBindingSource)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label capLabel;
        private System.Windows.Forms.TextBox viaTextBox;
        private System.Windows.Forms.Label viaLabel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox statoTextBox;
        private System.Windows.Forms.Label statoLabel;
        private System.Windows.Forms.TextBox cittaTextBox;
        private System.Windows.Forms.Label cittaLabel;
        private System.Windows.Forms.TextBox civicoTextBox;
        private System.Windows.Forms.Label civicoLabel;
        public System.Windows.Forms.BindingSource indirizzoBindingSource;
    }
}
