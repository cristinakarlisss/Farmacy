using System;
using System.Drawing;
using System.Windows.Forms;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Microsoft.ReportingServices;
using Microsoft.Reporting.WinForms;

namespace Farmacy
{
    public partial class Print_Preview : Form
    {
        public Print_Preview()
        {
            InitializeComponent();
        }
        SQL_Connection connection = new SQL_Connection();
        private void Print_Preview_Load(object sender, EventArgs e)
        {
            Crear();
        }
        private void Crear()
        {
            connection.ReturnLastSale();
            connection.LoadPreview(ReportViewer1, Program._venta, DataTable1BindingSource, Program._importe);
        }
    }
}
