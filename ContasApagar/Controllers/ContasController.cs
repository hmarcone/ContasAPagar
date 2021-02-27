using ApplicationApp.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace ContasApagar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContasController : ControllerBase
    {
        public readonly InterfaceContaApp _InterfaceContaApp;

        public ContasController(InterfaceContaApp interfaceContaApp)
        {
            _InterfaceContaApp = interfaceContaApp;
        }

        [HttpGet]
        public async Task<List<Conta>> Get()
        {
            return await ListarContas();
        }

        // GET: ContasController
        [Route("api/v1/ListarContas")]
        [HttpGet]       
        public async Task<List<Conta>> ListarContas()
        {
            return await _InterfaceContaApp.ListarContas();
        }

        [Route("api/v1/CriarConta")]
        [HttpPost]
        public async Task<IActionResult> Create(Conta conta)
        {
            try
            {
                await _InterfaceContaApp.AddConta(conta);

                if (conta.Notitycoes.Any())
                {
                    var jsonErro = new List<ResponseReturn>();

                    foreach (var item in conta.Notitycoes)
                    {
                        var erro = new ResponseReturn
                        {
                            Nome = item.NomePropriedade,
                            Mensagem = item.mensagem
                        };

                        jsonErro.Add(erro);

                        //ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }

                    return new JsonResult(jsonErro);


                }
                return Ok(conta);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex}");
            }
        }

        public class ResponseReturn
        {
            public string Nome { get; set; }
            public string Mensagem { get; set; }
        }
    }
}
