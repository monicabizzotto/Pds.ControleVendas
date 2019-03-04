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
	//[Route("v1/fornecedor")]
	//[ApiController]
	//public class FornecedorController : ControllerBase
	//{
	//	[HttpGet]
	//	[Route("")]
	//	[ProducesResponseType(typeof(Model.FornecedorResponse), 200)]
	//	public async Task<IActionResult> GetFornecedores()
	//	{
	//		try
	//		{
	//			FornecedorNegocio fornecedorNegocio = new FornecedorNegocio();

	//			var retorno = new FornecedorResponse() { Fornecedores = fornecedorNegocio.GetFornecedores() };

	//			return Ok(retorno);
	//		}
	//		catch (Exception ex)
	//		{
	//			return BadRequest();
	//		}
	//	}
	//}
}