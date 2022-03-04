using System;

namespace ComandApp.Domain.Entitities
{
    public class ComandaProduto
    {
        public int Id { get; private set; }

        public Comanda Comanda { get; set; }

        public Produto Produto { get; set; }

        public Tamanho Tamanho { get; set; }

        public decimal? Preco { get; private set; }

        public int Quantidade { get; private set; }

        public DateTime DataPedido { get; private set; }

        public bool Entregue { get; private set; }

        public decimal? Total()
        {
            return Preco * Quantidade;
        }


    }
}
