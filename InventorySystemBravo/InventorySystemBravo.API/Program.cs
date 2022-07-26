﻿using InventorySystemBravo.API.Extension;
using InventorySystemBravo.Repository;
using InventorySystemBravo.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddServiceLayer();
builder.Services.AddRepositoryLayer();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AppConnectionString") ?? string.Empty
        , b => b.MigrationsAssembly("InventorySystemBravo.Repository")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>(); 
    db.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseErrorHandlerMiddleware();
app.MapControllers();

app.Run();

