using LibraryOn.Api.csproj.Filters;
using LibraryOn.Api.csproj.Middleware;
using LibraryOn.Application;
using LibraryOn.Infrastructure;
using LibraryOn.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//filtro excecoes
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

//injeção de dependencia
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CultureMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await MigrateDataBase();

app.Run();

async Task MigrateDataBase()
{
    //update migrations automatico
    await using var scope = app.Services.CreateAsyncScope();

    await DataBaseMigartion.MigrateDataBse(scope.ServiceProvider);
}
