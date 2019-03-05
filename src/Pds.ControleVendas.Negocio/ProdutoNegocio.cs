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
		private readonly IAmazonS3 s3Client;
		private readonly ArquivoDados arquivoDados;
		
		public ProdutoNegocio(IAmazonS3 s3Client, ArquivoDados arquivoDados)
		{
			this.s3Client = s3Client;
			this.arquivoDados = arquivoDados;
		}

		public List<Produto> GetProdutos()
		{
			ProdutoDados produtoDados = new ProdutoDados(s3Client, arquivoDados);
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
			ProdutoDados produtoDados = new ProdutoDados(s3Client, arquivoDados);

			var produto = produtoDados.GetProduto(codigo);

			produtoDados = null;

			return produto;
		}
	}
}
