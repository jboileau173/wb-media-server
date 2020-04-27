using WbMediaCore.Entities;
using WbMediaModels;

namespace WbMediaCore.Mappers
{
    public static class FileMapper
    {
        public static FileEntity ToEntity(File model)
        {
            if (model == null) { return null; }

            return new FileEntity()
            {
                Id = model.FileId,
                Guid = model.Guid,
                ContentType = model.ContentType,
                FileName = model.FileName,
                Length = model.Length,
                Path = model.Path
            };
        }
    }
}
