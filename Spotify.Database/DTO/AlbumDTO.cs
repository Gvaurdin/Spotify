﻿using Spotify.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Database.DTO
{
    public class AlbumDTO
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required DateOnly ReleaseDate { get; set; }
    }
}
