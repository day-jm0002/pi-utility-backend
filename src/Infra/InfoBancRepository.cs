using DayFw.DataAccess;
using DayFw.DataAccess.Extension.Ado;
using DayFw.DataAccess.Interfaces;
using Infra.Entidade;
using Infra.Interface;
using Infra.Signature;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class InfoBancRepository : BaseRepositoryAdo , IInfoBancRepository
    {
        public InfoBancRepository() : base(new DcvInfobancParameter())
        {

        }

        public async Task<Gerente> ObterGerenteAsync(GerenteRepositorySignature gerenteRepositorySignature)
        {
                var parametros = new List<SqlParameter>(0);
                parametros.Add(new SqlParameter("@CODEXTERNO", SqlDbType.VarChar) { Value = gerenteRepositorySignature.CodExterno });

                var execute = new CreateExecuteAdo()
                    .WithParameters(parametros)
                    .WithProcedure("P_OBTER_GERENTE");

                return await ExecuteObjectAsync<Gerente>(execute);
        }

        public async Task<IList<Gerente>> ObterListaGerenteAsync()
        {
            var parametros = new List<SqlParameter>(0);

            var execute = new CreateExecuteAdo()
                .WithParameters(parametros)
                .WithProcedure("P_OBTER_LISTA_GERENTES");

            return await ExecuteListAsync<Gerente>(execute);
        }

    }
}
