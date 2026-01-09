using App;
using App.Interface;
using App.Result;
using App.Signature;
using App.Signature.Enum;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PI.Utility.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailerController : Controller
    {
        private readonly IMailerApp _mailerApp;
        public MailerController(IMailerApp mailerApp)
        {
            _mailerApp = mailerApp;
        }

        [HttpPost]
        [Route(nameof(ObterEmailsAgendados))]
        public async Task<ActionResult<EmailAgendadoResult>> ObterEmailsAgendados(EmailAgendadoSignature signature)
        {
            await _mailerApp.EmailAgendado(signature);
            return Ok();
        }
    }
}
