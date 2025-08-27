using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using App.Interface;
using PI.Utility.App.Interface;
using PI.Utility.App.Result;
using PI.Utility.Models;

namespace PI.Utility.App
{
    public class ChangeApp : IChangeApp
    {
        private readonly IWordDocumentApp _wordDocumentApp;

        public ChangeApp(IWordDocumentApp wordDocumentApp)
        {
            _wordDocumentApp = wordDocumentApp;
        }

        public async Task<ChangeResult> ProcessarMudanca(ChangeRequest request)
        {
            try
            {

                string templatePath = Path.Combine(@"C:\Daycoval\", "Documento_Original.docx");

                // Caminho onde o arquivo será salvo
                string outputPath = Path.Combine(@"C:\Daycoval\Mudanca\", "R25-02-21682-GMUD-Portal-Investimentos-Chamada-Capital-V3.7.0_rev003.docx");

                // Variáveis a serem substituídas
                var variables = new Dictionary<string, string>
{
                    { "1.1-TituloMudanca", request.dados.TituloMudanca },
    { "1.2-DataAbertura", DateTime.ParseExact(request.dados.DataAbertura, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy") },
    { "1.3-Solicitante", request.dados.Solicitante },
    { "1.4-DataHoraInicio", request.dados.DataHoraInicio },
    { "1.5-TempoExecucao", request.dados.TempoExecucao },
    { "1.6-AreaBeneficiada", request.dados.AreaBeneficiada },
    { "1.7-MotivoEmergencial", "TESTE DE VARIAVEL" },
    { "1.7-AcaoGMUD", request.dados.Acao },
    { "1.7.1-JustificativaGMUD", request.dados.JustificativaEmergencial },
    { "1.8-CalculosFinanceiros", request.dados.CalculosFinanceiros },
    { "1.9-LGPD", request.dados.LGPD },
    { "1.9.1-ResponsavelCiencia", request.dados.ResponsavelCiencia },
    { "1.9.2-RPA", request.dados.Rpa },
    { "1.10-Servidor", request.dados.Servidor },
    { "1.11-PlanoVolta", request.dados.PlanoVolta },
    { "1.11-JustificativaPlanoVolta", request.dados.JustificativaPlanoVolta },
    { "1.12-TempoPlanoVolta", request.dados.TempoPlanoVolta },
    { "1.13-Monitoramento", request.dados.Monitoramento },
    { "1.13-EquipeResponsavel", request.dados.EquipeResponsavel },
    { "1.13-NomeSistema", request.dados.NomeSistema },
    { "1.13-TipoImpacto", request.dados.TipoImpacto },
    { "1.13-ServidorVip", request.dados.ServidorVip },
    { "1.13-NomeServico", request.dados.NomeServico },
    { "1.13-TipoMonitoramento", request.dados.TipoMonitoramento },
    { "1.13-HealthCheck", request.dados.HealthCheck },
    { "1.13-TempoChecagem", request.dados.TempoChecagem },
    { "1.13-QuantidadeChecagem", request.dados.QuantidadeChecagem },
    { "1.14-Firewall", request.dados.Firewall },
    { "1.15-Auditoria", request.dados.Auditoria },
    { "1.16-Chamados", request.dados.Chamados },

    // 2.0 - Mudança
    { "2.1-ChamadosAssociados", request.mudanca.Chamados },
    { "2.2-DescricaoMudanca", request.mudanca.Descricao },
    { "2.3-RotinaNoturna", request.mudanca.RotinaNoturna },
    { "2.4-OperadorNoturno", request.mudanca.OperadorNoturno },

    // 3.0 - Impactos
    { "3.1-ImpactoRotinaNoturna", request.impactos.RotinaNoturna },
    { "3.2-OperadorNoturno", request.impactos.OperadorNoturno },
    { "3.3-ImpactosMudanca", request.impactos.OperadorNoturno },
    { "3.3.1-QuaisImpactos", request.impactos.OperadorNoturno },
    { "3.4-ItensAfetados", request.impactos.OperadorNoturno },

    // 4.0 - Usuário
    { "4.1-Treinamento", request.usuario.Treinamento },
    { "4.2-ResponsavelTreinamento", request.usuario.ResponsavelTreinamento },
    { "4.3-Divulgacao", request.usuario.Divulgacao },
    { "4.4-OrientacaoHelpDesk", request.usuario.OrientacaoHelpDesk },
    { "4.5-HelpDesk", request.usuario.HelpDesk },
    { "4.6-DetalhesHelpDesk", request.usuario.DetalhesHelpDesk },

    // 5.0 - Testes
    { "5.1-Homologacao", request.testes.Homologacao },
    { "5.1.1-JustificativaHomologacao", request.testes.JustificativaHomologacao },
    { "5.2-TestesPrevios", request.testes.TestesPrevios },
    { "5.2.1-JustificativaTestesPrevios", request.testes.JustificativaTestesPrevios },
    { "5.3-DescricaoTestes", request.testes.DescricaoTestes },
    { "5.4-ResultadoTestes", request.testes.ResultadoTestes },
    { "5.5-ResponsavelTestes", request.testes.ResponsavelTestes },
    { "5.6-TestesPos", request.testes.TestesPos },
    { "5.6.1-JustificativaTestesPos", request.testes.JustificativaTestesPos },
    { "5.7-DescricaoTestesPos", request.testes.DescricaoTestesPos },
    { "5.8-ResponsavelTestesPos", request.testes.ResponsavelTestesPos },

    // 6.0 - Permissões
    { "6.1-BancoDeDados", request.permissoes.LoginBanco },
    { "6.1-FinalidadeCriacao", request.permissoes.FinalidadeCriacao },
    { "6.1-FinalidadeManutencao", request.permissoes.FinalidadeManutencao },

    // 7.0 - Procedimentos
    { "7.1-Couchbase", request.procedimentos.Couchbase },
    { "7.1.1-TipoAplicacao", request.procedimentos.TipoAplicacao },
    { "7.1.2-ProcedimentosDBA", request.procedimentos.ProcedimentosDBA },
    { "7.3-ProcedimentosRedes", request.procedimentos.ProcedimentosRedes },
    { "7.4-ProcedimentosGestao", request.procedimentos.ProcedimentosGestao },

    // 8.0 - Plano de Volta
    { "8.1-CouchbasePlanoVoltaDBA", request.planoVolta.CouchbasePlanoVolta },
    { "8.1.2-TipoAplicacaoPlanoVoltaDBA", request.planoVolta.TipoAplicacaoPlanoVolta },
    { "8.1.3-ProcedimentoPlanoVoltaDBA", request.planoVolta.ProcedimentosDBAPlanoVolta },
    { "8.2-ProcedimentosRedesPlanoVolta", request.planoVolta.ProcedimentosRedesPlanoVolta },
    { "8.3-ProcedimentosGestaoPlanoVolta", request.planoVolta.ProcedimentosGestaoPlanoVolta },
};
                _wordDocumentApp.ReplaceVariables(templatePath, outputPath, variables);


                if (string.IsNullOrEmpty(request.dados.TituloMudanca))
                {
                    return new ChangeResult
                    {
                        Success = false,
                        Message = "O título da mudança é obrigatório"
                    };
                }


                return new ChangeResult
                {
                    Success = true,
                    Message = "Mudança processada com sucesso",
                    IdMudanca = Guid.NewGuid().ToString()
                };
            }
            catch (Exception ex)
            {
                return new ChangeResult
                {
                    Success = false,
                    Message = $"Erro ao processar mudança: {ex.Message}"
                };
            }
        }
    }
}