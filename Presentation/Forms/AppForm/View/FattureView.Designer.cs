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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FattureView));
            this.fattureDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fattureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.nuovaFatturaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.apriFatturaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.aggiornaToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.fattureDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fattureBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fattureDataGridView
            // 
            this.fattureDataGridView.AllowUserToAddRows = false;
            this.fattureDataGridView.AllowUserToDeleteRows = false;
            this.fattureDataGridView.AllowUserToResizeRows = false;
            this.fattureDataGridView.AutoGenerateColumns = false;
            this.fattureDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fattureDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fattureDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn,
            this.totaleDataGridViewTextBoxColumn});
            this.fattureDataGridView.DataSource = this.fattureBindingSource;
            this.fattureDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fattureDataGridView.Location = new System.Drawing.Point(5, 32);
            this.fattureDataGridView.Margin = new System.Windows.Forms.Padding(5);
            this.fattureDataGridView.MultiSelect = false;
            this.fattureDataGridView.Name = "fattureDataGridView";
            this.fattureDataGridView.ReadOnly = true;
            this.fattureDataGridView.RowHeadersVisible = false;
            this.fattureDataGridView.RowHeadersWidth = 51;
            this.fattureDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fattureDataGridView.Size = new System.Drawing.Size(612, 504);
            this.fattureDataGridView.TabIndex = 6;
            this.fattureDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FattureDataGridViewCellDoubleClick);
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
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totaleDataGridViewTextBoxColumn
            // 
            this.totaleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.totaleDataGridViewTextBoxColumn.DataPropertyName = "Totale";
            this.totaleDataGridViewTextBoxColumn.HeaderText = "Totale";
            this.totaleDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totaleDataGridViewTextBoxColumn.Name = "totaleDataGridViewTextBoxColumn";
            this.totaleDataGridViewTextBoxColumn.ReadOnly = true;
            this.totaleDataGridViewTextBoxColumn.Width = 79;
            // 
            // fattureBindingSource
            // 
            this.fattureBindingSource.DataSource = typeof(CiccioGest.Domain.Documenti.FatturaReadOnly);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.fattureDataGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(622, 541);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovaFatturaToolStripButton,
            this.apriFatturaToolStripButton,
            this.aboutToolStripButton,
            this.aggiornaToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(622, 27);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // nuovaFatturaToolStripButton
            // 
            this.nuovaFatturaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nuovaFatturaToolStripButton.Image")));
            this.nuovaFatturaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuovaFatturaToolStripButton.Name = "nuovaFatturaToolStripButton";
            this.nuovaFatturaToolStripButton.Size = new System.Drawing.Size(76, 24);
            this.nuovaFatturaToolStripButton.Text = "Nuova";
            this.nuovaFatturaToolStripButton.Click += new System.EventHandler(this.NuovaFatturaToolStripButton_Click);
            // 
            // apriFatturaToolStripButton
            // 
            this.apriFatturaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("apriFatturaToolStripButton.Image")));
            this.apriFatturaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.apriFatturaToolStripButton.Name = "apriFatturaToolStripButton";
            this.apriFatturaToolStripButton.Size = new System.Drawing.Size(61, 24);
            this.apriFatturaToolStripButton.Text = "Apri";
            this.apriFatturaToolStripButton.Click += new System.EventHandler(this.ApriFatturaToolStripButton_Click);
            // 
            // aboutToolStripButton
            // 
            this.aboutToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.aboutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aboutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripButton.Image")));
            this.aboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutToolStripButton.Name = "aboutToolStripButton";
            this.aboutToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.aboutToolStripButton.Text = "&?";
            this.aboutToolStripButton.Click += new System.EventHandler(this.AboutToolStripButton_Click);
            // 
            // aggiornaToolStripButton
            // 
            this.aggiornaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("aggiornaToolStripButton.Image")));
            this.aggiornaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aggiornaToolStripButton.Name = "aggiornaToolStripButton";
            this.aggiornaToolStripButton.Size = new System.Drawing.Size(95, 24);
            this.aggiornaToolStripButton.Text = "Aggiorna";
            // 
            // FattureView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 541);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FattureView";
            this.Text = "Fatture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListaFattureView_FormClosing);
            this.Load += new System.EventHandler(this.ListaFattureView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fattureDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fattureBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

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
