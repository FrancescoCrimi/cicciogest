namespace CiccioGest.Presentation.Forms.App1.Views
{
    partial class MainView
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fattureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magazinoMainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articoliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categorieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fornitoriToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opzioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.informazionisuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fattureToolStripMenuItem,
            this.clientiToolStripMenuItem,
            this.magazinoMainToolStripMenuItem,
            this.ToolStripMenuItem,
            this.esciToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(382, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fattureToolStripMenuItem
            // 
            this.fattureToolStripMenuItem.Name = "fattureToolStripMenuItem";
            this.fattureToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.fattureToolStripMenuItem.Text = "Fatture";
            this.fattureToolStripMenuItem.Click += new System.EventHandler(this.fattureToolStripMenuItem_Click);
            // 
            // clientiToolStripMenuItem
            // 
            this.clientiToolStripMenuItem.Name = "clientiToolStripMenuItem";
            this.clientiToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.clientiToolStripMenuItem.Text = "Clienti";
            this.clientiToolStripMenuItem.Click += new System.EventHandler(this.clientiToolStripMenuItem_Click);
            // 
            // magazinoMainToolStripMenuItem
            // 
            this.magazinoMainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.articoliToolStripMenuItem,
            this.categorieToolStripMenuItem,
            this.fornitoriToolStripMenuItem1});
            this.magazinoMainToolStripMenuItem.Name = "magazinoMainToolStripMenuItem";
            this.magazinoMainToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.magazinoMainToolStripMenuItem.Text = "Magazino";
            // 
            // articoliToolStripMenuItem
            // 
            this.articoliToolStripMenuItem.Name = "articoliToolStripMenuItem";
            this.articoliToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.articoliToolStripMenuItem.Text = "Articoli";
            this.articoliToolStripMenuItem.Click += new System.EventHandler(this.ArticoliToolStripMenuItem_Click);
            // 
            // categorieToolStripMenuItem
            // 
            this.categorieToolStripMenuItem.Name = "categorieToolStripMenuItem";
            this.categorieToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.categorieToolStripMenuItem.Text = "Categorie";
            this.categorieToolStripMenuItem.Click += new System.EventHandler(this.CategorieToolStripMenuItem_Click);
            // 
            // fornitoriToolStripMenuItem1
            // 
            this.fornitoriToolStripMenuItem1.Name = "fornitoriToolStripMenuItem1";
            this.fornitoriToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.fornitoriToolStripMenuItem1.Text = "Fornitori";
            this.fornitoriToolStripMenuItem1.Click += new System.EventHandler(this.fornitoriToolStripMenuItem1_Click);
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opzioniToolStripMenuItem,
            this.toolStripSeparator5,
            this.informazionisuToolStripMenuItem});
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(30, 24);
            this.ToolStripMenuItem.Text = "?";
            // 
            // opzioniToolStripMenuItem
            // 
            this.opzioniToolStripMenuItem.Name = "opzioniToolStripMenuItem";
            this.opzioniToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.opzioniToolStripMenuItem.Text = "Opzioni";
            this.opzioniToolStripMenuItem.Click += new System.EventHandler(this.OpzioniToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(200, 6);
            // 
            // informazionisuToolStripMenuItem
            // 
            this.informazionisuToolStripMenuItem.Name = "informazionisuToolStripMenuItem";
            this.informazionisuToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.informazionisuToolStripMenuItem.Text = "Informazioni su...";
            this.informazionisuToolStripMenuItem.Click += new System.EventHandler(this.InformazionisuToolStripMenuItem_Click);
            // 
            // esciToolStripMenuItem
            // 
            this.esciToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            this.esciToolStripMenuItem.Size = new System.Drawing.Size(48, 24);
            this.esciToolStripMenuItem.Text = "Esci";
            this.esciToolStripMenuItem.Click += new System.EventHandler(this.EsciToolStripMenuItem_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 313);
            this.Controls.Add(this.menuStrip);
            this.Name = "MainView";
            this.Text = "CiccioGest";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fattureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem magazinoMainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articoliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categorieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem informazionisuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opzioniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fornitoriToolStripMenuItem1;
    }
}
