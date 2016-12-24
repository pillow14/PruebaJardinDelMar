using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core
{
    public class Jugadores
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public double Estatura { get; set; }
        public double Peso { get; set; }
        public string Rut { get; set; }
        public string Domicilio{get;set;}
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
