namespace Proxy.Util
{
    public class ResponseDto
    {
        public string SerializedObject { get; set; }
        public bool IsResponseOk { get; set; }
        public int StatusCode { get; set; }
    }
}