using LerningPlatform.DAL.Postgres;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LerningDBContext>(
    options =>
    {
        options.UseNpgsql(configuration.GetConnectionString(nameof(LerningDBContext)));
    });
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();