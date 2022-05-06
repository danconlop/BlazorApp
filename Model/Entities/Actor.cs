using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int YearsActive { get; set; }
        public string PhotoUrl { get; set; }
        [StringLength(100)]
        public string Bio { get; set; }
        public ICollection<Movie> Movies { get; set; }

    }
}
