using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Clases
{
    public class Ventas
    {

        public int IdVehiculo { get; set; }
        public int? IdCliente { get; set; }
        public int? IdVendedor { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal PrecioVenta { get; set; }
        public string MetodoPago { get; set; }

        public Ventas()
        {
        }

        public Ventas(int idVehiculo, int? idCliente, int idVendedor, DateTime fechaVenta, decimal precioVenta, string metodoPago)
        {
            IdVehiculo = idVehiculo;
            IdCliente = idCliente;
            IdVendedor = idVendedor;
            FechaVenta = fechaVenta;
            PrecioVenta = precioVenta;
            MetodoPago = metodoPago;
        }
    }
}

