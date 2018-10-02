using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ESVS
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=9777");
        }

        ///Instruction
        ///Open Package Manager Console (Средства >> Диспетчер пакетов NuGet >> Консоль диспетчера пакетов;
        ///Tap: Add-Migration Initial
        ///To undo this action, use Remove-Migration.
        ///Tap: Update-Database
        ///Molodoy cheloveck proidemte
        ///Надо ли это делать у вас я ХЗ.
    }
}
