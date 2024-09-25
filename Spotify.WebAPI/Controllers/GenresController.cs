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
    public class GenresController(IGenreRepository genreRepository,
        IGroupRepository groupRepository) : Controller
    {
        [HttpGet(Name = "GetAllGenres")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Genre>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var genres = await genreRepository.GetAllAsync();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true,
                MaxDepth = 64
            };

            string json = JsonSerializer.Serialize(genres, options);
            return Content(json, "application/json");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Genre))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (!await genreRepository.ExistsByIdAsync(id))
            {
                NotFound();
            }
            var genre = await genreRepository.GetByIdAsync(id);
            return Ok(genre);
        }

        [HttpPost(Name = "AddGenre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddGenreAsync([FromForm] GenreDTO genreDTO, [FromForm] List<int> groupIds)
        {
            if (genreDTO == null)
            {
                return BadRequest();
            }
            var genre = new Genre
            {
                Title = genreDTO.Title,
                Groups = new List<Group>()
            };
            var groups = await groupRepository.GetGroupsByIdsAsync(groupIds);
            if (groups.Count != 0)
            {
                genre.Groups.AddRange(groups);
            }
            if (await genreRepository.ExistsByTitleAsync(genre.Title))
            {
                ModelState.AddModelError("", "Genre already exists");
                return StatusCode(StatusCodes.Status402PaymentRequired, ModelState);
            }
            await genreRepository.AddAsync(genre);
            return Ok();
        }

        [HttpDelete("{id}", Name = "RemoveGenre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveGenreAsync(int id)
        {
            if (!await genreRepository.ExistsByIdAsync(id))
            {
                return NotFound();
            }
            await genreRepository.RemoveAsync(id);
            return Ok();
        }

        [HttpPut("{id}", Name = "UpdateGenre")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateGenreAsync(int id, [FromForm] GenreDTO genreDTO, List<int> groupIds)
        {
            if (!await genreRepository.ExistsByIdAsync(id))
            {
                return NotFound();
            }
            var genre = new Genre
            {
                Title = genreDTO.Title,
                Groups = new List<Group>()
            };
            var groups = await groupRepository.GetGroupsByIdsAsync(groupIds);
            if (groups.Count != 0)
            {
                genre.Groups.AddRange(groups);
            }
            await genreRepository.UpdateAsync(id, genre);
            return Ok();
        }
    }
}
