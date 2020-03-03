using System.Collections.Generic;
using Senai.InLock.WebApi.Domains;

namespace Senai.InLock.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        List<JogoDomain> ListarTodosJogos();

        UsuarioDomain BuscarPorEmailSenha(string email, string senha);

    }
}