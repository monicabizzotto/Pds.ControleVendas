using Amazon.S3;
using Pds.ControleVendas.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Pds.ControleVendas.Dados
{
	public class FornecedorDados
	{
		private readonly ArquivoDados arquivoDados;
		private readonly IAmazonS3 s3Client;

		public FornecedorDados(IAmazonS3 s3Client, ArquivoDados arquivoDados)
		{
			this.s3Client = s3Client;
			this.arquivoDados = arquivoDados;
		}

		public List<Fornecedor> GetFornecedores()
		{
			var ms = arquivoDados.GetArquivo("Fornecedores.txt");
			Task.WaitAll(ms);
			StreamReader streamReader = new StreamReader(ms.Result);

			if (!streamReader.EndOfStream)
				streamReader.ReadLine();

			List<Fornecedor> fornecedores = new List<Fornecedor>();
			string linha;
			string[] linhaArr;

			while (!streamReader.EndOfStream)
			{
				linha = streamReader.ReadLine();
				linhaArr = linha.Split(";");
				fornecedores.Add(new Fornecedor(Convert.ToInt32(linhaArr[0]), linhaArr[1]));
			}

			streamReader.Close();

			return fornecedores;
		}
		public Fornecedor GetFornecedor(int id)
		{
			var ms = arquivoDados.GetArquivo("Fornecedores.txt");
			Task.WaitAll(ms);
			StreamReader streamReader = new StreamReader(ms.Result);

			if (!streamReader.EndOfStream)
				streamReader.ReadLine();

			string linha;
			string[] linhaArr;
			Fornecedor fornecedor = null;

			while (!streamReader.EndOfStream)
			{
				linha = streamReader.ReadLine();
				linhaArr = linha.Split(";");

				if (Convert.ToInt32(linhaArr[0]) == id)
				{
					fornecedor = new Fornecedor(Convert.ToInt32(linhaArr[0]), linhaArr[1]);
					break;
				}
			}

			streamReader.Close();

			return fornecedor;
		}
	}
}
