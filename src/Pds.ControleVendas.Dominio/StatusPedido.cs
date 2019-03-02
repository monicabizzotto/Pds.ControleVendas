using System;
using System.Collections.Generic;
using System.Text;

namespace Pds.ControleVendas.Dominio
{
	public enum StatusPedido : int
	{
		Realizado = 0,
		AguardandoPagamento = 1,
		PagamentoConfirmado = 2,
		SeparacaoEstoque = 3,
		Transportadora = 4,
		EmRotaEntrega = 5,
		Entregue = 6,
		Outros = 99
	}
}
