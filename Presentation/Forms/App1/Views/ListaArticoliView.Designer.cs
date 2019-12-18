namespace CiccioGest.Presentation.Forms.App1.Views
{
    partial class ListaArticoliView
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
            this.articoliBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.articoliDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.articoliBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.articoliDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // articoliBindingSource
            // 
            this.articoliBindingSource.DataSource = typeof(CiccioGest.Domain.Magazino.Articolo);
            // 
            // articoliDataGridView
            // 
            this.articoliDataGridView.AllowUserToAddRows = false;
            this.articoliDataGridView.AllowUserToDeleteRows = false;
            this.articoliDataGridView.AllowUserToResizeRows = false;
            this.articoliDataGridView.AutoGenerateColumns = false;
            this.articoliDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.articoliDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.nomeDataGridViewTextBoxColumn,
            this.NomeCategoria,
            this.prezzoDataGridViewTextBoxColumn});
            this.articoliDataGridView.DataSource = this.articoliBindingSource;
            this.articoliDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.articoliDataGridView.Location = new System.Drawing.Point(0, 0);
            this.articoliDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.articoliDataGridView.MultiSelect = false;
            this.articoliDataGridView.Name = "articoliDataGridView";
            this.articoliDataGridView.ReadOnly = true;
            this.articoliDataGridView.RowHeadersVisible = false;
            this.articoliDataGridView.RowHeadersWidth = 51;
            this.articoliDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.articoliDataGridView.Size = new System.Drawing.Size(332, 303);
            this.articoliDataGridView.TabIndex = 1;
            this.articoliDataGridView.DoubleClick += new System.EventHandler(this.ArticoliDataGridView_DoubleClick);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 48;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // NomeCategoria
            // 
            this.NomeCategoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NomeCategoria.DataPropertyName = "NomeCategoria";
            this.NomeCategoria.HeaderText = "Categoria";
            this.NomeCategoria.MinimumWidth = 6;
            this.NomeCategoria.Name = "NomeCategoria";
            this.NomeCategoria.ReadOnly = true;
            // 
            // prezzoDataGridViewTextBoxColumn
            // 
            this.prezzoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.prezzoDataGridViewTextBoxColumn.DataPropertyName = "Prezzo";
            this.prezzoDataGridViewTextBoxColumn.HeaderText = "Prezzo";
            this.prezzoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.prezzoDataGridViewTextBoxColumn.Name = "prezzoDataGridViewTextBoxColumn";
            this.prezzoDataGridViewTextBoxColumn.ReadOnly = true;
            this.prezzoDataGridViewTextBoxColumn.Width = 81;
            // 
            // ListaArticoliView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 303);
            this.Controls.Add(this.articoliDataGridView);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ListaArticoliView";
            this.Text = "Articoli";
            this.Load += new System.EventHandler(this.View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.articoliBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.articoliDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezzoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView articoliDataGridView;
        private System.Windows.Forms.BindingSource articoliBindingSource;
    }
}
