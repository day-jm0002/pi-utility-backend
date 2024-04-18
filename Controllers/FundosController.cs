using AppFundos.Interface;
using AppFundos.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PI.Utility.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FundosController : ControllerBase
    {
        private readonly IFundosApp _fundoApp;
        public FundosController(IFundosApp fundosApp)
        {
            _fundoApp = fundosApp;
        }

        [HttpGet]
        [Route(nameof(ObterGestores))]
        public async Task<ActionResult<List<GestoresDriveAMnetResult>>> ObterGestores()
        {
            var gestores = await _fundoApp.ObterGestoresDrive();
            return Ok(gestores);
        }

        [HttpGet]
        [Route(nameof(ObterFundosGestores))]
        public async Task<ActionResult<List<FundosDriveAMnetResult>>> ObterFundosGestores()
        {
            var fundos = await _fundoApp.ObterFundosGestoresDrive();
            return Ok(fundos);
        }


    }
}
