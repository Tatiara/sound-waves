using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;

namespace Negocio
{
    public class Playlist
    {
        private Persistencia.Playlist p = new Persistencia.Playlist();
        public List<Modelo.Playlist> Select()
        {
            return p.Select();
        }
        public void Insert(Modelo.Playlist m)
        {
            if (m == null)
                throw new ArgumentNullException("Os dados não foram informados, por favor insira os dados necessários!");
            if (p.Select().Where(r => r.Id == m.Id).Count() > 0)
                throw new InvalidOperationException("Música já cadastrado...");
            p.Insert(m);
        }
        public void Update(Modelo.Playlist m)
        {
            p.Update(m);
        }
        public void Delete(Modelo.Playlist m)
        {
            p.Delete(m);
        }
    }
}
