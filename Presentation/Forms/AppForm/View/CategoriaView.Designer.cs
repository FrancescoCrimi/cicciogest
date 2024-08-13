namespace CiccioGest.Presentation.AppForm.View
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
            this.categorieDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categorieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nomeLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CategoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.nuovoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.cancellaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.salvaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.categorieDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categorieBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriaBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // categorieDataGridView
            // 
            this.categorieDataGridView.AllowUserToAddRows = false;
            this.categorieDataGridView.AllowUserToDeleteRows = false;
            this.categorieDataGridView.AllowUserToResizeRows = false;
            this.categorieDataGridView.AutoGenerateColumns = false;
            this.categorieDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.categorieDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categorieDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn});
            this.categorieDataGridView.DataSource = this.categorieBindingSource;
            this.categorieDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categorieDataGridView.Location = new System.Drawing.Point(4, 79);
            this.categorieDataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.categorieDataGridView.MultiSelect = false;
            this.categorieDataGridView.Name = "categorieDataGridView";
            this.categorieDataGridView.ReadOnly = true;
            this.categorieDataGridView.RowHeadersVisible = false;
            this.categorieDataGridView.RowHeadersWidth = 51;
            this.categorieDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.categorieDataGridView.Size = new System.Drawing.Size(334, 307);
            this.categorieDataGridView.TabIndex = 1;
            this.categorieDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CategorieDataGridView_CellDoubleClick);
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
            // categorieBindingSource
            // 
            this.categorieBindingSource.DataSource = typeof(CiccioGest.Domain.Magazzino.Categoria);
            // 
            // nomeLabel
            // 
            this.nomeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nomeLabel.AutoSize = true;
            this.nomeLabel.Location = new System.Drawing.Point(4, 8);
            this.nomeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nomeLabel.Name = "nomeLabel";
            this.nomeLabel.Size = new System.Drawing.Size(53, 20);
            this.nomeLabel.TabIndex = 3;
            this.nomeLabel.Text = "Nome:";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CategoriaBindingSource, "Nome", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(65, 5);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 27);
            this.textBox1.TabIndex = 4;
            // 
            // CategoriaBindingSource
            // 
            this.CategoriaBindingSource.DataSource = typeof(CiccioGest.Domain.Magazzino.Categoria);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.categorieDataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(342, 391);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovoToolStripButton,
            this.cancellaToolStripButton,
            this.salvaToolStripButton,
            this.aboutToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(342, 27);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip1";
            // 
            // nuovoToolStripButton
            // 
            this.nuovoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nuovoToolStripButton.Image")));
            this.nuovoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuovoToolStripButton.Name = "nuovoToolStripButton";
            this.nuovoToolStripButton.Size = new System.Drawing.Size(77, 24);
            this.nuovoToolStripButton.Text = "Nuovo";
            this.nuovoToolStripButton.Click += new System.EventHandler(this.NuovoToolStripButton_Click);
            // 
            // cancellaToolStripButton
            // 
            this.cancellaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cancellaToolStripButton.Image")));
            this.cancellaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancellaToolStripButton.Name = "cancellaToolStripButton";
            this.cancellaToolStripButton.Size = new System.Drawing.Size(89, 24);
            this.cancellaToolStripButton.Text = "Cancella";
            this.cancellaToolStripButton.Click += new System.EventHandler(this.CancellaToolStripButton_Click);
            // 
            // salvaToolStripButton
            // 
            this.salvaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("salvaToolStripButton.Image")));
            this.salvaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salvaToolStripButton.Name = "salvaToolStripButton";
            this.salvaToolStripButton.Size = new System.Drawing.Size(68, 24);
            this.salvaToolStripButton.Text = "Salva";
            this.salvaToolStripButton.Click += new System.EventHandler(this.SalvaToolStripButton_Click);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.nomeLabel);
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 32);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(334, 37);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // CategoriaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 391);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CategoriaView";
            this.Text = "Categorie";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CategoriaView_FormClosing);
            this.Load += new System.EventHandler(this.CategoriaView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.categorieDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categorieBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriaBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label nomeLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView categorieDataGridView;
        private System.Windows.Forms.BindingSource categorieBindingSource;
        private System.Windows.Forms.BindingSource CategoriaBindingSource;
        private System.Windows.Forms.ToolStripButton nuovoToolStripButton;
        private System.Windows.Forms.ToolStripButton cancellaToolStripButton;
        private System.Windows.Forms.ToolStripButton salvaToolStripButton;
        private System.Windows.Forms.ToolStripButton aboutToolStripButton;
    }
}
