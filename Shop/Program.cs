using System;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShopDbContext>(opt => {
    var connectionString = builder.Configuration.GetConnectionString("ShopConnectionString");
    opt.UseNpgsql(connectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LearningService v1"));
    app.UseExceptionHandler("/error-local-development");
}
else
{
    app.UseExceptionHandler("/error");
}

app.Run();
