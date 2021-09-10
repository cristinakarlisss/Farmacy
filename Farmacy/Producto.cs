using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacy
{
    public class Producto
    {
        public static int Id { get; set; }
        public static string CodigoBarras { get; set; }
        public static string Nombre { get; set; }
        public static int IdCategoria { get; set; }
        public static decimal Precio { get; set; }
        public static string Marca { get; set; }
        [DataType(DataType.Date)]
        public static DateTime Caducidad { get; set; } 
        public static string Descripcion { get; set; }
    }
}
