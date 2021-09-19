using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id {get;set;}

        [Required]
        [MaxLength(200)]
        public string Name {get;set;}

        public string Author {get;set;}

        [Display(Name = "Publish Date")]
        [DataType(DataType.Date)]
        public DateTime PublishDate {get;set;}

        [Display(Name = "Upload Book Cover")]
        public IFormFile CoverFile {get;set;}

        public string CoverUrl {get;set;}

        public async Task SaveCover(IWebHostEnvironment host)
        {
            if (CoverFile == null)
                return;

            string filePath = @$"{host.WebRootPath}\img\{CoverFile.FileName}";
            using (FileStream targetFile = new FileStream(filePath, FileMode.Create))
            {
                await CoverFile.CopyToAsync(targetFile);
            }

            CoverUrl = $"img/{CoverFile.FileName}";
        }
    }
}