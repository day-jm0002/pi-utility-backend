using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxy.AccessControl.Response;
using Proxy.AccessControl.Util;
using Proxy.Util;

namespace Proxy.AccessControl
{
    public class AccessControlProxy : IAccessControlProxy
    {
        public HttpClient _http { get; set; }
        
        public AccessControlProxy()
        {
            this._http = new HttpClient();
        }

        public async Task<List<RoleResultProxy>> ObterListaRolePortalInvestimentos()
        {
            try
            {
                _http.DefaultRequestHeaders.Accept.Clear();
                _http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/sjon"));
                _http.Timeout = TimeSpan.FromMinutes(1);
                var parametros = Sistema.CodigoDoSistema(new Sistema() { CodigoSistema = 14 });
                var content = new StringContent(parametros, Encoding.UTF8, "application/json");
                var result = await _http.PostAsync("http://sdaysp06qa009/AccessControl/Admin/sm/api/Role/Listar", content);
                var json = await result.Content.ReadAsStringAsync();
                var responseDto = JsonConvert.DeserializeObject<ResponseDto>(json);
                var retorno = JsonConvert.DeserializeObject<List<RoleResultProxy>>(responseDto.SerializedObject);
                return retorno;
            }catch(Exception ex)
            {
                return new List<RoleResultProxy>();
            }
        }

        public async Task<string> ObterTicket()
        {
            _http.DefaultRequestHeaders.Accept.Clear();
            _http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _http.Timeout = TimeSpan.FromMinutes(1);
            var parametros = SSO.PayloadToJson(new SSO() { CodCliente = "000271861" });
            var content = new StringContent(parametros, Encoding.UTF8, "application/json");
            var result = await _http.PostAsync("http://sdaysp06qa009/AccessControl/Security/sso/api/Ticket/CreateTicket", content);
            var json = await result.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<ResponseDto>(json);
            var retorno = JsonConvert.DeserializeObject<TicketSSo>(responseDto.SerializedObject);
            return retorno.Ticket;
        }

        public async Task<string> ObterTicket(string CodCliente)
        {
            _http.DefaultRequestHeaders.Accept.Clear();
            _http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _http.Timeout = TimeSpan.FromMinutes(1);
            var parametros = SSO.PayloadToJson(new SSO() { CodCliente = CodCliente });
            var content = new StringContent(parametros, Encoding.UTF8, "application/json");
            var result = await _http.PostAsync("http://sdaysp06qa009/AccessControl/Security/sso/api/Ticket/CreateTicket", content);
            var json = await result.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<ResponseDto>(json);
            var retorno = JsonConvert.DeserializeObject<TicketSSo>(responseDto.SerializedObject);
            return retorno.Ticket;
        }
    }
}