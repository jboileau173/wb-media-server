using System;
using System.Collections.Generic;
using WbMediaCore.Entities;
using WbMediaModels;

namespace WbMediaCore.Services
{
    public interface IFileService : IGenericService<File>
    {
        File Create(FormFileEntity file);

        File GetByGuid(string guid);

        void DeleteByGuid(string guid);

        List<File> Search(string query);
    }
}
