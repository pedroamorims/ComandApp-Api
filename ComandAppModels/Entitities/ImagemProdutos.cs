namespace ComandApp.Domain.Entitities
{
    public class ImagemProduto
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public Produto Produtos { get; set; }


    }
}
