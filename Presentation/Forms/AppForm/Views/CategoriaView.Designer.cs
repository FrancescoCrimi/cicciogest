namespace CiccioGest.Presentation.AppForm.Views
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoriaView));
            categorieDataGridView = new System.Windows.Forms.DataGridView();
            idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            categorieBindingSource = new System.Windows.Forms.BindingSource(components);
            nomeLabel = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            CategoriaBindingSource = new System.Windows.Forms.BindingSource(components);
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            toolStrip = new System.Windows.Forms.ToolStrip();
            nuovoToolStripButton = new System.Windows.Forms.ToolStripButton();
            cancellaToolStripButton = new System.Windows.Forms.ToolStripButton();
            salvaToolStripButton = new System.Windows.Forms.ToolStripButton();
            aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)categorieDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categorieBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CategoriaBindingSource).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            toolStrip.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // categorieDataGridView
            // 
            categorieDataGridView.AllowUserToAddRows = false;
            categorieDataGridView.AllowUserToDeleteRows = false;
            categorieDataGridView.AllowUserToResizeRows = false;
            categorieDataGridView.AutoGenerateColumns = false;
            categorieDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            categorieDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            categorieDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn });
            categorieDataGridView.DataSource = categorieBindingSource;
            categorieDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            categorieDataGridView.Location = new System.Drawing.Point(4, 70);
            categorieDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            categorieDataGridView.MultiSelect = false;
            categorieDataGridView.Name = "categorieDataGridView";
            categorieDataGridView.ReadOnly = true;
            categorieDataGridView.RowHeadersVisible = false;
            categorieDataGridView.RowHeadersWidth = 51;
            categorieDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            categorieDataGridView.Size = new System.Drawing.Size(291, 219);
            categorieDataGridView.TabIndex = 1;
            categorieDataGridView.CellDoubleClick += CategorieDataGridView_CellDoubleClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 42;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.MinimumWidth = 6;
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categorieBindingSource
            // 
            categorieBindingSource.DataSource = typeof(Domain.Magazzino.Categoria);
            // 
            // nomeLabel
            // 
            nomeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(4, 8);
            nomeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(43, 15);
            nomeLabel.TabIndex = 3;
            nomeLabel.Text = "Nome:";
            // 
            // textBox1
            // 
            textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", CategoriaBindingSource, "Nome", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            textBox1.Location = new System.Drawing.Point(55, 4);
            textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(141, 23);
            textBox1.TabIndex = 4;
            // 
            // CategoriaBindingSource
            // 
            CategoriaBindingSource.DataSource = typeof(Domain.Magazzino.Categoria);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(toolStrip, 0, 0);
            tableLayoutPanel1.Controls.Add(categorieDataGridView, 0, 2);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(299, 293);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // toolStrip
            // 
            toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { nuovoToolStripButton, salvaToolStripButton, cancellaToolStripButton, aboutToolStripButton });
            toolStrip.Location = new System.Drawing.Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new System.Drawing.Size(299, 27);
            toolStrip.TabIndex = 3;
            toolStrip.Text = "toolStrip1";
            // 
            // nuovoToolStripButton
            // 
            nuovoToolStripButton.Image = (System.Drawing.Image)resources.GetObject("nuovoToolStripButton.Image");
            nuovoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            nuovoToolStripButton.Name = "nuovoToolStripButton";
            nuovoToolStripButton.Size = new System.Drawing.Size(67, 24);
            nuovoToolStripButton.Text = "Nuovo";
            nuovoToolStripButton.Click += NuovoToolStripButton_Click;
            // 
            // cancellaToolStripButton
            // 
            cancellaToolStripButton.Image = (System.Drawing.Image)resources.GetObject("cancellaToolStripButton.Image");
            cancellaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            cancellaToolStripButton.Name = "cancellaToolStripButton";
            cancellaToolStripButton.Size = new System.Drawing.Size(76, 24);
            cancellaToolStripButton.Text = "Cancella";
            cancellaToolStripButton.Click += CancellaToolStripButton_Click;
            // 
            // salvaToolStripButton
            // 
            salvaToolStripButton.Image = (System.Drawing.Image)resources.GetObject("salvaToolStripButton.Image");
            salvaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            salvaToolStripButton.Name = "salvaToolStripButton";
            salvaToolStripButton.Size = new System.Drawing.Size(58, 24);
            salvaToolStripButton.Text = "Salva";
            salvaToolStripButton.Click += SalvaToolStripButton_Click;
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
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(nomeLabel);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.Location = new System.Drawing.Point(4, 31);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(291, 31);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // CategoriaView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(299, 293);
            Controls.Add(tableLayoutPanel1);
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            Name = "CategoriaView";
            Text = "Categorie";
            FormClosing += CategoriaView_FormClosing;
            Load += CategoriaView_Load;
            ((System.ComponentModel.ISupportInitialize)categorieDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)categorieBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)CategoriaBindingSource).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

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
