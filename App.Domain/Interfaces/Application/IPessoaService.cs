using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.Application
{
    public interface IPessoaService
    {
        List<Pessoa> listaPessoas(string? busca);
        Pessoa BuscarPorId(int id);
        void Criar(Pessoa obj);
        void Editar(Pessoa obj);
        void Deletar(int id);
    }
}
