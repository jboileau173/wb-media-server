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

        public void DeleteByGuid(string guid)
        {
            File existing = _table.FirstOrDefault(f => f.Guid == guid);
            _table.Remove(existing);

            Save();
        }

        public File GetByGuid(string guid)
        {
            return _table.FirstOrDefault(f => f.Guid == guid);
        }
    }
}
