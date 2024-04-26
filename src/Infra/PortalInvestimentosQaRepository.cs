using DayFw.DataAccess;
using DayFw.DataAccess.Interfaces;
using Infra.Entidade;
using Infra.Interface;
using Infra.Result;
using Infra.Signature;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class PortalInvestimentosQaRepository : BaseRepositoryAdo, IPortalInvestimentoQaRepository
    {
        public PortalInvestimentosQaRepository() : base(new DcvPortalInvestimentosParametersQa())
        {

        } 
        public async Task<IList<UsuarioPi>> ObterListaUsuarioAsync()
        {

            var execute = new CreateExecuteAdo();
			execute.CommandType = System.Data.CommandType.Text;
            execute.SqlCommand = "SELECT Nome FROM dbo.Usuario";            
            var retorno = await ExecuteNonQueryAsync(execute);
			return null;
        }      
    }
}
