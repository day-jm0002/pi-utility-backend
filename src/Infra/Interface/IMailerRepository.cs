using Infra.Entidade;
using Infra.Signature;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interface
{
    public interface IMailerRepository
    {
        Task<IList<AgendaEmail>> ObterListaUsuarioAsync(AgendaEmailRepositorySignature signature);
    }
}
