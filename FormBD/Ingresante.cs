using System;
using System.Text;

namespace FormBD
{
    public class Ingresante
    {
        private string nombre;
        private string direccion;
        private int edad;
        private string cuit;
        private string genero;
        private string pais;
        private string[] curso;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Pais { get => pais; set => pais = value; }
        public string[] Curso { get => curso; set => curso = value; }
        public string Cuit { get => cuit; set => cuit = value; }

        public Ingresante() { }

        public Ingresante(string nombre, string direccion, int edad, string cuit, string genero, string pais, string[] curso)
        {
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Edad = edad;
            this.Cuit = cuit;
            this.Genero = genero;
            this.Curso = curso;
            this.Pais = pais;
        }

        public Ingresante(string nombre, string cuit, string genero, int edad, string pais, string direccion)
        {
            this.Nombre = nombre;
            this.Cuit = cuit;
            this.Genero = genero;
            this.Edad = edad;
            this.Pais = pais;
            this.Direccion = direccion;
        }

        // Muestra en pantalla los datos ingresados
        public override String ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Nombre: {Nombre}");
            stringBuilder.AppendLine($"Dirección: {Direccion}");
            stringBuilder.AppendLine($"Edad: {Edad}");
            stringBuilder.AppendLine($"Cuit: {Cuit}");
            stringBuilder.AppendLine($"Género: {Genero}");
            stringBuilder.AppendLine($"País: {Pais}");

            return stringBuilder.ToString();
        }

        // Muestra en pantalla los cursos seleccionados
        public String ToStringCursos()
        {
            return "Los cursos seleccionados son: \n" + curso[0] + "\n" + curso[1] + "\n" + curso[2];
        }
    }
}
