using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using UTunes.Core.Entities;

namespace UTunes.Core.AlbumManager
{
    

    public class AlbumService : IAlbumService
    {
        private readonly IRepository<Album> albumRepository;
        private readonly IRepository<Song> songRepository;

        public AlbumService(IRepository<Album> albumRepository, IRepository<Song> songRepository)
        {
            this.albumRepository = albumRepository;
            this.songRepository = songRepository;
        }

        public async Task<OperationResult<IReadOnlyList<Album>>> GetAllAsync() =>
            (await this.albumRepository.AllAsync
            ()).ToList();

        public OperationResult<AlbumExtended> GetExtendedAlbumInfo(int id)
        {
            var album = this.albumRepository.GetById(id);
            if (album is null)
            {
                return new OperationResult<AlbumExtended>(new Error
                {
                    Code = ErrorCode.NotFound,
                    Message = $"Album con id {id} no existe"
                });
            }
            var albumPrice = this.songRepository.Filter(x => x.AlbumId == id).Sum(x => x.SongPrice);
            int albumScore = 0;
            if(album.Votes > 0)
            {
                albumScore = album.Likes / album.Votes;
            }
            else
            {
                albumScore = 0;
            }

            var songList = this.songRepository.Filter(x => x.AlbumId == id)
         .Select(song => new SongAlbumInfo
            {
           Name = song.Name,
           Artist = song.Artist,
           SongPrice = song.SongPrice
           })
       .ToList();

            return new OperationResult<AlbumExtended>(new AlbumExtended
            {
                Name = album.Name,
                Artist = album.Artist,
                Review = album.Review,
                Songs= songList,
                Score = albumScore,
                AlbumPrice = albumPrice
            });
           
        }
    }
}
