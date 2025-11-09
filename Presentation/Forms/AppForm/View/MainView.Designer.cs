namespace CiccioGest.Presentation.AppForm.View
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
            menuStrip = new System.Windows.Forms.MenuStrip();
            documentiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ApriFatturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            magazinoMainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            articoliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            categorieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            anagraficaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clientiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            fornitoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            opzioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            informazionisuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            NuovaFatturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { documentiToolStripMenuItem, magazinoMainToolStripMenuItem, anagraficaToolStripMenuItem, ToolStripMenuItem });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            menuStrip.Size = new System.Drawing.Size(422, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // documentiToolStripMenuItem
            // 
            documentiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { ApriFatturaToolStripMenuItem, NuovaFatturaToolStripMenuItem });
            documentiToolStripMenuItem.Name = "documentiToolStripMenuItem";
            documentiToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            documentiToolStripMenuItem.Text = "Fatture";
            // 
            // ApriFatturaToolStripMenuItem
            // 
            ApriFatturaToolStripMenuItem.Name = "ApriFatturaToolStripMenuItem";
            ApriFatturaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            ApriFatturaToolStripMenuItem.Text = "Apri Fattura";
            ApriFatturaToolStripMenuItem.Click += ApriFattura_Click;
            // 
            // magazinoMainToolStripMenuItem
            // 
            magazinoMainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { articoliToolStripMenuItem, categorieToolStripMenuItem });
            magazinoMainToolStripMenuItem.Name = "magazinoMainToolStripMenuItem";
            magazinoMainToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            magazinoMainToolStripMenuItem.Text = "Magazino";
            // 
            // articoliToolStripMenuItem
            // 
            articoliToolStripMenuItem.Name = "articoliToolStripMenuItem";
            articoliToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            articoliToolStripMenuItem.Text = "Articoli";
            articoliToolStripMenuItem.Click += ArticoliToolStripMenuItem_Click;
            // 
            // categorieToolStripMenuItem
            // 
            categorieToolStripMenuItem.Name = "categorieToolStripMenuItem";
            categorieToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            categorieToolStripMenuItem.Text = "Categorie";
            categorieToolStripMenuItem.Click += CategorieToolStripMenuItem_Click;
            // 
            // anagraficaToolStripMenuItem
            // 
            anagraficaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { clientiToolStripMenuItem, fornitoriToolStripMenuItem });
            anagraficaToolStripMenuItem.Name = "anagraficaToolStripMenuItem";
            anagraficaToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            anagraficaToolStripMenuItem.Text = "Anagrafica";
            // 
            // clientiToolStripMenuItem
            // 
            clientiToolStripMenuItem.Name = "clientiToolStripMenuItem";
            clientiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            clientiToolStripMenuItem.Text = "Clienti";
            clientiToolStripMenuItem.Click += ClientiToolStripMenuItem_Click;
            // 
            // fornitoriToolStripMenuItem
            // 
            fornitoriToolStripMenuItem.Name = "fornitoriToolStripMenuItem";
            fornitoriToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            fornitoriToolStripMenuItem.Text = "Fornitori";
            fornitoriToolStripMenuItem.Click += FornitoriToolStripMenuItem_Click;
            // 
            // ToolStripMenuItem
            // 
            ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { opzioniToolStripMenuItem, toolStripSeparator5, informazionisuToolStripMenuItem });
            ToolStripMenuItem.Name = "ToolStripMenuItem";
            ToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            ToolStripMenuItem.Text = "?";
            // 
            // opzioniToolStripMenuItem
            // 
            opzioniToolStripMenuItem.Name = "opzioniToolStripMenuItem";
            opzioniToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            opzioniToolStripMenuItem.Text = "Opzioni";
            opzioniToolStripMenuItem.Click += OpzioniToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(177, 6);
            // 
            // informazionisuToolStripMenuItem
            // 
            informazionisuToolStripMenuItem.Name = "informazionisuToolStripMenuItem";
            informazionisuToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            informazionisuToolStripMenuItem.Text = "Informazioni su...";
            informazionisuToolStripMenuItem.Click += InformazionisuToolStripMenuItem_Click;
            // 
            // NuovaFatturaToolStripMenuItem
            // 
            NuovaFatturaToolStripMenuItem.Name = "NuovaFatturaToolStripMenuItem";
            NuovaFatturaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            NuovaFatturaToolStripMenuItem.Text = "Nuova Fattura";
            NuovaFatturaToolStripMenuItem.Click += NuovaFattura_Click;
            // 
            // MainView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(422, 331);
            Controls.Add(menuStrip);
            Name = "MainView";
            Text = "CiccioGest";
            FormClosing += MainView_FormClosing;
            Load += MainView_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem documentiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem magazinoMainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anagraficaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articoliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categorieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem informazionisuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opzioniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ApriFatturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fornitoriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NuovaFatturaToolStripMenuItem;
    }
}
