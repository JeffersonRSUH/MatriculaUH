using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos
{
    public class oGrupo
    {
        public int IdGrupo { get; set; }
        public oMateria Materia { get; set; } // Objeto Materia
        public int NumeroGrupo { get; set; }
        public Horario Horario { get; set; } // Enum
        public int Cupo { get; set; }
        public EstadoGrupo Estado { get; set; } // Enum
    }
}
