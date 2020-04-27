using System.Collections.Generic;
using WbMediaCore.Entities;

namespace WbMediaCore.Messages
{
    public class CreateFileResponse
    {
        public List<FileEntity> Medias { get; set; }
    }
}
