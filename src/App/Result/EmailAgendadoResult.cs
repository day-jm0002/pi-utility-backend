using System;

namespace App.Result
{
    public class EmailAgendadoResult
    {
        public DateTime DataCadastro { get; set; }
        public DateTime? DataEnvio { get; set; }
        public int CodTemplate { get; set; }
        public string NomeTemplate { get; set; }
        public string Assunto { get; set; }
        public string Parametros { get; set; }
        public bool PossuiArquivo { get; set; }
        public bool Enviado { get; set; }
        public bool ErroEnvio { get; set; }
    }
}
