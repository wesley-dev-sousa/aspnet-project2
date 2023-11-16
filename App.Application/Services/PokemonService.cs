using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class PokemonService : IPokemonService
    {
        private IRepositoryBase<Pokemon> _repository { get; set; }

        public PokemonService(IRepositoryBase<Pokemon> repository)
        {
            _repository = repository;
        }

        public void ValidarDados(Pokemon pokemon)
        {
            if (string.IsNullOrEmpty(pokemon.Nome))
            {
                throw new ArgumentNullException(nameof(pokemon.Nome), "Nome não pode estar vazio.");
            }
            if (pokemon.Level == 0)
            {
                throw new ArgumentNullException(nameof(pokemon.Nome), "O level não pode ser 0.");
            }
            if (pokemon.Tipo.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(pokemon.Nome), "O tipo não pode ser vazio.");
            }
        }


        void IPokemonService.Criar(Pokemon pokemon)
        {

            ValidarDados(pokemon);
            _repository.Save(pokemon);
            _repository.SaveChanges();
        }

        public List<Pokemon> BuscarLista()
        {
            return _repository.Query(x=>1 == 1).ToList();
        }

        public Pokemon BuscarPorId(int id)
        {
            var obj = _repository.Query(x => x.Id == id).FirstOrDefault();
            return obj;
        }

        public void Deletar(int id)
        {
            var dadosAntigos = _repository.Query(x => x.Id == id).FirstOrDefault();
            if (dadosAntigos == null)
            {
                throw new ArgumentException("Pokemon não encontrado.");
            }
            _repository.Delete(id);
            _repository.SaveChanges();
        }

       

        void IPokemonService.Editar(Pokemon pokemon)
        {
            var dadosAntigos = _repository.Query(x => x.Id ==
            pokemon.Id).FirstOrDefault();
            if (dadosAntigos == null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }
            Pokemon dadosAtualizados = new Pokemon
            {
                Id = dadosAntigos.Id,
                Nome = pokemon.Nome ?? dadosAntigos.Nome,
                Level = (pokemon.Level != 0) ? pokemon.Level :
            dadosAntigos.Level,
                Tipo = (pokemon.Tipo.IsNullOrEmpty()) ? pokemon.Tipo :
            dadosAntigos.Tipo
            };
            _repository.Update(dadosAtualizados);
            _repository.SaveChanges();
        }

        Pokemon IPokemonService.BuscarPorNome(string nome)
        {
            var obj = _repository.Query(x => x.Nome == nome).FirstOrDefault();
            return obj;
        }
    }
}
