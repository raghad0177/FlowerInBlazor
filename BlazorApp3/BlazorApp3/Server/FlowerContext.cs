using BlazorApp3.Shared;
using LazurdIT.FluentOrm.MsSql;
using System.Data.SqlClient;

namespace BlazorApp3.Server
{
    public class FlowerContext : MsSqlFluentRepository<Flower>
    {
        public FlowerContext(string connectionString) : base(new SqlConnection(connectionString)) { }
    }
    
}
