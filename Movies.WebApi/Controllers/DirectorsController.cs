using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.Dtos;
using Movie.Application.Interfaces;
using Movie.Application.Services;
using Movie.Application.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.WebApi.Controllers
{
    [Route("api/diretores")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorsService _directorsService;
        private readonly DirectorsValidation _directorsValidation;

        public DirectorsController(IDirectorsService directorsService, DirectorsValidation directorsValidation)
        {
            _directorsService = directorsService;
            _directorsValidation = directorsValidation;

        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_directorsService.GetDirectorsDtos());
        }

        [HttpPost]
        public IActionResult Post([FromBody]DirectorsDto directorsDto)
        {
            return Ok(_directorsService.PostDirector(directorsDto));
        }
        
        public int Calcular(int num1, int num2)
        {
            return num1 + num2;
        }

    }
}
