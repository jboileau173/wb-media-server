using System.Collections.Generic;
using WbMediaCore.Entities;
using WbMediaCore.Mappers;
using WbMediaCore.Messages;
using WbMediaCore.Services;

namespace WbMediaCore.Features.CreateFileFeature
{
    public class CreateFileFeature : IFeature<CreateFileRequest, CreateFileResponse>
    {
        public CreateFileResponse Result { get; private set; }

        private IFileService _fileService { get; set; }

        public CreateFileFeature(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void Execute(CreateFileRequest request)
        {
            var medias = new List<FileEntity>();

            request.FormFiles
                .ForEach(file =>
                {
                    medias.Add(FileMapper.ToEntity(_fileService.Create(file)));
                });

            Result = new CreateFileResponse()
            {
                Medias = medias
            };
        }
    }
}
