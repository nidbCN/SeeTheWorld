using SeeTheWorld.Dto;
using System.Collections.Generic;

namespace SeeTheWorld.Services
{
    public interface IPictureService
    {
        PictureItem GetPicture();

        ICollection<PictureItem> GetPictures(uint number);
    }
}
