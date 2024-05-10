using App.Result;
using App.Signature;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Interface
{
    public interface IAmbienteApp
    {
        Task<List<AmbienteResult>> ObterTodos();
        Task<AmbienteResultQa> ObterPacoteQa();
        Task AtualizarAmbiente(AmbienteSignature ambienteSignature);
        Task AtualizarAmbienteQa(AmbienteSignatureQa ambienteSignature);
        Task AtualizarChamadoAmbienteQa(AmbienteChamadoSignature ambienteSignature);

    }
}
