
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FornitoreView));
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            nuovoToolStripButton = new System.Windows.Forms.ToolStripButton();
            salvaToolStripButton = new System.Windows.Forms.ToolStripButton();
            apriToolStripButton = new System.Windows.Forms.ToolStripButton();
            aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            eliminaToolStripButton = new System.Windows.Forms.ToolStripButton();
            groupBox1 = new System.Windows.Forms.GroupBox();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            panel2 = new System.Windows.Forms.Panel();
            codiceFiscaleLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            codiceFiscaleTextBox = new System.Windows.Forms.TextBox();
            fornitoreBindingSource = new System.Windows.Forms.BindingSource(components);
            emailTextBox = new System.Windows.Forms.TextBox();
            cognomeTextBox = new System.Windows.Forms.TextBox();
            cognomeLabel = new System.Windows.Forms.Label();
            telefonoTextBox = new System.Windows.Forms.TextBox();
            telefonoLabel = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            societaLabel = new System.Windows.Forms.Label();
            societaTextBox = new System.Windows.Forms.TextBox();
            mobileLabel = new System.Windows.Forms.Label();
            mobileTextBox = new System.Windows.Forms.TextBox();
            nomeLabel = new System.Windows.Forms.Label();
            nomeTextBox = new System.Windows.Forms.TextBox();
            partitaIvaTextBox = new System.Windows.Forms.TextBox();
            partitaIvaLabel = new System.Windows.Forms.Label();
            indirizzoUserControl1 = new IndirizzoUserControl();
            tableLayoutPanel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fornitoreBindingSource).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(toolStrip1, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            tableLayoutPanel1.Size = new System.Drawing.Size(624, 281);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { nuovoToolStripButton, salvaToolStripButton, apriToolStripButton, aboutToolStripButton, eliminaToolStripButton });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(624, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // nuovoToolStripButton
            // 
            nuovoToolStripButton.Image = Properties.Resources.Nuovo;
            nuovoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            nuovoToolStripButton.Name = "nuovoToolStripButton";
            nuovoToolStripButton.Size = new System.Drawing.Size(67, 24);
            nuovoToolStripButton.Text = "&Nuovo";
            nuovoToolStripButton.Click += Nuovo_Click;
            // 
            // salvaToolStripButton
            // 
            salvaToolStripButton.Image = Properties.Resources.Salva;
            salvaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            salvaToolStripButton.Name = "salvaToolStripButton";
            salvaToolStripButton.Size = new System.Drawing.Size(58, 24);
            salvaToolStripButton.Text = "&Salva";
            salvaToolStripButton.Click += Salva_Click;
            // 
            // apriToolStripButton
            // 
            apriToolStripButton.Image = Properties.Resources.CaricaDefault;
            apriToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            apriToolStripButton.Name = "apriToolStripButton";
            apriToolStripButton.Size = new System.Drawing.Size(53, 24);
            apriToolStripButton.Text = "&Apri";
            apriToolStripButton.Click += Apri_Click;
            // 
            // aboutToolStripButton
            // 
            aboutToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            aboutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            aboutToolStripButton.Image = Properties.Resources.About;
            aboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            aboutToolStripButton.Name = "aboutToolStripButton";
            aboutToolStripButton.Size = new System.Drawing.Size(24, 24);
            aboutToolStripButton.Text = "&?";
            aboutToolStripButton.Click += AboutToolStripButton_Click;
            // 
            // eliminaToolStripButton
            // 
            eliminaToolStripButton.Image = (System.Drawing.Image)resources.GetObject("eliminaToolStripButton.Image");
            eliminaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            eliminaToolStripButton.Name = "eliminaToolStripButton";
            eliminaToolStripButton.Size = new System.Drawing.Size(70, 24);
            eliminaToolStripButton.Text = "Elimina";
            eliminaToolStripButton.Click += Elimina_Click;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(tableLayoutPanel2);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Location = new System.Drawing.Point(3, 29);
            groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox1.Size = new System.Drawing.Size(618, 250);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Fornitore";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Controls.Add(indirizzoUserControl1, 0, 1);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.Size = new System.Drawing.Size(612, 230);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(panel2, 0, 0);
            tableLayoutPanel3.Controls.Add(panel1, 0, 0);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel3.Location = new System.Drawing.Point(3, 2);
            tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new System.Drawing.Size(606, 119);
            tableLayoutPanel3.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(codiceFiscaleLabel);
            panel2.Controls.Add(emailLabel);
            panel2.Controls.Add(codiceFiscaleTextBox);
            panel2.Controls.Add(emailTextBox);
            panel2.Controls.Add(cognomeTextBox);
            panel2.Controls.Add(cognomeLabel);
            panel2.Controls.Add(telefonoTextBox);
            panel2.Controls.Add(telefonoLabel);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(306, 2);
            panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(297, 115);
            panel2.TabIndex = 7;
            // 
            // codiceFiscaleLabel
            // 
            codiceFiscaleLabel.AutoSize = true;
            codiceFiscaleLabel.Location = new System.Drawing.Point(4, 90);
            codiceFiscaleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            codiceFiscaleLabel.Name = "codiceFiscaleLabel";
            codiceFiscaleLabel.Size = new System.Drawing.Size(85, 15);
            codiceFiscaleLabel.TabIndex = 0;
            codiceFiscaleLabel.Text = "Codice Fiscale:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(4, 34);
            emailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(39, 15);
            emailLabel.TabIndex = 6;
            emailLabel.Text = "Email:";
            // 
            // codiceFiscaleTextBox
            // 
            codiceFiscaleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", fornitoreBindingSource, "CodiceFiscale", true));
            codiceFiscaleTextBox.Location = new System.Drawing.Point(105, 88);
            codiceFiscaleTextBox.Margin = new System.Windows.Forms.Padding(4);
            codiceFiscaleTextBox.Name = "codiceFiscaleTextBox";
            codiceFiscaleTextBox.Size = new System.Drawing.Size(176, 23);
            codiceFiscaleTextBox.TabIndex = 1;
            // 
            // fornitoreBindingSource
            // 
            fornitoreBindingSource.DataSource = typeof(Domain.ClientiFornitori.Fornitore);
            // 
            // emailTextBox
            // 
            emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", fornitoreBindingSource, "Email", true));
            emailTextBox.Location = new System.Drawing.Point(105, 32);
            emailTextBox.Margin = new System.Windows.Forms.Padding(4);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new System.Drawing.Size(176, 23);
            emailTextBox.TabIndex = 7;
            // 
            // cognomeTextBox
            // 
            cognomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", fornitoreBindingSource, "Cognome", true));
            cognomeTextBox.Location = new System.Drawing.Point(105, 4);
            cognomeTextBox.Margin = new System.Windows.Forms.Padding(4);
            cognomeTextBox.Name = "cognomeTextBox";
            cognomeTextBox.Size = new System.Drawing.Size(176, 23);
            cognomeTextBox.TabIndex = 3;
            // 
            // cognomeLabel
            // 
            cognomeLabel.AutoSize = true;
            cognomeLabel.Location = new System.Drawing.Point(4, 7);
            cognomeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            cognomeLabel.Name = "cognomeLabel";
            cognomeLabel.Size = new System.Drawing.Size(63, 15);
            cognomeLabel.TabIndex = 2;
            cognomeLabel.Text = "Cognome:";
            // 
            // telefonoTextBox
            // 
            telefonoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", fornitoreBindingSource, "Telefono", true));
            telefonoTextBox.Location = new System.Drawing.Point(105, 60);
            telefonoTextBox.Margin = new System.Windows.Forms.Padding(4);
            telefonoTextBox.Name = "telefonoTextBox";
            telefonoTextBox.Size = new System.Drawing.Size(176, 23);
            telefonoTextBox.TabIndex = 17;
            // 
            // telefonoLabel
            // 
            telefonoLabel.AutoSize = true;
            telefonoLabel.Location = new System.Drawing.Point(4, 62);
            telefonoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            telefonoLabel.Name = "telefonoLabel";
            telefonoLabel.Size = new System.Drawing.Size(56, 15);
            telefonoLabel.TabIndex = 16;
            telefonoLabel.Text = "Telefono:";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(societaLabel);
            panel1.Controls.Add(societaTextBox);
            panel1.Controls.Add(mobileLabel);
            panel1.Controls.Add(mobileTextBox);
            panel1.Controls.Add(nomeLabel);
            panel1.Controls.Add(nomeTextBox);
            panel1.Controls.Add(partitaIvaTextBox);
            panel1.Controls.Add(partitaIvaLabel);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 2);
            panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(297, 115);
            panel1.TabIndex = 6;
            // 
            // societaLabel
            // 
            societaLabel.AutoSize = true;
            societaLabel.Location = new System.Drawing.Point(4, 34);
            societaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            societaLabel.Name = "societaLabel";
            societaLabel.Size = new System.Drawing.Size(48, 15);
            societaLabel.TabIndex = 4;
            societaLabel.Text = "Societa:";
            // 
            // societaTextBox
            // 
            societaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", fornitoreBindingSource, "Email", true));
            societaTextBox.Location = new System.Drawing.Point(105, 32);
            societaTextBox.Margin = new System.Windows.Forms.Padding(4);
            societaTextBox.Name = "societaTextBox";
            societaTextBox.Size = new System.Drawing.Size(176, 23);
            societaTextBox.TabIndex = 5;
            // 
            // mobileLabel
            // 
            mobileLabel.AutoSize = true;
            mobileLabel.Location = new System.Drawing.Point(4, 62);
            mobileLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            mobileLabel.Name = "mobileLabel";
            mobileLabel.Size = new System.Drawing.Size(47, 15);
            mobileLabel.TabIndex = 8;
            mobileLabel.Text = "Mobile:";
            // 
            // mobileTextBox
            // 
            mobileTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", fornitoreBindingSource, "Indirizzo", true));
            mobileTextBox.Location = new System.Drawing.Point(105, 60);
            mobileTextBox.Margin = new System.Windows.Forms.Padding(4);
            mobileTextBox.Name = "mobileTextBox";
            mobileTextBox.Size = new System.Drawing.Size(176, 23);
            mobileTextBox.TabIndex = 9;
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(4, 7);
            nomeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(43, 15);
            nomeLabel.TabIndex = 10;
            nomeLabel.Text = "Nome:";
            // 
            // nomeTextBox
            // 
            nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", fornitoreBindingSource, "Nome", true));
            nomeTextBox.Location = new System.Drawing.Point(105, 4);
            nomeTextBox.Margin = new System.Windows.Forms.Padding(4);
            nomeTextBox.Name = "nomeTextBox";
            nomeTextBox.Size = new System.Drawing.Size(176, 23);
            nomeTextBox.TabIndex = 11;
            // 
            // partitaIvaTextBox
            // 
            partitaIvaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", fornitoreBindingSource, "PartitaIva", true));
            partitaIvaTextBox.Location = new System.Drawing.Point(105, 88);
            partitaIvaTextBox.Margin = new System.Windows.Forms.Padding(4);
            partitaIvaTextBox.Name = "partitaIvaTextBox";
            partitaIvaTextBox.Size = new System.Drawing.Size(176, 23);
            partitaIvaTextBox.TabIndex = 15;
            // 
            // partitaIvaLabel
            // 
            partitaIvaLabel.AutoSize = true;
            partitaIvaLabel.Location = new System.Drawing.Point(4, 90);
            partitaIvaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            partitaIvaLabel.Name = "partitaIvaLabel";
            partitaIvaLabel.Size = new System.Drawing.Size(62, 15);
            partitaIvaLabel.TabIndex = 14;
            partitaIvaLabel.Text = "Partita Iva:";
            // 
            // indirizzoUserControl1
            // 
            indirizzoUserControl1.Location = new System.Drawing.Point(3, 125);
            indirizzoUserControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            indirizzoUserControl1.Name = "indirizzoUserControl1";
            indirizzoUserControl1.Size = new System.Drawing.Size(606, 104);
            indirizzoUserControl1.TabIndex = 7;
            // 
            // FornitoreView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(624, 281);
            Controls.Add(tableLayoutPanel1);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "FornitoreView";
            Text = "Fornitore";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fornitoreBindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton nuovoToolStripButton;
        private System.Windows.Forms.ToolStripButton apriToolStripButton;
        private System.Windows.Forms.ToolStripButton salvaToolStripButton;
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
        private System.Windows.Forms.ToolStripButton eliminaToolStripButton;
        private IndirizzoUserControl indirizzoUserControl1;
    }
}