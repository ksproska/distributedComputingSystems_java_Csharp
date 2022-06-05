using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebClientMVC.Models
{
    public class Book
    {
        public Book() { }
        public Book(int id, string title, string genre, string author)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Author = author;
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

    }
}
