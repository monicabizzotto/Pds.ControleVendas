using Pds.ControleVendas.Dados;
using Pds.ControleVendas.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pds.ControleVendas.Negocio
{
	public class ProdutoNegocio
	{
		public ProdutoNegocio()
		{
		}

		public List<Produto> GetProdutos()
		{
			ProdutoDados produtoDados = new ProdutoDados();
			FornecedorNegocio fornecedorNegocio = new FornecedorNegocio();
			var produtos = produtoDados.GetProdutos();

			for (int i = 0; i < produtos.Count; i++)
			{
				produtos[i].Fornecedor = fornecedorNegocio.GetFornecedor(produtos[i].Fornecedor.Id);
			}

			return produtos;
		}
	}
}
