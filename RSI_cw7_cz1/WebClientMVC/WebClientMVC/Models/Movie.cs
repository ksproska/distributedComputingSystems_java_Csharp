using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebClientMVC.Models
{
    public class Movie
    {
        public Movie() { }
        public Movie(int id, string title, int length, string director)
        {
            Id = id;
            Title = title;
            Length = length;
            Director = director;
        }
        //[Required]
        [JsonProperty("Id")]
        public int Id { get; set; }
        [Required]
        [JsonProperty("Title")]
        public string Title { get; set; }
        [Required]
        [JsonProperty("Length")]
        public int Length { get; set; }
        [Required]
        [JsonProperty("Director")]
        public string Director { get; set; }
    }
}
