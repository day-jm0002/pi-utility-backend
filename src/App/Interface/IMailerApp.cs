using App.Result;
using App.Signature.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Interface
{
    public interface IMailerApp
    {
        public Task EmailAgendado(EmailAgendadoSignature signature);
    }
}
