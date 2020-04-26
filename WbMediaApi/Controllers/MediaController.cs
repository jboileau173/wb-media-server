using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WbMediaCore.Entities;
using WbMediaCore.Features;
using WbMediaCore.Messages;

namespace WbMediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private IFeature<CreateMediaRequest, CreateMediaResponse> _createMediaFeature { get; set; }

        public MediaController(IFeature<CreateMediaRequest, CreateMediaResponse> createMediaFeature)
        {
            _createMediaFeature = createMediaFeature;
        }

        [HttpPost, DisableRequestSizeLimit]
        public ActionResult<CreateMediaResponse> Create()
        {
            var createMediaRequest = new CreateMediaRequest()
            {
                Medias = Request.Form.Files.Select(file =>
                {
                    return new MediaEntity()
                    {
                        ContentType = file.ContentType,
                        FileName = file.FileName,
                        Length = file.Length,
                        Content = file.OpenReadStream()
                    };
                }).ToList()
            };

            _createMediaFeature.Execute(createMediaRequest);

            return _createMediaFeature.Result;
        }
    }
}