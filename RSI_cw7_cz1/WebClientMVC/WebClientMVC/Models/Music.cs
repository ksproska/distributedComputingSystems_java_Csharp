using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebClientMVC.Models
{
    public class Music
    {
        public Music() { }
        public Music(int id, string title, string genre, string author, float length)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Author = author;
            Length = length;
        }
        //[Required]
        [JsonProperty("Id")]
        public int Id { get; set; }
        [Required]
        [JsonProperty("Title")]
        public string Title { get; set; }
        [Required]
        [JsonProperty("Genre")]
        public string Genre { get; set; }
        [Required]
        [JsonProperty("Author")]
        public string Author { get; set; }
        [Required]
        /*[Range(0, float.MaxValue, ErrorMessage = "Please enter positive number")] //TODO: change condition?*/
        [JsonProperty("Length")]
        public float Length { get; set; }
    }
}
