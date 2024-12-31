using Application.Test1;
using Domain.Interfaces.Test1;
using Domain.Models.Test1;
using Infrastructure.Persistence.Repositories.Test1;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddScoped<IPersonUseCase, PersonService>();
builder.Services.AddScoped<IPersonRepo, PersonRepository>();

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

