using Movie.Application.Dtos;
using Movie.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Movie.Domain.Interfaces;
using System.Linq;
using Movie.Domain.Models;

namespace Movie.Application.Services
{
    public class DirectorsService : IDirectorsService
    {
        private readonly IDirectorsRepository _directorsRepository;

        public DirectorsService(IDirectorsRepository directorsRepository)
        {
            _directorsRepository = directorsRepository;
        }

        public IEnumerable<DirectorsDto> GetDirectorsDtos()
        {
            var diretoresDto = new List<DirectorsDto>();
            var diretores = _directorsRepository.GetDirectors();
            foreach (var diretor in diretores)
            {
                diretoresDto.Add(new DirectorsDto()
                {
                    codigo = diretor.Id,
                    quantidade_filmes = diretor.CountMovies,
                    nome = diretor.Name
                });
            }
            return diretoresDto;
        }

        public DirectorsDto PostDirector(DirectorsDto directorsDto)
        {
            if(directorsDto == null)
            {
                return null;
            }
            var diretor = new Directors()
            {
                Name = directorsDto.nome,
                CountMovies = directorsDto.quantidade_filmes
            };
            _directorsRepository.PostDirector(diretor);
            return directorsDto;
        }
    }
}
