using Dapper;
using dapper_test.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace dapper_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> logger;
        private readonly UserInfoRead read;
        private readonly UserInfoMaintain maintain;
        public WeatherForecastController(ILogger<WeatherForecastController> logger
            , UserInfoRead read
            , UserInfoMaintain maintain)
        {
            this.logger = logger;
            this.read = read;
            this.maintain = maintain;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data1 = read.Query<UserInfo>("select * from user_info").ToList();

            var data2 = read.Query<UserInfo>("select * from user_info").ToList();

            return Ok(data2);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserInfo user)
        {
            var sql = "INSERT INTO user_info (name, nickname) values(@name, @nickname)";

            var result1 = maintain.BeginTrans().Create(sql, user);

            var result2 = maintain.Create(sql, user).Commit().GetData();

            return Ok(result2);
        }

        public class UserInfo
        { 
            public long id { get; set; }
            public string name { get; set; }
            public string nickname { get; set; }
        }

    }
}