using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Musica : IId
    {
        public string Titulo { get; set; }
        public string Cantor { get; set; }
        public int Id { get; set; }
        public override string ToString()
        {
            return $"{Titulo} - {Cantor}";
        }
    }
}
