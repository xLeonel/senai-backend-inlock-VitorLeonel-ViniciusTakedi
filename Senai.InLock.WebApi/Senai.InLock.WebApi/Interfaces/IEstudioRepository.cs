using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IEstudioRepository
    {
        List<EstudioDomain> Listar(); //Para listar todos os Estudios
        void Cadastrar(EstudioDomain estudio); //Para cadastrar um novo jogo
        void AtualizarEstudioIdUrl(int id, EstudioDomain estudio); //Atualizar estudio passando seu id na url
        void Deletar(int id); //Para deletar um estudio
        EstudioDomain BuscarId(int id); // buscar estudio por Id
    }
}
