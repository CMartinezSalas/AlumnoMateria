using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Materia
    {
        public int IdMateria { get; set; }
        public String Nombre { get; set; }
        public Decimal Costo { get; set; }
        public List<Object> Materias { get; set; }
    }
}
