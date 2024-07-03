using System.Drawing;
using System.Windows.Forms;

namespace FormBD
{
    partial class FormExportacion
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
            this.rbC = new System.Windows.Forms.RadioButton();
            this.rbCplus = new System.Windows.Forms.RadioButton();
            this.rbJs = new System.Windows.Forms.RadioButton();
            this.btn_exportar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbJson = new System.Windows.Forms.RadioButton();
            this.rbXml = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbC
            // 
            this.rbC.AutoSize = true;
            this.rbC.Location = new System.Drawing.Point(12, 19);
            this.rbC.Name = "rbC";
            this.rbC.Size = new System.Drawing.Size(39, 17);
            this.rbC.TabIndex = 0;
            this.rbC.TabStop = true;
            this.rbC.Text = "C#";
            this.rbC.UseVisualStyleBackColor = true;
            // 
            // rbCplus
            // 
            this.rbCplus.AutoSize = true;
            this.rbCplus.Location = new System.Drawing.Point(12, 41);
            this.rbCplus.Name = "rbCplus";
            this.rbCplus.Size = new System.Drawing.Size(44, 17);
            this.rbCplus.TabIndex = 1;
            this.rbCplus.TabStop = true;
            this.rbCplus.Text = "C++";
            this.rbCplus.UseVisualStyleBackColor = true;
            // 
            // rbJs
            // 
            this.rbJs.AutoSize = true;
            this.rbJs.Location = new System.Drawing.Point(12, 62);
            this.rbJs.Name = "rbJs";
            this.rbJs.Size = new System.Drawing.Size(75, 17);
            this.rbJs.TabIndex = 2;
            this.rbJs.TabStop = true;
            this.rbJs.Text = "JavaScript";
            this.rbJs.UseVisualStyleBackColor = true;
            // 
            // btn_exportar
            // 
            this.btn_exportar.Enabled = false;
            this.btn_exportar.Location = new System.Drawing.Point(168, 247);
            this.btn_exportar.Name = "btn_exportar";
            this.btn_exportar.Size = new System.Drawing.Size(64, 20);
            this.btn_exportar.TabIndex = 3;
            this.btn_exportar.Text = "Exportar";
            this.btn_exportar.UseVisualStyleBackColor = true;
            this.btn_exportar.Click += new System.EventHandler(this.btn_exportar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbC);
            this.groupBox1.Controls.Add(this.rbCplus);
            this.groupBox1.Controls.Add(this.rbJs);
            this.groupBox1.Location = new System.Drawing.Point(116, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 87);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cursos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbJson);
            this.groupBox2.Controls.Add(this.rbXml);
            this.groupBox2.Location = new System.Drawing.Point(116, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 68);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo";
            // 
            // rbJson
            // 
            this.rbJson.AutoSize = true;
            this.rbJson.Location = new System.Drawing.Point(12, 19);
            this.rbJson.Name = "rbJson";
            this.rbJson.Size = new System.Drawing.Size(53, 17);
            this.rbJson.TabIndex = 0;
            this.rbJson.TabStop = true;
            this.rbJson.Text = "JSON";
            this.rbJson.UseVisualStyleBackColor = true;
            this.rbJson.CheckedChanged += new System.EventHandler(this.rbJson_CheckedChanged);
            // 
            // rbXml
            // 
            this.rbXml.AutoSize = true;
            this.rbXml.Location = new System.Drawing.Point(12, 41);
            this.rbXml.Name = "rbXml";
            this.rbXml.Size = new System.Drawing.Size(47, 17);
            this.rbXml.TabIndex = 1;
            this.rbXml.TabStop = true;
            this.rbXml.Text = "XML";
            this.rbXml.UseVisualStyleBackColor = true;
            this.rbXml.CheckedChanged += new System.EventHandler(this.rbXml_CheckedChanged);
            // 
            // FormExportacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 319);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_exportar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormExportacion";
            this.Text = "FormExportacion";            
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RadioButton rbC;
        private RadioButton rbCplus;
        private RadioButton rbJs;
        private Button btn_exportar;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private RadioButton rbJson;
        private RadioButton rbXml;
    }
}