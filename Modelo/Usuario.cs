using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Admin { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Nome} - {Admin}";
            if (Admin == true)
            {
                return Nome + "Administrador";
            }
            else return Nome + "Usuario";
        }
    }
}
