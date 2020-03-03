using Senai.InLock.WebApi.Enums;

namespace Senai.InLock.WebApi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario {get;set;}
        public string Email {get;set;}
        public string Senha {get;set;}
        public int IdTipoUsuario {get;set;}
        
        public UsuarioDomain()
        {
            this.IdTipoUsuario = (int)TipoUsuario.Cliente;
        }
    }
}