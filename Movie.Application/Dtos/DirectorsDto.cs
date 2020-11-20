﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Application.Dtos
{
    public class DirectorsDto
    {
        [JsonProperty("codigo")]
        public int codigo { get; set; }

        [JsonProperty("nome")]
        public string nome { get; set; }

        [JsonProperty("quantidade_filmes")]
        public int quantidade_filmes { get; set; }
    }
}
