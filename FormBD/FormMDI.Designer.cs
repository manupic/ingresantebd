using System.Drawing;
using System.Windows.Forms;

namespace FormBD
{
    partial class FormMDI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoRegistroBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarEliminarRegistroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.exportacionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(686, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoRegistroBtn,
            this.modificarEliminarRegistroToolStripMenuItem});
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            // 
            // nuevoRegistroBtn
            // 
            this.nuevoRegistroBtn.Name = "nuevoRegistroBtn";
            this.nuevoRegistroBtn.Size = new System.Drawing.Size(216, 22);
            this.nuevoRegistroBtn.Text = "Nuevo Registro";
            this.nuevoRegistroBtn.Click += new System.EventHandler(this.nuevoRegistroBtn_Click);
            // 
            // modificarEliminarRegistroToolStripMenuItem
            // 
            this.modificarEliminarRegistroToolStripMenuItem.Name = "modificarEliminarRegistroToolStripMenuItem";
            this.modificarEliminarRegistroToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.modificarEliminarRegistroToolStripMenuItem.Text = "Modificar/Eliminar registro";
            // 
            // exportacionesToolStripMenuItem
            // 
            this.exportacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarXMLToolStripMenuItem});
            this.exportacionesToolStripMenuItem.Name = "exportacionesToolStripMenuItem";
            this.exportacionesToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.exportacionesToolStripMenuItem.Text = "Exportaciones";
            // 
            // exportarXMLToolStripMenuItem
            // 
            this.exportarXMLToolStripMenuItem.Name = "exportarXMLToolStripMenuItem";
            this.exportarXMLToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportarXMLToolStripMenuItem.Text = "Exportar XML/JSON";
            this.exportarXMLToolStripMenuItem.Click += new System.EventHandler(this.exportarXMLToolStripMenuItem_Click);
            // 
            // FormMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMDI";
            this.Text = "FormMDI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem inicioToolStripMenuItem;
        private ToolStripMenuItem nuevoRegistroBtn;
        private ToolStripMenuItem modificarEliminarRegistroToolStripMenuItem;
        private ToolStripMenuItem exportacionesToolStripMenuItem;
        private ToolStripMenuItem exportarXMLToolStripMenuItem;
    }
}