using System;
using System.ComponentModel.DataAnnotations;

namespace SeeTheWorld.Dto
{
    public class PictureDto
    {
        /// <summary>
        /// 存储时间
        /// </summary>
        public DateTime DumpTime { get; set; }
        
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        [Required]
        [Url]
        public string Url { get; set; }
    }
}
