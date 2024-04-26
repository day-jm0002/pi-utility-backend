using App.Interface;
using App.Result;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PI.Utility.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesenvolvedorController : ControllerBase
    {
        private readonly IDesenvolvedorApp _desenvolvedorApp;
        public DesenvolvedorController(IDesenvolvedorApp desenvolvedorApp)
        {
            _desenvolvedorApp = desenvolvedorApp;
        }

        [HttpGet]
        [Route(nameof(ObterTodosDev))]
        public async Task<ActionResult<List<DesenvolvedorResult>>> ObterTodosDev()
        {
            var lstDev = await _desenvolvedorApp.ObterTodos();
            return Ok(lstDev);
        }

    }
}
