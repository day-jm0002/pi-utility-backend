using App.Converter;
using App.Interface;
using App.Result;
using Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class DesenvolvedorApp : IDesenvolvedorApp
    {

        private readonly IPortalInvestimentoRepository _portalInvestimentoRepository;

        public DesenvolvedorApp(IPortalInvestimentoRepository portalInvestimentoRepository)
        {
            _portalInvestimentoRepository = portalInvestimentoRepository;
        }
        public void ObterPorId()
        {
            throw new NotImplementedException();
        }


        public async Task<List<DesenvolvedorResult>> ObterTodos()
        {
            var desenvolvedor = await _portalInvestimentoRepository.ObterDesenvolvedoresPI();
            return PortalInvestimentosConverter.ToListDesenvolvedorResult(desenvolvedor);

        }
    }
}
