using System.Collections.Generic;
using System.Threading.Tasks;
using App.Result;
using App.Signature;
using PI.Utility.Signature;

namespace App.Interface
{
    public interface IPiApp
    { 
        Task <IList<UsuarioPiResult>> ListaUsuarioAsync();
        Task <IList<TipoUsuarioResult>> ListaTipoUsuarioAsync();
        Task <IList<TipoAutenticacaoResult>> ListaTipoAutenticacaoAsync();
        Task <UsuarioPiResult> UsuarioPorCodigoClienteAsync(UsuarioSignature signature);
        Task<int> AtualizarUsuarioAsync(EditarUsuarioSignature signature);
        Task<InfotreasuryResult> ObterStatusInfotreasury();
        Task<LimparCacheResult> LimperCacheStage(LimparCacheSignature signature);

        Task<PerfilResult> ObterPerfilCliente(PerfilSignature signature);
        Task<List<SituacaoResult>> ObterListaStatus();

    }
}