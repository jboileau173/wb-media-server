using System.Collections.Generic;
using WbMediaCore.Entities;

namespace WbMediaCore.Messages
{
    public class CreateFileRequest
    {
        public List<FormFileEntity> FormFiles { get; set; }
    }
}
