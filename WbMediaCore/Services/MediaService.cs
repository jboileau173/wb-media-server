using System;
using System.IO;
using WbMediaConfig;
using WbMediaCore.Entities;

namespace WbMediaCore.Services
{
    public class MediaService : IMediaService
    {
        private ILocationOptions _locationOptions { get; set; }

        public MediaService(ILocationOptions locationOptions)
        {
            _locationOptions = locationOptions;
        }

        public void CheckLocationPath()
        {
            if (!Directory.Exists(_locationOptions.Path))
            {
                Directory.CreateDirectory(_locationOptions.Path);
            }
        }

        public string Create(MediaEntity media)
        {
            var guid = Guid.NewGuid().ToString("N");

            var mediaInfo = new FileInfo(media.FileName);

            var destination = Path.Combine(_locationOptions.Path, $"{guid}{mediaInfo.Extension}");

            using var stream = new FileStream(destination, FileMode.Create);

            media.Content.CopyTo(stream);
            media.Content.Close();

            return guid;
        }
    }
}
