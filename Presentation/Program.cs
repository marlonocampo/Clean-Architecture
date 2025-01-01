using Application.GenerateId;
using Application.Log;
using Domain.Interfaces.Id;
using Domain.Interfaces.Log;
using Domain.Models.Log;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories.Log;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddScoped<IPersonUseCase, PersonService>();
builder.Services.AddScoped<IPersonRepo, PersonRepository>();
builder.Services.AddScoped<IGenerateIdUseCase, GenerateIdService>();
builder.Services.AddSingleton<MiK8sContext, MiK8sContext>();

builder.Services.Configure<AppSettings>(config.GetSection("AppSettings"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{

});

builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();

