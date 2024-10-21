using App.Interface;
using App.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proxy.DriveAMnet.Interface;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PI.Utility.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {

        private readonly IMonitorApp _monitorApp;

        public MonitorController(IMonitorApp monitorApp)
        {
            _monitorApp = monitorApp;
        }

        [HttpGet]
        [Route(nameof(StatusDriveAMnet))]
        public async Task<ActionResult<DriveAMnetResult>> StatusDriveAMnet()
        {
            var retorno = await _monitorApp.ObterAutenticacaoDriveAMnet();
            if (retorno.type == -100)
            {
                return NotFound(retorno);
            }
            else
            {
                return Ok(retorno);
            }

        }

        [HttpGet]
        [Route(nameof(StatusSinacor))]
        public async Task<ActionResult<DriveAMnetResult>> StatusSinacor()
        {
            var retorno = await _monitorApp.ObterAutenticacaoSinaCor();
            if (retorno.IsAuthenticated == "Y")
            {
                return Ok(retorno);
            }
            else
            {
                return NotFound(retorno);
            }
        }

        [HttpGet]
        [Route(nameof(StatusSmartBrain))]
        public async Task<ActionResult<SmartBrainResult>> StatusSmartBrain()
        {
            var retorno = await _monitorApp.ObterAutenticacaoSmartBrain();
            if (retorno.login)
            {
                return Ok(retorno);
            }
            else
            {
                return NotFound(retorno);
            }
        }

        [HttpGet]
        [Route(nameof(StatusSisfinance))]
        public async Task<ActionResult<SisfinanceResult>> StatusSisfinance()
        {
            var retorno = await _monitorApp.ObterAutenticacaoSisfinance() ;
            if (retorno.login)
            {
                return Ok(retorno);
            }
            else
            {
                return NotFound(retorno);
            }
        }

        [HttpGet]
        [Route(nameof(StatusIcatu))]
        public async Task<ActionResult<IcatuResult>> StatusIcatu()
        {
            var retorno = await _monitorApp.ObterGrauParentescoIcatu();
            return Ok(retorno);
        }

        [HttpGet]
        [Route(nameof(ObterStatusInfotreasury))]
        public async Task<ActionResult<InfotreasuryResult>> ObterStatusInfotreasury()
        {
            try
            {
                var info = await _monitorApp.ObterStatusInfotreasury();
                return Ok(info);
            }
            catch (Exception ex)
            {
                return NotFound(new InfotreasuryResult { Message = ex.Message });
            }
        }

    }
}
