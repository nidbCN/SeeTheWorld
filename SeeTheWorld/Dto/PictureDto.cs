using System;
using System.ComponentModel.DataAnnotations;

namespace SeeTheWorld.Dto
{
    public class PictureDto
    {
        public DateTime DumpTime { get; set; }
        public string Title { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }
    }
}
