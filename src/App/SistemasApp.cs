using App.Converter;
using App.Interface;
using App.Result;
using Infra;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class SistemasApp : ISistemaApp
    {
        private readonly IPortalInvestimentoRepository _portalInvestimentoRepository;

        public SistemasApp(IPortalInvestimentoRepository portalInvestimentoRepository)
        {
            _portalInvestimentoRepository = portalInvestimentoRepository;
        }

        public async Task<List<SistemasResult>> ObterTodos()
        {
            var sistemas = await _portalInvestimentoRepository.ObterSistemas();
            return PortalInvestimentosConverter.ToListSistemaResult(sistemas);
        }

    }
}
