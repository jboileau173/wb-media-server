using WbMediaCore.Mappers;
using WbMediaCore.Messages;
using WbMediaCore.Services;

namespace WbMediaCore.Features.GetFileByGuidFeature
{
    public class GetFileByGuidFeature : IFeature<GetFileByGuidRequest, GetFileByGuidResponse>
    {
        public GetFileByGuidResponse Result { get; set; }

        private IFileService _fileService { get; set; }

        public GetFileByGuidFeature(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void Execute(GetFileByGuidRequest request)
        {
            Result = new GetFileByGuidResponse()
            {
                File = FileMapper.ToEntity(_fileService.GetByGuid(request.guid))
            };
        }
    }
}
