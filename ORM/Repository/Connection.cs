using Microsoft.Extensions.Configuration;

namespace ORM
{
    public class Connection
    {
        public IConfiguration _configuration;
        public Connection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            return _configuration.GetSection("Connections").GetSection("ConnectionString").Value;
        }
    }
}