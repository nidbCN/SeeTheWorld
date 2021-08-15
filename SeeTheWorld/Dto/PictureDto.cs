using System;
using System.ComponentModel.DataAnnotations;
using SLMapper.Interfaces;
using SeeTheWorld.Entities;

namespace SeeTheWorld.Dto
{
    public class PictureDto : IMapable<PictureEntity>
    {
        /// <summary>
        /// 存储时间
        /// </summary>
        public DateTime? DumpTime { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        [Required]
        [Url]
        public string Url { get; set; }

        public void MapFrom(PictureEntity src)
        {
            DumpTime = src.DumpTime;
            Info = src.Info;
            Url = src.Url;
        }

        public PictureEntity MapTo() =>
            new()
            {
                DumpTime = DumpTime ?? DateTime.Now,
                Info = Info,
                Url = Url
            };
    }
}