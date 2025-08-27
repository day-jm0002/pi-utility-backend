using App.Interface;
using App.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PI.Utility.App.Interface;
using PI.Utility.App.Result;
using PI.Utility.Models;
using System;
using System.Threading.Tasks;

namespace PI.Utility.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeController : ControllerBase
    {
        private readonly IChangeApp _changeApp;

        public ChangeController(IChangeApp changeApp)        {
            _changeApp = changeApp;
        }

        [HttpPost]
        [Route(nameof(ProcessarMudanca))]
        public async Task<ActionResult> ProcessarMudanca([FromBody] ChangeRequest request)
        {
            try
            {
                var resultado = await _changeApp.ProcessarMudanca(request);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new ChangeResult { Message = ex.Message });
            }
        }
    }
} 