using Microsoft.Extensions.Options;
using SeeTheWorld.Models;
using System;
using System.IO;

namespace SeeTheWorld.Repositories
{
    public class PictureFileRepository : IPictureFileRepository
    {
        public IOptions<AppConfig> Options { get; }
        public PictureFileRepository(IOptions<AppConfig> options)
        {
            Options = options
                ?? throw new ArgumentNullException(nameof(options));
        }
        public string RandomFileName()
        {
            var path = Options.Value.PicPath
                ?? "pictures";
            var directoryInfo = new DirectoryInfo(path);
            var fileInfos = directoryInfo.GetFiles();
            var n = new Random().Next(0, fileInfos.Length);
            return fileInfos[n].Name;
        }
    }
}
