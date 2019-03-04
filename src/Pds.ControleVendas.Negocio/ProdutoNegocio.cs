using Amazon.S3;
using Pds.ControleVendas.Dados;
using Pds.ControleVendas.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pds.ControleVendas.Negocio
{
	public class ProdutoNegocio
	{
		private IAmazonS3 s3Client;
		public ProdutoNegocio(IAmazonS3 s3Client)
		{
			this.s3Client = s3Client;
		}

		public List<Produto> GetProdutos()
		{
			ProdutoDados produtoDados = new ProdutoDados(s3Client);
			FornecedorNegocio fornecedorNegocio = new FornecedorNegocio();
			var produtos = produtoDados.GetProdutos();

			for (int i = 0; i < produtos.Count; i++)
			{
				produtos[i].Fornecedor = fornecedorNegocio.GetFornecedor(produtos[i].Fornecedor.Id);
			}

			return produtos;
		}
		public Produto GetProduto(int codigo)
		{
			ProdutoDados produtoDados = new ProdutoDados(s3Client);

			var produto = produtoDados.GetProduto(codigo);

			produtoDados = null;

			return produto;
		}
	}
}
