using System.Text;
using System.Windows.Forms;

namespace FormBD
{
    internal static class Funciones

    {    
            /*
          <summary>
           Calcula el dígito verificador dado un CUIT completo o sin él.
           </summary>
           <param name="cuit">El CUIT como String sin guiones</param>
           <returns>El valor del dígito verificador calculado.</returns>
           */
            private static int CalcularDigitoCuit(string cuit)
            {
                int[] mult = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                char[] nums = cuit.ToCharArray();
                int total = 0;

                for (int i = 0; i < mult.Length; i++)
                {
                    total += int.Parse(nums[i].ToString()) * mult[i];
                }

                var resto = total % 11;
                return resto == 0 ? 0 : resto == 1 ? 9 : 11 - resto;
            }


            /* <summary>
             Valida el CUIT ingresado.
             </summary>
             <param name="cuit" />Número de CUIT como string con o sin guiones
             <returns>True si el CUIT es válido y False si no.</returns>
            */
            public static bool ValidaCuit(string cuit)
            {
                if (cuit == null)
                {
                    return false;
                }
                //Quito los guiones, el cuit resultante debe tener 11 caracteres.
                cuit = cuit.Replace("-", string.Empty);
                if (cuit.Length != 11)
                {
                    return false;
                }
                else
                {
                    int calculado = CalcularDigitoCuit(cuit);
                    int digito = int.Parse(cuit.Substring(10));
                    return calculado == digito;
                }
            }
            
            public static string formatoCuit(string cuit)
            {
                return cuit.Replace("-", "");
            }

            public static string formatoIngresante(Ingresante ingresante)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ingresante.Nombre).Append("|");
                sb.Append(formatoCuit(ingresante.Cuit)).Append("|");
                sb.Append(ingresante.Genero).Append("|");
                sb.Append(ingresante.Edad).Append("|");
                sb.Append(ingresante.Pais).Append("|");
                sb.Append(ingresante.Direccion);
                return sb.ToString();
            }

            public static void mError(Form actual, string mensaje)
            {
                MessageBox.Show(actual, mensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //Para mostrar mensaje de confirmación
            public static void mOk(Form actual, string mensaje)
            {
                MessageBox.Show(actual, mensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            public static bool mConsulta(Form actual, string mensaje)
            {
                if (MessageBox.Show(actual, mensaje, "CONSULTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public static void mAdvertencia(Form actual, string mensaje)
            {
                MessageBox.Show(actual, mensaje, "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }        
    }
}
