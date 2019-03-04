using Amazon.S3;
using Pds.ControleVendas.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pds.ControleVendas.Dados
{
	public class ProdutoDados
	{
		private string path = @"C:\Users\pgoli\OneDrive\POCMonica\TemplateArquivos\ListaProdutos.txt";
		private ArquivoDados arquivoDados;

		public ProdutoDados(IAmazonS3 s3Client)
		{
			arquivoDados = new ArquivoDados(s3Client);
			var r = arquivoDados.ListarArquivos();
		}

		public List<Produto> GetProdutos()
		{
			StreamReader streamReader = new StreamReader(path);

			if (!streamReader.EndOfStream)
				streamReader.ReadLine();

			List<Produto> produtos = new List<Produto>();
			string linha;
			string[] linhaArr;

			while (!streamReader.EndOfStream)
			{
				linha = streamReader.ReadLine();
				linhaArr = linha.Split(";");
				produtos.Add(new Produto(Convert.ToInt32(linhaArr[0]), linhaArr[1], new Fornecedor(){ Id = Convert.ToInt32(linhaArr[2]) }));
			}

			streamReader.Close();

			return produtos;
		}
	}
}
