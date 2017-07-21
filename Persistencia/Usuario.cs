using System;
using System.Collections.Generic;
//using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Persistencia 
{
    class Usuario 
    {
        private string arquivo = "c:\\Users\\Tatiara\\Desktop\\usuario.json";
        public List<Modelo.Usuario> Select()
        {
            return Arquivo<Modelo.Usuario>.Select(arquivo);
        }
        public void Insert(Modelo.Usuario u)
        {
            Arquivo<Modelo.Usuario>.Insert(arquivo, u);
        }
        public void Update(Modelo.Usuario u)
        {
            Arquivo<Modelo.Usuario>.Update(arquivo, u);
        }
        public void Delete(Modelo.Usuario u)
        {
            Arquivo<Modelo.Usuario>.Delete(arquivo, u);
        }

    }
}
