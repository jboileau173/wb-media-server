using System.Linq;
using WbMediaCore.Mappers;
using WbMediaCore.Messages;
using WbMediaCore.Services;

namespace WbMediaCore.Features.GetAllFileFeature
{
    public class GetAllFileFeature : IFeature<GetAllFileRequest, GetAllFileResponse>
    {
        public GetAllFileResponse Result { get; set; }

        private IFileService _fileService { get; set; }

        public GetAllFileFeature(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void Execute(GetAllFileRequest request)
        {
            Result = new GetAllFileResponse()
            {
                Files = _fileService.GetAll()
                    .Select(f => FileMapper.ToEntity(f))
                    .ToList()
            };
        }
    }
}
