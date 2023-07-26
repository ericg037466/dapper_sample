using Dapper;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace dapper_test.Services
{
    public class UserInfoMaintain
    {
        private readonly IDbService db;
        private MySqlTransaction trans;
        private int id;
        public UserInfoMaintain(IDbService db)
        {
            this.db = db;
        }

        public UserInfoMaintain BeginTrans()
        {
            trans = db.BeginTrans();

            return this;
        }

        public UserInfoMaintain Commit()
        {
            if (db.Connect().State != System.Data.ConnectionState.Closed) trans.Commit();

            return this;
        }

        public UserInfoMaintain Create<T>(string sql, T obj)
        {
            var result = db.Connect().Execute(sql, obj);

            id = result;

            return this;
        }

        public int GetData()
        {
            return id;
        }
    }
}
