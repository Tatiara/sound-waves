using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;

namespace Negocio
{
    public class Acessos
    {
        private Persistencia.Acesso p = new Persistencia.Acesso();
        public List<Modelo.Acesso> Select()
        {
            return p.Select();
        }    

        public void Insert(Modelo.Acesso a)
        {
            if (a == null)
                throw new ArgumentNullException("Os dados não foram informados, por favor insira os dados necessários!");
            if (p.Select().Where(r => r.Id == a.Id).Count() > 0)
                throw new InvalidOperationException("Dados já cadastrados...");
            p.Insert(a);
        }
        public void Update(Modelo.Acesso a)
        {
            p.Update(a);
        }
        public void Delete(Modelo.Acesso a)
        {
            p.Delete(a);
        }
    }
}
