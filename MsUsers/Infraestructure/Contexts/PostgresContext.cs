using System;
using Microsoft.EntityFrameworkCore;
using MsUsers.models.entity;

namespace MsUsers.Context
{
    public class PostgresContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options)
        {
        }
    }
}
