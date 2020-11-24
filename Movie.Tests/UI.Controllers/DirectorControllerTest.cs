using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movie.Application.Dtos;
using Movie.Application.Interfaces;
using Movie.Application.Validation;
using Movies.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Tests.UI.Controllers
{
    [TestClass]
    public class DirectorControllerTest
    {

        private DirectorsController directorController;

        Mock<IDirectorsService> mockIDirectorsService;
        Mock<DirectorsValidation> mockDirectorsValidation;

        [TestInitialize]
        public void Iniciar()
        {
            mockIDirectorsService = new Mock<IDirectorsService>();
            mockDirectorsValidation = new Mock<DirectorsValidation>();

            directorController = new DirectorsController(mockIDirectorsService.Object, mockDirectorsValidation.Object);
        }

        [TestMethod]
        public void TestCalcular()
        {
            var expected = 8;
            var result = directorController.Calcular(4, 4);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Post_Test_Ok()
        {

            var directorsDto = new DirectorsDto()
            {
                codigo = 1,
                nome = "Diretor teste",
                quantidade_filmes = 15
            };

            mockIDirectorsService.Setup(m => m.PostDirector(directorsDto)).Returns(directorsDto);

            var result = directorController.Post(directorsDto);
            var okResult = result as OkObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void Post_Test_Error()
        {
            var directorsDto = new DirectorsDto()
            {
                codigo = 1,
                nome = "Diretor test",
                quantidade_filmes = 150
            };


            var expected = "Não é possível cadastrar um diretor com mais de 15 filmes!";


            mockIDirectorsService
                .Setup(m => m.PostDirector(directorsDto))
                .Returns(directorsDto);

            var result = directorController.Post(directorsDto);
            var badRequestResult = result as BadRequestObjectResult;

            //Assert.AreEqual(400, badRequestResult.StatusCode);
            Assert.AreEqual(expected, badRequestResult.Value);
        }



    }
}
