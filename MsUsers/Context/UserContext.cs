using System;
using Microsoft.EntityFrameworkCore;
using MsUsers.models.entity;

namespace MsUsers.Context
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
    }
}
