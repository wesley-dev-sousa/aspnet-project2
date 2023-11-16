using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Application.Services {
    public class CidadeService : ICidadeService {
        private IRepositoryBase<Cidade> _repository { get; set; }
        public CidadeService(IRepositoryBase<Cidade> repository) {
            _repository = repository;
        }
        public Cidade BuscaPorCep(string cep) {
            if (!String.IsNullOrEmpty(cep)) {
                throw new Exception("Informe o CEP!");
            }
            var obj = _repository.Query(x => x.Cep == cep).FirstOrDefault();
            return obj;
        }

        public Cidade BuscaPorId(int id) {

            var obj = _repository.Query(x => x.Id == id).FirstOrDefault();
            return obj;
        }

        public List<Cidade> listaCidades(string busca) {
            busca = (busca ?? "").ToUpper();
            return _repository.Query(x =>

            (
            x.Nome.ToUpper().Contains(busca) ||
            x.Cep.ToUpper().Contains(busca) ||
            x.Uf.ToUpper().Contains(busca)
            )

            ).ToList();
        }

        public void Remover(int id) {
            _repository.Delete(id);
            _repository.SaveChanges();
        }

        public void Salvar(Cidade obj) {
            if (String.IsNullOrEmpty(obj.Nome)) {
                throw new Exception("Informe o nome");
            }
            _repository.Save(obj);
            _repository.SaveChanges();
        }
    }
}
