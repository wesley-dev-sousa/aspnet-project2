using App.Domain.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Interfaces.Application {
    public interface ICidadeService {
        Cidade BuscaPorId(Guid id);
        Cidade BuscaPorCep(string cep);
        List<Cidade> listaCidades(string busca);
        void Salvar(Cidade obj);
        void Remover(Guid id);
    }
}