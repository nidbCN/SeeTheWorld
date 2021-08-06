using System.Threading.Tasks;
using System.Collections.Generic;
using SeeTheWorld.Contexts;
using SeeTheWorld.Entities;
using SeeTheWorld.Repositories;

namespace SeeTheWorld.Services
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepository _pictureRepository;
        public PictureService(SeeTheWorldContext context)
        {
            _pictureRepository = new PictureRepository(context);
        }

        public async Task<IEnumerable<PictureEntity>> GetPictures(uint? number)
        {
            var result = number is null
               ? await _pictureRepository.GetAllAsync()
               : await _pictureRepository.RandomAsync((int)number);

            return result;
        }


        public void PutPicture(PictureEntity pictureIn)
            => _pictureRepository.PutPicture(pictureIn);
    }
}
