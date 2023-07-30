using Eticaret.Model;
using Eticaret.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using NLog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));

builder.Services.AddLogging(loggingBuilder => {
    loggingBuilder.ClearProviders();
    loggingBuilder.AddNLog();
});

builder.Services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer
("Data Source=OMER-DIRICANLI\\SQLEXPRESS; Initial Catalog=EticaretDb; Integrated Security=true; TrustServerCertificate=True"));

builder.Services.AddScoped<RepositoryWrapper, RepositoryWrapper>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache(); //Cache servisi aktive et

//json serileasiton aktive etme
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();


//Burda hata olayýnýn kullanýcýya ve developmenta nasýl gösterileceðinin methodunu yazdýk.
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error-development");
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
