using Pds.ControleVendas.Dados;
using Pds.ControleVendas.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pds.ControleVendas.Negocio
{
	public class PedidoNegocio
	{
		public PedidoNegocio()
		{
		}

		public Pedido AddPedido(Pedido pedido)
		{
			PedidoDados pedidoDados = new PedidoDados();

			return pedidoDados.AddPedido(pedido);
		}
		public List<RetornoPedido> GetRetornoPedido()
		{
			List<RetornoPedido> pedidos = new List<RetornoPedido>();

			PedidoDados pedidoDados = new PedidoDados();

			pedidos = pedidoDados.GetRetornoPedido();
			pedidoDados = null;

			return pedidos;
		}
	}
}
