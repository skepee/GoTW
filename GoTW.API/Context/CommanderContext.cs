using Microsoft.EntityFrameworkCore;

namespace GoTW.API.Context
{
    public class CommanderContext: DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> options) : base(options)
        { 
        }

        public DbSet<CommanderSkill> CommanderSkill { get; set; }
    }
}
