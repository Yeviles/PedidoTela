using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidoTela.Entidades.Logica
{
    public class Utilidades
    {
        public string mCalculados2(string totalUnidades, string consumo)
        {
            /*Para el campo M Calculados se requiere que el sistema realice la siguiente operación : (Total unidades*Consumo) *  1.10*/

            CultureInfo culture = new CultureInfo("en-US");
            decimal totalUni = (totalUnidades.ToString() != null && totalUnidades.ToString() != "") ? decimal.Parse(totalUnidades.ToString(),culture) : 0;
            decimal con = (consumo.ToString() != null && consumo.ToString() != "") ? decimal.Parse(consumo.ToString(), culture) : 0;
            decimal constante = 1.10m;
            decimal total = totalUni * con * constante;
            decimal vfinal = Decimal.Round(total, 2);

            string result = Convert.ToString(vfinal).Replace(",","."); 
            return result;
        }
        public string mSolicitar(string mCalculado, string mReservar)
        {
            /*M a Solicitar debe ser la diferencia entre M Calculados  -  Mreservados. */
 
            CultureInfo culture = new CultureInfo("en-US");
       
            decimal m = (mCalculado.ToString() != null && mCalculado.ToString() != "") ? decimal.Parse(mCalculado.ToString(),culture) : 0;
            decimal t = (mReservar.ToString() != null && mReservar.ToString() != "") ? decimal.Parse(mReservar.ToString(),culture) : 0;

            decimal total = (m) - (t);
            decimal vfinal = Decimal.Round(total, 2);
            
            string result = Convert.ToString(vfinal).Replace(",",".");

            return result;

        }
        public string DisponibleTeorico(string disponible, string mReservar)
        {
            /*Para este  campo  se requiere   que  el  sistema  realice   siguiente    operación  (  Disponible -  Cantidad    Reservada )  */
            CultureInfo culture = new CultureInfo("en-US");
            decimal d = (disponible.ToString() != null && disponible.ToString() != "") ? decimal.Parse(disponible.ToString(), culture) : 0;
            decimal r = (mReservar.ToString() != null && mReservar.ToString() != "") ? decimal.Parse(mReservar.ToString(), culture) : 0;

            decimal total = ((d) - (r));
            Math.Abs(total);
            decimal vfinal = Decimal.Round(total, 2);
            
            string result = Convert.ToString(vfinal).Replace(",", ".");

            return result;
        }
        public int ContarChecked(DataGridView prmDataGridView)
        {
            //CONTAR SOLO CHECKS SELECCIONADOS
            int contador = 0;
            foreach (DataGridViewRow row in prmDataGridView.Rows)
            {
                if (row.Cells[0].Value.Equals(true))//Columna de checks
                {
                    contador++;
                }
            }
            return contador;
        }
        public int Cifras(int numero)
        {
            int contador = 0;
            while (numero > 0)
            {
                numero = numero / 10;

                contador = contador + 1;
            }
            return contador;
        }
    }
}
