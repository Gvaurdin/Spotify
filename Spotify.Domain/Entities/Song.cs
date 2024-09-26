using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Spotify.Domain.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Desciption { get; set; }
        public List<Album> Albums { get; set; } = new List<Album>();
    }
}
