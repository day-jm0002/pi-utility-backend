using Infra.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public interface IGestorFundosRepository
    {
       Task <IList<FundosDriveAMnet>> ObterListaFundosAsync();

        Task<IList<GestoresDriveAMnet>> ObterGestoresDeFundosAsync();
    }
}
