using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pds.ControleVendas.Api.Model;
using Pds.ControleVendas.Negocio;

namespace Pds.ControleVendas.Api.Controllers
{
	[Route("v1/pedido")]
	[ApiController]
	public class PedidoController : ControllerBase
	{
		[HttpPost]
		[Route("")]
		[ProducesResponseType(typeof(Model.PedidoResponse), 200)]
		public async Task<IActionResult> Post([FromBody] PedidoRequest pedidoRequest)
		{
			PedidoNegocio pedidoNegocio = new PedidoNegocio();

			return Ok(pedidoNegocio.AddPedido(pedidoRequest.ToPedido()) as PedidoResponse);
		}

		[HttpGet]
		[Route("status")]
		public async Task<IActionResult> GetStatusPedidos()
		{
			PedidoNegocio pedidoNegocio = new PedidoNegocio();

			pedidoNegocio.GetRetornoPedido();

			return Ok(pedidoNegocio.GetRetornoPedido());
		}
		[HttpGet]
		[Route("{idPedido}/status")]
		public async Task<IActionResult> GetStatusPedido(int idPedido)
		{
			PedidoNegocio pedidoNegocio = new PedidoNegocio();

			pedidoNegocio.GetRetornoPedido();

			return Ok(pedidoNegocio.GetRetornoPedido());
		}
	}
}