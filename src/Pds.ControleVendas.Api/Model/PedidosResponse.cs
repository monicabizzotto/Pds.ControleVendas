using Pds.ControleVendas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pds.ControleVendas.Api.Model
{
	public class PedidosResponse
	{
		public List<RetornoPedido> Pedidos { get; set; }
	}
}
