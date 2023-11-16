using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.Application
{
    public interface IPokemonService
    {
        void Editar(Pokemon obj);
        void Deletar(int id);
        void Criar(Pokemon obj);
        Pokemon BuscarPorId(int id);
        Pokemon BuscarPorNome(String nome);
        List<Pokemon> BuscarLista();

    }
}
