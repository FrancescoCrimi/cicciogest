
namespace CiccioGest.Presentation.AppForm.View
{
    partial class FornitoreView
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.nuovoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.apriToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.salvaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stampaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.fornitoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cognomeTextBox = new System.Windows.Forms.TextBox();
            this.cognomeLabel = new System.Windows.Forms.Label();
            this.telefonoTextBox = new System.Windows.Forms.TextBox();
            this.telefonoLabel = new System.Windows.Forms.Label();
            this.partitaIvaTextBox = new System.Windows.Forms.TextBox();
            this.partitaIvaLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.codiceFiscaleLabel = new System.Windows.Forms.Label();
            this.codiceFiscaleTextBox = new System.Windows.Forms.TextBox();
            this.societaLabel = new System.Windows.Forms.Label();
            this.societaTextBox = new System.Windows.Forms.TextBox();
            this.mobileLabel = new System.Windows.Forms.Label();
            this.mobileTextBox = new System.Windows.Forms.TextBox();
            this.nomeLabel = new System.Windows.Forms.Label();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.indirizzoUserControl1 = new CiccioGest.Presentation.AppForm.View.IndirizzoUserControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fornitoreBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(782, 358);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovoToolStripButton,
            this.apriToolStripButton,
            this.salvaToolStripButton,
            this.stampaToolStripButton,
            this.aboutToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(782, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // nuovoToolStripButton
            // 
            this.nuovoToolStripButton.Image = global::CiccioGest.Presentation.AppForm.Properties.Resources.Nuovo;
            this.nuovoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuovoToolStripButton.Name = "nuovoToolStripButton";
            this.nuovoToolStripButton.Size = new System.Drawing.Size(77, 24);
            this.nuovoToolStripButton.Text = "&Nuovo";
            this.nuovoToolStripButton.Click += new System.EventHandler(this.NuovoToolStripButton_Click);
            // 
            // apriToolStripButton
            // 
            this.apriToolStripButton.Image = global::CiccioGest.Presentation.AppForm.Properties.Resources.CaricaDefault;
            this.apriToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.apriToolStripButton.Name = "apriToolStripButton";
            this.apriToolStripButton.Size = new System.Drawing.Size(61, 24);
            this.apriToolStripButton.Text = "&Apri";
            this.apriToolStripButton.Click += new System.EventHandler(this.ApriToolStripButton_Click);
            // 
            // salvaToolStripButton
            // 
            this.salvaToolStripButton.Image = global::CiccioGest.Presentation.AppForm.Properties.Resources.Salva;
            this.salvaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salvaToolStripButton.Name = "salvaToolStripButton";
            this.salvaToolStripButton.Size = new System.Drawing.Size(68, 24);
            this.salvaToolStripButton.Text = "&Salva";
            this.salvaToolStripButton.Click += new System.EventHandler(this.SalvaToolStripButton_Click);
            // 
            // stampaToolStripButton
            // 
            this.stampaToolStripButton.Image = global::CiccioGest.Presentation.AppForm.Properties.Resources.stampa;
            this.stampaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stampaToolStripButton.Name = "stampaToolStripButton";
            this.stampaToolStripButton.Size = new System.Drawing.Size(84, 24);
            this.stampaToolStripButton.Text = "&Stampa";
            this.stampaToolStripButton.Click += new System.EventHandler(this.StampaToolStripButton_Click);
            // 
            // aboutToolStripButton
            // 
            this.aboutToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.aboutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aboutToolStripButton.Image = global::CiccioGest.Presentation.AppForm.Properties.Resources.About;
            this.aboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutToolStripButton.Name = "aboutToolStripButton";
            this.aboutToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.aboutToolStripButton.Text = "&?";
            this.aboutToolStripButton.Click += new System.EventHandler(this.AboutToolStripButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 325);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fornitore";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.indirizzoUserControl1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(770, 299);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(764, 155);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.codiceFiscaleLabel);
            this.panel2.Controls.Add(this.emailLabel);
            this.panel2.Controls.Add(this.codiceFiscaleTextBox);
            this.panel2.Controls.Add(this.emailTextBox);
            this.panel2.Controls.Add(this.cognomeTextBox);
            this.panel2.Controls.Add(this.cognomeLabel);
            this.panel2.Controls.Add(this.telefonoTextBox);
            this.panel2.Controls.Add(this.telefonoLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(385, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 149);
            this.panel2.TabIndex = 7;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(4, 46);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(49, 20);
            this.emailLabel.TabIndex = 6;
            this.emailLabel.Text = "Email:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fornitoreBindingSource, "Email", true));
            this.emailTextBox.Location = new System.Drawing.Point(120, 43);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(200, 27);
            this.emailTextBox.TabIndex = 7;
            // 
            // fornitoreBindingSource
            // 
            this.fornitoreBindingSource.DataSource = typeof(CiccioGest.Domain.ClientiFornitori.Fornitore);
            // 
            // cognomeTextBox
            // 
            this.cognomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fornitoreBindingSource, "Cognome", true));
            this.cognomeTextBox.Location = new System.Drawing.Point(120, 6);
            this.cognomeTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cognomeTextBox.Name = "cognomeTextBox";
            this.cognomeTextBox.Size = new System.Drawing.Size(200, 27);
            this.cognomeTextBox.TabIndex = 3;
            // 
            // cognomeLabel
            // 
            this.cognomeLabel.AutoSize = true;
            this.cognomeLabel.Location = new System.Drawing.Point(4, 9);
            this.cognomeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cognomeLabel.Name = "cognomeLabel";
            this.cognomeLabel.Size = new System.Drawing.Size(77, 20);
            this.cognomeLabel.TabIndex = 2;
            this.cognomeLabel.Text = "Cognome:";
            // 
            // telefonoTextBox
            // 
            this.telefonoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fornitoreBindingSource, "Telefono", true));
            this.telefonoTextBox.Location = new System.Drawing.Point(120, 80);
            this.telefonoTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.telefonoTextBox.Name = "telefonoTextBox";
            this.telefonoTextBox.Size = new System.Drawing.Size(200, 27);
            this.telefonoTextBox.TabIndex = 17;
            // 
            // telefonoLabel
            // 
            this.telefonoLabel.AutoSize = true;
            this.telefonoLabel.Location = new System.Drawing.Point(4, 83);
            this.telefonoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.telefonoLabel.Name = "telefonoLabel";
            this.telefonoLabel.Size = new System.Drawing.Size(70, 20);
            this.telefonoLabel.TabIndex = 16;
            this.telefonoLabel.Text = "Telefono:";
            // 
            // partitaIvaTextBox
            // 
            this.partitaIvaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fornitoreBindingSource, "PartitaIva", true));
            this.partitaIvaTextBox.Location = new System.Drawing.Point(120, 117);
            this.partitaIvaTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.partitaIvaTextBox.Name = "partitaIvaTextBox";
            this.partitaIvaTextBox.Size = new System.Drawing.Size(200, 27);
            this.partitaIvaTextBox.TabIndex = 15;
            // 
            // partitaIvaLabel
            // 
            this.partitaIvaLabel.AutoSize = true;
            this.partitaIvaLabel.Location = new System.Drawing.Point(4, 120);
            this.partitaIvaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.partitaIvaLabel.Name = "partitaIvaLabel";
            this.partitaIvaLabel.Size = new System.Drawing.Size(77, 20);
            this.partitaIvaLabel.TabIndex = 14;
            this.partitaIvaLabel.Text = "Partita Iva:";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.societaLabel);
            this.panel1.Controls.Add(this.societaTextBox);
            this.panel1.Controls.Add(this.mobileLabel);
            this.panel1.Controls.Add(this.mobileTextBox);
            this.panel1.Controls.Add(this.nomeLabel);
            this.panel1.Controls.Add(this.nomeTextBox);
            this.panel1.Controls.Add(this.partitaIvaTextBox);
            this.panel1.Controls.Add(this.partitaIvaLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 149);
            this.panel1.TabIndex = 6;
            // 
            // codiceFiscaleLabel
            // 
            this.codiceFiscaleLabel.AutoSize = true;
            this.codiceFiscaleLabel.Location = new System.Drawing.Point(4, 120);
            this.codiceFiscaleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.codiceFiscaleLabel.Name = "codiceFiscaleLabel";
            this.codiceFiscaleLabel.Size = new System.Drawing.Size(106, 20);
            this.codiceFiscaleLabel.TabIndex = 0;
            this.codiceFiscaleLabel.Text = "Codice Fiscale:";
            // 
            // codiceFiscaleTextBox
            // 
            this.codiceFiscaleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fornitoreBindingSource, "CodiceFiscale", true));
            this.codiceFiscaleTextBox.Location = new System.Drawing.Point(120, 117);
            this.codiceFiscaleTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.codiceFiscaleTextBox.Name = "codiceFiscaleTextBox";
            this.codiceFiscaleTextBox.Size = new System.Drawing.Size(200, 27);
            this.codiceFiscaleTextBox.TabIndex = 1;
            // 
            // societaLabel
            // 
            this.societaLabel.AutoSize = true;
            this.societaLabel.Location = new System.Drawing.Point(4, 46);
            this.societaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.societaLabel.Name = "societaLabel";
            this.societaLabel.Size = new System.Drawing.Size(61, 20);
            this.societaLabel.TabIndex = 4;
            this.societaLabel.Text = "Societa:";
            // 
            // societaTextBox
            // 
            this.societaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fornitoreBindingSource, "Email", true));
            this.societaTextBox.Location = new System.Drawing.Point(120, 43);
            this.societaTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.societaTextBox.Name = "societaTextBox";
            this.societaTextBox.Size = new System.Drawing.Size(200, 27);
            this.societaTextBox.TabIndex = 5;
            // 
            // mobileLabel
            // 
            this.mobileLabel.AutoSize = true;
            this.mobileLabel.Location = new System.Drawing.Point(4, 83);
            this.mobileLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mobileLabel.Name = "mobileLabel";
            this.mobileLabel.Size = new System.Drawing.Size(59, 20);
            this.mobileLabel.TabIndex = 8;
            this.mobileLabel.Text = "Mobile:";
            // 
            // mobileTextBox
            // 
            this.mobileTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fornitoreBindingSource, "Indirizzo", true));
            this.mobileTextBox.Location = new System.Drawing.Point(120, 80);
            this.mobileTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mobileTextBox.Name = "mobileTextBox";
            this.mobileTextBox.Size = new System.Drawing.Size(200, 27);
            this.mobileTextBox.TabIndex = 9;
            // 
            // nomeLabel
            // 
            this.nomeLabel.AutoSize = true;
            this.nomeLabel.Location = new System.Drawing.Point(4, 9);
            this.nomeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nomeLabel.Name = "nomeLabel";
            this.nomeLabel.Size = new System.Drawing.Size(53, 20);
            this.nomeLabel.TabIndex = 10;
            this.nomeLabel.Text = "Nome:";
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fornitoreBindingSource, "Nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(120, 6);
            this.nomeTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(200, 27);
            this.nomeTextBox.TabIndex = 11;
            // 
            // indirizzoUserControl1
            // 
            this.indirizzoUserControl1.AutoSize = true;
            this.indirizzoUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.indirizzoUserControl1.Location = new System.Drawing.Point(3, 164);
            this.indirizzoUserControl1.Name = "indirizzoUserControl1";
            this.indirizzoUserControl1.Size = new System.Drawing.Size(764, 132);
            this.indirizzoUserControl1.TabIndex = 7;
            // 
            // FornitoreView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 358);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FornitoreView";
            this.Text = "Fornitore";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FornitoreView_FormClosing);
            this.Load += new System.EventHandler(this.FornitoreView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fornitoreBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton nuovoToolStripButton;
        private System.Windows.Forms.ToolStripButton apriToolStripButton;
        private System.Windows.Forms.ToolStripButton salvaToolStripButton;
        private System.Windows.Forms.ToolStripButton stampaToolStripButton;
        private System.Windows.Forms.ToolStripButton aboutToolStripButton;
        private System.Windows.Forms.BindingSource fornitoreBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox cognomeTextBox;
        private System.Windows.Forms.Label cognomeLabel;
        private System.Windows.Forms.TextBox telefonoTextBox;
        private System.Windows.Forms.Label telefonoLabel;
        private System.Windows.Forms.TextBox partitaIvaTextBox;
        private System.Windows.Forms.Label partitaIvaLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label codiceFiscaleLabel;
        private System.Windows.Forms.TextBox codiceFiscaleTextBox;
        private System.Windows.Forms.Label societaLabel;
        private System.Windows.Forms.TextBox societaTextBox;
        private System.Windows.Forms.Label mobileLabel;
        private System.Windows.Forms.TextBox mobileTextBox;
        private System.Windows.Forms.Label nomeLabel;
        private System.Windows.Forms.TextBox nomeTextBox;
        private IndirizzoUserControl indirizzoUserControl1;
    }
}