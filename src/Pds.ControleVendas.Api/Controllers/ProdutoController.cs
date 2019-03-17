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
	[Route("v1/produto")]
	[ApiController]
	public class ProdutoController : ControllerBase
	{
		private readonly IAmazonS3 s3Client;
		private readonly Dados.ArquivoDados arquivoDados;

		public ProdutoController(IAmazonS3 s3Client, Dados.ArquivoDados arquivoDados)
		{
			this.s3Client = s3Client;
			this.arquivoDados = arquivoDados;
		}

		[HttpGet]
		[Route("")]
		[ProducesResponseType(typeof(Model.ProdutoResponse), 200)]
		public async Task<IActionResult> GetProdutos()
		{
			try
			{
				ProdutoNegocio produtoNegocio = new ProdutoNegocio(s3Client, arquivoDados);

				var retorno = new ProdutoResponse() { Produtos = produtoNegocio.GetProdutos() };

				return Ok(retorno);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		//TODO:Implementar getProduto
	}
}