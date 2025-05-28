namespace ComandApp.Domain.ViewModels
{
    public class ComandaProdutoViewModel
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; } // Assuming Produto has a Nome property
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; } // Assuming Produto has a Preco property
        public decimal Subtotal => Quantidade * PrecoUnitario;
        public string Observacao { get; set; }
    }
}
