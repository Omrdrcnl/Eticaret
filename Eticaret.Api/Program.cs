using Eticaret.Model;
using Eticaret.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer("Data Source=OMER-DIRICANLI\\SQLEXPRESS; Initial Catalog=EticaretDb; Integrated Security=true; TrustServerCertificate=True"));

builder.Services.AddScoped<KategoriRepository, KategoriRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
