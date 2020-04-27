using System.Collections.Generic;
using WbMediaCore.Entities;

namespace WbMediaCore.Messages
{
    public class CreateFileResponse
    {
        public List<FileEntity> Files { get; set; }
    }
}
