using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WbMediaCore.Entities;
using WbMediaCore.Features;
using WbMediaCore.Messages;

namespace WbMediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        public ActionResult<CreateFileResponse> Create(
            [FromServices] IFeature<CreateFileRequest, CreateFileResponse> createFileFeature)
        {
            var request = new CreateFileRequest()
            {
                FormFiles = Request.Form.Files.Select(formFile =>
                {
                    return new FormFileEntity()
                    {
                        ContentType = formFile.ContentType,
                        FileName = formFile.FileName,
                        Length = formFile.Length,
                        Content = formFile.OpenReadStream()
                    };
                }).ToList()
            };

            createFileFeature.Execute(request);

            return createFileFeature.Result;
        }
    }
}