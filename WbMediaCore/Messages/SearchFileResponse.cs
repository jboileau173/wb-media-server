using System.Collections.Generic;
using WbMediaCore.Entities;

namespace WbMediaCore.Messages
{
    public class SearchFileResponse
    {
        public List<FileEntity> Files { get; set; }
    }
}
