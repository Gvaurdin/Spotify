using Microsoft.AspNetCore.Mvc;
using Spotify.Database.DTO;
using Spotify.Database.Entities;
using Spotify.Database.Repositories;
using Spotify.Database.Repositories.Interfaces;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Spotify.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongsController(ISongRepository songRepository,
        IAlbumRepository albumRepository) : Controller
    {
        [HttpGet(Name = "GetAllSongs")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Song>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var songs = await songRepository.GetAllAsync();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true,
                MaxDepth = 64 
            };

            string json = JsonSerializer.Serialize(songs, options);
            return Content(json, "application/json");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Song))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (!await songRepository.ExistsByIdAsync(id))
            {
                NotFound();
            }
            var song = await songRepository.GetByIdAsync(id);
            return Ok(song);
        }

        [HttpPost(Name = "AddSongAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddSongAsync([FromForm]SongDTO songDTO, [FromForm] List<int> albumIds)
        {
            if (songDTO == null)
            {
                return BadRequest();
            }
            var song = new Song
            {
                Title = songDTO.Title,
                Desciption = songDTO.Desciption,
                Albums = new List<Album>()
            };
            var albums = await albumRepository.GetAlbumsByIdsAsync(albumIds);
            if(albums.Count != 0)
            {
                song.Albums.AddRange(albums);
            }
            if (await songRepository.ExistsByTitleAsync(song.Title))
            {
                ModelState.AddModelError("", "Song already exists");
                return StatusCode(StatusCodes.Status402PaymentRequired, ModelState);
            }
            await songRepository.AddAsync(song);
            //return CreatedAtAction(nameof(GetByIdAsync), new { Id = song.Id },song);
            return Ok();
        }

        [HttpDelete("{id}", Name = "RemoveSong")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveSongAsync(int id)
        {
            if (!await songRepository.ExistsByIdAsync(id))
            {
                return NotFound();
            }
            await songRepository.RemoveAsync(id);
            return Ok();
        }

        [HttpPut("{id}", Name = "UpdateSong")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSongAsync(int id, [FromForm] SongDTO songDTO, [FromForm] List<int> albumIds)
        {
            if (!await songRepository.ExistsByIdAsync(id))
            {
                return NotFound();
            }
            var song = new Song
            {
                Title = songDTO.Title,
                Desciption = songDTO.Desciption,
                Albums = new List<Album>()
            };
            var albums = await albumRepository.GetAlbumsByIdsAsync(albumIds);
            if (albums.Count != 0)
            {
                song.Albums.AddRange(albums);
            }
            await songRepository.UpdateAsync(id, song);
            return Ok();
        }
    }
}
