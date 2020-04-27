﻿using Microsoft.AspNetCore.Mvc;
using System.IO;
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
        [HttpGet]
        [Route("info/{guid}")]
        public ActionResult<GetFileInfoByGuidResponse> GetFileInfoByGuid(
            [FromServices] IFeature<GetFileInfoByGuidRequest, GetFileInfoByGuidResponse> getFileInfoByGuidFeature,
            string guid)
        {
            getFileInfoByGuidFeature.Execute(new GetFileInfoByGuidRequest() { Guid = guid });

            return getFileInfoByGuidFeature.Result;
        }

        [HttpGet]
        [Route("{guid}")]
        public ActionResult<GetFileByGuidResponse> GetByGuid(
            [FromServices] IFeature<GetFileByGuidRequest, GetFileByGuidResponse> getFileByGuidFeature,
            string guid)
        {
            getFileByGuidFeature.Execute(new GetFileByGuidRequest() { Guid = guid });

            var stream = new FileStream(getFileByGuidFeature.Result.File.Path, FileMode.Open, FileAccess.Read);
            return File(stream, getFileByGuidFeature.Result.File.ContentType);
        }

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

        [HttpDelete]
        [Route("{guid}")]
        public ActionResult<DeleteFileByGuidResponse> DeleteByGuid(
            [FromServices] IFeature<DeleteFileByGuidRequest, DeleteFileByGuidResponse> deleteFileByGuidFeature,
            string guid)
        {
            var request = new DeleteFileByGuidRequest()
            {
                guid = guid
            };

            deleteFileByGuidFeature.Execute(request);

            return deleteFileByGuidFeature.Result;
        }

        [HttpGet]
        [Route("search")]
        public ActionResult<SearchFileResponse> Search(
            [FromServices] IFeature<SearchFileRequest, SearchFileResponse> searchFileFeature,
            [FromQuery(Name = "query")] string query)
        {
            searchFileFeature.Execute(new SearchFileRequest() { query = query });

            return searchFileFeature.Result;
        }

        [HttpGet]
        public ActionResult<GetAllFileResponse> GetAll(
            [FromServices] IFeature<GetAllFileRequest, GetAllFileResponse> getAllFileFeature)
        {
            getAllFileFeature.Execute(new GetAllFileRequest());

            return getAllFileFeature.Result;
        }
    }
}