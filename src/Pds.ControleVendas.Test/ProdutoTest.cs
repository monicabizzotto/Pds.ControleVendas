using System;
using System.Collections.Generic;
using Xunit;

namespace Pds.ControleVendas.Test
{
	public class ProdutoTest
	{
		[Fact]
		public void ListarProdutos()
		{
			var produtoNegocio = new Negocio.ProdutoNegocio();
			
			Assert.NotNull(produtoNegocio);
			Assert.IsType<Negocio.ProdutoNegocio>(produtoNegocio);

			var produtos = produtoNegocio.GetProdutos();

			Assert.NotNull(produtoNegocio);
			Assert.IsType<List<Dominio.Produto>>(produtos);
			Assert.True(produtos.Count >= 0);

			for (int i = 0; i < produtos.Count; i++)
			{
				Assert.NotNull(produtos[i]);
				Assert.IsType<Dominio.Produto>(produtos[i]);

				Assert.True(produtos[i].Id >= 1);

				Assert.NotNull(produtos[i].Nome);
				Assert.True(produtos[i].Nome.Length <= 100);

				Assert.NotNull(produtos[i].Fornecedor);
				Assert.IsType<Dominio.Fornecedor>(produtos[i].Fornecedor);
			}
		}
	}
}
