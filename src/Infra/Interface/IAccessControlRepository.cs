using Infra.Entidade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interface
{
    public interface IAccessControlRepository
    {
        public Task<IList<Token>> ObterLoginPorToken();
    }
}
