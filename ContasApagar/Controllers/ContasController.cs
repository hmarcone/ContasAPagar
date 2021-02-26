using ApplicationApp.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        // GET: ContasController
        [Route("api/v1/ListarContas")]
        [HttpGet]       
        public async Task<List<Conta>> ListarContas()
        {
            return await _InterfaceContaApp.ListarContas();
        }
    }
}
