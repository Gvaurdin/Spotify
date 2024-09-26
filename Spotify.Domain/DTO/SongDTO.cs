using Spotify.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Database.DTO
{
    public class SongDTO
    {
        public required string Title { get; set; }
        public string? Desciption { get; set; }
    }
}
