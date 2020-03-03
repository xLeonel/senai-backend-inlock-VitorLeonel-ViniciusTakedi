using System.Collections.Generic;
using Senai.InLock.WebApi.Domains;

namespace Senai.InLock.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        List<JogoDomain> ListarTodosJogos();
        List<UsuarioDomain> ListarUsuarios();
        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
        void Atualizar(int id, UsuarioDomain usuario);
    }
}