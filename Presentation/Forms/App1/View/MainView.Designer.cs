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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fattureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apriFatturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuovaFatturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apriClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuovoClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apriFornitoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuovoFornitoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magazinoMainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apriArticoloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuovoArticoloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categorieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip.Size = new System.Drawing.Size(482, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fattureToolStripMenuItem
            // 
            this.fattureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apriFatturaToolStripMenuItem,
            this.nuovaFatturaToolStripMenuItem});
            this.fattureToolStripMenuItem.Name = "fattureToolStripMenuItem";
            this.fattureToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.fattureToolStripMenuItem.Text = "Fatture";
            // 
            // apriFatturaToolStripMenuItem
            // 
            this.apriFatturaToolStripMenuItem.Name = "apriFatturaToolStripMenuItem";
            this.apriFatturaToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.apriFatturaToolStripMenuItem.Text = "Apri Fattura";
            this.apriFatturaToolStripMenuItem.Click += new System.EventHandler(this.ApriFatturaToolStripMenuItem_Click);
            // 
            // nuovaFatturaToolStripMenuItem
            // 
            this.nuovaFatturaToolStripMenuItem.Name = "nuovaFatturaToolStripMenuItem";
            this.nuovaFatturaToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.nuovaFatturaToolStripMenuItem.Text = "Nuova Fattura";
            this.nuovaFatturaToolStripMenuItem.Click += new System.EventHandler(this.NuovaFatturaToolStripMenuItem_Click);
            // 
            // clientiToolStripMenuItem
            // 
            this.clientiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apriClienteToolStripMenuItem,
            this.nuovoClienteToolStripMenuItem,
            this.apriFornitoreToolStripMenuItem,
            this.nuovoFornitoreToolStripMenuItem});
            this.clientiToolStripMenuItem.Name = "clientiToolStripMenuItem";
            this.clientiToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.clientiToolStripMenuItem.Text = "Clienti";
            // 
            // apriClienteToolStripMenuItem
            // 
            this.apriClienteToolStripMenuItem.Name = "apriClienteToolStripMenuItem";
            this.apriClienteToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.apriClienteToolStripMenuItem.Text = "Apri Cliente";
            this.apriClienteToolStripMenuItem.Click += new System.EventHandler(this.ApriClienteToolStripMenuItem_Click);
            // 
            // nuovoClienteToolStripMenuItem
            // 
            this.nuovoClienteToolStripMenuItem.Name = "nuovoClienteToolStripMenuItem";
            this.nuovoClienteToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.nuovoClienteToolStripMenuItem.Text = "Nuovo Cliente";
            this.nuovoClienteToolStripMenuItem.Click += new System.EventHandler(this.NuovoClienteToolStripMenuItem_Click);
            // 
            // apriFornitoreToolStripMenuItem
            // 
            this.apriFornitoreToolStripMenuItem.Name = "apriFornitoreToolStripMenuItem";
            this.apriFornitoreToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.apriFornitoreToolStripMenuItem.Text = "Apri Fornitore";
            this.apriFornitoreToolStripMenuItem.Click += new System.EventHandler(this.ApriFornitoreToolStripMenuItem_Click);
            // 
            // nuovoFornitoreToolStripMenuItem
            // 
            this.nuovoFornitoreToolStripMenuItem.Name = "nuovoFornitoreToolStripMenuItem";
            this.nuovoFornitoreToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.nuovoFornitoreToolStripMenuItem.Text = "Nuovo Fornitore";
            this.nuovoFornitoreToolStripMenuItem.Click += new System.EventHandler(this.NuovoFornitoreToolStripMenuItem_Click);
            // 
            // magazinoMainToolStripMenuItem
            // 
            this.magazinoMainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apriArticoloToolStripMenuItem,
            this.nuovoArticoloToolStripMenuItem,
            this.categorieToolStripMenuItem});
            this.magazinoMainToolStripMenuItem.Name = "magazinoMainToolStripMenuItem";
            this.magazinoMainToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.magazinoMainToolStripMenuItem.Text = "Magazino";
            // 
            // apriArticoloToolStripMenuItem
            // 
            this.apriArticoloToolStripMenuItem.Name = "apriArticoloToolStripMenuItem";
            this.apriArticoloToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.apriArticoloToolStripMenuItem.Text = "Apri Articolo";
            this.apriArticoloToolStripMenuItem.Click += new System.EventHandler(this.ApriArticoloToolStripMenuItem_Click);
            // 
            // nuovoArticoloToolStripMenuItem
            // 
            this.nuovoArticoloToolStripMenuItem.Name = "nuovoArticoloToolStripMenuItem";
            this.nuovoArticoloToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.nuovoArticoloToolStripMenuItem.Text = "Nuovo Articolo";
            this.nuovoArticoloToolStripMenuItem.Click += new System.EventHandler(this.NuovoArticoloToolStripMenuItem_Click);
            // 
            // categorieToolStripMenuItem
            // 
            this.categorieToolStripMenuItem.Name = "categorieToolStripMenuItem";
            this.categorieToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.categorieToolStripMenuItem.Text = "Categorie";
            this.categorieToolStripMenuItem.Click += new System.EventHandler(this.categorieToolStripMenuItem_Click);
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
            this.ClientSize = new System.Drawing.Size(482, 353);
            this.Controls.Add(this.menuStrip);
            this.Name = "MainView";
            this.Text = "CiccioGest";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainView_FormClosed);
            this.Load += new System.EventHandler(this.MainView_Load);
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
        private System.Windows.Forms.ToolStripMenuItem apriArticoloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categorieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem informazionisuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opzioniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apriFatturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuovaFatturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apriClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuovoClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apriFornitoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuovoFornitoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuovoArticoloToolStripMenuItem;
    }
}
