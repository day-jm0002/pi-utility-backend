using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.AccessControl.Util
{
    public class SSO
    {
        public int CodSistema => 14;
        public string Login => "ss0001";
        public string RequestByHost => "10.11.21.192";

        private string _codCliente;
        public string CodCliente
        {
            get { return _codCliente; }
            set { _codCliente = value; }
        }

        public string Payload => "{\"path\": \"consulta-posicao\", \"codCliente\": \"" + CodCliente + "\"}";


        public static string PayloadToJson(SSO sso)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(sso);
        }

        
    }

    public class TicketSSo
    {
        public string Ticket { get; set; }
    }

    public class Payload
    {
        public string path => "consulta-posicao";
        public string codCliente => "000634646";
    }
}
