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
    public class AlbumsController(IAlbumRepository albumRepository,
        ISongRepository songRepository,
        IGroupRepository groupRepository) : Controller
    {
        [HttpGet(Name = "GetAllAlbums")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Album>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var albums = await albumRepository.GetAllAsync();
            // Настройка JsonSerializerOptions
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true,
                MaxDepth = 64 // Установите желаемую максимальную глубину
            };

            // Сериализация в JSON
            string json = JsonSerializer.Serialize(albums, options);
            return Content(json, "application/json");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Album))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (await albumRepository.ExistsByIdAsync(id))
            {
                NotFound();
            }
            var album = await albumRepository.GetByIdAsync(id);
            return Ok(album);
        }

        [HttpPost(Name = "AddAlbum")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAlbumAsync([FromForm] AlbumDTO albumDTO, [FromForm] List<int> songIds, [FromForm] List<int> groupIds )
        {
            if (albumDTO == null)
            {
                return BadRequest();
            }
            var album = new Album
            {
                Title = albumDTO.Title,
                Description = albumDTO.Description,
                ReleaseDate = albumDTO.ReleaseDate,
                Groups = new List<Group>(),
                Songs = new List<Song>()
            };
            var songs = await songRepository.GetSongsByIdsAsync(songIds);
            if (songs.Count != 0)
            {
                album.Songs.AddRange(songs);
            }
            var groups = await groupRepository.GetGroupsByIdsAsync(groupIds);
            if (groups.Count != 0)
            {
                album.Groups.AddRange(groups);
            }
            if (await albumRepository.ExistsByTitleAsync(album.Title))
            {
                ModelState.AddModelError("", "Album already exists");
                return StatusCode(StatusCodes.Status402PaymentRequired, ModelState);
            }
            await albumRepository.AddAsync(album);
            return Ok();
        }

        [HttpDelete("{id}", Name = "RemoveAlbum")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveAlbumAsync(int id)
        {
            if (!await albumRepository.ExistsByIdAsync(id))
            {
                return NotFound();
            }
            await albumRepository.RemoveAsync(id);
            return Ok();
        }

        [HttpPut("{id}", Name = "UpdateAlbum")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAlbumAsync(int id, [FromForm] AlbumDTO albumDTO, [FromForm] List<int> songIds, [FromForm] List<int> groupIds)
        {
            if (!await albumRepository.ExistsByIdAsync(id))
            {
                return NotFound();
            }
            var album = new Album
            {
                Title = albumDTO.Title,
                Description = albumDTO.Description,
                ReleaseDate = albumDTO.ReleaseDate,
                Groups = new List<Group>(),
                Songs = new List<Song>()
            };
            var songs = await songRepository.GetSongsByIdsAsync(songIds);
            if (songs.Count != 0)
            {
                album.Songs.AddRange(songs);
            }
            var groups = await groupRepository.GetGroupsByIdsAsync(groupIds);
            if (groups.Count != 0)
            {
                album.Groups.AddRange(groups);
            }
            await albumRepository.UpdateAsync(id, album);
            return Ok();
        }
    }
}
