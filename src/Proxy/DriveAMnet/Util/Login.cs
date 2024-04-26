using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.DriveAMnet.Util
{
    public class Login
    {
            public string? user { get; set; }
            public string? password { get; set; }
            public static string Autenticacao(Login login)
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(login);
            }        
    }
}
