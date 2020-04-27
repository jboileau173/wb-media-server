using Microsoft.EntityFrameworkCore.Design;
using WbMediaCore.Configurations;

namespace WbMediaRepository.Contexts
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var databaseOptions = new DatabaseOptions()
            {
                Server = "127.0.0.1",
                Database = "wbmedia",
                UserId = "jonathan",
                Password = "password"
            };

            return new Context(databaseOptions);
        }
    }

}
