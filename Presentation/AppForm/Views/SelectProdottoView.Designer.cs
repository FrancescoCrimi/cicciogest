namespace CiccioGest.Presentation.AppForm.Views
{
    partial class SelectProdottoView
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
            this.prodottiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prodottiDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.prodottiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottiDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // prodottiBindingSource
            // 
            this.prodottiBindingSource.DataSource = typeof(CiccioGest.Domain.Magazino.Prodotto);
            // 
            // prodottiDataGridView
            // 
            this.prodottiDataGridView.AllowUserToAddRows = false;
            this.prodottiDataGridView.AllowUserToDeleteRows = false;
            this.prodottiDataGridView.AllowUserToResizeRows = false;
            this.prodottiDataGridView.AutoGenerateColumns = false;
            this.prodottiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prodottiDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.nomeDataGridViewTextBoxColumn,
            this.NomeCategoria,
            this.prezzoDataGridViewTextBoxColumn});
            this.prodottiDataGridView.DataSource = this.prodottiBindingSource;
            this.prodottiDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prodottiDataGridView.Location = new System.Drawing.Point(0, 0);
            this.prodottiDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.prodottiDataGridView.MultiSelect = false;
            this.prodottiDataGridView.Name = "prodottiDataGridView";
            this.prodottiDataGridView.ReadOnly = true;
            this.prodottiDataGridView.RowHeadersVisible = false;
            this.prodottiDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.prodottiDataGridView.Size = new System.Drawing.Size(332, 303);
            this.prodottiDataGridView.TabIndex = 1;
            this.prodottiDataGridView.DoubleClick += new System.EventHandler(this.ProdottiDataGridView_DoubleClick);
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
            this.nomeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // NomeCategoria
            // 
            this.NomeCategoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
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
            // SelectProdottoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 303);
            this.Controls.Add(this.prodottiDataGridView);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SelectProdottoView";
            this.Text = "Seleziona Prodotto";
            this.Load += new System.EventHandler(this.View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prodottiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottiDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezzoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView prodottiDataGridView;
        private System.Windows.Forms.BindingSource prodottiBindingSource;
    }
}