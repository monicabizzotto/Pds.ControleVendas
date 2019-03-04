using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3;
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
		private IAmazonS3 s3Client;
		public PedidoController(IAmazonS3 s3Client)
		{
			this.s3Client = s3Client;
		}

		[HttpPost]
		[Route("")]
		[ProducesResponseType(typeof(Model.PedidoResponse), 200)]
		public async Task<IActionResult> Post([FromBody] PedidoRequest pedidoRequest)
		{
			PedidoNegocio pedidoNegocio = new PedidoNegocio(s3Client);

			return Ok(pedidoNegocio.AddPedido(pedidoRequest.ToPedido()) as PedidoResponse);
		}

		[HttpGet]
		[Route("status")]
		[ProducesResponseType(typeof(List<Dominio.RetornoPedido>), 200)]
		public async Task<IActionResult> GetStatusPedidos()
		{
			PedidoNegocio pedidoNegocio = new PedidoNegocio(s3Client);

			var retorno = pedidoNegocio.GetRetornoPedido();

			return Ok(retorno);
		}
		[HttpGet]
		[Route("{idPedido}/status")]
		public async Task<IActionResult> GetStatusPedido(int idPedido)
		{
			PedidoNegocio pedidoNegocio = new PedidoNegocio(s3Client);

			pedidoNegocio.GetRetornoPedido();

			return Ok(pedidoNegocio.GetRetornoPedido());
		}
	}
}