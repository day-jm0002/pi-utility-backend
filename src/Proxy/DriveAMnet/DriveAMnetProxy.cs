using Newtonsoft.Json;
using Proxy.DriveAMnet.Interface;
using Proxy.DriveAMnet.Response;
using Proxy.DriveAMnet.Util;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.DriveAMnet
{
    public class DriveAMnetProxy : IDriveAMnetProxy
    {
        public RestClient _rest { get; set; }
        public DriveAMnetProxy()
        {
           this._rest = new RestClient("http://sdaysp06qa072:8080/DaycovalQA/api/v1/auth/login");
        }
        public async Task<DriveAMnetResponse> Autenticar()
        {            
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "AMnetWebToken=eyJhbGciOiJIUzUxMiJ9.eyJ1c3ItaWQiOjE1MDg1ODY0ODIsImlzcyI6IlNpbnFpYSIsImNoYW5uZWwiOiJCQUNLT0ZGSUNFIiwiZXhwIjoxNjgzNjQzNTc0LCJzc24taWQiOjE1MTI2NDcyNTh9.2iNQDqOUFaxW2cR59dN-zlvzwP_aTg1v9nbR3tgzibTXssf5cXdkZiygiYxiqB2y5rsx6FAs80vKpWfCs4orUA");
            var body = Login.Autenticacao(new Login() { user = "csh_DriveAMnetapi", password = "IFppJXq0tyDlyuHZeiq9" });
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse content = await _rest.ExecuteAsync(request);
            var drive = JsonConvert.DeserializeObject<DriveAMnetResponse>(content.Content);
            return drive;
        }        
    }
}


