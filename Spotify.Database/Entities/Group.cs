using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Database.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required DateOnly FoundationDate { get; set; }
        public required string UrlImage { get; set; }
        public string? Description { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<Album> Albums { get; set; } = new List<Album>();
    }
}
