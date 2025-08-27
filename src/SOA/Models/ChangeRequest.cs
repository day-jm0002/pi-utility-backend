using System;

namespace PI.Utility.Models
{
    public class ChangeRequest
    {
        public Dados dados { get; set; }
        public Impactos impactos { get; set; }
        public Mudanca mudanca { get; set; }
        public Permissoes permissoes { get; set; }
        public PlanoVolta planoVolta { get; set; }
        public Procedimentos procedimentos { get; set;}
        public Testes testes { get; set; }
        public Usuario usuario { get; set; }

    }
} 

public class Dados
{
    public string TituloMudanca { get; set; }
    public string DataAbertura { get; set; }
    public string Solicitante { get; set; }
    public string DataHoraInicio { get; set; }
    public string TempoExecucao { get; set; }
    public string AreaBeneficiada { get; set; }
    public string LGPD { get; set; }
    public string Chamados { get; set; }
    public string Emergencial { get; set; }
    public string Acao { get; set; }
    public string JustificativaEmergencial { get; set; }
    public string CalculosFinanceiros { get; set; }
    public string ResponsavelCiencia { get; set; }
    public string Rpa { get; set; }
    public string Servidor { get; set; }
    public string PlanoVolta { get; set; }
    public string JustificativaPlanoVolta { get; set; }
    public string TempoPlanoVolta { get; set; }
    public string Monitoramento { get; set; }
    public string EquipeResponsavel { get; set; }
    public string NomeSistema { get; set; }
    public string TipoImpacto { get; set; }
    public string ServidorVip { get; set; }
    public string NomeServico { get; set; }
    public string TipoMonitoramento { get; set; }
    public string HealthCheck { get; set; }
    public string TempoChecagem { get; set; }
    public string QuantidadeChecagem { get; set; }
    public string Firewall { get; set; }
    public string Auditoria { get; set; }

}

public class Impactos
{
    public string ImpactosRotinaNoturna { get; set; }
    public string ImpactosOperadorNoturno { get; set; }

    public string RotinaNoturna { get; set; }
    public string OperadorNoturno { get; set; }
}

public class ListaPermissoes
{

}

public class Permissoes
{
    public string LoginBanco { get; set; }
    public string FinalidadeCriacao { get; set; }
    public string FinalidadeManutencao { get; set; }

}

public class PlanoVolta
{
    public string CouchbasePlanoVolta { get; set; }
    public string TipoAplicacaoPlanoVolta { get; set; }
    public string ProcedimentosDBAPlanoVolta { get; set; }
    public string ProcedimentosRedesPlanoVolta { get; set; }
    public string ProcedimentosGestaoPlanoVolta { get; set; }
}

public class Procedimentos
{
    public string Couchbase { get; set; }
    public string TipoAplicacao { get; set; }
    public string ProcedimentosDBA { get; set; }
    public string ProcedimentosRedes { get; set; }
    public string ProcedimentosGestao { get; set; }

}

public class Testes
{
    public string Homologacao { get; set; }
    public string JustificativaHomologacao { get; set; }
    public string TestesPrevios { get; set; }
    public string JustificativaTestesPrevios { get; set; }
    public string DescricaoTestes { get; set; }
    public string ResultadoTestes { get; set; }
    public string ResponsavelTestes { get; set; }
    public string TestesPos { get; set; }
    public string JustificativaTestesPos { get; set; }
    public string DescricaoTestesPos { get; set; }
    public string ResponsavelTestesPos { get; set; }

}

public class Usuario
{
    public string Treinamento { get; set; }
    public string ResponsavelTreinamento { get; set; }
    public string Divulgacao { get; set; }
    public string OrientacaoHelpDesk { get; set; }
    public string HelpDesk { get; set; }
    public string DetalhesHelpDesk { get; set; }
}

public class Mudanca
{
    public string Chamados { get; set; }
    public string Descricao { get; set; }
    public string RotinaNoturna { get; set; }
    public string OperadorNoturno { get; set; }

}