using App.Interface;
using App.Result;
using App.Signature;
using Infra.Interface;
using Infra.Signature;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class InfoBancApp : IInfoBancApp
    {

        private readonly IInfoBancRepository _infoBancRepository;
        public InfoBancApp(IInfoBancRepository infoBancRepository)
        {
            _infoBancRepository = infoBancRepository;
        }

        public async Task<GerenteResult> ObterGerente(GerenteSignature gerenteSignature)
        {
            var gerente = await _infoBancRepository.ObterGerenteAsync(new GerenteRepositorySignature { CodExterno = gerenteSignature.CodExterno });

            if(gerente != null)
            {
                var gerenteResult = new GerenteResult();
                gerenteResult.CodExterno = gerente.CodExterno;
                gerenteResult.Nome = gerente.Nome;
                gerenteResult.CodcCusto = gerente.CodcCusto;
                gerenteResult.TipoGerente = gerente.TipoGerente;
                gerenteResult.Email = gerente.Email;

                return gerenteResult;

            }
            return null;
        }

        public async Task<List<GerenteResult>> ObterListaGerentes()
        {

            var listaGerentes = await _infoBancRepository.ObterListaGerenteAsync();
            var listaGerentesResult = new List<GerenteResult>();

            foreach(var item in listaGerentes)
            {
                var gerente = new GerenteResult();
                gerente.CodExterno = item.CodExterno;
                gerente.Nome = item.Nome;
                gerente.CodcCusto = item.CodcCusto;
                gerente.TipoGerente = item.TipoGerente;
                gerente.Email = item.Email;
                listaGerentesResult.Add(gerente);
            }

            return listaGerentesResult;
        }
    }
}
