using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.SmartBrain.Util
{
    public class LoginSmartBrain
    {
        public string? user { get; set; }
        public string? password { get; set; }
        public static string Autenticacao(LoginSmartBrain login)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(login);
        }
    }
}
