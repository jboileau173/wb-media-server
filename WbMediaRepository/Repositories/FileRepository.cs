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
    }
}
