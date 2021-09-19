using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Data
{
    public class Book
    {
        public int Id {get;set;}

        [Required]
        [StringLength(200)]
        public string Name {get;set;}

        [StringLength(200)]
        public string Author {get;set;}

        public string CoverUrl {get;set;}

        public DateTime PublishDate {get;set;}
    }
}