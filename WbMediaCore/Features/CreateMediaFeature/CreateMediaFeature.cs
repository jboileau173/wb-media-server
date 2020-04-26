using System.Collections.Generic;
using WbMediaCore.Messages;
using WbMediaCore.Services;

namespace WbMediaCore.Features.CreateMediaFeature
{
    public class CreateMediaFeature : IFeature<CreateMediaRequest, CreateMediaResponse>
    {
        public CreateMediaResponse Result { get; private set; }

        private IMediaService _mediaService { get; set; }

        public CreateMediaFeature(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        public void Execute(CreateMediaRequest request)
        {
            var guids = new List<string>();

            for (int i = 0; i < request.Medias.Count; i++)
            {
                guids.Add(_mediaService.Create(request.Medias[i]));
            }

            Result = new CreateMediaResponse()
            {
                Guid = guids
            };
        }
    }
}
