﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using UTunes.Core.Entities;

namespace UTunes.Core.AlbumManager
{
    public interface IAlbumService
    {
        Task<OperationResult<IReadOnlyList<Album>>> GetAllAsync();

        OperationResult<AlbumExtended> GetExtendedAlbumInfo(int id);

    }
}
