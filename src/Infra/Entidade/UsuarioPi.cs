namespace Infra.Result
{
    public class UsuarioPi
    {
        
        public TipoAutenticacao TipoAutenticacaoD { get; set; }
        public TipoUsuario TipoUsuarioD { get; set; }
        public TipoRole  CodigoRole { get; set; }
        public int CodUsuario { get; set; }
        public int CodTipoUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public int CodTipoAutenticacao { get; set; }
        public string TipoAutenticacao { get; set; }
        public int CodRole { get; set; }
        public string Role { get; set; }
        public string CodExterno { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public bool CodAtivo { get; set; }
        public string Ativo { get; set; }
    }
}