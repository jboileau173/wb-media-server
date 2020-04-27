using System;
using System.Collections.Generic;
using WbMediaModels;

namespace WbMediaCore.Repositories
{
    public interface IFileRepository : IGenericRepository<File>
    {
        File GetByGuid(string guid);

        void DeleteByGuid(string guid);

        List<File> Search(string query);
    }
}
