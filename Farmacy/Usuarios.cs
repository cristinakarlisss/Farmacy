using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacy
{
    public class Usuarios
    {
        public static int Id { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static DateTime? LastUpd { get; set; }
        public static int UserLevel { get; set; }
    }
}
