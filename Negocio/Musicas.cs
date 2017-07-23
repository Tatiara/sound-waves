using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;

namespace Negocio
{
    public class Musicas
    {
        private Persistencia.Musica p = new Persistencia.Musica();
        public List<Modelo.Musica> Select()
        {
            return p.Select();
        }
        public void Insert(Modelo.Musica m)
        {
            if (m == null)
                throw new ArgumentNullException("Os dados não foram informados, por favor insira os dados necessários!");
            if (p.Select().Where(r => r.Id == m.Id).Count() > 0)
                throw new InvalidOperationException("Música já cadastrado...");
            p.Insert(m);
        }
        public void Update(Modelo.Musica m)
        {
            p.Update(m);
        }
        public void Delete(Modelo.Musica m)
        {
            p.Delete(m);
        }
    }
}
