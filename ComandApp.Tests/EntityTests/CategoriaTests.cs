using ComandApp.Domain.Entitities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComandApp.Tests.Models
{
    [TestClass]
    public class CategoriaTests
    {
        private readonly Categoria _validcategoria = new Categoria("Bebida", true, "http://www.teste.com");

        [TestMethod]
        public void Dado_uma_nova_categoria_lista_de_produtos_tem_que_ser_vazia()
        {
            Assert.AreEqual(0, _validcategoria.Produtos.Count);
        }




    }
}
