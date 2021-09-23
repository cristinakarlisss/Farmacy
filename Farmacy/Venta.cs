using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacy
{
    public class Venta
    {
        public static int Id { get; set; }
        public static int Cantidad { get; set; }
        public static DateTime Fecha { get; set; }
        public static int UserId { get; set; }
        public static double ValorVenta { get; set; }
        public static double Subtotal { get; set; }
        public static double IGV { get; set; }
        public static double Total { get; set; }


    }
}
