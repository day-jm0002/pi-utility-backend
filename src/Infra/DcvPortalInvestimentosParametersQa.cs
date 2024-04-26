using DayFw.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra
{
    public class DcvPortalInvestimentosParametersQa : IConnectionParameters
    {
        public bool UseDayFwConfigurationFile => true;
        public string SistemaDaycoval => "DAYSYSTEM_503";
        public string ConnectionName => "DCV_PI";
        public int? TimeOut { get; set; }
    }
}
