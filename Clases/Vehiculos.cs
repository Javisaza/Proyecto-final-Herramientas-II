using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare
{
    public class Vehiculos
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public int Kilometraje { get; set; }
        public string Color { get; set; }
        public string Estado { get; set; }
        public string TipoCombustible { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        

        public Vehiculos() { }

        public Vehiculos(string marca, string modelo, int año, int Km, string color,string estado, string tipoCombustible, string descripcion, int precio)
        {
            Marca = marca;
            Modelo = modelo;
            Anio = año;
            Kilometraje = Km;
            Color = color;
            Estado=estado;
            TipoCombustible = tipoCombustible;
            Descripcion=descripcion;
            Precio=precio;
        }
    }
}
