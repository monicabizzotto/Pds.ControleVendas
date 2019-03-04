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
		private IAmazonS3 s3Client;
		public PedidoNegocio(IAmazonS3 s3Client)
		{
			this.s3Client = s3Client;
		}

		public Pedido AddPedido(Pedido pedido)
		{
			PedidoDados pedidoDados = new PedidoDados(s3Client);

			return pedidoDados.AddPedido(pedido);
		}
		public List<RetornoPedido> GetRetornoPedido()
		{
			List<RetornoPedido> pedidos = new List<RetornoPedido>();

			PedidoDados pedidoDados = new PedidoDados(s3Client);

			pedidos = pedidoDados.GetRetornoPedido();
			pedidoDados = null;

			return pedidos;
		}
	}
}
