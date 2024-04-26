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
    public class NegocioApp :INegocioApp
    {

        private readonly IPortalInvestimentoRepository _portalInvestimentoRepository;

        public NegocioApp(IPortalInvestimentoRepository portalInvestimentoRepository)
        {
            _portalInvestimentoRepository = portalInvestimentoRepository;
        }


        public async Task<List<NegocioResult>> ObterTodos()
        {
            var desenvolvedor = await _portalInvestimentoRepository.ObterNegocioPI();
            return PortalInvestimentosConverter.ToListDesenvolvedorResult(desenvolvedor);

        }

    }
}
