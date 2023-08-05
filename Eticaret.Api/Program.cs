using Eticaret.Model;
using Eticaret.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using NLog;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

/*
* JWT Authentication için eklenmesi gereken kodlar
*/
builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o => {
    var Key = Encoding.UTF8.GetBytes("ETicaretKeyVektorelAhlatciGrupDersi");
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };
});

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
