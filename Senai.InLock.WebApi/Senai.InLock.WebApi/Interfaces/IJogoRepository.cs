using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IJogoRepository
    {
        List<JogoDomain> Listar(); //Para listar todos os jogos
        void Cadastrar(JogoDomain jogo); //Para cadastrar um novo jogo
        void AtualizarJogoIdUrl(int id, JogoDomain jogo); //Para atulizar um jogo existente passando o Id na URL
        void Deletar(int id); //Para deletar um jogo

    }
}
