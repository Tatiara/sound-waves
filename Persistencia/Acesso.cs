using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Persistencia
{
    public class Acesso 
    {
        private string arquivo = "c:\\Users\\Tatiara\\Desktop\\acesso.json";
        public List<Modelo.Acesso> Select()
        {
            return Arquivo<Modelo.Acesso>.Select(arquivo);
        }
        public void Insert(Modelo.Acesso u)
        {
            Arquivo<Modelo.Acesso>.Insert(arquivo, u);
        }
        public void Update(Modelo.Acesso u)
        {
            Arquivo<Modelo.Acesso>.Update(arquivo, u);
        }
        public void Delete(Modelo.Acesso u)
        {
            Arquivo<Modelo.Acesso>.Delete(arquivo, u);
        }
    }
}
