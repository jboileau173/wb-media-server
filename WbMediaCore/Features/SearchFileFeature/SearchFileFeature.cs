using System.Linq;
using WbMediaCore.Mappers;
using WbMediaCore.Messages;
using WbMediaCore.Services;

namespace WbMediaCore.Features.SearchFileFeature
{
    public class SearchFileFeature : IFeature<SearchFileRequest, SearchFileResponse>
    {
        public SearchFileResponse Result { get; set; }

        private IFileService _fileService { get; set; }

        public SearchFileFeature(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void Execute(SearchFileRequest request)
        {
            if (string.IsNullOrEmpty(request.query))
            {
                Result = new SearchFileResponse()
                {
                    Files = _fileService.GetAll()
                        .Select(f => FileMapper.ToEntity(f))
                        .ToList()
                };
            }
            else
            {
                Result = new SearchFileResponse()
                {
                    Files = _fileService.Search(request.query)
                    .Select(f => FileMapper.ToEntity(f))
                    .ToList()
                };
            }
        }
    }
}
