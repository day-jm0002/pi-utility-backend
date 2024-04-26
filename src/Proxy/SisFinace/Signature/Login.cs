using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.SisFinace.Signature
{
    public class Login
    {
        public string? login { get; set; }
        public string? password { get; set; }
        public static string Credenciais(Login login)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(login);
        }
    }
}
