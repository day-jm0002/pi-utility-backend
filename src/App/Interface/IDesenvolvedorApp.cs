using App.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Interface
{
    public interface IDesenvolvedorApp
    {
        void ObterPorId();
        Task<List<DesenvolvedorResult>> ObterTodos();
    }
}
