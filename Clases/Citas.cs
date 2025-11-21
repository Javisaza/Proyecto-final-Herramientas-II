using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Clases
{
    public class Citas
    {

        public int IdCita { get; set; }
        public string NombreClienteReserva { get; set; }
        public string ApellidoClienteReserva { get; set; }
        public string EmailClienteReserva { get; set; }
        public string TelefonoClienteReserva { get; set; }
        public DateTime FechaHoraCita { get; set; }
        public string Motivo { get; set; }
        public int IdVehiculo { get; set; }
        public int IdClienteExistente { get; set; }
        public string IdentificacionClienteReserva { get; set; }
        public string EstadoCita { get; set; }
        public DateTime FechaRegistro { get; set; }

        // Datos del vehículo
        public string MarcaVehiculo { get; set; }
        public string ModeloVehiculo { get; set; }
        public int AnioVehiculo { get; set; }

        // Propiedad calculada
        public string Vehiculo
        {
            get { return $"{MarcaVehiculo}_{ModeloVehiculo}_{AnioVehiculo}"; } set { }
        }



    }
}
