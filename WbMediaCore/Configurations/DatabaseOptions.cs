using WbMediaCore.Configurations.Interfaces;

namespace WbMediaCore.Configurations
{
    public class DatabaseOptions : IDatabaseOptions
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
