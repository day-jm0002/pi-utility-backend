using Infra.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interface
{
    public interface IPortalInvestimentoQaRepository
    {
        Task<IList<UsuarioPi>> ObterListaUsuarioAsync();
    }
}
