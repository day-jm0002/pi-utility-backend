namespace Proxy.AccessControl.Util
{
    public class Sistema
    {
        public int CodigoSistema { get; set; }
        
        public static string CodigoDoSistema(Sistema sistema)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(sistema);
        }
    }
}