using Movie.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Domain.Interfaces
{
    public interface IDirectorsRepository
    {

        IEnumerable<Directors> GetDirectors();

        Directors PostDirector(Directors directors);
    }
}
