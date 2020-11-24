using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;
using Movie.Application.Services;
using Moq;

namespace Movie.Tests.Application.Services
{
    [TestClass]
    public class MoviesService_Tests
    {

        public MoviesService moviesService;

        Mock<IMoviesRepository> mockIMoviesRespository;

        [TestInitialize]
        public void Inicio()
        {
            mockIMoviesRespository = new Mock<IMoviesRepository>();
            moviesService = new MoviesService(mockIMoviesRespository.Object);
        }

        public void GetMovieById_Test()
        {
            Assert.IsTrue(true);
        }
    }
}
