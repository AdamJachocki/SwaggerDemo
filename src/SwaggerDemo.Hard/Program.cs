using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using SwaggerDemo.Hard;
using SwaggerDemo.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(o =>
{
    o.Conventions.Add(new GroupingByNamespaceConvention());
});

builder.Services.AddApiVersioning(o =>
{
    o.DefaultApiVersion = new ApiVersion(1, 0);
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.ReportApiVersions = true;
});

builder.Services.AddSwaggerGen(o =>
{
    var assemblyName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
    var docFile = Path.Combine(AppContext.BaseDirectory, assemblyName);
    o.IncludeXmlComments(docFile);

    var modelsAssemblyName = typeof(User).Assembly.GetName().Name + ".xml";
    var modelsDocFile = Path.Combine(AppContext.BaseDirectory, modelsAssemblyName);
    o.IncludeXmlComments(modelsDocFile);

    o.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Wersja 1",
        Version = "v1"
    });

    o.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "Wersja 2",
        Version = "v2"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(o =>
    {
        o.SwaggerEndpoint("/swagger/v1/swagger.json", "Wersja 1");
        o.SwaggerEndpoint("/swagger/v2/swagger.json", "Wersja 2");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
