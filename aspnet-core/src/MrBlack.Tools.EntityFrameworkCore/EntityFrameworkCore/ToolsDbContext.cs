using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MrBlack.Tools.Authorization.Roles;
using MrBlack.Tools.Authorization.Users;
using MrBlack.Tools.MultiTenancy;

namespace MrBlack.Tools.EntityFrameworkCore
{
    public class ToolsDbContext : AbpZeroDbContext<Tenant, Role, User, ToolsDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ToolsDbContext(DbContextOptions<ToolsDbContext> options)
            : base(options)
        {
        }
    }
}
