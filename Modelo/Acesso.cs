﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Acesso : IId
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Data { get; set; }
    }
}
