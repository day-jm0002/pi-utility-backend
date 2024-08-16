using App.Interface;
using App.Result;
using App.Signature;
using Infra;
using Infra.Signature;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class AmbienteApp : IAmbienteApp
    {
        private readonly IPortalInvestimentoRepository _portalInvestimentoRepository;

        public AmbienteApp(IPortalInvestimentoRepository portalInvestimentoRepository)
        {
            _portalInvestimentoRepository = portalInvestimentoRepository;
        }

        public async Task AtualizarAmbiente(AmbienteSignature ambienteSignature)
        {
            var editar = new EditarAmbienteRepositorySignature();
            editar.Id = ambienteSignature.Id;
            editar.Branch = ambienteSignature.Branch;
            editar.Descricao = ambienteSignature.Descricao;
            editar.NumeroChamado = ambienteSignature.NumeroChamado;
            editar.DevId = ambienteSignature.DevId;
            editar.NegId = ambienteSignature.NegId;
            editar.SitId = ambienteSignature.SitId;
            editar.Dependencia = ambienteSignature.Dependencia;

            await _portalInvestimentoRepository.AtualizarAmbientesPI(editar);
        }

        public async Task AtualizarAmbienteQa(AmbienteSignatureQa ambienteSignature)
        {
            var editar = new EditarAmbienteQaRepositorySignature();
            editar.AmbienteId = ambienteSignature.Id;
            editar.Release = ambienteSignature.Release;
            editar.Requisicao = ambienteSignature.Requisicao;
            editar.DevId = ambienteSignature.DevId;
            editar.NegId = ambienteSignature.NegId;
            editar.DataImplatacao = ambienteSignature.DataImplantacao;

            await _portalInvestimentoRepository.AtualizarAmbientesNovoPIQa(editar);
            var excluir = ambienteSignature.Branch.FindAll(x => x.Apagar == true);
            foreach (var item in excluir)
            {
                await _portalInvestimentoRepository.ExcluirFeatureAmbiente(item.ChamadoId);
            }
            var atualizar = ambienteSignature.Branch.FindAll(x => x.Apagar == false);
            foreach (var item in atualizar)
            {
                var pacote = new PacoteRepositorySignature();
                pacote.ReleaseId = ambienteSignature.Id;
                pacote.Branch = item.Branch;
                pacote.ChamadoId = item.ChamadoId;
                pacote.NegocioTesteId = item.NegocioTesteId;
                pacote.SituacaoId = item.SituacaoId;
                await _portalInvestimentoRepository.AtualizarChamadosQa(pacote);
            }
        }

        public async Task<AmbienteResultQa> ObterPacoteQa()
        {
            var ambiente = await _portalInvestimentoRepository.ObterAmbientesPIQa();
            var listaPacotes = await _portalInvestimentoRepository.ObterListaPacoteQa();

            var ambienteResultQa = new AmbienteResultQa();
            ambienteResultQa.ReleaseId = ambiente.ReleaseId;
            ambienteResultQa.Nome = ambiente.Nome;
            ambienteResultQa.Requisicao = ambiente.Requisicao;
            ambienteResultQa.Desenvolvedor = ambiente.Desenvolvedor;
            ambienteResultQa.DesenvolvedorId = ambiente.DesenvolvedorId;
            ambienteResultQa.Negocio = ambiente.Negocio;
            ambienteResultQa.NegocioId = ambiente.NegocioId;
            ambienteResultQa.DataImplantacao = ambiente.DataImplantacao;
            
            var lista = new List<PacoteReleaseQa>();
            if (listaPacotes.Count > 0)
            {
                foreach (var item in listaPacotes)
                {
                    lista.Add(new PacoteReleaseQa 
                    { 
                        ReleaseId = item.ReleaseId, 
                        Branch = item.Branch ,
                        NegocioTeste = item.Nome,
                        NegocioTesteId = item.NegocioId,
                        SituacaoId = item.SituacaoId,
                        Situacao = item.Descricao,
                        ChamadoId = item.ChamadoId                                       
                    });
                }
            }

            ambienteResultQa.Pacote = lista;

            return ambienteResultQa;
        }

        public async Task<List<AmbienteResult>> ObterTodos()
        {
           var ambienteResult = new List<AmbienteResult>();
           var ambientes = await _portalInvestimentoRepository.ObterAmbientesPI();
           foreach(var ambiente in ambientes)
            {
                AmbienteResult result = new AmbienteResult();
                result.Id = ambiente.Id;
                result.Nome = ambiente.Nome;
                result.Branch = ambiente.Branch; 
                result.NumeroChamado = ambiente.NumeroChamado; 
                result.Descricao = ambiente.Descricao;
                result.DevId = ambiente.DevId;
                result.Desenvolvedor = ambiente.Desenvolvedor;
                result.NegId = ambiente.NegId;
                result.Negocio = ambiente.Negocio;
                result.Link = ambiente.Link;
                result.SituacaoId = ambiente.SituacaoId;
                result.Situacao = ambiente.Situacao;
                result.Dependencia = ambiente.Dependencia;
                
                ambienteResult.Add(result);
            }
            return ambienteResult;
        }

        public async Task AtualizarChamadoAmbienteQa(AmbienteChamadoSignature ambienteSignature)
        {
            var repositorySignature = new ChamadoAmbienteQaRepositorio();
            repositorySignature.ChamadoId = ambienteSignature.ChamadoId;
            repositorySignature.SituacaoId = ambienteSignature.SituacaoId;
            repositorySignature.NegocioTesteId = ambienteSignature.NegocioTesteId;

           await _portalInvestimentoRepository.AtualizarChamadoAmbienteQa(repositorySignature);
        }
    }
}
