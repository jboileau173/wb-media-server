using System.Collections.Generic;
using WbMediaCore.Entities;

namespace WbMediaCore.Messages
{
    public class GetAllFileResponse
    {
        public List<FileEntity> Files { get; set; }
    }
}
