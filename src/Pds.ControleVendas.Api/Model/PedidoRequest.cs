using Pds.ControleVendas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pds.ControleVendas.Api.Model
{
	public class PedidoRequest
	{
		public PedidoRequest()
		{
		}

		public int CodigoProduto { get; set; }
		public int CodigoCliente { get; set; }
		public int Quantidade { get; set; }

		public Pedido ToPedido()
		{
			return new Pedido()
			{
				Cliente = new Cliente() { Id = CodigoCliente },
				Produto = new Produto() { Id = CodigoProduto },
				Quantidade = this.Quantidade
			};
		}
	}
}
