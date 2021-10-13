
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FornitoreView));
            System.Windows.Forms.Label codiceFiscaleLabel;
            System.Windows.Forms.Label cognomeLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label indirizzoLabel;
            System.Windows.Forms.Label nomeLabel;
            System.Windows.Forms.Label nomeCompletoLabel;
            System.Windows.Forms.Label partitaIvaLabel;
            System.Windows.Forms.Label telefonoLabel;
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nuovoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.apriToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.salvaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stampaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fornitoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codiceFiscaleTextBox = new System.Windows.Forms.TextBox();
            this.cognomeTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.indirizzoTextBox = new System.Windows.Forms.TextBox();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.nomeCompletoTextBox = new System.Windows.Forms.TextBox();
            this.partitaIvaTextBox = new System.Windows.Forms.TextBox();
            this.telefonoTextBox = new System.Windows.Forms.TextBox();
            codiceFiscaleLabel = new System.Windows.Forms.Label();
            cognomeLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            indirizzoLabel = new System.Windows.Forms.Label();
            nomeLabel = new System.Windows.Forms.Label();
            nomeCompletoLabel = new System.Windows.Forms.Label();
            partitaIvaLabel = new System.Windows.Forms.Label();
            telefonoLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fornitoreBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(702, 453);
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
            this.toolStripSeparator,
            this.ToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(702, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(codiceFiscaleLabel);
            this.panel1.Controls.Add(this.codiceFiscaleTextBox);
            this.panel1.Controls.Add(cognomeLabel);
            this.panel1.Controls.Add(this.cognomeTextBox);
            this.panel1.Controls.Add(emailLabel);
            this.panel1.Controls.Add(this.emailTextBox);
            this.panel1.Controls.Add(indirizzoLabel);
            this.panel1.Controls.Add(this.indirizzoTextBox);
            this.panel1.Controls.Add(nomeLabel);
            this.panel1.Controls.Add(this.nomeTextBox);
            this.panel1.Controls.Add(nomeCompletoLabel);
            this.panel1.Controls.Add(this.nomeCompletoTextBox);
            this.panel1.Controls.Add(partitaIvaLabel);
            this.panel1.Controls.Add(this.partitaIvaTextBox);
            this.panel1.Controls.Add(telefonoLabel);
            this.panel1.Controls.Add(this.telefonoTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 32);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 416);
            this.panel1.TabIndex = 1;
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
            // fornitoreBindingSource
            // 
            this.fornitoreBindingSource.DataSource = typeof(CiccioGest.Domain.ClientiFornitori.Fornitore);
            // 
            // codiceFiscaleLabel
            // 
            codiceFiscaleLabel.AutoSize = true;
            codiceFiscaleLabel.Location = new System.Drawing.Point(19, 250);
            codiceFiscaleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            codiceFiscaleLabel.Name = "codiceFiscaleLabel";
            codiceFiscaleLabel.Size = new System.Drawing.Size(106, 20);
            codiceFiscaleLabel.TabIndex = 0;
            codiceFiscaleLabel.Text = "Codice Fiscale:";
            // 
            // codiceFiscaleTextBox
            // 
            this.codiceFiscaleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fornitoreBindingSource, "CodiceFiscale", true));
            this.codiceFiscaleTextBox.Location = new System.Drawing.Point(160, 246);
            this.codiceFiscaleTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.codiceFiscaleTextBox.Name = "codiceFiscaleTextBox";
            this.codiceFiscaleTextBox.Size = new System.Drawing.Size(300, 27);
            this.codiceFiscaleTextBox.TabIndex = 1;
            // 
            // cognomeLabel
            // 
            cognomeLabel.AutoSize = true;
            cognomeLabel.Location = new System.Drawing.Point(19, 65);
            cognomeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            cognomeLabel.Name = "cognomeLabel";
            cognomeLabel.Size = new System.Drawing.Size(77, 20);
            cognomeLabel.TabIndex = 2;
            cognomeLabel.Text = "Cognome:";
            // 
            // cognomeTextBox
            // 
            this.cognomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fornitoreBindingSource, "Cognome", true));
            this.cognomeTextBox.Location = new System.Drawing.Point(160, 61);
            this.cognomeTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cognomeTextBox.Name = "cognomeTextBox";
            this.cognomeTextBox.Size = new System.Drawing.Size(300, 27);
            this.cognomeTextBox.TabIndex = 3;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(19, 139);
            emailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(49, 20);
            emailLabel.TabIndex = 4;
            emailLabel.Text = "Email:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fornitoreBindingSource, "Email", true));
            this.emailTextBox.Location = new System.Drawing.Point(160, 135);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(300, 27);
            this.emailTextBox.TabIndex = 5;
            // 
            // indirizzoLabel
            // 
            indirizzoLabel.AutoSize = true;
            indirizzoLabel.Location = new System.Drawing.Point(19, 213);
            indirizzoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            indirizzoLabel.Name = "indirizzoLabel";
            indirizzoLabel.Size = new System.Drawing.Size(69, 20);
            indirizzoLabel.TabIndex = 8;
            indirizzoLabel.Text = "Indirizzo:";
            // 
            // indirizzoTextBox
            // 
            this.indirizzoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fornitoreBindingSource, "Indirizzo", true));
            this.indirizzoTextBox.Location = new System.Drawing.Point(160, 209);
            this.indirizzoTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.indirizzoTextBox.Name = "indirizzoTextBox";
            this.indirizzoTextBox.Size = new System.Drawing.Size(300, 27);
            this.indirizzoTextBox.TabIndex = 9;
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(19, 28);
            nomeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(53, 20);
            nomeLabel.TabIndex = 10;
            nomeLabel.Text = "Nome:";
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fornitoreBindingSource, "Nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(160, 24);
            this.nomeTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(300, 27);
            this.nomeTextBox.TabIndex = 11;
            // 
            // nomeCompletoLabel
            // 
            nomeCompletoLabel.AutoSize = true;
            nomeCompletoLabel.Location = new System.Drawing.Point(19, 102);
            nomeCompletoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            nomeCompletoLabel.Name = "nomeCompletoLabel";
            nomeCompletoLabel.Size = new System.Drawing.Size(123, 20);
            nomeCompletoLabel.TabIndex = 12;
            nomeCompletoLabel.Text = "Nome Completo:";
            // 
            // nomeCompletoTextBox
            // 
            this.nomeCompletoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fornitoreBindingSource, "NomeCompleto", true));
            this.nomeCompletoTextBox.Location = new System.Drawing.Point(160, 98);
            this.nomeCompletoTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nomeCompletoTextBox.Name = "nomeCompletoTextBox";
            this.nomeCompletoTextBox.Size = new System.Drawing.Size(300, 27);
            this.nomeCompletoTextBox.TabIndex = 13;
            // 
            // partitaIvaLabel
            // 
            partitaIvaLabel.AutoSize = true;
            partitaIvaLabel.Location = new System.Drawing.Point(19, 287);
            partitaIvaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            partitaIvaLabel.Name = "partitaIvaLabel";
            partitaIvaLabel.Size = new System.Drawing.Size(77, 20);
            partitaIvaLabel.TabIndex = 14;
            partitaIvaLabel.Text = "Partita Iva:";
            // 
            // partitaIvaTextBox
            // 
            this.partitaIvaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fornitoreBindingSource, "PartitaIva", true));
            this.partitaIvaTextBox.Location = new System.Drawing.Point(160, 283);
            this.partitaIvaTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.partitaIvaTextBox.Name = "partitaIvaTextBox";
            this.partitaIvaTextBox.Size = new System.Drawing.Size(300, 27);
            this.partitaIvaTextBox.TabIndex = 15;
            // 
            // telefonoLabel
            // 
            telefonoLabel.AutoSize = true;
            telefonoLabel.Location = new System.Drawing.Point(19, 176);
            telefonoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            telefonoLabel.Name = "telefonoLabel";
            telefonoLabel.Size = new System.Drawing.Size(70, 20);
            telefonoLabel.TabIndex = 16;
            telefonoLabel.Text = "Telefono:";
            // 
            // telefonoTextBox
            // 
            this.telefonoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fornitoreBindingSource, "Telefono", true));
            this.telefonoTextBox.Location = new System.Drawing.Point(160, 172);
            this.telefonoTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.telefonoTextBox.Name = "telefonoTextBox";
            this.telefonoTextBox.Size = new System.Drawing.Size(300, 27);
            this.telefonoTextBox.TabIndex = 17;
            // 
            // FornitoreView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 453);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FornitoreView";
            this.Text = "FornitoreView";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fornitoreBindingSource)).EndInit();
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
        private System.Windows.Forms.ToolStripButton ToolStripButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox codiceFiscaleTextBox;
        private System.Windows.Forms.BindingSource fornitoreBindingSource;
        private System.Windows.Forms.TextBox cognomeTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox indirizzoTextBox;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.TextBox nomeCompletoTextBox;
        private System.Windows.Forms.TextBox partitaIvaTextBox;
        private System.Windows.Forms.TextBox telefonoTextBox;
    }
}