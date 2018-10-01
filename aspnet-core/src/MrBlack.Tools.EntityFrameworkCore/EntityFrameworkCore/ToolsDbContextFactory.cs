using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MrBlack.Tools.Configuration;
using MrBlack.Tools.Web;

namespace MrBlack.Tools.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ToolsDbContextFactory : IDesignTimeDbContextFactory<ToolsDbContext>
    {
        public ToolsDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ToolsDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ToolsDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ToolsConsts.ConnectionStringName));

            return new ToolsDbContext(builder.Options);
        }
    }
}
