using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    class PlayList
    {
        private Persistencia.Playlist p = new Persistencia.Playlist();
        public List<Modelo.Playlist> Select()
        {
            return p.Select();
        }
        public void Insert(Modelo.Playlist l)
        {
            if (l == null)
                throw new ArgumentNullException("Os dados não foram informados, por favor insira os dados necessários!");
            if (p.Select().Where(r => r.Id == l.Id).Count() > 0)
                throw new InvalidOperationException("PlayList já cadastrado...");
            p.Insert(l);
        }
        public void Update(Modelo.Playlist l)
        {
            p.Update(l);
        }
        public void Delete(Modelo.Playlist l)
        {
            p.Delete(l);
        }
    }
}
