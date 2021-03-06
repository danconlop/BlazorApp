using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Poster { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public string TitleFit
        {
            get
            {
                if (string.IsNullOrEmpty(Title))
                {
                    return null;
                }
                if(Title.Length > 60)
                {
                    return Title.Substring(0, 57) + "...";
                }
                else
                {
                    return Title;
                }

            }
        }
        
    }
}
