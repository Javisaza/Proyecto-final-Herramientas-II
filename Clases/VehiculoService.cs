using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Clases
{
    internal class VehiculoService
    {
        public List<Vehiculos> MapearVehiculos(DataTable dt)
        {
            var lista = new List<Vehiculos>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Vehiculos
                {
                    Marca = row["marca"].ToString(),
                    Modelo = row["modelo"].ToString(),
                    Anio = Convert.ToInt32(row["anio"]),
                    Color = row["color"].ToString(),
                    TipoCombustible = row["tipo_combustible"].ToString(),
                    Descripcion = row["descripcion"].ToString(),
                    Precio = Convert.ToDecimal(row["precio"]),
                    Kilometraje = Convert.ToInt32(row["kilometraje"])
                });
            }
            return lista;
        }
    }
}
