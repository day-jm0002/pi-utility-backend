namespace Proxy.AccessControl.Response
{
    public class RoleResultProxy
    {
        public int CodigoRole { get; set; }
        public int CodigoSistema { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}