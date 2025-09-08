using App.Interface;
using App.Result;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PI.Utility.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemasController : Controller
    {

        private readonly ISistemaApp _sistemaApp;

        public SistemasController(ISistemaApp sistemaApp)
        {
            _sistemaApp = sistemaApp;
        }

        [HttpGet]
        [Route(nameof(ObterTodosSistemas))]
        public async Task<ActionResult<List<SistemasResult>>> ObterTodosSistemas()
        {
            var sistemas = await _sistemaApp.ObterTodos();
            return Ok(sistemas);
        }


    }
}
