using AutoglassTeste.Data.BLL;
using AutoglassTeste.Data.Interface;
using AutoglassTeste.Domain;
using AutoglassTeste.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoglassTeste.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoBLL _bll;

        public ProdutoController(ProdutoBLL produtoBLL)
        {
            _bll = produtoBLL;
        }

        [HttpGet("{codigo}")]
        public IActionResult Get(int codigo)
        {

            var model = _bll.Ler(codigo);

            if (model != null)
                return Ok(model);
            else
                return NotFound();

        }
        [HttpGet]
        public IActionResult GetAll(string descricaoProduto=null, string descricaoFornecedo = null, int? codigoFornecedor = null,DateTime? dataFabricacao = null, DateTime? dataValidade = null, int pagination = 0)
        {
            var filter = new FilterModel
            {
                DescricaoProduto = descricaoProduto,
                CodigoFornecedor = codigoFornecedor,
                DescricaoFornecedor = descricaoFornecedo,
                DataFabricacao = dataFabricacao,
                DataValidade = dataValidade
            };
            var lista = _bll.Listar(filter,take: 10, pagination);
            return Ok(lista);
        }

        [HttpPost]
        public IActionResult Add(ProdutoModel model)
        {
            _bll.Salvar(model);
            if (_bll.Notificacao.HasErro)
                return BadRequest(_bll.Notificacao.MensagemFormata);
            else
                return Ok();
        }

        [HttpPut]
        public IActionResult Edite(ProdutoModel model)
        {
            _bll.Atualizar(model);
            if (_bll.Notificacao.HasErro)
                return BadRequest(_bll.Notificacao.MensagemFormata);
            else
                return Ok();
        }

        [HttpDelete]
        public IActionResult Excluir(int codigo)
        {

            _bll.Excluir(codigo);
            return Ok();
        }
    }
}
