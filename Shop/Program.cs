using System;
using Microsoft.EntityFrameworkCore;
using Shop.BLL;
using Shop.BLL.Exceptions;
using Shop.BLL.JWT;
using Shop.BLL.Services;
using Shop.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShopDbContext>(opt => {
    var connectionString = builder.Configuration.GetConnectionString("ShopConnectionString");
    opt.UseNpgsql(connectionString);
    opt.UseLazyLoadingProxies(true);
});

builder.Services.AddControllers();
builder.Services.AddScoped<JwtFactory>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LearningService v1"));
}

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
