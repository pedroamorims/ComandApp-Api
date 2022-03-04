using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandApp.Domain.Entitities
{
    public  class Comanda
    {
        public Comanda(string codigo, bool ativo)
        {
            Codigo = codigo;
            Ativo = ativo;
        }

        public int Id { get; set; }

        public string Codigo { get; private set; }

        public bool Ativo { get; private set; }

    }
}
