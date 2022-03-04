using System;
using System.Collections.Generic;

namespace ComandApp.Domain.Entitities
{
    public class Produto
    {
        public Produto(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public Categoria Categoria { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataAlteracao { get; private set; }
        public IList<Tamanho> Tamanhos { get; set; }

    }
}
