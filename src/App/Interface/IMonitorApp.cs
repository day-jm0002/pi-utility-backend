using App.Result;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Interface
{
    public interface IMonitorApp
    {
        Task<DriveAMnetResult> ObterAutenticacaoDriveAMnet();
        Task<SinacorResult> ObterAutenticacaoSinaCor();
        Task<SmartBrainResult> ObterAutenticacaoSmartBrain();
        Task<SisfinanceResult> ObterAutenticacaoSisfinance();

    }
}
