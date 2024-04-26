using DayFw.DataAccess.Interfaces;

namespace Infra
{
    public class DcvPortalInvestimentosParameters : IConnectionParameters
    {
        public bool UseDayFwConfigurationFile => true;
        public string SistemaDaycoval => "PORTALINVESTIMENTOS";
        public string ConnectionName => "DCV_PI";
        public int? TimeOut { get; set; }
    }
}