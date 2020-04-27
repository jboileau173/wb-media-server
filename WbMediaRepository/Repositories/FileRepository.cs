using System.Linq;
using WbMediaCore.Repositories;
using WbMediaModels;
using WbMediaRepository.Contexts;

namespace WbMediaRepository.Repositories
{
    public class FileRepository : AGenericRepository<File>, IFileRepository
    {
        public FileRepository(Context context) : base(context)
        { }

        public File GetByGuid(string guid)
        {
            return _table.FirstOrDefault(f => f.Guid == guid);
        }
    }
}
