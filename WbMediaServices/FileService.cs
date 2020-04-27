using System;
using System.IO;
using WbMediaCore.Configurations.Interfaces;
using WbMediaCore.Entities;
using WbMediaCore.Repositories;
using WbMediaCore.Services;

namespace WbMediaServices
{
    public class FileService : AGenericService<WbMediaModels.File>, IFileService
    {
        private IFileRepository _mediaRepository { get; set; }
        private ILocationOptions _locationOptions { get; set; }

        public FileService(
            IFileRepository fileRepository,
            ILocationOptions locationOptions) : base(fileRepository)
        {
            _mediaRepository = fileRepository;
            _locationOptions = locationOptions;

            if (!Directory.Exists(_locationOptions.Path))
            {
                Directory.CreateDirectory(_locationOptions.Path);
            }
        }

        public WbMediaModels.File Create(FormFileEntity file)
        {
            var guid = Guid.NewGuid().ToString("N");
            var mediaInfo = new FileInfo(file.FileName);
            var name = $"{guid}{mediaInfo.Extension}";
            var destination = Path.Combine(_locationOptions.Path, name);

            using var stream = new FileStream(destination, FileMode.Create);

            file.Content.CopyTo(stream);
            file.Content.Close();

            return this.Create(new WbMediaModels.File()
            {
                ContentType = file.ContentType,
                FileName = file.FileName,
                Length = file.Length,
                Path = destination,
                Guid = guid
            });
        }

        public WbMediaModels.File GetByGuid(string guid)
        {
            return _mediaRepository.GetByGuid(guid);
        }

        public void DeleteByGuid(string guid)
        {
            _mediaRepository.DeleteByGuid(guid);
        }
    }
}
