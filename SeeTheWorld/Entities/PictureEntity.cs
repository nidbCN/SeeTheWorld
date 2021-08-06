using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SeeTheWorld.Entities
{
    public class PictureEntity
    {
        [NotNull]
        public int Id { get; set; }
        public DateTime DumpTime { get; set; }
        public string Info { get; set; }
        
        [Url]
        public string Url { get; set; }
    }
}
