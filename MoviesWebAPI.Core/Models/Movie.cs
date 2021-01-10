using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesWebAPI.Core.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Language { get; set; }
        public string Location { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public List<string> SoundEffects { get; set; }
        public List<string> Stills { get; set; }
        public string Title { get; set; }
        public string ImdbID { get; set; }
        public string ListingType { get; set; }
        public string ImdbRating { get; set; }
    }
}
