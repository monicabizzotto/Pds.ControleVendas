using Amazon.S3;
using Pds.ControleVendas.Dados;
using Pds.ControleVendas.Dominio;
using System;
using System.Collections.Generic;

namespace Pds.ControleVendas.Negocio
{
	public class FornecedorNegocio
	{
		private readonly IAmazonS3 s3Client;
		private readonly ArquivoDados arquivoDados;

		public FornecedorNegocio(IAmazonS3 s3Client, ArquivoDados arquivoDados)
		{
			this.s3Client = s3Client;
			this.arquivoDados = arquivoDados;
		}

		public List<Fornecedor> GetFornecedores()
		{
			FornecedorDados fornecedorDados = new FornecedorDados(s3Client, arquivoDados);

			return fornecedorDados.GetFornecedores();
		}
		public Fornecedor GetFornecedor(int id)
		{
			FornecedorDados fornecedorDados = new FornecedorDados(s3Client, arquivoDados);

			return fornecedorDados.GetFornecedor(id);
		}
	}
}
