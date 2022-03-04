using System;

namespace ComandApp.Domain.Entitities
{
    public class Tamanho
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public decimal? Preco { get; set; }

        public Produto Produto { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastUpdateDate  { get; set; }
    }
}
