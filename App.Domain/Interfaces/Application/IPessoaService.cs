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
        void Editar(Pessoa pessoa);

        void Deletar(int id);

        void Criar(Pessoa pessoa);

        Pessoa BuscarPorId(int id);

        List<Pessoa> BuscarLista();


    }
}
