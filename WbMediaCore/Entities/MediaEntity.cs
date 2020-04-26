using System.IO;

namespace WbMediaCore.Entities
{
    public class MediaEntity
    {
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public long Length { get; set; }
        public Stream Content { get; set; }
    }
}
