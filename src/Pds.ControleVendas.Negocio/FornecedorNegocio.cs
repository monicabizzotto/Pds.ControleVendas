using Pds.ControleVendas.Dados;
using Pds.ControleVendas.Dominio;
using System;
using System.Collections.Generic;

namespace Pds.ControleVendas.Negocio
{
	public class FornecedorNegocio
	{
		public FornecedorNegocio()
		{
		}

		public List<Fornecedor> GetFornecedores()
		{
			FornecedorDados fornecedorDados = new FornecedorDados();

			return fornecedorDados.GetFornecedores();
		}
		public Fornecedor GetFornecedor(int id)
		{
			FornecedorDados fornecedorDados = new FornecedorDados();

			return fornecedorDados.GetFornecedor(id);
		}
	}
}
