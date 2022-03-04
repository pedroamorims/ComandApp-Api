using System.Collections.Generic;

namespace ComandApp.Domain.Entitities
{
    public class Categoria : Entity
    {
        public Categoria(string descricao, bool ativo, string iconURL)
        {
            Descricao = descricao;
            Ativo = ativo;
            IconURL = iconURL;
            Produtos = new List<Produto>();
        }

        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public string IconURL { get; private set; }

        public IList<Produto> Produtos { get; private set; }

        public void adicionarProduto(Produto produto)
        {
            if (produto is not null && !Produtos.Contains(produto))
            {
                Produtos.Add(produto);
            }
         
        }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Inativo()
        {
            Ativo = false;
        }

        public void AtualizarDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void AtualizarIcon(string iconurl)
        {
            IconURL = iconurl;
        }



    }
}
