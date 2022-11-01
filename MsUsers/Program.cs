using System.Data.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using MsUsers.Configurations;
using MsUsers.Context;
using MsUsers.Contracts;
using MsUsers.Models.Mapper;
using MsUsers.Repository;
using MsUsers.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();

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

    
    app.UseMiddleware(typeof(ErrorHandlingMiddleware));

    //app.UseExceptionHandler("/error");

    // Configure the HTTP request pipeline.
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}



