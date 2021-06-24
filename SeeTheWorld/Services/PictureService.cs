using System.Threading.Tasks;
using System.Collections.Generic;
using SeeTheWorld.Entities;
using SeeTheWorld.Repositories;
using System;

namespace SeeTheWorld.Services
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepository _pictureRepository;
        public PictureService(IPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository 
                ?? throw new ArgumentNullException(nameof(pictureRepository));
        }

        public async Task<IEnumerable<PictureEntity>> GetPictures(uint number = 1)
            => await _pictureRepository.GetPictures(number);

        public void PutPicture(PictureEntity pictureIn)
            => _pictureRepository.PutPicture(pictureIn);
    }
}
