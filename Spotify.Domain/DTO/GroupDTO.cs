using Spotify.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Database.DTO
{
    public class GroupDTO
    {
        public required string Title { get; set; }
        public required DateOnly FoundationDate { get; set; }
        public required string UrlImage { get; set; }
        public string? Description { get; set; }
    }
}
