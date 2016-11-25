namespace Ciccio1.Presentation.WinForm.Views
{
    partial class CategoriaView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoriaView));
            this.CategorieDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategorieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoProdottoLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CategoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.NuovoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.CancellaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SalvaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.AboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.CategorieDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategorieBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriaBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CategorieDataGridView
            // 
            this.CategorieDataGridView.AllowUserToAddRows = false;
            this.CategorieDataGridView.AllowUserToDeleteRows = false;
            this.CategorieDataGridView.AllowUserToResizeRows = false;
            this.CategorieDataGridView.AutoGenerateColumns = false;
            this.CategorieDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CategorieDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CategorieDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn});
            this.CategorieDataGridView.DataSource = this.CategorieBindingSource;
            this.CategorieDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategorieDataGridView.Location = new System.Drawing.Point(3, 60);
            this.CategorieDataGridView.MultiSelect = false;
            this.CategorieDataGridView.Name = "CategorieDataGridView";
            this.CategorieDataGridView.ReadOnly = true;
            this.CategorieDataGridView.RowHeadersVisible = false;
            this.CategorieDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CategorieDataGridView.Size = new System.Drawing.Size(238, 199);
            this.CategorieDataGridView.TabIndex = 1;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 41;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CategorieBindingSource
            // 
            this.CategorieBindingSource.DataSource = typeof(Ciccio1.Domain.Categoria);
            // 
            // tipoProdottoLabel
            // 
            this.tipoProdottoLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tipoProdottoLabel.AutoSize = true;
            this.tipoProdottoLabel.Location = new System.Drawing.Point(3, 6);
            this.tipoProdottoLabel.Name = "tipoProdottoLabel";
            this.tipoProdottoLabel.Size = new System.Drawing.Size(98, 13);
            this.tipoProdottoLabel.TabIndex = 3;
            this.tipoProdottoLabel.Text = "Categoria Prodotto:";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CategoriaBindingSource, "Nome", true));
            this.textBox1.Location = new System.Drawing.Point(107, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(122, 20);
            this.textBox1.TabIndex = 4;
            // 
            // CategoriaBindingSource
            // 
            this.CategoriaBindingSource.DataSource = typeof(Ciccio1.Domain.Categoria);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CategorieDataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(244, 262);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NuovoToolStripButton,
            this.CancellaToolStripButton,
            this.SalvaToolStripButton,
            this.AboutToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(244, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // NuovoToolStripButton
            // 
            this.NuovoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("NuovoToolStripButton.Image")));
            this.NuovoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NuovoToolStripButton.Name = "NuovoToolStripButton";
            this.NuovoToolStripButton.Size = new System.Drawing.Size(63, 22);
            this.NuovoToolStripButton.Text = "&Nuovo";
            // 
            // CancellaToolStripButton
            // 
            this.CancellaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("CancellaToolStripButton.Image")));
            this.CancellaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancellaToolStripButton.Name = "CancellaToolStripButton";
            this.CancellaToolStripButton.Size = new System.Drawing.Size(72, 22);
            this.CancellaToolStripButton.Text = "&Cancella";
            // 
            // SalvaToolStripButton
            // 
            this.SalvaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SalvaToolStripButton.Image")));
            this.SalvaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SalvaToolStripButton.Name = "SalvaToolStripButton";
            this.SalvaToolStripButton.Size = new System.Drawing.Size(54, 22);
            this.SalvaToolStripButton.Text = "&Salva";
            // 
            // AboutToolStripButton
            // 
            this.AboutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AboutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AboutToolStripButton.Image")));
            this.AboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutToolStripButton.Name = "AboutToolStripButton";
            this.AboutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.AboutToolStripButton.Text = "&?";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.tipoProdottoLabel);
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 28);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(238, 26);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // CategoriaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 262);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CategoriaView";
            this.Text = "Categoria Prodotto";
            ((System.ComponentModel.ISupportInitialize)(this.CategorieDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategorieBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriaBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label tipoProdottoLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.DataGridView CategorieDataGridView;
        internal System.Windows.Forms.BindingSource CategorieBindingSource;
        internal System.Windows.Forms.BindingSource CategoriaBindingSource;
        internal System.Windows.Forms.ToolStripButton NuovoToolStripButton;
        internal System.Windows.Forms.ToolStripButton CancellaToolStripButton;
        internal System.Windows.Forms.ToolStripButton SalvaToolStripButton;
        internal System.Windows.Forms.ToolStripButton AboutToolStripButton;
    }
}