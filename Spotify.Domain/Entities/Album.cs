using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public List<Group> Groups { get; set; } = new List<Group>();
        public List<Song> Songs { get; set; } = new List<Song>();
    }
}




