using DayFw.DataAccess;
using DayFw.DataAccess.Extension.Ado;
using DayFw.DataAccess.Interfaces;
using DayFw.DataAccess.Interfaces.Ado;
using Infra.Result;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infra
{
    public class GestorFundosRepository : BaseRepositoryAdo, IGestorFundosRepository
    {
        //DcvInvestimentoParameter
        public GestorFundosRepository() : base(new DcvInvestimentoParameter())
        {
        }

        public async Task<IList<GestoresDriveAMnet>> ObterGestoresDeFundosAsync()
        {
            var parametros = new List<SqlParameter>(0);

            var execute = new CreateExecuteAdo()     
                .WithParameters(parametros)
                .WithProcedure("P_OBTER_GESTORES_DRIVE");

                return await ExecuteListAsync<GestoresDriveAMnet>(execute);
        }

        public async Task<IList<FundosDriveAMnet>> ObterListaFundosAsync()
        {
            var parametros = new List<SqlParameter>(0);
           
            var execute = new CreateExecuteAdo()
                .WithParameters(parametros)
                .WithProcedure("P_OBTER_FUDNOS_GESTORES_DRIVE");

            return await ExecuteListAsync<FundosDriveAMnet>(execute);

        }       
    }
}
