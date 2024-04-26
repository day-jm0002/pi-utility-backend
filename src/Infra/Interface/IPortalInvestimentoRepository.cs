using System.Collections.Generic;
using System.Threading.Tasks;
using Infra.Entidade;
using Infra.Result;
using Infra.Signature;

namespace Infra
{
    public interface IPortalInvestimentoRepository
    {
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

    }
}