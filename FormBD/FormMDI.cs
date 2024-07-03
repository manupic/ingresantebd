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
    public partial class FormMDI : Form
    {
        public FormMDI()
        {
            InitializeComponent();

        }

        private void nuevoRegistroBtn_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.MdiParent = this;
            f.Text = "Form - " + this.MdiChildren.Length.ToString();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void exportarXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExportacion f = new FormExportacion();
            f.MdiParent = this;
            f.Text = "Form - " + this.MdiChildren.Length.ToString();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
    }
}
