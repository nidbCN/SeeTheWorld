using System.Threading.Tasks;
using System.Collections.Generic;

using SeeTheWorld.Contexts;
using SeeTheWorld.Entities;
using SeeTheWorld.Repositories;

namespace SeeTheWorld.Services
{
    public class PictureService : IPictureService
    {
        private IPictureRepository PictureRepository { get; }
        public PictureService(SeeTheWorldContext context)
        {
            PictureRepository = new PictureRepository(context);
        }

        public async Task<IEnumerable<PictureEntity>> GetPictures(uint number)
            => await PictureRepository.GetPictures(number);

        public void PutPicture(PictureEntity pictureIn)
            => PictureRepository.PutPicture(pictureIn);
    }
}
