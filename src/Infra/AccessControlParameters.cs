using DayFw.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra
{
    public class AccessControlParameters : IConnectionParameters
    {
        public bool UseDayFwConfigurationFile => true;
        public string SistemaDaycoval => "ACCESSCONTROL";
        public string ConnectionName => "DCV_CONTROL";
        public int? TimeOut { get; set; }
    }
}
