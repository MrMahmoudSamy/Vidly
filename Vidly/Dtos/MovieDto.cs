﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
       
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
       
        [Range(1, 20)]
        public int NumberInStock { get; set; }


        [Required]
        
        public int GenreId { get; set; }

        public GenreDto Genre { get; set; }
    }
}