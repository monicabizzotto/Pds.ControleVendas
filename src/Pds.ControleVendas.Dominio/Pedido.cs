using System;
using System.Collections.Generic;
using System.Text;

namespace Pds.ControleVendas.Dominio
{
	public class Pedido
	{
		public Pedido()
		{

		}
		public Pedido(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
		public Produto Produto { get; set; }
		public Cliente Cliente { get; set; }
		public int Quantidade { get; set; }
	}
}
