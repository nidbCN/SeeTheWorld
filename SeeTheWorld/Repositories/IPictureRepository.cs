using System.Collections.Generic;
using System.Threading.Tasks;
using SeeTheWorld.Entities;

namespace SeeTheWorld.Repositories
{
    public interface IPictureRepository
    {
        Task<IEnumerable<PictureEntity>> GetAllAsync();

        Task<IEnumerable<PictureEntity>> RandomAsync(int count);

        /// <summary>
        /// 存储单个图片
        /// </summary>
        /// <param name="pictureIn">图片实体</param>
        void PutPicture(PictureEntity pictureIn);
    }
}
