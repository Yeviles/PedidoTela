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
            // detalle.Total = (row.Cells[11].Value != null && row.Cells[11].Value.ToString() != "") ? int.Parse(row.Cells[11].Value.ToString()) : 0;

            //decimal total;
            //string result;
            double t = (totalUnidades.ToString() != null && totalUnidades.ToString() != "") ? double.Parse(totalUnidades.ToString()) : 0;
            //decimal cont = 1.10m;
            //total = ((t) * decimal.Parse(consumo)) * cont;
            // decimal vfinal = Decimal.Round(total, 3);
            //result = Convert.ToString(vfinal);
            double total;
            string result;
            double cont = 1.10D;
            double a = Convert.ToDouble(consumo);
            //decimal separator will always be '.'
            string txt = a.ToString(CultureInfo.InvariantCulture);
            double a2 = double.Parse(txt,CultureInfo.InvariantCulture);
            total = ((t * a2) * cont);
            //back to a double
            result = Convert.ToString(total);

            return result;
        }
        public string mSolicitar(string mCalculado, string mReservar)
        {
            decimal total;
            string result;

            decimal m = (mCalculado.ToString() != null && mCalculado.ToString() != "") ? Decimal.Parse(mCalculado.ToString()) : 0;
            int t = (mReservar.ToString() != null && mReservar.ToString() != "") ? int.Parse(mReservar.ToString()) : 0;

            total = (m) - (t) * -1;
            decimal vfinal = Decimal.Round(total, 1);
            result = Convert.ToString(vfinal);
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
    }
}
