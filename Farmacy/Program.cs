using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacy
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static bool _isLogin { get; set; }
        public static string _userName { get; set; }
        public static int _userId { get; set; }
        public static int _id { get; set; }
        public static bool _delete { get; set; }
        public static string _option { get; set; }
        public static bool _edit { get; set; }
        public static int _venta { get; set; }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
