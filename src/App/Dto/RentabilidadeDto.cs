using System;
using System.Collections.Generic;
using System.Text;

namespace App.Result
{
    public class RentabilidadeDto
    {
        //retorno sql
        public string DataPosicao { get; set; }
        public decimal ValorAplicado { get; set; }
        public decimal ValorBruto { get; set; }
        public string GrupoPapel { get; set; }

        public decimal Movimento { get; set; }
        public decimal Cota { get; set; }
        public decimal Rentabilidade { get; set; }
        public decimal Variacao { get; set; }

    }
}
