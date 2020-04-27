namespace WbMediaModels
{
    public class File
    {
        public int FileId { get; set; }
        public string Guid { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public long Length { get; set; }
        public string Path { get; set; }
    }
}
