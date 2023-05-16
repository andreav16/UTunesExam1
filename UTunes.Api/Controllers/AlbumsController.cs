﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UTunes.Api.DataTransferObjects;
using UTunes.Core;
using UTunes.Core.AlbumManager;
using UTunes.Core.Entities;

namespace UTunes.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumsController : UTunesBaseController
{
    private readonly IAlbumService albumService;
    private readonly IMapper mapper;

    public AlbumsController(IAlbumService albumService, IMapper mapper)
    {
        this.albumService = albumService;
        this.mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetAccountsAsync()
    {
        var result = await this.albumService.GetAllAsync();
        var albums = this.mapper.Map<IList<AlbumDetailsDto>>(result.Result);
        return result.Succeeded ? Ok(albums) : GetErrorResult<IReadOnlyList<Core.Entities.Album>>(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetAlbumById([FromRoute] int id)
    {
        var result =  this.albumService.GetExtendedAlbumInfo(id);
        var album = this.mapper.Map<ExtendedAlbumDetailsDto>(result.Result);
        return result.Succeeded ? Ok(album) : GetErrorResult<Core.Entities.AlbumExtended>(result);

    }
}

