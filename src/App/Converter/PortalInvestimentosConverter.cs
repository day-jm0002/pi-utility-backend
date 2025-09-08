using App.Result;
using Infra.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Converter
{
    public static class PortalInvestimentosConverter
    {
        public static List<SistemasResult> ToListSistemaResult(this IList<Sistema> sistemas)
        {
            List<SistemasResult> result = new List<SistemasResult>();

            foreach (var sistemasItem in sistemas)
            {
                SistemasResult sistemaResult = new SistemasResult();
                sistemaResult.Id = sistemasItem.Id;
                sistemaResult.Nome = sistemasItem.Nome;
                result.Add(sistemaResult);
            }
            return result;
        }

        public static List<DesenvolvedorResult> ToListDesenvolvedorResult(this IList<Desenvolvedor> desenvolvedor)
        {
            List<DesenvolvedorResult> result = new List<DesenvolvedorResult>();

            foreach (Desenvolvedor desenvolvedorItem in desenvolvedor)
            {
                DesenvolvedorResult desenvolvedorResult = new DesenvolvedorResult();
                desenvolvedorResult.Id = desenvolvedorItem.Id;
                desenvolvedorResult.Nome = desenvolvedorItem.Nome;
                result.Add(desenvolvedorResult);
            }
            return result;
        }

        public static List<NegocioResult> ToListDesenvolvedorResult(this IList<Negocio> negocio)
        {
            List<NegocioResult> result = new List<NegocioResult>();

            foreach (Negocio negocioItem in negocio)
            {
                NegocioResult negocioResult = new NegocioResult();
                negocioResult.Id = negocioItem.Id;
                negocioResult.Nome = negocioItem.Nome;
                result.Add(negocioResult);
            }
            return result;
        }

        public static List<SituacaoResult> ToListSituacaoResult(this IList<AmbienteStatus> ambienteStatus)
        {
            List<SituacaoResult> result = new List<SituacaoResult>();

            foreach (AmbienteStatus status in ambienteStatus)
            {
                SituacaoResult situacao = new SituacaoResult();
                situacao.Id = status.Id;
                situacao.Descricao = status.Descricao;
                result.Add(situacao);
            }
            return result;
        }


    }
}
