using System;
using System.Collections.Generic;

namespace ComandApp.Domain.Entitities
{
    public class Produto : Entity
    {
        public Produto(string nome, string descricao, bool ativo)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            DataCriacao = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public Categoria Categoria { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataAlteracao { get; private set; }
        public IList<Tamanho> Tamanhos { get; private set; }
        public bool Ativo { get; private set; }

        public void defineCategoria(Categoria categoria)
        {
            Categoria = categoria;
        }

    }
}
