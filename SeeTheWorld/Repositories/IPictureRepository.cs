using System.Collections.Generic;
using System.Threading.Tasks;
using SeeTheWorld.Entities;

namespace SeeTheWorld.Repositories
{
    public interface IPictureRepository
    {
        /// <summary>
        /// 获取图片数组
        /// </summary>
        /// <param name="count">总数，默认为1</param>
        /// <returns></returns>
        Task<IEnumerable<PictureEntity>> GetPictures(uint count = 1);

        /// <summary>
        /// 存储单个图片
        /// </summary>
        /// <param name="pictureIn">图片实体</param>
        void PutPicture(PictureEntity pictureIn);
    }
}
