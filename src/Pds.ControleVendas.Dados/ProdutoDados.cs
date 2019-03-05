using Amazon.S3;
using Pds.ControleVendas.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Pds.ControleVendas.Dados
{
	public class ProdutoDados
	{
		private readonly ArquivoDados arquivoDados;
		private readonly IAmazonS3 s3Client;
		
		public ProdutoDados(IAmazonS3 s3Client, ArquivoDados arquivoDados)
		{
			this.s3Client = s3Client;
			this.arquivoDados = arquivoDados;
		}

		public List<Produto> GetProdutos()
		{
			var ms = arquivoDados.GetArquivo("ListaProdutos.txt");
			Task.WaitAll(ms);
			StreamReader streamReader = new StreamReader(ms.Result);

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
		public Produto GetProduto(int codigo)
		{
			Produto produto = null;

			var ms = arquivoDados.GetArquivo("ListaProdutos.txt");
			Task.WaitAll(ms);
			StreamReader streamReader = new StreamReader(ms.Result);

			if (!streamReader.EndOfStream)
				streamReader.ReadLine();

			List<Produto> produtos = new List<Produto>();
			string linha;
			string[] linhaArr;

			while (!streamReader.EndOfStream)
			{
				linha = streamReader.ReadLine();
				linhaArr = linha.Split(";");

				if (Convert.ToInt32(linhaArr[0]) == codigo)
				{
					produto = new Produto(Convert.ToInt32(linhaArr[0]), linhaArr[1], new Fornecedor() { Id = Convert.ToInt32(linhaArr[2]) });
					break;
				}
			}

			streamReader.Close();

			return produto;
		}
	}
}
