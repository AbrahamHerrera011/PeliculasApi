using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PeliculasApi.Models
{
    public partial class Pelicula
    {
        [Required]
        public int Idpeliculas { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public string Genero { get; set; }
        public double Puntacion { get; set; }
        public string Rating { get; set; }
        public int AnioDePublicacion { get; set; }
    }
}
