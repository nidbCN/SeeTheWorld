using System.Threading.Tasks;
using System.Collections.Generic;

using SeeTheWorld.Entities;

namespace SeeTheWorld.Services
{
    public interface IPictureService
    {
        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="number">数量</param>
        /// <returns></returns>
        Task<IEnumerable<PictureEntity>> GetPictures(uint? number);

        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="pictureIn">图片</param>
        void PutPicture(PictureEntity pictureIn);
    }
}
