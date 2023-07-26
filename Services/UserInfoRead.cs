using Dapper;
using static dapper_test.Controllers.WeatherForecastController;

namespace dapper_test.Services
{
    public class UserInfoRead
    {
        private readonly IDbService db;
        public UserInfoRead(IDbService db)
        {
            this.db = db;
        }

        public List<T> Query<T>(string sql)
        {
            return db.Connect().Query<T>(sql).ToList();
        }
    }
}
