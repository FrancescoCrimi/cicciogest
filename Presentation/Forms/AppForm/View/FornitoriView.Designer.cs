namespace CiccioGest.Presentation.AppForm.View
{
    partial class FornitoriView
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
            System.Windows.Forms.Label nomeCompletoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FornitoriView));
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            apriToolStripButton = new System.Windows.Forms.ToolStripButton();
            aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            fornitoriDataGridView = new System.Windows.Forms.DataGridView();
            nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cognomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            nomeCompletoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            telefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            indirizzoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            partitaIvaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            codiceFiscaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            fornitoriBindingSource = new System.Windows.Forms.BindingSource(components);
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            nomeCompletoTextBox = new System.Windows.Forms.TextBox();
            nomeCompletoLabel = new System.Windows.Forms.Label();
            tableLayoutPanel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fornitoriDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fornitoriBindingSource).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // nomeCompletoLabel
            // 
            nomeCompletoLabel.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nomeCompletoLabel.AutoSize = true;
            nomeCompletoLabel.Location = new System.Drawing.Point(3, 7);
            nomeCompletoLabel.Name = "nomeCompletoLabel";
            nomeCompletoLabel.Size = new System.Drawing.Size(40, 15);
            nomeCompletoLabel.TabIndex = 0;
            nomeCompletoLabel.Text = "Cerca:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(toolStrip1, 0, 0);
            tableLayoutPanel1.Controls.Add(fornitoriDataGridView, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(684, 415);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { apriToolStripButton, aboutToolStripButton });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(684, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // apriToolStripButton
            // 
            apriToolStripButton.Image = (System.Drawing.Image)resources.GetObject("apriToolStripButton.Image");
            apriToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            apriToolStripButton.Name = "apriToolStripButton";
            apriToolStripButton.Size = new System.Drawing.Size(53, 24);
            apriToolStripButton.Text = "&Apri";
            apriToolStripButton.Click += ApriToolStripButton_Click;
            // 
            // aboutToolStripButton
            // 
            aboutToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            aboutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            aboutToolStripButton.Image = (System.Drawing.Image)resources.GetObject("aboutToolStripButton.Image");
            aboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            aboutToolStripButton.Name = "aboutToolStripButton";
            aboutToolStripButton.Size = new System.Drawing.Size(24, 24);
            aboutToolStripButton.Text = "&?";
            aboutToolStripButton.Click += AboutToolStripButton_Click;
            // 
            // fornitoriDataGridView
            // 
            fornitoriDataGridView.AllowUserToAddRows = false;
            fornitoriDataGridView.AllowUserToDeleteRows = false;
            fornitoriDataGridView.AutoGenerateColumns = false;
            fornitoriDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            fornitoriDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { nomeDataGridViewTextBoxColumn, cognomeDataGridViewTextBoxColumn, nomeCompletoDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, telefonoDataGridViewTextBoxColumn, indirizzoDataGridViewTextBoxColumn, partitaIvaDataGridViewTextBoxColumn, codiceFiscaleDataGridViewTextBoxColumn, idDataGridViewTextBoxColumn });
            fornitoriDataGridView.DataSource = fornitoriBindingSource;
            fornitoriDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            fornitoriDataGridView.Location = new System.Drawing.Point(3, 65);
            fornitoriDataGridView.MultiSelect = false;
            fornitoriDataGridView.Name = "fornitoriDataGridView";
            fornitoriDataGridView.ReadOnly = true;
            fornitoriDataGridView.RowHeadersVisible = false;
            fornitoriDataGridView.RowHeadersWidth = 51;
            fornitoriDataGridView.RowTemplate.Height = 24;
            fornitoriDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            fornitoriDataGridView.Size = new System.Drawing.Size(678, 347);
            fornitoriDataGridView.TabIndex = 0;
            fornitoriDataGridView.CellDoubleClick += FornitoriDataGridView_CellDoubleClick;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.MinimumWidth = 6;
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            nomeDataGridViewTextBoxColumn.Width = 125;
            // 
            // cognomeDataGridViewTextBoxColumn
            // 
            cognomeDataGridViewTextBoxColumn.DataPropertyName = "Cognome";
            cognomeDataGridViewTextBoxColumn.HeaderText = "Cognome";
            cognomeDataGridViewTextBoxColumn.MinimumWidth = 6;
            cognomeDataGridViewTextBoxColumn.Name = "cognomeDataGridViewTextBoxColumn";
            cognomeDataGridViewTextBoxColumn.ReadOnly = true;
            cognomeDataGridViewTextBoxColumn.Width = 125;
            // 
            // nomeCompletoDataGridViewTextBoxColumn
            // 
            nomeCompletoDataGridViewTextBoxColumn.DataPropertyName = "NomeCompleto";
            nomeCompletoDataGridViewTextBoxColumn.HeaderText = "NomeCompleto";
            nomeCompletoDataGridViewTextBoxColumn.MinimumWidth = 6;
            nomeCompletoDataGridViewTextBoxColumn.Name = "nomeCompletoDataGridViewTextBoxColumn";
            nomeCompletoDataGridViewTextBoxColumn.ReadOnly = true;
            nomeCompletoDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.ReadOnly = true;
            emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            telefonoDataGridViewTextBoxColumn.DataPropertyName = "Telefono";
            telefonoDataGridViewTextBoxColumn.HeaderText = "Telefono";
            telefonoDataGridViewTextBoxColumn.MinimumWidth = 6;
            telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            telefonoDataGridViewTextBoxColumn.Width = 125;
            // 
            // indirizzoDataGridViewTextBoxColumn
            // 
            indirizzoDataGridViewTextBoxColumn.DataPropertyName = "Indirizzo";
            indirizzoDataGridViewTextBoxColumn.HeaderText = "Indirizzo";
            indirizzoDataGridViewTextBoxColumn.MinimumWidth = 6;
            indirizzoDataGridViewTextBoxColumn.Name = "indirizzoDataGridViewTextBoxColumn";
            indirizzoDataGridViewTextBoxColumn.ReadOnly = true;
            indirizzoDataGridViewTextBoxColumn.Width = 125;
            // 
            // partitaIvaDataGridViewTextBoxColumn
            // 
            partitaIvaDataGridViewTextBoxColumn.DataPropertyName = "PartitaIva";
            partitaIvaDataGridViewTextBoxColumn.HeaderText = "PartitaIva";
            partitaIvaDataGridViewTextBoxColumn.MinimumWidth = 6;
            partitaIvaDataGridViewTextBoxColumn.Name = "partitaIvaDataGridViewTextBoxColumn";
            partitaIvaDataGridViewTextBoxColumn.ReadOnly = true;
            partitaIvaDataGridViewTextBoxColumn.Width = 125;
            // 
            // codiceFiscaleDataGridViewTextBoxColumn
            // 
            codiceFiscaleDataGridViewTextBoxColumn.DataPropertyName = "CodiceFiscale";
            codiceFiscaleDataGridViewTextBoxColumn.HeaderText = "CodiceFiscale";
            codiceFiscaleDataGridViewTextBoxColumn.MinimumWidth = 6;
            codiceFiscaleDataGridViewTextBoxColumn.Name = "codiceFiscaleDataGridViewTextBoxColumn";
            codiceFiscaleDataGridViewTextBoxColumn.ReadOnly = true;
            codiceFiscaleDataGridViewTextBoxColumn.Width = 125;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 125;
            // 
            // fornitoriBindingSource
            // 
            fornitoriBindingSource.AllowNew = false;
            fornitoriBindingSource.DataSource = typeof(Domain.Anagrafica.Fornitore);
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(nomeCompletoLabel, 0, 0);
            tableLayoutPanel2.Controls.Add(nomeCompletoTextBox, 1, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(3, 30);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new System.Drawing.Size(678, 29);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // nomeCompletoTextBox
            // 
            nomeCompletoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            nomeCompletoTextBox.Location = new System.Drawing.Point(49, 3);
            nomeCompletoTextBox.Name = "nomeCompletoTextBox";
            nomeCompletoTextBox.Size = new System.Drawing.Size(626, 23);
            nomeCompletoTextBox.TabIndex = 1;
            // 
            // FornitoriView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(684, 415);
            Controls.Add(tableLayoutPanel1);
            Name = "FornitoriView";
            Text = "Fornitori";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fornitoriDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)fornitoriBindingSource).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton apriToolStripButton;
        private System.Windows.Forms.ToolStripButton aboutToolStripButton;
        private System.Windows.Forms.DataGridView fornitoriDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox nomeCompletoTextBox;
        private System.Windows.Forms.BindingSource fornitoriBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cognomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeCompletoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indirizzoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partitaIvaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codiceFiscaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
    }
}