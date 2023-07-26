
using MySql.Data.MySqlClient;

namespace dapper_test.Services
{
    public class DbService : IDbService
    {
        
        private readonly IConfiguration configuration;
        private readonly MySqlConnection db;
        public DbService(IConfiguration configuration)
        {
            this.configuration = configuration;

            //this.db = new MySqlConnection(configuration["ConnectionStrings:Default"]);
            //var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings:Default");
            var connectionString = configuration["ConnectionStrings:Default"];
            this.db = new MySqlConnection(connectionString);
        }

        public MySqlConnection Connect() { return db; }
        public MySqlTransaction BeginTrans() {
            db.Open();
            return db.BeginTransaction(); 
        }
    }

    public interface IDbService
    {
        public MySqlConnection Connect();
        public MySqlTransaction BeginTrans();
    }
}
