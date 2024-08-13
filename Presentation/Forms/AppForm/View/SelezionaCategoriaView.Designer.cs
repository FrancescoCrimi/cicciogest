
using System;

namespace CiccioGest.Presentation.AppForm.View
{
    partial class SelezionaCategoriaView
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
            this.nomeCompletoLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.categorieDataGridView = new System.Windows.Forms.DataGridView();
            this.categorieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.nomeCompletoTextBox = new System.Windows.Forms.TextBox();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categorieDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categorieBindingSource)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nomeCompletoLabel
            // 
            this.nomeCompletoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nomeCompletoLabel.AutoSize = true;
            this.nomeCompletoLabel.Location = new System.Drawing.Point(3, 7);
            this.nomeCompletoLabel.Name = "nomeCompletoLabel";
            this.nomeCompletoLabel.Size = new System.Drawing.Size(49, 20);
            this.nomeCompletoLabel.TabIndex = 0;
            this.nomeCompletoLabel.Text = "Cerca:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.categorieDataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 562);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // categorieDataGridView
            // 
            this.categorieDataGridView.AllowUserToAddRows = false;
            this.categorieDataGridView.AllowUserToDeleteRows = false;
            this.categorieDataGridView.AutoGenerateColumns = false;
            this.categorieDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categorieDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomeDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn});
            this.categorieDataGridView.DataSource = this.categorieBindingSource;
            this.categorieDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categorieDataGridView.Location = new System.Drawing.Point(3, 47);
            this.categorieDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.categorieDataGridView.MultiSelect = false;
            this.categorieDataGridView.Name = "categorieDataGridView";
            this.categorieDataGridView.ReadOnly = true;
            this.categorieDataGridView.RowHeadersVisible = false;
            this.categorieDataGridView.RowHeadersWidth = 51;
            this.categorieDataGridView.RowTemplate.Height = 24;
            this.categorieDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.categorieDataGridView.Size = new System.Drawing.Size(794, 511);
            this.categorieDataGridView.TabIndex = 0;
            this.categorieDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CategorieDataGridView_CellDoubleClick);
            // 
            // categorieBindingSource
            // 
            this.categorieBindingSource.AllowNew = false;
            this.categorieBindingSource.DataSource = typeof(CiccioGest.Domain.Magazzino.Categoria);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.nomeCompletoLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.nomeCompletoTextBox, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 35);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // nomeCompletoTextBox
            // 
            this.nomeCompletoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nomeCompletoTextBox.Location = new System.Drawing.Point(58, 4);
            this.nomeCompletoTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nomeCompletoTextBox.Name = "nomeCompletoTextBox";
            this.nomeCompletoTextBox.Size = new System.Drawing.Size(733, 27);
            this.nomeCompletoTextBox.TabIndex = 1;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomeDataGridViewTextBoxColumn.Width = 125;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // SelezionaCategoriaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SelezionaCategoriaView";
            this.Text = "Seleziona Categoria";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelezionaCategoriaView_FormClosing);
            this.Load += new System.EventHandler(this.SelezionaCategoriaView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categorieDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categorieBindingSource)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView categorieDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox nomeCompletoTextBox;
        private System.Windows.Forms.BindingSource categorieBindingSource;

        #endregion

        private System.Windows.Forms.Label nomeCompletoLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
    }
}