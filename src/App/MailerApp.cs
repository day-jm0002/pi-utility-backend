using App.Interface;
using App.Result;
using App.Signature.Enum;
using Infra;
using Infra.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class MailerApp : IMailerApp
    {
        private readonly IPortalInvestimentoRepository _portalDeInvestimentosRepository;
        public MailerApp(IPortalInvestimentoRepository portalDeInvestimentosRepository)
        {
            _portalDeInvestimentosRepository = portalDeInvestimentosRepository;
        }
        public async Task EmailAgendado(EmailAgendadoSignature signature)
        {
            var retorno = await _portalDeInvestimentosRepository
                .ObterEmailAgendado(new Infra.Signature.AgendaEmailRepositorySignature { DataCastro = signature.DataCadastro });           
            Task.CompletedTask.Wait();
        }
    }
}
