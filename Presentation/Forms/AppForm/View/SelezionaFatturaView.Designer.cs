
namespace CiccioGest.Presentation.AppForm.View
{
    partial class SelezionaFatturaView
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
            nomeCompletoLabel = new System.Windows.Forms.Label();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            fattureDataGridView = new System.Windows.Forms.DataGridView();
            idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            totaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            fattureBindingSource = new System.Windows.Forms.BindingSource(components);
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            nomeCompletoTextBox = new System.Windows.Forms.TextBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fattureDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fattureBindingSource).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // nomeCompletoLabel
            // 
            nomeCompletoLabel.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nomeCompletoLabel.AutoSize = true;
            nomeCompletoLabel.Location = new System.Drawing.Point(3, 7);
            nomeCompletoLabel.Name = "nomeCompletoLabel";
            nomeCompletoLabel.Size = new System.Drawing.Size(49, 20);
            nomeCompletoLabel.TabIndex = 0;
            nomeCompletoLabel.Text = "Cerca:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(fattureDataGridView, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(622, 541);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // fattureDataGridView
            // 
            fattureDataGridView.AllowUserToAddRows = false;
            fattureDataGridView.AllowUserToDeleteRows = false;
            fattureDataGridView.AllowUserToResizeRows = false;
            fattureDataGridView.AutoGenerateColumns = false;
            fattureDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            fattureDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            fattureDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, totaleDataGridViewTextBoxColumn });
            fattureDataGridView.DataSource = fattureBindingSource;
            fattureDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            fattureDataGridView.Location = new System.Drawing.Point(3, 46);
            fattureDataGridView.MultiSelect = false;
            fattureDataGridView.Name = "fattureDataGridView";
            fattureDataGridView.ReadOnly = true;
            fattureDataGridView.RowHeadersVisible = false;
            fattureDataGridView.RowHeadersWidth = 51;
            fattureDataGridView.RowTemplate.Height = 24;
            fattureDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            fattureDataGridView.Size = new System.Drawing.Size(616, 492);
            fattureDataGridView.TabIndex = 0;
            fattureDataGridView.CellDoubleClick += FattureDataGridView_CellDoubleClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 51;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.MinimumWidth = 6;
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totaleDataGridViewTextBoxColumn
            // 
            totaleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            totaleDataGridViewTextBoxColumn.DataPropertyName = "Totale";
            totaleDataGridViewTextBoxColumn.HeaderText = "Totale";
            totaleDataGridViewTextBoxColumn.MinimumWidth = 6;
            totaleDataGridViewTextBoxColumn.Name = "totaleDataGridViewTextBoxColumn";
            totaleDataGridViewTextBoxColumn.ReadOnly = true;
            totaleDataGridViewTextBoxColumn.Width = 79;
            // 
            // fattureBindingSource
            // 
            fattureBindingSource.AllowNew = false;
            fattureBindingSource.DataSource = typeof(Domain.Documenti.FatturaReadOnly);
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
            tableLayoutPanel2.Location = new System.Drawing.Point(3, 4);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new System.Drawing.Size(616, 35);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // nomeCompletoTextBox
            // 
            nomeCompletoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            nomeCompletoTextBox.Location = new System.Drawing.Point(58, 4);
            nomeCompletoTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            nomeCompletoTextBox.Name = "nomeCompletoTextBox";
            nomeCompletoTextBox.Size = new System.Drawing.Size(555, 27);
            nomeCompletoTextBox.TabIndex = 1;
            // 
            // SelezionaFatturaView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(622, 541);
            Controls.Add(tableLayoutPanel1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "SelezionaFatturaView";
            Text = "Seleziona Fattura";
            FormClosing += SelezionaFatturaView_FormClosing;
            Load += SelezionaFatturaView_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fattureDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)fattureBindingSource).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView fattureDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox nomeCompletoTextBox;
        private System.Windows.Forms.BindingSource fattureBindingSource;

        #endregion

        private System.Windows.Forms.Label nomeCompletoLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totaleDataGridViewTextBoxColumn;
    }
}