using DayFw.DataAccess.Interfaces;

namespace Infra
{
    public class DcvInfobancParameter : IConnectionParameters
    {
        public bool UseDayFwConfigurationFile => true;
        public string SistemaDaycoval =>  "PORTALINVESTIMENTOS";
        public string ConnectionName => "AB_INFOBANC";
        public int? TimeOut { get; set; }
    }    
}
