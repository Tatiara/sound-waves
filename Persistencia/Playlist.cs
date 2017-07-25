using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Persistencia
{
    public class Playlist
    {
        private string arquivo = "c:\\Users\\Tatiara\\Desktop\\usuario.json";
        public List<Modelo.Playlist> Select()
        {
            return Arquivo<Modelo.Playlist>.Select(arquivo);
        }
        public void Insert(Modelo.Playlist u)
        {
            Arquivo<Modelo.Playlist>.Insert(arquivo, u);
        }
        public void Update(Modelo.Playlist u)
        {
            Arquivo<Modelo.Playlist>.Update(arquivo, u);
        }
        public void Delete(Modelo.Playlist u)
        {
            Arquivo<Modelo.Playlist>.Delete(arquivo, u);
        }

    }
}
