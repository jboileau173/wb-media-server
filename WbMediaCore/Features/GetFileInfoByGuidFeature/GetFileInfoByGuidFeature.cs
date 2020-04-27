using WbMediaCore.Mappers;
using WbMediaCore.Messages;
using WbMediaCore.Services;

namespace WbMediaCore.Features.GetFileInfoByGuidFeature
{
    public class GetFileInfoByGuidFeature : IFeature<GetFileInfoByGuidRequest, GetFileInfoByGuidResponse>
    {
        public GetFileInfoByGuidResponse Result { get; set; }

        private IFileService _fileService;

        public GetFileInfoByGuidFeature(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void Execute(GetFileInfoByGuidRequest request)
        {
            Result = new GetFileInfoByGuidResponse()
            {
                File = FileMapper.ToEntity(_fileService.GetByGuid(request.Guid))
            };
        }
    }
}
