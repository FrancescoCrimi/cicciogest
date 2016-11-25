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
            System.Windows.Forms.Label nomeTipoProdottoLabel;
            System.Windows.Forms.Label prezzoLabel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProdottoView));
            this.ProdottiDataGridView = new System.Windows.Forms.DataGridView();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdottiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.ProdottoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoProdottoComboBox = new System.Windows.Forms.ComboBox();
            this.CategorieProdottoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prezzoTextBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.NuovoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.CancellaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SalvaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.AboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            nomeLabel = new System.Windows.Forms.Label();
            nomeTipoProdottoLabel = new System.Windows.Forms.Label();
            prezzoLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProdottiDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProdottiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProdottoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategorieProdottoBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(3, 0);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(38, 13);
            nomeLabel.TabIndex = 2;
            nomeLabel.Text = "Nome:";
            // 
            // nomeTipoProdottoLabel
            // 
            nomeTipoProdottoLabel.AutoSize = true;
            nomeTipoProdottoLabel.Location = new System.Drawing.Point(165, 0);
            nomeTipoProdottoLabel.Name = "nomeTipoProdottoLabel";
            nomeTipoProdottoLabel.Size = new System.Drawing.Size(98, 13);
            nomeTipoProdottoLabel.TabIndex = 10;
            nomeTipoProdottoLabel.Text = "Categoria Prodotto:";
            // 
            // prezzoLabel1
            // 
            prezzoLabel1.AutoSize = true;
            prezzoLabel1.Location = new System.Drawing.Point(109, 0);
            prezzoLabel1.Name = "prezzoLabel1";
            prezzoLabel1.Size = new System.Drawing.Size(42, 13);
            prezzoLabel1.TabIndex = 10;
            prezzoLabel1.Text = "Prezzo:";
            // 
            // ProdottiDataGridView
            // 
            this.ProdottiDataGridView.AllowUserToAddRows = false;
            this.ProdottiDataGridView.AllowUserToDeleteRows = false;
            this.ProdottiDataGridView.AllowUserToResizeRows = false;
            this.ProdottiDataGridView.AutoGenerateColumns = false;
            this.ProdottiDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProdottiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProdottiDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomeDataGridViewTextBoxColumn,
            this.prezzoDataGridViewTextBoxColumn});
            this.ProdottiDataGridView.DataSource = this.ProdottiBindingSource;
            this.ProdottiDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProdottiDataGridView.Location = new System.Drawing.Point(3, 74);
            this.ProdottiDataGridView.MultiSelect = false;
            this.ProdottiDataGridView.Name = "ProdottiDataGridView";
            this.ProdottiDataGridView.ReadOnly = true;
            this.ProdottiDataGridView.RowHeadersVisible = false;
            this.ProdottiDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProdottiDataGridView.Size = new System.Drawing.Size(293, 185);
            this.ProdottiDataGridView.TabIndex = 1;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prezzoDataGridViewTextBoxColumn
            // 
            this.prezzoDataGridViewTextBoxColumn.DataPropertyName = "Prezzo";
            this.prezzoDataGridViewTextBoxColumn.HeaderText = "Prezzo";
            this.prezzoDataGridViewTextBoxColumn.Name = "prezzoDataGridViewTextBoxColumn";
            this.prezzoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ProdottiBindingSource
            // 
            this.ProdottiBindingSource.AllowNew = false;
            this.ProdottiBindingSource.DataSource = typeof(Ciccio1.Domain.Prodotto);
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ProdottoBindingSource, "Nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(3, 16);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(100, 20);
            this.nomeTextBox.TabIndex = 3;
            // 
            // ProdottoBindingSource
            // 
            this.ProdottoBindingSource.DataSource = typeof(Ciccio1.Domain.Prodotto);
            // 
            // tipoProdottoComboBox
            // 
            this.tipoProdottoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ProdottoBindingSource, "Categoria", true));
            this.tipoProdottoComboBox.DataSource = this.CategorieProdottoBindingSource;
            this.tipoProdottoComboBox.DisplayMember = "Nome";
            this.tipoProdottoComboBox.FormattingEnabled = true;
            this.tipoProdottoComboBox.Location = new System.Drawing.Point(165, 16);
            this.tipoProdottoComboBox.Name = "tipoProdottoComboBox";
            this.tipoProdottoComboBox.Size = new System.Drawing.Size(121, 21);
            this.tipoProdottoComboBox.TabIndex = 10;
            // 
            // CategorieProdottoBindingSource
            // 
            this.CategorieProdottoBindingSource.DataSource = typeof(Ciccio1.Domain.Categoria);
            // 
            // prezzoTextBox1
            // 
            this.prezzoTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ProdottoBindingSource, "Prezzo", true));
            this.prezzoTextBox1.Location = new System.Drawing.Point(109, 16);
            this.prezzoTextBox1.Name = "prezzoTextBox1";
            this.prezzoTextBox1.Size = new System.Drawing.Size(50, 20);
            this.prezzoTextBox1.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ProdottiDataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(299, 262);
            this.tableLayoutPanel1.TabIndex = 12;
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
            this.toolStrip1.Size = new System.Drawing.Size(299, 25);
            this.toolStrip1.TabIndex = 10;
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(nomeLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tipoProdottoComboBox, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.prezzoTextBox1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(prezzoLabel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(nomeTipoProdottoLabel, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.nomeTextBox, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 28);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(293, 40);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // ProdottoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 262);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProdottoView";
            this.Text = "Prodotto";
            ((System.ComponentModel.ISupportInitialize)(this.ProdottiDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProdottiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProdottoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategorieProdottoBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.ComboBox tipoProdottoComboBox;
        private System.Windows.Forms.TextBox prezzoTextBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezzoDataGridViewTextBoxColumn;
        internal System.Windows.Forms.DataGridView ProdottiDataGridView;
        internal System.Windows.Forms.ToolStripButton NuovoToolStripButton;
        internal System.Windows.Forms.ToolStripButton CancellaToolStripButton;
        internal System.Windows.Forms.ToolStripButton SalvaToolStripButton;
        internal System.Windows.Forms.ToolStripButton AboutToolStripButton;
        internal System.Windows.Forms.BindingSource ProdottiBindingSource;
        internal System.Windows.Forms.BindingSource ProdottoBindingSource;
        internal System.Windows.Forms.BindingSource CategorieProdottoBindingSource;
    }
}