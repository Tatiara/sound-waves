using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;

namespace Negocio
{
    public class Usuario
    {
        private Persistencia.Usuario p = new Persistencia.Usuario();
        public List<Modelo.Usuario> Select()
        {
            return p.Select();
        }
        public Modelo.Usuario Find(int id)
        {
            List<Modelo.Usuario> lista_u = p.Select();
            return lista_u.Find(u => u.Id == id);
        }
        public void Insert(Modelo.Usuario u)
        {
            if (u == null)
                throw new ArgumentNullException("Os dados não foram informados, por favor insira os dados necessários!");
            if (p.Select().Where(r => r.Id == u.Id).Count() > 0)
               throw new InvalidOperationException("Usuário já cadastrado...");
            p.Insert(u);
        }
        public void Update(Modelo.Usuario u)
        {
            p.Update(u);
        }
        public void Delete(Modelo.Usuario u)
        {
            p.Delete(u);
        }
    }
}
