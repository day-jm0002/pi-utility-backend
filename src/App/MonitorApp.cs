using App.Interface;
using App.Result;
using Proxy.DriveAMnet.Interface;
using Proxy.Sinacor.Interface;
using Proxy.SisFinace;
using Proxy.SmartBrain.Interface;
using Proxy.Icatu.Interface;
using System;
using System.Threading.Tasks;
using Infra.Converter;
using Infra;
using Proxy.ApiCatalogRendaFixa.Interface;
using App.Signature.Enum;
using App.Signature;

namespace App
{
    public class MonitorApp : IMonitorApp
    {
        private readonly IDriveAMnetProxy _driveAMnetProxy;
        private readonly ISinacorProxy _sinacorProxy;
        private readonly ISmartBrainProxy _smartBrainProxy;
        private readonly ISisFinanceProxy _sisfinance;
        private readonly IIcatuProxy _icatu;
        private readonly IPortalInvestimentoRepository _usuarioPiRepository;
        private readonly IApiCatalogoRendaFixaProxy _apiCatalogoRendaFixaProxy;

        public MonitorApp(IDriveAMnetProxy driveAMnetProxy, ISinacorProxy sinacorProxy, ISmartBrainProxy smartBrainProxy, ISisFinanceProxy sisFinanceProxy, IIcatuProxy icatuProxy, IPortalInvestimentoRepository portalInvestimentoRepository, IApiCatalogoRendaFixaProxy apiCatalogoRendaFixaProxy)
        {
            _driveAMnetProxy = driveAMnetProxy;
            _sinacorProxy = sinacorProxy;
            _smartBrainProxy = smartBrainProxy;
            _sisfinance = sisFinanceProxy;
            _icatu = icatuProxy;
            _usuarioPiRepository = portalInvestimentoRepository;
            _apiCatalogoRendaFixaProxy = apiCatalogoRendaFixaProxy;
        }
        public async Task<DriveAMnetResult> ObterAutenticacaoDriveAMnet()
        {
            var driveAMnetResult = new DriveAMnetResult();        
            var result = await _driveAMnetProxy.Autenticar();

            if(result.metadata.type == 1){
                driveAMnetResult.type = result.metadata.type;
                driveAMnetResult.message = "Autenticação OK";
            }
            else{
                driveAMnetResult.type = result.metadata.type;
                driveAMnetResult.message = result.metadata.message;
            }

            return driveAMnetResult;
        }

        public async Task<SinacorResult> ObterAutenticacaoSinaCor()
        {
            var sinacor = await _sinacorProxy.Autenticar();
            var result = new SinacorResult();
            if(sinacor.IsAuthenticated == "Y")
            {
                result.IsAuthenticated = sinacor.IsAuthenticated;
                result.Text = sinacor.Text;
            }
            else
            {
                result.IsAuthenticated = sinacor.IsAuthenticated;
                result.Text = string.IsNullOrEmpty(result.Text) ? "Autenticação Falhou !!" : result.Text;
            }

            return result;

        }

        public async Task<SisfinanceResult> ObterAutenticacaoSisfinance()
        {
            var sisfinanceResult = new SisfinanceResult();
            var resultado = await _sisfinance.Autenticar();

            if (!string.IsNullOrEmpty(resultado.token))
            {
                sisfinanceResult.login = true;
                sisfinanceResult.text = "Autenticação Ok";

                return sisfinanceResult;
            }
                sisfinanceResult.login = false;
                sisfinanceResult.text = "Falha na autenticação";
                return sisfinanceResult;
        }

        public async Task<SmartBrainResult> ObterAutenticacaoSmartBrain()
        {
           

            var result = new SmartBrainResult();
            var smartBrain = await _smartBrainProxy.Autenticar();

            if (!(smartBrain is string) && !string.IsNullOrEmpty(smartBrain?.AccessToken))
            {
                result.login = true;
                result.text = "Autenticação Ok";
                
                return result;
            }
            else
            {
                result.login = false;
                result.text = smartBrain is string ? smartBrain : "Falha na autenticação";
                return result;
            }
        }

        public async Task<IcatuResult> ObterGrauParentescoIcatu()
        {
            var response = await _icatu.ObterGrauParentesco();
            if (response.Sucesso)
            {
                return new IcatuResult { Sucesso = true , Mensagem = "Comunicação Ok !"};
            }
            return new IcatuResult { Sucesso = false , Mensagem = response.Mensagem };
        }

        public async Task<InfotreasuryResult> ObterStatusInfotreasury()
        {
            var infotreasury = await _usuarioPiRepository.ObterDataGiroInfotreasury();
            return new InfotreasuryResult { DataGiro = infotreasury.DataGiro, Message = "Ok" };
        }

        public async Task LimparCacheRendaFixa(CacheRendaFixaSignature signature)
        {
            switch (signature.Tipo)
            {
                case TipoCacheRendaFixa.Gerentes:
                    await _apiCatalogoRendaFixaProxy.LimparCacheApiCatalogoGerentes();
                    break;

                case TipoCacheRendaFixa.Lastros:
                    await _apiCatalogoRendaFixaProxy.LimparCacheApiCatalogoLastros();
                    break;

                case TipoCacheRendaFixa.ProdutosBancarios:
                    await _apiCatalogoRendaFixaProxy.LimparCacheApiCatalogoProdutosBancarios();
                    break;

                case TipoCacheRendaFixa.ProdutosPrivados:
                    await _apiCatalogoRendaFixaProxy.LimparCacheApiCatalogoProdutosPrivado();
                    break;
                case TipoCacheRendaFixa.Todos:
                    await _apiCatalogoRendaFixaProxy.LimparCacheApiCatalogoGerentes();
                    await _apiCatalogoRendaFixaProxy.LimparCacheApiCatalogoLastros();
                    await _apiCatalogoRendaFixaProxy.LimparCacheApiCatalogoProdutosBancarios();
                    await _apiCatalogoRendaFixaProxy.LimparCacheApiCatalogoProdutosPrivado();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(signature.Tipo), signature.Tipo, "Tipo de cache não suportado.");
            }           
        }

    }
}
