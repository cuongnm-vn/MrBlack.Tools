using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MrBlack.Tools.EntityFrameworkCore
{
    public static class ToolsDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ToolsDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ToolsDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
