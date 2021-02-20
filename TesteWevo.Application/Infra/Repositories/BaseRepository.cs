using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using System.Data;
using TesteWevo.Application.Domain.DTOs;

namespace TesteWevo.Application.Infra.Repositories
{

    public abstract class BaseRepository
    {

        protected readonly IOptions<Configurations> _configurations;

        protected BaseRepository(IOptions<Configurations> configurations)
        {

            _configurations = configurations;

        }

        public IDbConnection GetSQLiteConn() {


            var connection = new SqliteConnection(_configurations.Value.ConnectionStrings.SQLiteConn);

            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_dynamic_cdecl());

            return connection;

        }

    }

}
