
namespace CiccioGest.Presentation.AppForm.View
{
    partial class SelezionaFornitoreView
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
            this.nomeCompletoLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fornitoriDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indirizzoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partitaIvaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codiceFiscaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fornitoriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.nomeCompletoTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fornitoriDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornitoriBindingSource)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nomeCompletoLabel
            // 
            this.nomeCompletoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nomeCompletoLabel.AutoSize = true;
            this.nomeCompletoLabel.Location = new System.Drawing.Point(3, 7);
            this.nomeCompletoLabel.Name = "nomeCompletoLabel";
            this.nomeCompletoLabel.Size = new System.Drawing.Size(49, 20);
            this.nomeCompletoLabel.TabIndex = 0;
            this.nomeCompletoLabel.Text = "Cerca:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.fornitoriDataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 562);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // fornitoriDataGridView
            // 
            this.fornitoriDataGridView.AllowUserToAddRows = false;
            this.fornitoriDataGridView.AllowUserToDeleteRows = false;
            this.fornitoriDataGridView.AutoGenerateColumns = false;
            this.fornitoriDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fornitoriDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.NomeCompleto,
            this.indirizzoDataGridViewTextBoxColumn,
            this.partitaIvaDataGridViewTextBoxColumn,
            this.codiceFiscaleDataGridViewTextBoxColumn});
            this.fornitoriDataGridView.DataSource = this.fornitoriBindingSource;
            this.fornitoriDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fornitoriDataGridView.Location = new System.Drawing.Point(3, 47);
            this.fornitoriDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fornitoriDataGridView.MultiSelect = false;
            this.fornitoriDataGridView.Name = "fornitoriDataGridView";
            this.fornitoriDataGridView.ReadOnly = true;
            this.fornitoriDataGridView.RowHeadersVisible = false;
            this.fornitoriDataGridView.RowHeadersWidth = 51;
            this.fornitoriDataGridView.RowTemplate.Height = 24;
            this.fornitoriDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fornitoriDataGridView.Size = new System.Drawing.Size(794, 511);
            this.fornitoriDataGridView.TabIndex = 0;
            this.fornitoriDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FornitoriDataGridView_CellDoubleClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 51;
            // 
            // NomeCompleto
            // 
            this.NomeCompleto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NomeCompleto.DataPropertyName = "NomeCompleto";
            this.NomeCompleto.HeaderText = "Nome";
            this.NomeCompleto.MinimumWidth = 6;
            this.NomeCompleto.Name = "NomeCompleto";
            this.NomeCompleto.ReadOnly = true;
            // 
            // indirizzoDataGridViewTextBoxColumn
            // 
            this.indirizzoDataGridViewTextBoxColumn.DataPropertyName = "Indirizzo";
            this.indirizzoDataGridViewTextBoxColumn.HeaderText = "Indirizzo";
            this.indirizzoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.indirizzoDataGridViewTextBoxColumn.Name = "indirizzoDataGridViewTextBoxColumn";
            this.indirizzoDataGridViewTextBoxColumn.ReadOnly = true;
            this.indirizzoDataGridViewTextBoxColumn.Width = 125;
            // 
            // partitaIvaDataGridViewTextBoxColumn
            // 
            this.partitaIvaDataGridViewTextBoxColumn.DataPropertyName = "PartitaIva";
            this.partitaIvaDataGridViewTextBoxColumn.HeaderText = "PartitaIva";
            this.partitaIvaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.partitaIvaDataGridViewTextBoxColumn.Name = "partitaIvaDataGridViewTextBoxColumn";
            this.partitaIvaDataGridViewTextBoxColumn.ReadOnly = true;
            this.partitaIvaDataGridViewTextBoxColumn.Width = 125;
            // 
            // codiceFiscaleDataGridViewTextBoxColumn
            // 
            this.codiceFiscaleDataGridViewTextBoxColumn.DataPropertyName = "CodiceFiscale";
            this.codiceFiscaleDataGridViewTextBoxColumn.HeaderText = "CodiceFiscale";
            this.codiceFiscaleDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.codiceFiscaleDataGridViewTextBoxColumn.Name = "codiceFiscaleDataGridViewTextBoxColumn";
            this.codiceFiscaleDataGridViewTextBoxColumn.ReadOnly = true;
            this.codiceFiscaleDataGridViewTextBoxColumn.Width = 125;
            // 
            // fornitoriBindingSource
            // 
            this.fornitoriBindingSource.AllowNew = false;
            this.fornitoriBindingSource.DataSource = typeof(CiccioGest.Domain.ClientiFornitori.Fornitore);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.nomeCompletoLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.nomeCompletoTextBox, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 35);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // nomeCompletoTextBox
            // 
            this.nomeCompletoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nomeCompletoTextBox.Location = new System.Drawing.Point(58, 4);
            this.nomeCompletoTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nomeCompletoTextBox.Name = "nomeCompletoTextBox";
            this.nomeCompletoTextBox.Size = new System.Drawing.Size(733, 27);
            this.nomeCompletoTextBox.TabIndex = 1;
            // 
            // SelezionaFornitoreView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SelezionaFornitoreView";
            this.Text = "Seleziona Fornitore";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelezionaFornitoreView_FormClosing);
            this.Load += new System.EventHandler(this.SelezionaFornitoreView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fornitoriDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornitoriBindingSource)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView fornitoriDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox nomeCompletoTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn societaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indirizzoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partitaIvaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codiceFiscaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource fornitoriBindingSource;

        #endregion

        private System.Windows.Forms.Label nomeCompletoLabel;
    }
}