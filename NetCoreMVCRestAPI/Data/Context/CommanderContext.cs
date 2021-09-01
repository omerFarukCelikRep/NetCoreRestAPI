using Microsoft.EntityFrameworkCore;
using NetCoreMVCRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMVCRestAPI.Data.Context
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> options) : base(options)
        {

        }

        public DbSet<Command> Commands { get; set; }

    }
}
