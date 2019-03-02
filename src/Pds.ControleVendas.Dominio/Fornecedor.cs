using System;

namespace Pds.ControleVendas.Dominio
{
	public class Fornecedor
	{
		public Fornecedor()
		{
		}
		public Fornecedor(int id, string nome)
		{
			Id = id;
			Nome = nome;
		}

		public int Id { get; set; }
		public string Nome { get; set; }
	}
}
