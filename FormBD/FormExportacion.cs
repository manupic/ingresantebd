using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormBD
{
    public partial class FormExportacion : Form
    {
        public FormExportacion()
        {
            InitializeComponent();
        }

        private void btn_exportar_Click(object sender, EventArgs e)
        {
            Curso curso = null;

            if (rbC.Checked)
            {
                curso = new Curso(rbC.Text.Trim());
            }
            else if (rbCplus.Checked)
            {
                curso = new Curso(rbCplus.Text.Trim());
            }
            else if (rbJs.Checked)
            {
                curso = new Curso(rbJs.Text.Trim());
            }

            if (curso != null)
            {
                try
                {
                    curso.cargarInfoAlArrayIngresantes(this);

                    if (rbJson.Checked)
                    {
                        curso.exportarInfoJSON();
                        this.Vaciar();
                    }
                    else if (rbXml.Checked)
                    {
                        curso.exportarInfoXML();
                        this.Vaciar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar información: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void rbJson_CheckedChanged(object sender, EventArgs e)
        {
            btn_exportar.Enabled = true;
        }

        private void rbXml_CheckedChanged(object sender, EventArgs e)
        {
            btn_exportar.Enabled = true;
        }

        internal void Vaciar()
        {
            rbC.Checked = false;
            rbCplus.Checked = false;
            rbJs.Checked = false;
            rbJson.Checked = false;
            rbXml.Checked = false;
        }
    }
}
