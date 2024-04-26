using AppFundos.Interface;
using AppFundos.Result;
using Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFundos
{
    public class FundosApp : IFundosApp
    {
        private readonly IGestorFundosRepository _IgestorFundosRepository;
        public FundosApp(IGestorFundosRepository gestorFundosRepository)
        {
            _IgestorFundosRepository = gestorFundosRepository;
        }

        public async Task<List<FundosDriveAMnetResult>> ObterFundosGestoresDrive()
        {         

            var fundos = await _IgestorFundosRepository.ObterListaFundosAsync();

            List<FundosDriveAMnetResult> resultado = new List<FundosDriveAMnetResult>();

            for (var i = 0; i < fundos.Count; i++)
            {
                var gestor = new FundosDriveAMnetResult();
                gestor.IdFundo                 =fundos[i].IdFundo                   ;
                gestor.IdGestor                =fundos[i].IdGestor                  ;
                gestor.Cnpj                    =fundos[i].Cnpj                      ;
                gestor.TipoNome                =fundos[i].TipoNome                  ;
                gestor.Inativo                 =fundos[i].Inativo                   ;
                gestor.Calculado               =fundos[i].Calculado                 ;
                gestor.Integracao              =fundos[i].Integracao                ;
                gestor.valorCotaDecimals       =fundos[i].valorCotaDecimals         ;
                gestor.QuantidadeCotaDecimals  =fundos[i].QuantidadeCotaDecimals    ;
                gestor.coberturaAutoCaixa      =fundos[i].coberturaAutoCaixa        ;
                gestor.bCoEncerr               =fundos[i].bCoEncerr                 ;
                gestor.contaSELIC              =fundos[i].contaSELIC                ;
                gestor.contaCETIP              =fundos[i].contaCETIP                ;
                gestor.codCETIP                =fundos[i].contaCETIP                ;
                gestor.Nome                    =fundos[i].Nome                      ;
                gestor.NomeCompleto            =fundos[i].NomeCompleto              ;
                gestor.isinCode                =fundos[i].isinCode                  ;
                resultado.Add(gestor);
            }
            return resultado;

        }

        public async Task<List<GestoresDriveAMnetResult>> ObterGestoresDrive()
        {
            var gestores = await _IgestorFundosRepository.ObterGestoresDeFundosAsync();
            List<GestoresDriveAMnetResult> resultado = new List<GestoresDriveAMnetResult>();

            for(var i = 0; i < gestores.Count ; i++)
            {
                var gestor = new GestoresDriveAMnetResult();
                gestor.IdGestor = gestores[i].IdGestor;
                gestor.CpfCNPJ = gestores[i].CpfCNPJ;
                gestor.Nome = gestores[i].Nome.Replace("/","");
                gestor.NomeCompleto = gestores[i].NomeCompleto;
                resultado.Add(gestor);
            }
            return resultado;
        }
    }
}
