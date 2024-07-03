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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btoIngresar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            int edad = (int)nupEdad.Value;
            string cuit = mtbCUIT.Text.Trim();
            if (Funciones.ValidaCuit(cuit))
            {
                string genero = "";
                if (rbFemenino.Checked) genero = rbFemenino.Text.Trim();
                if (rbMasculino.Checked) genero = rbMasculino.Text.Trim();
                if (rbNoBinario.Checked) genero = rbNoBinario.Text.Trim();

                // Se inicializan los nombres de los cursos con stringBuilder
                StringBuilder curso_c = new StringBuilder("");
                StringBuilder curso_cplus = new StringBuilder("");
                StringBuilder curso_js = new StringBuilder("");

                // El curso chequeado toma el nombre y lo asigna al StringBuilder de arriba
                if (chkc.Checked)
                {
                    curso_c.Append(chkc.Text.Trim());
                }
                if (chkCplus.Checked)
                {
                    curso_cplus.Append(chkCplus.Text.Trim());
                }
                if (chkJavaScript.Checked)
                {
                    curso_js.Append(chkJavaScript.Text.Trim());
                }

                string[] curso = new string[3];

                // Controla que se haya seleccionado un curso
                if (curso_c.Equals("") && curso_cplus.Equals("") && curso_js.Equals(""))
                {
                    MessageBox.Show("Seleccione una opci�n para curso", "ATENCI�N", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    curso[0] = curso_c.ToString();
                    curso[1] = curso_cplus.ToString();
                    curso[2] = curso_js.ToString();

                    string pais = lbPais.Text.Trim();

                    // Validaciones de los campos
                    List<string> errores = new List<string>();

                    if (string.IsNullOrEmpty(nombre))
                    {
                        errores.Add("Complete el nombre\n");
                    }

                    if (string.IsNullOrEmpty(direccion))
                    {
                        errores.Add("Complete la dirección\n");
                    }

                    if (string.IsNullOrEmpty(pais))
                    {
                        errores.Add("Seleccione un país\n");
                    }

                    if (!rbMasculino.Checked && !rbFemenino.Checked && !rbNoBinario.Checked)
                    {
                        errores.Add("Seleccione un genero");
                    }

                    if (errores.Count == 0)
                    {
                        Ingresante ing = new Ingresante(nombre, direccion, edad, cuit, genero, pais, curso);
                        this.confirmarSubmit(ing);
                    }
                    else
                    {
                        string mensajeError = string.Join("\n", errores);
                        Funciones.mAdvertencia(this, mensajeError);
                    }
                    // FIN validaciones de los campos
                }
            }
            else
            {
                MessageBox.Show("Ingrese un Cuit Valido", "ATENCI�N", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        internal void Vaciar()
        {
            txtDireccion.Text = "";
            txtNombre.Text = "";
            nupEdad.Value = 18;
            mtbCUIT.Text = "";
            rbFemenino.Checked = false;
            rbMasculino.Checked = false;
            rbNoBinario.Checked = false;
            chkc.Checked = false;
            chkCplus.Checked = false;
            chkJavaScript.Checked = false;
            lbPais.Text = "";
        }

        internal void confirmarSubmit(Ingresante ingresante)
        {
            // Muesta la info del ingresante, la acepta o descarta
            if (Funciones.mConsulta(this, "Confirme los datos del ingresante \n\n" + ingresante.ToString()))
            {
                // Muestra los cursos que se inscribio
                if (MessageBox.Show(ingresante.ToStringCursos(), "Cursos Inscripto", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    // Recorre los cursos del ingresante
                    foreach (string curso_str in ingresante.Curso)
                    {
                        if (curso_str != "")
                        {
                            Curso curso = new Curso(curso_str);
                            //se inicializa el curso con los datos
                            curso.guardarIngresanteEnTxt(ingresante);
                        }
                    }
                    this.Vaciar();
                }
                else
                {
                    MessageBox.Show("Verifique los datos e intente nuevamente", "ATENCI�N", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Datos descartados", "ATENCI�N", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Vaciar();
            }
        }

        private void btoIngresar_Click_1(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            int edad = (int)nupEdad.Value;
            string cuit = mtbCUIT.Text.Trim();
            if (Funciones.ValidaCuit(cuit))
            {
                string genero = "";
                if (rbFemenino.Checked) genero = rbFemenino.Text.Trim();
                if (rbMasculino.Checked) genero = rbMasculino.Text.Trim();
                if (rbNoBinario.Checked) genero = rbNoBinario.Text.Trim();

                // Se inicializan los nombres de los cursos con stringBuilder
                StringBuilder curso_c = new StringBuilder("");
                StringBuilder curso_cplus = new StringBuilder("");
                StringBuilder curso_js = new StringBuilder("");

                // El curso chequeado toma el nombre y lo asigna al StringBuilder de arriba
                if (chkc.Checked)
                {
                    curso_c.Append(chkc.Text.Trim());
                }
                if (chkCplus.Checked)
                {
                    curso_cplus.Append(chkCplus.Text.Trim());
                }
                if (chkJavaScript.Checked)
                {
                    curso_js.Append(chkJavaScript.Text.Trim());
                }

                string[] curso = new string[3];

                // Controla que se haya seleccionado un curso
                if (curso_c.Equals("") && curso_cplus.Equals("") && curso_js.Equals(""))
                {
                    MessageBox.Show("Seleccione una opci�n para curso", "ATENCI�N", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    curso[0] = curso_c.ToString();
                    curso[1] = curso_cplus.ToString();
                    curso[2] = curso_js.ToString();

                    string pais = lbPais.Text.Trim();

                    // Validaciones de los campos
                    List<string> errores = new List<string>();

                    if (string.IsNullOrEmpty(nombre))
                    {
                        errores.Add("Complete el nombre\n");
                    }

                    if (string.IsNullOrEmpty(direccion))
                    {
                        errores.Add("Complete la dirección\n");
                    }

                    if (string.IsNullOrEmpty(pais))
                    {
                        errores.Add("Seleccione un país\n");
                    }

                    if (!rbMasculino.Checked && !rbFemenino.Checked && !rbNoBinario.Checked)
                    {
                        errores.Add("Seleccione un genero");
                    }

                    if (errores.Count == 0)
                    {
                        Ingresante ing = new Ingresante(nombre, direccion, edad, cuit, genero, pais, curso);
                        this.confirmarSubmit(ing);
                    }
                    else
                    {
                        string mensajeError = string.Join("\n", errores);
                        Funciones.mAdvertencia(this, mensajeError);
                    }
                    // FIN validaciones de los campos
                }
            }
            else
            {
                MessageBox.Show("Ingrese un Cuit Valido", "ATENCI�N", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
    }
}
