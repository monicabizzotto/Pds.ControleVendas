using Pds.ControleVendas.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pds.ControleVendas.Dados
{
	public class PedidoDados
	{
		private string path = @"C:\Users\pgoli\OneDrive\POCMonica\TemplateArquivos\ListaPedido.txt";
		private string retornoPedidoPath = @"C:\Users\pgoli\OneDrive\POCMonica\TemplateArquivos\RetornoPedido.txt";

		public PedidoDados()
		{
		}

		public Pedido AddPedido(Pedido pedido)
		{
			StreamReader streamReader = new StreamReader(path);

			string linha = "";

			while (!streamReader.EndOfStream)
			{
				linha = streamReader.ReadLine();
			}

			streamReader.Close();

			if (!String.IsNullOrEmpty(linha) && !linha.Equals("CodigoPedido;CodigoProduto;CodigoCliente;Quantidade;"))
			{
				string[] linhaArr = linha.Split(";");

				pedido.Id = Convert.ToInt32(linhaArr[0]) + 1; 
			}
			else
			{
				pedido.Id = 1;
			}

			StreamWriter streamWriter = new StreamWriter(path, true);
			streamWriter.WriteLine();
			streamWriter.Write(String.Format("{0};{1};{2};{3};", pedido.Id, pedido.Produto.Id, pedido.Cliente.Id, pedido.Quantidade));

			streamWriter.Close();

			return pedido;
		}
		public List<RetornoPedido> GetRetornoPedido()
		{
			StreamReader streamReader = new StreamReader(retornoPedidoPath);

			string linha = "";
			List<RetornoPedido> retornoPedidos = new List<RetornoPedido>();

			while (!streamReader.EndOfStream)
			{
				linha = streamReader.ReadLine();

				if (!String.IsNullOrEmpty(linha) && !linha.Equals("CodigoPedido;Status;"))
				{
					string[] linhaArr = linha.Split(";");
					retornoPedidos.Add(new RetornoPedido(Convert.ToInt32(linhaArr[0]), Convert.ToInt32(linhaArr[1])));
				}
			}

			streamReader.Close();

			return retornoPedidos;
		}
	}
}
