using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Persistencia
{
    public class Musica
    {
        private string arquivo = "c:\\Users\\Tatiara\\Desktop\\usuario.json";
        public List<Modelo.Musica> Select()
        {
            return Arquivo<Modelo.Musica>.Select(arquivo);
        }
        public void Insert(Modelo.Musica u)
        {
            Arquivo<Modelo.Musica>.Insert(arquivo, u);
        }
        public void Update(Modelo.Musica u)
        {
            Arquivo<Modelo.Musica>.Update(arquivo, u);
        }
        public void Delete(Modelo.Musica u)
        {
            Arquivo<Modelo.Musica>.Delete(arquivo, u);
        }
    }
}
