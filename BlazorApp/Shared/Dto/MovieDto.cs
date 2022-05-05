using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Poster { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}
