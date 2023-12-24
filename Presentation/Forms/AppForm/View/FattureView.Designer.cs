namespace CiccioGest.Presentation.AppForm.View
{
    partial class FattureView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FattureView));
            fattureDataGridView = new System.Windows.Forms.DataGridView();
            idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            totaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            fattureBindingSource = new System.Windows.Forms.BindingSource(components);
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            nuovaFatturaToolStripButton = new System.Windows.Forms.ToolStripButton();
            apriFatturaToolStripButton = new System.Windows.Forms.ToolStripButton();
            aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            aggiornaToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)fattureDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fattureBindingSource).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
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
            fattureDataGridView.Location = new System.Drawing.Point(3, 30);
            fattureDataGridView.MultiSelect = false;
            fattureDataGridView.Name = "fattureDataGridView";
            fattureDataGridView.ReadOnly = true;
            fattureDataGridView.RowHeadersVisible = false;
            fattureDataGridView.RowHeadersWidth = 51;
            fattureDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            fattureDataGridView.Size = new System.Drawing.Size(616, 508);
            fattureDataGridView.TabIndex = 6;
            fattureDataGridView.CellDoubleClick += FattureDataGridViewCellDoubleClick;
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
            fattureBindingSource.DataSource = typeof(Domain.Documenti.FatturaReadOnly);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(fattureDataGridView, 0, 1);
            tableLayoutPanel1.Controls.Add(toolStrip1, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(622, 541);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { nuovaFatturaToolStripButton, apriFatturaToolStripButton, aboutToolStripButton, aggiornaToolStripButton });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(622, 27);
            toolStrip1.TabIndex = 7;
            toolStrip1.Text = "toolStrip1";
            // 
            // nuovaFatturaToolStripButton
            // 
            nuovaFatturaToolStripButton.Image = (System.Drawing.Image)resources.GetObject("nuovaFatturaToolStripButton.Image");
            nuovaFatturaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            nuovaFatturaToolStripButton.Name = "nuovaFatturaToolStripButton";
            nuovaFatturaToolStripButton.Size = new System.Drawing.Size(76, 24);
            nuovaFatturaToolStripButton.Text = "Nuova";
            nuovaFatturaToolStripButton.Click += NuovaFatturaToolStripButton_Click;
            // 
            // apriFatturaToolStripButton
            // 
            apriFatturaToolStripButton.Image = (System.Drawing.Image)resources.GetObject("apriFatturaToolStripButton.Image");
            apriFatturaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            apriFatturaToolStripButton.Name = "apriFatturaToolStripButton";
            apriFatturaToolStripButton.Size = new System.Drawing.Size(61, 24);
            apriFatturaToolStripButton.Text = "Apri";
            apriFatturaToolStripButton.Click += ApriFatturaToolStripButton_Click;
            // 
            // aboutToolStripButton
            // 
            aboutToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            aboutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            aboutToolStripButton.Image = (System.Drawing.Image)resources.GetObject("aboutToolStripButton.Image");
            aboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            aboutToolStripButton.Name = "aboutToolStripButton";
            aboutToolStripButton.Size = new System.Drawing.Size(29, 24);
            aboutToolStripButton.Text = "&?";
            aboutToolStripButton.Click += AboutToolStripButton_Click;
            // 
            // aggiornaToolStripButton
            // 
            aggiornaToolStripButton.Image = (System.Drawing.Image)resources.GetObject("aggiornaToolStripButton.Image");
            aggiornaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            aggiornaToolStripButton.Name = "aggiornaToolStripButton";
            aggiornaToolStripButton.Size = new System.Drawing.Size(95, 24);
            aggiornaToolStripButton.Text = "Aggiorna";
            // 
            // FattureView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(622, 541);
            Controls.Add(tableLayoutPanel1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "FattureView";
            Text = "Fatture";
            FormClosing += ListaFattureView_FormClosing;
            Load += ListaFattureView_Load;
            ((System.ComponentModel.ISupportInitialize)fattureDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)fattureBindingSource).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView fattureDataGridView;
        private System.Windows.Forms.BindingSource fattureBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton nuovaFatturaToolStripButton;
        private System.Windows.Forms.ToolStripButton apriFatturaToolStripButton;
        private System.Windows.Forms.ToolStripButton aboutToolStripButton;
        private System.Windows.Forms.ToolStripButton aggiornaToolStripButton;
    }
}
