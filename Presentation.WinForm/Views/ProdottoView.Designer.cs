namespace Ciccio1.Presentation.WinForm.Views
{
    partial class ProdottoView
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
            System.Windows.Forms.Label nomeLabel;
            System.Windows.Forms.Label categoriaLabel;
            System.Windows.Forms.Label prezzoLabel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProdottoView));
            this.prodottiDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodottiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.prodottoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoriaComboBox = new System.Windows.Forms.ComboBox();
            this.categorieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prezzoTextBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.nuovoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.cancellaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.salvaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            nomeLabel = new System.Windows.Forms.Label();
            categoriaLabel = new System.Windows.Forms.Label();
            prezzoLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.prodottiDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categorieBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(4, 0);
            nomeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(49, 17);
            nomeLabel.TabIndex = 2;
            nomeLabel.Text = "Nome:";
            // 
            // categoriaLabel
            // 
            categoriaLabel.AutoSize = true;
            categoriaLabel.Location = new System.Drawing.Point(196, 0);
            categoriaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            categoriaLabel.Name = "categoriaLabel";
            categoriaLabel.Size = new System.Drawing.Size(73, 17);
            categoriaLabel.TabIndex = 10;
            categoriaLabel.Text = "Categoria:";
            // 
            // prezzoLabel1
            // 
            prezzoLabel1.AutoSize = true;
            prezzoLabel1.Location = new System.Drawing.Point(132, 0);
            prezzoLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            prezzoLabel1.Name = "prezzoLabel1";
            prezzoLabel1.Size = new System.Drawing.Size(56, 17);
            prezzoLabel1.TabIndex = 10;
            prezzoLabel1.Text = "Prezzo:";
            // 
            // prodottiDataGridView
            // 
            this.prodottiDataGridView.AllowUserToAddRows = false;
            this.prodottiDataGridView.AllowUserToDeleteRows = false;
            this.prodottiDataGridView.AllowUserToResizeRows = false;
            this.prodottiDataGridView.AutoGenerateColumns = false;
            this.prodottiDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.prodottiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prodottiDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.nomeDataGridViewTextBoxColumn,
            this.NomeCategoria,
            this.prezzoDataGridViewTextBoxColumn});
            this.prodottiDataGridView.DataSource = this.prodottiBindingSource;
            this.prodottiDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prodottiDataGridView.Location = new System.Drawing.Point(4, 88);
            this.prodottiDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.prodottiDataGridView.MultiSelect = false;
            this.prodottiDataGridView.Name = "prodottiDataGridView";
            this.prodottiDataGridView.ReadOnly = true;
            this.prodottiDataGridView.RowHeadersVisible = false;
            this.prodottiDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.prodottiDataGridView.Size = new System.Drawing.Size(324, 211);
            this.prodottiDataGridView.TabIndex = 1;
            this.prodottiDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.prodottiDataGridView_CellDoubleClick_1);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 48;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // NomeCategoria
            // 
            this.NomeCategoria.DataPropertyName = "NomeCategoria";
            this.NomeCategoria.HeaderText = "Categoria";
            this.NomeCategoria.Name = "NomeCategoria";
            this.NomeCategoria.ReadOnly = true;
            // 
            // prezzoDataGridViewTextBoxColumn
            // 
            this.prezzoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.prezzoDataGridViewTextBoxColumn.DataPropertyName = "Prezzo";
            this.prezzoDataGridViewTextBoxColumn.HeaderText = "Prezzo";
            this.prezzoDataGridViewTextBoxColumn.Name = "prezzoDataGridViewTextBoxColumn";
            this.prezzoDataGridViewTextBoxColumn.ReadOnly = true;
            this.prezzoDataGridViewTextBoxColumn.Width = 81;
            // 
            // prodottiBindingSource
            // 
            this.prodottiBindingSource.AllowNew = false;
            this.prodottiBindingSource.DataSource = typeof(Ciccio1.Domain.Prodotto);
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prodottoBindingSource, "Nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(4, 21);
            this.nomeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(120, 22);
            this.nomeTextBox.TabIndex = 3;
            // 
            // prodottoBindingSource
            // 
            this.prodottoBindingSource.DataSource = typeof(Ciccio1.Domain.Prodotto);
            // 
            // categoriaComboBox
            // 
            this.categoriaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.prodottoBindingSource, "Categoria", true));
            this.categoriaComboBox.DataSource = this.categorieBindingSource;
            this.categoriaComboBox.DisplayMember = "Nome";
            this.categoriaComboBox.FormattingEnabled = true;
            this.categoriaComboBox.Location = new System.Drawing.Point(196, 21);
            this.categoriaComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.categoriaComboBox.Name = "categoriaComboBox";
            this.categoriaComboBox.Size = new System.Drawing.Size(120, 24);
            this.categoriaComboBox.TabIndex = 10;
            // 
            // categorieBindingSource
            // 
            this.categorieBindingSource.DataSource = typeof(Ciccio1.Domain.Categoria);
            // 
            // prezzoTextBox1
            // 
            this.prezzoTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prodottoBindingSource, "Prezzo", true));
            this.prezzoTextBox1.Location = new System.Drawing.Point(132, 21);
            this.prezzoTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.prezzoTextBox1.Name = "prezzoTextBox1";
            this.prezzoTextBox1.Size = new System.Drawing.Size(50, 22);
            this.prezzoTextBox1.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.prodottiDataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(332, 303);
            this.tableLayoutPanel1.TabIndex = 12;
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
            this.toolStrip.Size = new System.Drawing.Size(332, 27);
            this.toolStrip.TabIndex = 10;
            this.toolStrip.Text = "toolStrip1";
            // 
            // nuovoToolStripButton
            // 
            this.nuovoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nuovoToolStripButton.Image")));
            this.nuovoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuovoToolStripButton.Name = "nuovoToolStripButton";
            this.nuovoToolStripButton.Size = new System.Drawing.Size(77, 24);
            this.nuovoToolStripButton.Text = "&Nuovo";
            this.nuovoToolStripButton.Click += new System.EventHandler(this.NuovoToolStripButton_Click);
            // 
            // cancellaToolStripButton
            // 
            this.cancellaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cancellaToolStripButton.Image")));
            this.cancellaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancellaToolStripButton.Name = "cancellaToolStripButton";
            this.cancellaToolStripButton.Size = new System.Drawing.Size(89, 24);
            this.cancellaToolStripButton.Text = "&Cancella";
            this.cancellaToolStripButton.Click += new System.EventHandler(this.CancellaToolStripButton_Click);
            // 
            // salvaToolStripButton
            // 
            this.salvaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("salvaToolStripButton.Image")));
            this.salvaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salvaToolStripButton.Name = "salvaToolStripButton";
            this.salvaToolStripButton.Size = new System.Drawing.Size(68, 24);
            this.salvaToolStripButton.Text = "&Salva";
            this.salvaToolStripButton.Click += new System.EventHandler(this.SalvaToolStripButton_Click);
            // 
            // aboutToolStripButton
            // 
            this.aboutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aboutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripButton.Image")));
            this.aboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutToolStripButton.Name = "aboutToolStripButton";
            this.aboutToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.aboutToolStripButton.Text = "&?";
            this.aboutToolStripButton.Click += new System.EventHandler(this.AboutToolStripButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(nomeLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.categoriaComboBox, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.prezzoTextBox1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(prezzoLabel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(categoriaLabel, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.nomeTextBox, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 31);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(324, 49);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // ProdottoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 303);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProdottoView";
            this.Text = "Prodotto";
            this.Load += new System.EventHandler(this.View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prodottiDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categorieBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.ComboBox categoriaComboBox;
        private System.Windows.Forms.TextBox prezzoTextBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezzoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView prodottiDataGridView;
        private System.Windows.Forms.ToolStripButton nuovoToolStripButton;
        private System.Windows.Forms.ToolStripButton cancellaToolStripButton;
        private System.Windows.Forms.ToolStripButton salvaToolStripButton;
        private System.Windows.Forms.ToolStripButton aboutToolStripButton;
        private System.Windows.Forms.BindingSource prodottiBindingSource;
        private System.Windows.Forms.BindingSource prodottoBindingSource;
        private System.Windows.Forms.BindingSource categorieBindingSource;
    }
}