using DayFw.DataAccess;
using DayFw.DataAccess.Extension.Ado;
using DayFw.DataAccess.Interfaces;
using Infra.Entidade;
using Infra.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class AccessControlRepository : BaseRepositoryAdo , IAccessControlRepository
    {
        public AccessControlRepository() : base(new AccessControlParameters())
        {
        }

        public async Task<IList<Token>> ObterLoginPorToken()
        {
            var parametros = new List<SqlParameter>(0);

            var execute = new CreateExecuteAdo()
                .WithParameters(parametros)
                .WithProcedure("P_OBTER_USUARIO_TOKEN");

            return await ExecuteListAsync<Token>(execute);
        }
    }
}
