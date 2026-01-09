using System.Collections.Generic;
using System.Threading.Tasks;
using Infra.Entidade;
using Infra.Result;
using Infra.Signature;

namespace Infra
{
    public interface IPortalInvestimentoRepository
    {
        Task ExcluirFeatureAmbiente(int chamadoId);
        Task AtualizarAmbientesPI(EditarAmbienteRepositorySignature signature);
        Task AtualizarAmbientesPIQa(EditarAmbienteQaRepositorySignature signature);

        Task AtualizarAmbientesNovoPIQa(EditarAmbienteQaRepositorySignature signature);
        Task IncluirChamadosQa(List<PacoteRepositorySignature> signature);
        Task AtualizarChamadosQa(PacoteRepositorySignature signature);

        Task<IList<Desenvolvedor>> ObterDesenvolvedoresPI();
        Task <IList<UsuarioPi>> ObterListaUsuarioAsync();
        Task <IList<TipoAutenticacao>> ObterListaTipoAutenticacaoAsync();
        Task <IList<TipoUsuario>> ObterListaTipoUsuarioAsync();
        Task <UsuarioPi> ObterUsuarioPorCodigoUsuarioAsync(int codUsuario);
        Task<int> AtualizarUsuarioAsync(EditarUSuarioRepositorySignature signature);
        Task<Infotreasury> ObterDataGiroInfotreasury();
        Task<IList<Ambiente>> ObterAmbientesPI();
        Task<AmbienteQa> ObterAmbientesPIQa();
        Task<IList<Pacote>> ObterListaPacoteQa();
        Task<IList<Negocio>> ObterNegocioPI();
        Task<Perfil> ObterPerfilPorCodCliente(PerfilRepositorySignature signature);
        Task<IList<AmbienteStatus>> ObterStatus();
        Task AtualizarChamadoAmbienteQa(ChamadoAmbienteQaRepositorio signature);
        Task LiberarChamadoAmbientesQa(LiberarAmbienteRespositorySignature liberarAmbienteRespositorySignature);
        Task<IList<Sistema>> ObterSistemas();
        Task<bool> AdicionarAmbiente();
        Task<bool> ExcluirAmbiente(ExcluirAmbienteRepositorySignature signature);

        Task<IList<Ambiente>> ConsultarAmbientesPI(ConsultarAmbientesRespositorySignature signature);

        Task<IList<AgendaEmail>> ObterEmailAgendado(AgendaEmailRepositorySignature signature);

    }
}