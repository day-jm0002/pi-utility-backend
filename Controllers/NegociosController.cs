using App.Interface;
using App.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PI.Utility.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegociosController : ControllerBase
    {
        private readonly INegocioApp _negpcioApp;
        public NegociosController(INegocioApp negpcioApp)
        {
            _negpcioApp = negpcioApp;
        }

        [HttpGet]
        [Route(nameof(ObterTodosNegocio))]
        public async Task<ActionResult<List<NegocioResult>>> ObterTodosNegocio()
        {
            var lstDev = await _negpcioApp.ObterTodos();
            return Ok(lstDev);
        }
    }
}
