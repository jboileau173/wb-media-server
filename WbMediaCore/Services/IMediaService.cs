using System.Collections.Generic;
using WbMediaCore.Entities;

namespace WbMediaCore.Services
{
    public interface IMediaService
    {
        public void CheckLocationPath();

        public string Create(MediaEntity media);
    }
}
