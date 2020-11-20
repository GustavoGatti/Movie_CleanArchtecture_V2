using Movie.Domain.Interfaces;
using Movie.Domain.Models;
using Movie.Infraestructure.IoC.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Infraestructure.IoC.Repositories
{
    public class DirectorsRepositories : IDirectorsRepository
    {
        private readonly MovieDbContext _dbContex;

        public DirectorsRepositories(MovieDbContext dbContext)
        {
            _dbContex = dbContext;
        }

        public IEnumerable<Directors> GetDirectors()
        {
            return _dbContex.Directors;
        }

        public Directors PostDirector(Directors directors)
        {
            try
            {
                _dbContex.Directors.Add(directors);
                _dbContex.SaveChanges();
                return directors;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
