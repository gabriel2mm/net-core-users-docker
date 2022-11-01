using System.Data.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MsUsers.Context;
using MsUsers.Contracts;
using MsUsers.Models.Mapper;
using MsUsers.Repository;
using MsUsers.Services;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddDbContext<PostgresContext>(options =>
               options.UseNpgsql(builder.Configuration.GetConnectionString("UsersDBConnectionString")));
    builder.Services.AddAutoMapper(typeof(UserMapper));
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    //Auto Migrations

    using (var scope = app.Services.CreateAsyncScope())
    {
        PostgresContext dbContext = scope.ServiceProvider.GetRequiredService<PostgresContext>();
        dbContext.Database.Migrate();
    }

    app.UseSwagger();
    app.UseSwaggerUI();

    // Configure the HTTP request pipeline.

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}



