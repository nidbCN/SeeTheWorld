using Microsoft.Extensions.Options;
using SeeTheWorld.Dto;
using SeeTheWorld.Models;
using SeeTheWorld.Repositories;
using System;
using System.Collections.Generic;

namespace SeeTheWorld.Services
{
    public class PictureService : IPictureService
    {
        public  IPictureFileRepository PictureFileRepository { get; set; }
        public IOptions<AppConfig> Options { get; set; }
        public PictureService(IOptions<AppConfig> options)
        {
            Options = options
                      ?? throw new ArgumentNullException(nameof(options));
            PictureFileRepository = new PictureFileRepository(options);
        }
        public PictureItem GetPicture()
        {
            var name = PictureFileRepository.RandomFileName();
            return new PictureItem()
            {
                Url = Options.Value.UrlBase + name
            };
        }

        public ICollection<PictureItem> GetPictures(uint number)
        {
            var pictures = new List<PictureItem>();
            for (var i = 0; i < number; i++)
            {
                var name = PictureFileRepository.RandomFileName();
                pictures.Add(
                    new PictureItem()
                    {
                        Url = Options.Value.UrlBase + name
                    }
                );
            }

            return pictures;
        }
    }
}
