using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos
{
    public class oMatricula
    {
        public int IdMatricula { get; set; }
        public oEstudiante IdEstudiante { get; set; }
        public oGrupo IdGrupo { get; set; }
    }
}
