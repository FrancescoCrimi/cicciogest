﻿namespace CiccioGest.Presentation.AppForm.Views
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
            this.nuovaFatturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cercaFatturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prodottiMainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prodottiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categorieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fattureToolStripMenuItem,
            this.personeToolStripMenuItem,
            this.prodottiMainToolStripMenuItem,
            this.altroToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(502, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fattureToolStripMenuItem
            // 
            this.fattureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovaFatturaToolStripMenuItem,
            this.cercaFatturaToolStripMenuItem});
            this.fattureToolStripMenuItem.Name = "fattureToolStripMenuItem";
            this.fattureToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.fattureToolStripMenuItem.Text = "Fatture";
            // 
            // nuovaFatturaToolStripMenuItem
            // 
            this.nuovaFatturaToolStripMenuItem.Name = "nuovaFatturaToolStripMenuItem";
            this.nuovaFatturaToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.nuovaFatturaToolStripMenuItem.Text = "Nuova";
            this.nuovaFatturaToolStripMenuItem.Click += new System.EventHandler(this.nuovaFatturaToolStripMenuItem_Click);
            // 
            // cercaFatturaToolStripMenuItem
            // 
            this.cercaFatturaToolStripMenuItem.Name = "cercaFatturaToolStripMenuItem";
            this.cercaFatturaToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.cercaFatturaToolStripMenuItem.Text = "Cerca";
            this.cercaFatturaToolStripMenuItem.Click += new System.EventHandler(this.cercaFatturaToolStripMenuItem_Click);
            // 
            // personeToolStripMenuItem
            // 
            this.personeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientiToolStripMenuItem});
            this.personeToolStripMenuItem.Name = "personeToolStripMenuItem";
            this.personeToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.personeToolStripMenuItem.Text = "Persone";
            // 
            // clientiToolStripMenuItem
            // 
            this.clientiToolStripMenuItem.Name = "clientiToolStripMenuItem";
            this.clientiToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.clientiToolStripMenuItem.Text = "Clienti";
            this.clientiToolStripMenuItem.Click += new System.EventHandler(this.gestioneClientiToolStripMenuItem_Click);
            // 
            // prodottiMainToolStripMenuItem
            // 
            this.prodottiMainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prodottiToolStripMenuItem,
            this.categorieToolStripMenuItem});
            this.prodottiMainToolStripMenuItem.Name = "prodottiMainToolStripMenuItem";
            this.prodottiMainToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.prodottiMainToolStripMenuItem.Text = "Prodotti";
            // 
            // prodottiToolStripMenuItem
            // 
            this.prodottiToolStripMenuItem.Name = "prodottiToolStripMenuItem";
            this.prodottiToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.prodottiToolStripMenuItem.Text = "Prodotti";
            this.prodottiToolStripMenuItem.Click += new System.EventHandler(this.prodottiToolStripMenuItem_Click);
            // 
            // categorieToolStripMenuItem
            // 
            this.categorieToolStripMenuItem.Name = "categorieToolStripMenuItem";
            this.categorieToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.categorieToolStripMenuItem.Text = "Categorie";
            this.categorieToolStripMenuItem.Click += new System.EventHandler(this.categorieToolStripMenuItem_Click);
            // 
            // altroToolStripMenuItem
            // 
            this.altroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.esciToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.altroToolStripMenuItem.Name = "altroToolStripMenuItem";
            this.altroToolStripMenuItem.Size = new System.Drawing.Size(28, 24);
            this.altroToolStripMenuItem.Text = "?";
            // 
            // esciToolStripMenuItem
            // 
            this.esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            this.esciToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.esciToolStripMenuItem.Text = "Esci";
            this.esciToolStripMenuItem.Click += new System.EventHandler(this.esciToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 313);
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
        private System.Windows.Forms.ToolStripMenuItem nuovaFatturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cercaFatturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prodottiMainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prodottiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categorieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}