using Amazon.S3;
using Pds.ControleVendas.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Pds.ControleVendas.Dados
{
	public class PedidoDados
	{
		private ArquivoDados arquivoDados;

		public PedidoDados(IAmazonS3 s3Client)
		{
			arquivoDados = new ArquivoDados(s3Client);
		}

		public Pedido AddPedido(Pedido pedido)
		{
			var ms = arquivoDados.GetArquivo("ListaPedido.txt");
			Task.WaitAll(ms);
			StreamReader streamReader = new StreamReader(ms.Result);
			MemoryStream memoryStream = new MemoryStream();

			string linha = "";
			byte[] linhaBytes;

			while (!streamReader.EndOfStream)
			{
				linha = streamReader.ReadLine();
				linhaBytes = Encoding.Default.GetBytes(linha);
				memoryStream.Write(linhaBytes, 0, linhaBytes.Length);
				memoryStream.WriteByte(0x0A);
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

			//StreamWriter streamWriter = new StreamWriter(path, true);
			//streamWriter.WriteLine();

			//streamWriter.Write(String.Format("{0};{1};{2};{3};", pedido.Id, pedido.Produto.Id, pedido.Cliente.Id, pedido.Quantidade));
			memoryStream.Write(Encoding.Default.GetBytes(String.Format("{0};{1};{2};{3};", pedido.Id, pedido.Produto.Id, pedido.Cliente.Id, pedido.Quantidade)));
			memoryStream.WriteByte(0x0A);

			//streamWriter.Close();
			Task<bool> result = arquivoDados.PutArquivo("ListaPedido.txt", memoryStream);

			Task.WaitAll(result);
			memoryStream.Close();

			if (result.Result)
			{
				return pedido;
			}
			else
			{
				return null;
			}
		}
		public Pedido GetPedido(int codigo)
		{
			var ms = arquivoDados.GetArquivo("ListaPedido.txt");
			Task.WaitAll(ms);
			StreamReader streamReader = new StreamReader(ms.Result);

			string linha = "";
			Pedido pedido = null;

			while (!streamReader.EndOfStream)
			{
				linha = streamReader.ReadLine();

				if (!String.IsNullOrEmpty(linha) && !linha.Equals("CodigoPedido;CodigoProduto;CodigoCliente;Quantidade;"))
				{
					string[] linhaArr = linha.Split(";");

					if (Convert.ToInt32(linhaArr[0]) == codigo)
					{
						pedido = new Pedido()
						{
							Id = codigo,
							Produto = new Produto() { Id = Convert.ToInt32(linhaArr[1]) },
							Cliente = new Cliente() { Id = Convert.ToInt32(linhaArr[2]) },
							Quantidade = Convert.ToInt32(linhaArr[3])
						};

						break;
					}
				}
			}

			streamReader.Close();

			return pedido;
		}
		public List<Pedido> GetPedidos()
		{
			var ms = arquivoDados.GetArquivo("ListaPedido.txt");
			Task.WaitAll(ms);
			StreamReader streamReader = new StreamReader(ms.Result);

			string linha = "";
			List<Pedido> pedidos = new List<Pedido>();

			while (!streamReader.EndOfStream)
			{
				linha = streamReader.ReadLine();

				if (!String.IsNullOrEmpty(linha) && !linha.Equals("CodigoPedido;CodigoProduto;CodigoCliente;Quantidade;"))
				{
					string[] linhaArr = linha.Split(";");

					pedidos.Add(new Pedido()
					{
						Id = Convert.ToInt32(linhaArr[0]),
						Produto = new Produto() { Id = Convert.ToInt32(linhaArr[1]) },
						Cliente = new Cliente() { Id = Convert.ToInt32(linhaArr[2]) },
						Quantidade = Convert.ToInt32(linhaArr[3])
					});
				}
			}

			streamReader.Close();

			return pedidos;
		}
		public List<RetornoPedido> GetRetornoPedido()
		{
			var ms = arquivoDados.GetArquivo("RetornoPedido.txt");
			Task.WaitAll(ms);
			StreamReader streamReader = new StreamReader(ms.Result);

			string linha = "";
			List<RetornoPedido> retornoPedidos = new List<RetornoPedido>();

			while (!streamReader.EndOfStream)
			{
				linha = streamReader.ReadLine();

				if (!String.IsNullOrEmpty(linha) && !linha.Equals("CodigoPedido;Status;"))
				{
					string[] linhaArr = linha.Split(";");
					retornoPedidos.Add(new RetornoPedido()
					{
						Pedido = GetPedido(Convert.ToInt32(linhaArr[0])),
						StatusPedido = StatusPedido.Parse<StatusPedido>(linhaArr[1])
					});
				}
			}

			streamReader.Close();

			return retornoPedidos;
		}
	}
}
