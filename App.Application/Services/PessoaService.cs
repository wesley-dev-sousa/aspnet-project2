
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class PessoaService : IPessoaService {
        private IRepositoryBase<Pessoa> _repository { get; set; }
        public PessoaService(IRepositoryBase<Pessoa> repository)
        {
            _repository = repository;
        }
        private void ValidarDados(Pessoa obj)
        {
            if (string.IsNullOrEmpty(obj.Nome))
            {
                throw new ArgumentNullException(nameof(obj.Nome), "Nome não pode estar vazio.");
            }
            if (obj.DataAniversario == null) {
                throw new ArgumentNullException(nameof(obj.DataAniversario), "Data de Aniversario não pode estar vazia.");
            }
            if (string.IsNullOrEmpty(obj.Email))
            {
                throw new ArgumentNullException(nameof(obj.Email), "Email não pode estar vazio.");
            }
            if (string.IsNullOrEmpty(obj.Senha))
            {
                throw new ArgumentNullException(nameof(obj.Senha), "Senha não pode estar vazia.");
            }
        }
      
      public void Criar(Pessoa obj)
        {
            ValidarDados(obj);
            _repository.Save(obj);
            _repository.SaveChanges();
        }
        public void Editar(Pessoa pessoa)
        {
            var dadosAntigos = _repository.Query(x => x.Id ==
            pessoa.Id).FirstOrDefault();
            if (dadosAntigos == null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }
            Pessoa dadosAtualizados = new Pessoa
            {
                Id = dadosAntigos.Id,
                CPF = dadosAntigos.CPF,
                Nome = pessoa.Nome ?? dadosAntigos.Nome,
                DataAniversario = (pessoa.DataAniversario != null) ? pessoa.DataAniversario : dadosAntigos.DataAniversario,
                Email = (pessoa.Email != null) ? pessoa.Email :
            dadosAntigos.Email,
                Senha = (pessoa.Senha != null) ? pessoa.Senha :
            dadosAntigos.Senha
            };
            _repository.Update(dadosAtualizados);
            _repository.SaveChanges();
        }
        public List<Pessoa> listaPessoas(string? busca) {
            busca = (busca ?? "").ToUpper();
            return _repository.Query(x =>

            (
            x.Nome.ToUpper().Contains(busca) ||
            x.DataAniversario.ToString().ToUpper().Contains(busca) ||
            x.CPF.ToString().ToUpper().Contains(busca)
            )

            ).ToList();
        }
        public void Deletar(int id)
        {
            var dadosAntigos = _repository.Query(x => x.Id == id).FirstOrDefault();
            if (dadosAntigos == null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }
            _repository.Delete(id);
            _repository.SaveChanges();
        }
        public Pessoa BuscarPorId(int id)
        {
            var pessoa = _repository.Query(x => x.Id == id).FirstOrDefault();
            return pessoa;
        }
        public List<Pessoa> BuscarLista()
        {
            return _repository.Query(x => 1 == 1).ToList();
        }

        public List<Pessoa> BuscarLista(string? busca) {
            throw new NotImplementedException();
        }
    }
}
