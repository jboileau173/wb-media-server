namespace WbMediaCore.Entities
{
    public class FileEntity : ABaseEntity
    {
        public string Guid { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public long Length { get; set; }
        public string Path { get; set; }
    }
}
