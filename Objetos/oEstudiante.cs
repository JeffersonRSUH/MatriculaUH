using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos
{
    public class oEstudiante
    {
        public string IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Identificacion { get; set; } // Numero de Cedual, Pasaporte, CarnetResidente
        public oCarrera Carrera { get; set; } // Objeto Carrera
        public DateTime FechaNacimiento { get; set; } // GetDate() en SQL
        public DateTime FechaIngreso { get; set; } // GetDate() en SQL
        public EstadoEstudiante Estado { get; set; } // Enum
        public TipoIdentificacion TipoIdentificacion { get; set; } // Enum
    }
}
