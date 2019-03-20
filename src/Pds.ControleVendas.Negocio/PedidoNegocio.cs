using Amazon.S3;
using Pds.ControleVendas.Dados;
using Pds.ControleVendas.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pds.ControleVendas.Negocio
{
	public class PedidoNegocio
	{
		private readonly IAmazonS3 s3Client;
		private readonly ArquivoDados arquivoDados;

		public PedidoNegocio(IAmazonS3 s3Client, ArquivoDados arquivoDados)
		{
			this.s3Client = s3Client;
			this.arquivoDados = arquivoDados;
		}

		public Pedido AddPedido(Pedido pedido)
		{
			PedidoDados pedidoDados = new PedidoDados(s3Client);

			return pedidoDados.AddPedido(pedido);
		}
		public Pedido GetPedido(int codigo)
		{
			PedidoDados pedidoDados = new PedidoDados(s3Client);

			var pedido = pedidoDados.GetPedido(codigo);

			pedidoDados = null;

			return pedido;
		}
		public List<Pedido> GetPedidos()
		{
			List<Pedido> pedidos = new List<Pedido>();

			PedidoDados pedidoDados = new PedidoDados(s3Client);

			pedidos = pedidoDados.GetPedidos();
			pedidoDados = null;

			ProdutoNegocio produtoNegocio = new ProdutoNegocio(s3Client, arquivoDados);

			for (int i = 0; i < pedidos.Count; i++)
			{
				pedidos[i].Produto = produtoNegocio.GetProduto(pedidos[i].Produto.Id);
			}

			produtoNegocio = null;

			return pedidos;
		}
		public List<RetornoPedido> GetRetornoPedido()
		{
			List<RetornoPedido> pedidos = new List<RetornoPedido>();

			PedidoDados pedidoDados = new PedidoDados(s3Client);

			pedidos = pedidoDados.GetRetornoPedido();
			pedidoDados = null;

			ProdutoNegocio produtoNegocio = new ProdutoNegocio(s3Client, arquivoDados);

			for (int i = 0; i < pedidos.Count; i++)
			{
				pedidos[i].Pedido.Produto = produtoNegocio.GetProduto(pedidos[i].Pedido.Produto.Id);
			}

			produtoNegocio = null;

			return pedidos;
		}
	}
}
