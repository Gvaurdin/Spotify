using Microsoft.AspNetCore.Mvc;
using Spotify.Database.DTO;
using Spotify.Database.Entities;
using Spotify.Database.Repositories;
using Spotify.Database.Repositories.Interfaces;
using System.Text.Json.Serialization;
using System.Text.Json;
using AutoMapper;
using Spotify.Application.Models.Groups.Queries.GetGroupList;
using MediatR;
using Spotify.Application.Models.Groups.Commands.CreateGroup;
using Spotify.Application.Models.Groups.Queries.GetGroupDetails;
using Spotify.Application.Models.Groups.Commands.DeleteGroup;
using Spotify.Application.Models.Groups.Commands.UpdateGroup;

namespace Spotify.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupsController(IMapper mapper) : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<GroupListViewModel>> GetAll(int countSkipGroups, int countTakeGroups)
        {
            var query = new GetGroupListQuery
            {
                CountSkipGroups = countSkipGroups,
                TakeGroups = countTakeGroups
            };
            if (Mediator is null)
            {
                throw new NullReferenceException("Mediator is null");
            }
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupListViewModel>> GetById(int id)
        {
            var query = new GetGroupDetailsQuery { Id = id };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateGroupDTO createGroupDTO)
        {
            var command = mapper.Map<CreateGroupCommand>(createGroupDTO);
            if (Mediator is null)
            {
                throw new NullReferenceException("Mediator is null");
            }
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGroupDTO updateGroupDTO)
        {
            var command = mapper.Map<UpdateGroupCommand>(updateGroupDTO);
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
            var command = new DeleteGroupCommand
            {
                Id = id
            };

            await Mediator.Send(command);
            return NoContent();

        }
    }
}



    //public class GroupsController(IGroupRepository groupRepository,
    //    IGenreRepository genreRepository,
    //    IAlbumRepository albumRepository) : ControllerBase
    //{

    //    [HttpGet(Name = "GetAllGroups")]
    //    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Group>))]
    //    public async Task<IActionResult> GetAllAsync()
    //    {
    //        var groups = await groupRepository.GetAllAsync();

    //        var options = new JsonSerializerOptions
    //        {
    //            ReferenceHandler = ReferenceHandler.IgnoreCycles,
    //            WriteIndented = true,
    //            MaxDepth = 64
    //        };

    //        string json = JsonSerializer.Serialize(groups, options);
    //        return Content(json, "application/json");
    //    }

    //    [HttpGet("{id}")]
    //    [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(Group))]
    //    [ProducesResponseType(StatusCodes.Status404NotFound)]
    //    public async Task<IActionResult> GetByIdAsync(int id)
    //    {
    //        if(!await groupRepository.ExistsByIdAsync(id))
    //        {
    //            NotFound();
    //        }
    //        var group = await groupRepository.GetByIdAsync(id);
    //        return Ok(group);
    //    }

    //    [HttpPost(Name = "AddGroup")]
    //    [ProducesResponseType(StatusCodes.Status200OK)]
    //    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    //    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //    public async Task<IActionResult> AddGroupAsync([FromForm] GroupDTO groupDTO, [FromForm] List<int> genreIds, [FromForm] List<int> albumIds)
    //    {
    //        if(groupDTO == null)
    //        {
    //            return BadRequest();
    //        }

    //        var group = new Group
    //        {
    //            Title = groupDTO.Title,
    //            FoundationDate = groupDTO.FoundationDate,
    //            UrlImage = groupDTO.UrlImage,
    //            Description = groupDTO.Description,
    //            Genres = new List<Genre>(),
    //            Albums = new List<Album>()
    //        };
    //        if(await groupRepository.ExistsByTitleAsync(group.Title))
    //        {
    //            ModelState.AddModelError("", "Group already exists");
    //            return StatusCode(StatusCodes.Status402PaymentRequired,ModelState);
    //        }
    //        var genres = await genreRepository.GetGenresByIdsAsync(genreIds);
    //        if (genres.Count != 0)
    //        {
    //            group.Genres.AddRange(genres);
    //        }
    //        var albums = await albumRepository.GetAlbumsByIdsAsync(albumIds);
    //        if (albums.Count != 0)
    //        {
    //            group.Albums.AddRange(albums);
    //        }
    //        await groupRepository.AddAsync(group);
    //        return Ok();
    //    }

    //    [HttpDelete("{id}",Name = "RemoveGroup")]
    //    [ProducesResponseType(StatusCodes.Status200OK)]
    //    [ProducesResponseType(StatusCodes.Status404NotFound)]
    //    public async Task<IActionResult> RemoveGroupAsync(int id)
    //    {
    //        if(!await groupRepository.ExistsByIdAsync(id))
    //        {
    //            return NotFound();
    //        }
    //        await groupRepository.RemoveAsync(id);
    //        return Ok();
    //    }

    //    [HttpPut("{id}", Name = "UpdateGroup")]
    //    [ProducesResponseType(StatusCodes.Status404NotFound)]
    //    public async Task<IActionResult> UpdateGroupAsync(int id, [FromForm] GroupDTO groupDTO, [FromForm] List<int> genreIds, [FromForm] List<int> albumIds )
    //    {
    //        if (!await groupRepository.ExistsByIdAsync(id))
    //        {
    //            return NotFound();
    //        }
    //        var group = new Group
    //        {
    //            Title = groupDTO.Title,
    //            FoundationDate = groupDTO.FoundationDate,
    //            UrlImage = groupDTO.UrlImage,
    //            Description = groupDTO.Description,
    //            Genres = new List<Genre>(),
    //            Albums = new List<Album>()
    //        };

    //        if (genreIds != null)
    //        {
    //            var genres = await genreRepository.GetGenresByIdsAsync(genreIds);
    //            if (genres.Count != 0)
    //            {
    //                group.Genres.AddRange(genres);
    //            }
    //        }
    //        if (albumIds != null)
    //        {
    //            var albums = await albumRepository.GetAlbumsByIdsAsync(albumIds);
    //            if (albums.Count != 0)
    //            {
    //                group.Albums.AddRange(albums);
    //            }
    //        }
    //        await groupRepository.UpdateAsync(id, group);
    //        return Ok();
    //    }
    //}
