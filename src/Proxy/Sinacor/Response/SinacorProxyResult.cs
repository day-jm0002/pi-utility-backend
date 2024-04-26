using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.Sinacor.Response
{
    public  class SinacorProxyResult
    {
            public string AuthenticationReqId { get; set; }
            public string IsAuthenticated { get; set; }
            public string Username { get; set; }
            public string Text { get; set; }
    }
}
