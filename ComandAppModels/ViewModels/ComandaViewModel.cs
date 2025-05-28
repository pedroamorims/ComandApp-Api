using System;
using System.Collections.Generic;
using System.Linq;

namespace ComandApp.Domain.ViewModels
{
    public class ComandaViewModel
    {
        public int Id { get; set; }
        public int Mesa { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Status { get; set; } // Consider using an Enum or specific status strings
        public List<ComandaProdutoViewModel> Produtos { get; set; }
        public decimal TotalComanda => Produtos?.Sum(p => p.Subtotal) ?? 0;

        public ComandaViewModel()
        {
            Produtos = new List<ComandaProdutoViewModel>();
        }
    }
}
