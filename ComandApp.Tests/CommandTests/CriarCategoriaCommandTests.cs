using ComandApp.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComandApp.Tests.Models
{
    [TestClass]
    public class CriarCategoriaCommandTests
    {

        private readonly CriarCategoriaCommand _invalidCommand = new CriarCategoriaCommand("", true, "teste");
        private readonly CriarCategoriaCommand _validCommand = new CriarCategoriaCommand("Bebidas", true, "http://www.teste.com");


        [TestMethod]
        public void Dado_um_comando_invalido()
        {
            Assert.AreEqual(_invalidCommand.IsValid, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido()
        {
            Assert.AreEqual(_validCommand.IsValid, true);
        }

        /* [TestMethod]
         [TestCategory("Domain")]

         public void negar_inclusao_de_produto_nulo_na_categoria()
         {
             var categoria = new Categoria("Bebidas",true,"teste.com");
             var produto = new Produto("Brahma", "Pilsen");

             categoria.adicionarProduto(null);

             Assert.AreEqual(0, categoria.Produtos.Count);
         }

         [TestMethod]
         [TestCategory("Domain")]
         public void negar_inclusao_de_produto_repetido_na_categoria()
         {
             var categoria = new Categoria("Bebidas", true, "teste.com");
             var produto = new Produto("Brahma", "Pilsen");

             categoria.adicionarProduto(produto);

             var quantidade = categoria.Produtos.Count;

             var produto2 = new Produto("Brahma", "Pilsen");

             categoria.adicionarProduto(produto);

             Assert.AreEqual(quantidade, categoria.Produtos.Count);
         }*/
    }
}
