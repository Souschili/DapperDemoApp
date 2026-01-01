using Npgsql;

namespace DapperDemoApp.Db
{
    public sealed class DbSessionFactory
    {
        private readonly string _connectionString;

        public DbSessionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSession Create()
        {
            var connection = new NpgsqlConnection(_connectionString);
            return new DbSession(connection);
        }
    }
}
