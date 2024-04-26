using DayFw.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra
{
    public class DcvInvestimentoParameter : IConnectionParameters
    {
        public bool UseDayFwConfigurationFile => true;
        public string SistemaDaycoval => SistemaConst.ChaveSistema;
        public string ConnectionName => "DCV_INVESTIMENTO";
        public int? TimeOut { get; set; }
    }
}
public static class SistemaConst
{
    public const int CodSistemaWs = 503;
    public const string ChaveSistema = "DAYSYSTEM_503";
    public const string NomeProjeto = "Populador Gestor de Fundos";
    public const string UsuarioAplicacao = "ApiInvestimentosPopularGestorFundos";
}
