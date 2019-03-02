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
	[Route("v1/produto")]
	[ApiController]
	public class ProdutoController : ControllerBase
	{
		[HttpGet]
		[Route("")]
		[ProducesResponseType(typeof(Model.ProdutoResponse), 200)]
		public async Task<IActionResult> GetProdutos()
		{
			try
			{
				ProdutoNegocio produtoNegocio = new ProdutoNegocio();

				var retorno = new ProdutoResponse() { Produtos = produtoNegocio.GetProdutos() };

				return Ok(retorno);
			}
			catch (Exception ex)
			{
				return BadRequest();
			}
		}
	}
}