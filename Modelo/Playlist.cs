using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modelo
{
    public class Playlist : IId
    {
        public List<Musica> Musicas { get; set; }
        public int Id { get; set; }

    }
}
