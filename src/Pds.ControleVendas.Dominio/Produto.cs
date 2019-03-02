using System;
using System.Collections.Generic;
using System.Text;

namespace Pds.ControleVendas.Dominio
{
	public class Produto
	{
		public Produto()
		{
		}
		public Produto(int id, string nome, Fornecedor fornecedor)
		{
			Id = id;
			Nome = nome;
			Fornecedor = fornecedor;
		}

		public int Id { get; set; }
		public string Nome { get; set; }
		public Fornecedor Fornecedor { get; set; }
	}
}
