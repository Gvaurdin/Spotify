using Microsoft.AspNetCore.Mvc;
using Spotify.Database.DTO;
using Spotify.Database.Entities;
using Spotify.Database.Repositories;
using Spotify.Database.Repositories.Interfaces;
using System.Text.Json.Serialization;
using System.Text.Json;
using AutoMapper;
using Spotify.Application.Models.Albums.Queries.GetAlbumList;
using Spotify.Application.Models.Albums.Queries.GetAlbumDetails;
using Spotify.Application.Models.Albums.Commands.CreateAlbum;
using Spotify.Application.Models.Albums.Commands.UpdateAlbum;
using Spotify.Application.Models.Albums.Commands.DeleteAlbum;

namespace Spotify.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController(IMapper mapper) : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<AlbumListViewModel>> GetAll(int countSkipAlbums, int countTakeAlbums)
        {
            var query = new GetAlbumListQuery
            {
                CountSkipAlbums = countSkipAlbums,
                TakeAlbums = countTakeAlbums
            };
            if (Mediator is null)
            {
                throw new NullReferenceException("Mediator is null");
            }
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumListViewModel>> GetById(int id)
        {
            var query = new GetAlbumDetailsQuery { Id = id };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateAlbumDTO createAlbumDTO)
        {
            var command = mapper.Map<CreateAlbumCommand>(createAlbumDTO);
            if (Mediator is null)
            {
                throw new NullReferenceException("Mediator is null");
            }
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAlbumDTO updateAlbumDTO)
        {
            var command = mapper.Map<UpdateAlbumCommand>(updateAlbumDTO);
            if (Mediator is null)
            {
                throw new NullReferenceException("Mediator is null");
            }
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAlbumCommand
            {
                Id = id
            };

            await Mediator.Send(command);
            return NoContent();

        }

    }
}
    //public class AlbumsController(IAlbumRepository albumRepository,
    //    ISongRepository songRepository,
    //    IGroupRepository groupRepository) : Controller
    //{
    //    [HttpGet(Name = "GetAllAlbums")]
    //    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Album>))]
    //    public async Task<IActionResult> GetAllAsync()
    //    {
    //        var albums = await albumRepository.GetAllAsync();
    //        // Настройка JsonSerializerOptions
    //        var options = new JsonSerializerOptions
    //        {
    //            ReferenceHandler = ReferenceHandler.IgnoreCycles,
    //            WriteIndented = true,
    //            MaxDepth = 64 // Установите желаемую максимальную глубину
    //        };

    //        // Сериализация в JSON
    //        string json = JsonSerializer.Serialize(albums, options);
    //        return Content(json, "application/json");
    //    }

    //    [HttpGet("{id}")]
    //    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Album))]
    //    [ProducesResponseType(StatusCodes.Status404NotFound)]
    //    public async Task<IActionResult> GetByIdAsync(int id)
    //    {
    //        if (await albumRepository.ExistsByIdAsync(id))
    //        {
    //            NotFound();
    //        }
    //        var album = await albumRepository.GetByIdAsync(id);
    //        return Ok(album);
    //    }

    //    [HttpPost(Name = "AddAlbum")]
    //    [ProducesResponseType(StatusCodes.Status200OK)]
    //    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    //    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //    public async Task<IActionResult> AddAlbumAsync([FromForm] AlbumDTO albumDTO, [FromForm] List<int> songIds, [FromForm] List<int> groupIds )
    //    {
    //        if (albumDTO == null)
    //        {
    //            return BadRequest();
    //        }
    //        var album = new Album
    //        {
    //            Title = albumDTO.Title,
    //            Description = albumDTO.Description,
    //            ReleaseDate = albumDTO.ReleaseDate,
    //            Groups = new List<Group>(),
    //            Songs = new List<Song>()
    //        };
    //        var songs = await songRepository.GetSongsByIdsAsync(songIds);
    //        if (songs.Count != 0)
    //        {
    //            album.Songs.AddRange(songs);
    //        }
    //        var groups = await groupRepository.GetGroupsByIdsAsync(groupIds);
    //        if (groups.Count != 0)
    //        {
    //            album.Groups.AddRange(groups);
    //        }
    //        if (await albumRepository.ExistsByTitleAsync(album.Title))
    //        {
    //            ModelState.AddModelError("", "Album already exists");
    //            return StatusCode(StatusCodes.Status402PaymentRequired, ModelState);
    //        }
    //        await albumRepository.AddAsync(album);
    //        return Ok();
    //    }

    //    [HttpDelete("{id}", Name = "RemoveAlbum")]
    //    [ProducesResponseType(StatusCodes.Status200OK)]
    //    [ProducesResponseType(StatusCodes.Status404NotFound)]
    //    public async Task<IActionResult> RemoveAlbumAsync(int id)
    //    {
    //        if (!await albumRepository.ExistsByIdAsync(id))
    //        {
    //            return NotFound();
    //        }
    //        await albumRepository.RemoveAsync(id);
    //        return Ok();
    //    }

    //    [HttpPut("{id}", Name = "UpdateAlbum")]
    //    [ProducesResponseType(StatusCodes.Status404NotFound)]
    //    public async Task<IActionResult> UpdateAlbumAsync(int id, [FromForm] AlbumDTO albumDTO, [FromForm] List<int> songIds, [FromForm] List<int> groupIds)
    //    {
    //        if (!await albumRepository.ExistsByIdAsync(id))
    //        {
    //            return NotFound();
    //        }
    //        var album = new Album
    //        {
    //            Title = albumDTO.Title,
    //            Description = albumDTO.Description,
    //            ReleaseDate = albumDTO.ReleaseDate,
    //            Groups = new List<Group>(),
    //            Songs = new List<Song>()
    //        };
    //        var songs = await songRepository.GetSongsByIdsAsync(songIds);
    //        if (songs.Count != 0)
    //        {
    //            album.Songs.AddRange(songs);
    //        }
    //        var groups = await groupRepository.GetGroupsByIdsAsync(groupIds);
    //        if (groups.Count != 0)
    //        {
    //            album.Groups.AddRange(groups);
    //        }
    //        await albumRepository.UpdateAsync(id, album);
    //        return Ok();
    //    }
    //}
