using Dapper;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace dapper_test.Services
{
    public class UserInfoMaintain
    {
        private readonly IDbService db;
        private MySqlTransaction trans;
        public UserInfoMaintain(IDbService db)
        {
            this.db = db;
        }

        public bool Create<T>(bool isBeginTrans, string sql, T obj)
        {
            if (isBeginTrans) trans = db.BeginTrans();

            var result = db.Connect().Execute(sql, obj);

            if (isBeginTrans) trans.Commit();

            return result > 0;
        }
    }
}
