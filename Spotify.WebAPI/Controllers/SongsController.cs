using Microsoft.AspNetCore.Mvc;
using Spotify.Database.DTO;
using Spotify.Database.Entities;
using Spotify.Database.Repositories;
using Spotify.Database.Repositories.Interfaces;
using System.Text.Json.Serialization;
using System.Text.Json;
using AutoMapper;
using Spotify.Application.Models.Songs.Commands.CreateSong;
using Spotify.Application.Models.Songs.Commands.DeleteSong;
using Spotify.Application.Models.Songs.Commands.UpdateSong;
using Spotify.Application.Models.Songs.Queries.GetSongDetails;
using Spotify.Application.Models.Songs.Queries.GetSongList;

namespace Spotify.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongsController(IMapper mapper) : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<SongListViewModel>> GetAll(int countSkipSongs, int countTakeSongs)
        {
            var query = new GetSongListQuery
            {
                CountSkipSongs = countSkipSongs,
                TakeSongs = countTakeSongs
            };
            if (Mediator is null)
            {
                throw new NullReferenceException("Mediator is null");
            }
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SongListViewModel>> GetById(int id)
        {
            var query = new GetSongDetailsQuery { Id = id };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateSongDTO createSongDTO)
        {
            var command = mapper.Map<CreateSongCommand>(createSongDTO);
            if (Mediator is null)
            {
                throw new NullReferenceException("Mediator is null");
            }
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSongDTO updateSongDTO)
        {
            var command = mapper.Map<UpdateSongCommand>(updateSongDTO);
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
            var command = new DeleteSongCommand
            {
                Id = id
            };

            await Mediator.Send(command);
            return NoContent();

        }
    }
}
    //public class SongsController(ISongRepository songRepository,
    //    IAlbumRepository albumRepository) : Controller
    //{
    //    [HttpGet(Name = "GetAllSongs")]
    //    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Song>))]
    //    public async Task<IActionResult> GetAllAsync()
    //    {
    //        var songs = await songRepository.GetAllAsync();

//        var options = new JsonSerializerOptions
//        {
//            ReferenceHandler = ReferenceHandler.IgnoreCycles,
//            WriteIndented = true,
//            MaxDepth = 64 
//        };

//        string json = JsonSerializer.Serialize(songs, options);
//        return Content(json, "application/json");
//    }

//    [HttpGet("{id}")]
//    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Song))]
//    [ProducesResponseType(StatusCodes.Status404NotFound)]
//    public async Task<IActionResult> GetByIdAsync(int id)
//    {
//        if (!await songRepository.ExistsByIdAsync(id))
//        {
//            NotFound();
//        }
//        var song = await songRepository.GetByIdAsync(id);
//        return Ok(song);
//    }

//    [HttpPost(Name = "AddSongAsync")]
//    [ProducesResponseType(StatusCodes.Status200OK)]
//    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
//    [ProducesResponseType(StatusCodes.Status400BadRequest)]
//    public async Task<IActionResult> AddSongAsync([FromForm]SongDTO songDTO, [FromForm] List<int> albumIds)
//    {
//        if (songDTO == null)
//        {
//            return BadRequest();
//        }
//        var song = new Song
//        {
//            Title = songDTO.Title,
//            Desciption = songDTO.Desciption,
//            Albums = new List<Album>()
//        };
//        var albums = await albumRepository.GetAlbumsByIdsAsync(albumIds);
//        if(albums.Count != 0)
//        {
//            song.Albums.AddRange(albums);
//        }
//        if (await songRepository.ExistsByTitleAsync(song.Title))
//        {
//            ModelState.AddModelError("", "Song already exists");
//            return StatusCode(StatusCodes.Status402PaymentRequired, ModelState);
//        }
//        await songRepository.AddAsync(song);
//        //return CreatedAtAction(nameof(GetByIdAsync), new { Id = song.Id },song);
//        return Ok();
//    }

//    [HttpDelete("{id}", Name = "RemoveSong")]
//    [ProducesResponseType(StatusCodes.Status200OK)]
//    [ProducesResponseType(StatusCodes.Status404NotFound)]
//    public async Task<IActionResult> RemoveSongAsync(int id)
//    {
//        if (!await songRepository.ExistsByIdAsync(id))
//        {
//            return NotFound();
//        }
//        await songRepository.RemoveAsync(id);
//        return Ok();
//    }

//    [HttpPut("{id}", Name = "UpdateSong")]
//    [ProducesResponseType(StatusCodes.Status404NotFound)]
//    public async Task<IActionResult> UpdateSongAsync(int id, [FromForm] SongDTO songDTO, [FromForm] List<int> albumIds)
//    {
//        if (!await songRepository.ExistsByIdAsync(id))
//        {
//            return NotFound();
//        }
//        var song = new Song
//        {
//            Title = songDTO.Title,
//            Desciption = songDTO.Desciption,
//            Albums = new List<Album>()
//        };
//        var albums = await albumRepository.GetAlbumsByIdsAsync(albumIds);
//        if (albums.Count != 0)
//        {
//            song.Albums.AddRange(albums);
//        }
//        await songRepository.UpdateAsync(id, song);
//        return Ok();
//    }
//}
