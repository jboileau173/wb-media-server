using System.Collections.Generic;
using WbMediaCore.Entities;

namespace WbMediaCore.Messages
{
    public class CreateMediaRequest
    {
        public List<MediaEntity> Medias { get; set; }
    }
}
