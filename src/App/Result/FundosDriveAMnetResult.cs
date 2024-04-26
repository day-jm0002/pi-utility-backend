using Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFundos.Result
{
    public class FundosDriveAMnetResult
    {
        public int IdFundo { get; set; }
        public int IdGestor { get; set; }
        public string Cnpj { get; set; }
        public string TipoNome { get; set; }
        public string Inativo { get; set; }
        public string Calculado { get; set; }
        public string Integracao { get; set; }
        public string valorCotaDecimals { get; set; }
        public string QuantidadeCotaDecimals { get; set; }
        public string coberturaAutoCaixa { get; set; }
        public string bCoEncerr { get; set; }
        public string contaSELIC { get; set; }
        public string contaCETIP { get; set; }
        public string codCETIP { get; set; }
        public string Nome { get; set; }
        public string NomeCompleto { get; set; }
        public string isinCode { get; set; }
    }
}
