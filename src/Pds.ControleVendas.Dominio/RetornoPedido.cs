using System;
using System.Collections.Generic;
using System.Text;

namespace Pds.ControleVendas.Dominio
{
	public class RetornoPedido
	{
		public RetornoPedido()
		{
		}
		public RetornoPedido(int idPedido, int idStatusPedido)
		{
			Pedido = new Pedido(idPedido);
			StatusPedido = StatusPedido.Parse<StatusPedido>(idStatusPedido.ToString());
		}

		public Pedido Pedido { get; set; }
		public StatusPedido StatusPedido { get; set; }
	}
}
