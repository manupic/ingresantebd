using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FormBD
{
    internal class Curso
    {
        string nombre;
        ArrayList lista_ingresantes = new ArrayList();

        public Curso() { }

        public Curso(string nombre)
        {
            this.Nombre = nombre;
        }

        public string Nombre { get => nombre; set => nombre = value; }

        public void guardarIngresanteEnTxt(Ingresante ingresante)
        {
            // Obtener la ruta de la carpeta Descargas del usuario
            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string filePath = Path.Combine(downloadsPath, this.nombre + ".txt");

            //string de cursos p almacenarlos en la BD
            string cursos_str = string.Join(",", ingresante.Curso);
            
            //obtenemos el string de conexion
            string stringConexion = ConfigurationManager.AppSettings["conexion"];   

            using (SqlConnection conn = new SqlConnection(stringConexion))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Conexion exitosa");

                    string insertQuery = "INSERT INTO dbo.Ingresantes (nombre, cuit, genero, edad, pais, domicilio, cursos) VALUES (@nombre, @cuit, @genero, @edad, @pais, @domicilio, @cursos)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", ingresante.Nombre);
                        cmd.Parameters.AddWithValue("@cuit", ingresante.Cuit.Replace("-", ""));
                        cmd.Parameters.AddWithValue("@genero", ingresante.Genero);
                        cmd.Parameters.AddWithValue("@edad", ingresante.Edad);
                        cmd.Parameters.AddWithValue("@pais", ingresante.Pais);
                        cmd.Parameters.AddWithValue("@domicilio", ingresante.Direccion);
                        cmd.Parameters.AddWithValue("@cursos", cursos_str);

                        int rowsAffected = cmd.ExecuteNonQuery();                        
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            // Verificar si el archivo existe. 
            // Si no existe lo creamos y guardamos el ingresante            
            if (!File.Exists(filePath))
            {
                // Si el archivo no existe, agregar el ingresante                
                StreamWriter writer = null;
                try
                {
                    writer = new StreamWriter(filePath, true);
                    writer.WriteLine(formatoIngresante(ingresante));
                }
                catch (Exception e)
                {
                    Console.Write(e.ToString());
                }
                finally
                {
                    if (writer != null)
                    {
                        writer.Close();
                        writer.Dispose();
                    }
                }
            }
            else
            {
                // Si existe el archivo
                agregarIngresanteAlCurso(filePath, ingresante);
            }
        }

        public string formatoIngresante(Ingresante ingresante)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ingresante.Nombre).Append("|");
            sb.Append(ingresante.Cuit.Replace("-", "")).Append("|");
            sb.Append(ingresante.Genero).Append("|");
            sb.Append(ingresante.Edad).Append("|");
            sb.Append(ingresante.Pais).Append("|");
            sb.Append(ingresante.Direccion);
            return sb.ToString();
        }

        public void agregarIngresanteAlCurso(string path, Ingresante ingresante)
        {
            // Leemos todas las líneas del archivo y las guardamos en un arreglo de cadenas
            string[] lista_ingresantes = File.ReadAllLines(path);

            if (lista_ingresantes.Length < 40)
            {
                // Inicializamos una variable booleana para indicar si el ingresante ya existe en el archivo
                bool ingresanteExiste = false;

                // Recorremos cada registro en el archivo
                foreach (string registro in lista_ingresantes)
                {
                    // Dividimos el registro en partes usando el carácter "|" como separador
                    string[] partes = registro.Split('|');

                    // Extraemos el CUIT de cada registro
                    string cuit = partes[1];                    

                    // Comparamos el DNI con el Cuit del ingresante
                    if (ingresante.Cuit.Replace("-", "") == cuit)
                    {
                        // Si el Cuit ya existe en el archivo, seteamos la variable existe a true
                        ingresanteExiste = true;
                        string message_error = "El ingresante con CUIT " + ingresante.Cuit + " ya existe en el curso: " + this.Nombre;
                        MessageBox.Show(message_error, "Error: Ingresante Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        break;
                    }
                }

                // Si el Cuit no existe en el archivo, agregamos el nuevo ingresante
                if (!ingresanteExiste)
                {
                    StreamWriter writer = null;
                    try
                    {
                        writer = new StreamWriter(path, true);
                        writer.WriteLine(formatoIngresante(ingresante));
                    }
                    catch (Exception e)
                    {
                        Console.Write(e.ToString());
                    }
                    finally
                    {
                        if (writer != null)
                        {
                            writer.Close();
                            writer.Dispose();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No se puede registrar el ingresante porque hay más de 40 personas para este curso.", "ERROR: Exceso de registros", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public void cargarInfoAlArrayIngresantes(Form actual)
        {
            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string filePath = Path.Combine(downloadsPath, this.nombre + ".txt");

            // Verificar si el archivo existe
            if (File.Exists(filePath))
            {
                try
                {
                    string[] ingresantes = File.ReadAllLines(filePath);

                    // Agrega cada ingresante del txt al array
                    foreach (string registro in ingresantes)
                    {
                        string[] partes = registro.Split('|');
                        Ingresante ingresante = new Ingresante(partes[0], partes[1], partes[2], Convert.ToInt32(partes[3]), partes[4], partes[5]);
                        lista_ingresantes.Add(ingresante);
                    }
                }
                catch (Exception ex)
                {
                    Funciones.mError(actual, ex.Message);
                }
            }
            else
            {
                // Arroja el error y finaliza la ejecución
                throw new Exception("Archivo no encontrado.");
            }
        }

        public void exportarInfoXML()
        {
            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string filePath = Path.Combine(downloadsPath, this.nombre + ".xml");

            StreamWriter streamWriter = null;

            try
            {
                // Crea un objeto StreamWriter que escribe el archivo ubicado en la ruta especificada
                streamWriter = new StreamWriter(filePath, true);
                // Crea un objeto XmlSerializer que se utiliza para serializar objetos de tipo Ingresante a XML.
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Ingresante));

                MessageBox.Show("Exportando archivo", "EXPORTANDO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                foreach (Ingresante ingresante in this.lista_ingresantes)
                {
                    // Serializa cada objeto a XML
                    xmlSerializer.Serialize(streamWriter, ingresante);
                }
                MessageBox.Show("Exportación exitosa", "EXPORTANDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
        }

        public void exportarInfoJSON()
        {
            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string filePath = Path.Combine(downloadsPath, this.nombre + ".json");

            StreamWriter streamWriter = null;

            try
            {
                // Crea un objeto StreamWriter que escribe el archivo ubicado en la ruta especificada
                streamWriter = new StreamWriter(filePath, true);

                MessageBox.Show("Exportando archivo", "EXPORTANDO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                foreach (Ingresante ingresante in this.lista_ingresantes)
                {
                    string jsonString = JsonSerializer.Serialize(ingresante);
                    streamWriter.WriteLine(jsonString);
                }
                MessageBox.Show("Exportación exitosa", "EXPORTANDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }

        }

    }
}
