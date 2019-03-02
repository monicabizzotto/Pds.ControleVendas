using Pds.ControleVendas.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pds.ControleVendas.Dados
{
	public class FornecedorDados
	{
		private string path = @"C:\Users\pgoli\OneDrive\POCMonica\TemplateArquivos\Fornecedores.txt";

		public FornecedorDados()
		{
		}

		public List<Fornecedor> GetFornecedores()
		{
			StreamReader streamReader = new StreamReader(path);

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
			StreamReader streamReader = new StreamReader(path);

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
