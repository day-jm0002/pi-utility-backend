using AppFundos.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppFundos.Interface
{
    public interface IFundosApp
    {
        Task<List<GestoresDriveAMnetResult>> ObterGestoresDrive();

        Task<List<FundosDriveAMnetResult>> ObterFundosGestoresDrive();

    }
}
