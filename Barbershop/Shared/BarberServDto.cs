using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbershop.Shared
{
    public class BarberServDto
    {
        public int Id { get; set; } = 0;
        public string Klippning { get; set; } = string.Empty;
        public int Tid { get; set; } = 0;
        public int Pris { get; set; } = 0;
      
    }
   
}
