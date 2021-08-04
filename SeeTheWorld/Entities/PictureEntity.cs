using System;
using System.ComponentModel.DataAnnotations;

namespace SeeTheWorld.Entities
{
    public class PictureEntity
    {
        public uint Id { get; set; }
        public DateTime DumpTime { get; set; }
        public string Info { get; set; }
        
        [Url]
        public string Url { get; set; }
    }
}
