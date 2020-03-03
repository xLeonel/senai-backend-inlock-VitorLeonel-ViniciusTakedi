using System.Collections.Generic;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            throw new System.NotImplementedException();
        }

        public List<JogoDomain> ListarTodosJogos()
        {
            throw new System.NotImplementedException();
        }
    }
}