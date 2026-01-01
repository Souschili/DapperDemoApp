using System.Data;

namespace DapperDemoApp.Db
{
    public sealed class DbSession : IDisposable
    {
        public IDbConnection Connection { get; } = default!;
        public IDbTransaction? Transaction { get;private set; }


        public DbSession(IDbConnection connection)
        {
            Connection = connection;
            Connection.Open();
        }

        public void BeginTransaction()
        {
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            Transaction?.Commit();
        }

        public void Rollback()
        {
            Transaction?.Rollback();
        }


        public void Dispose()
        {
            Connection?.Dispose();
            Transaction?.Dispose();
        }
    }
}
