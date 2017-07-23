using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;

namespace Negocio
{
    class Acessos
    {
        private Persistencia.Acesso p = new Persistencia.Acesso;
        public List<Modelo.Acesso> Escolher()
        {
            return p.Escolher();
        }    

        public void Inserir(Modelo.Acesso a)
        {
            if (a == null)
                throw new ArgumentNullException("Os dados não foram informados, por favor insira os dados necessários!");
            if (p.Escolher().Where(r => r.Id).Count() > 0)
                throw new InvalidOperationException("Usuário já cadastrado...");
            p.Inserir(a);
        }
        public void Att(Modelo.Acesso a)
        {
            p.Att(a);
        }
        public void Del(Modelo.Acesso a)
        {
            p.Del(a);
        }
    }
}
