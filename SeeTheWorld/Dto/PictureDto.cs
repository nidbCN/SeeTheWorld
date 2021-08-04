using System;
using System.ComponentModel.DataAnnotations;
using SeeTheWorld.Entities;
using SeeTheWorld.Interfaces;

namespace SeeTheWorld.Dto
{
    public class PictureDto : IMapable<PictureDto, PictureEntity>
    {
        /// <summary>
        /// 存储时间
        /// </summary>
        public DateTime DumpTime { get; set; }

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

        public void MapFrom(PictureEntity source)
        {
            DumpTime = source.DumpTime;
            Info = source.Info;
            Url = source.Url;
        }

        public PictureEntity MapTo(PictureDto source) =>
            new()
            {
                DumpTime = source.DumpTime,
                Info = source.Info,
                Url = source.Url
            };
    }
}