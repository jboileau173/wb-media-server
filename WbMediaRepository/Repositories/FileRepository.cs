using WbMediaCore.Repositories;
using WbMediaModels;
using WbMediaRepository.Contexts;

namespace WbMediaRepository.Repositories
{
    public class FileRepository : AGenericRepository<File>, IFileRepository
    {
        public FileRepository(Context context) : base(context)
        {
        }

        public override File Create(File ressource)
        {
            return new File()
            {
                ContentType = ressource.ContentType,
                FileId = 1,
                FileName = ressource.FileName,
                Guid = ressource.Guid,
                Length = ressource.Length,
                Path = ressource.Path
            };

            //return base.Create(ressource);
        }
    }
}
