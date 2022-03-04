using ComandApp.Domain.Handlers;
using ComandApp.Domain.Respositories;
using ComandApp.Infra.Contexts;
using ComandApp.Infra.Repositories;
using ComandAppApi;
using ComandAppApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IO.Compression;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigureAuthentication(builder);
ConfigureMvc(builder);
ConfigureServices(builder);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

LoadConfiguration(app);

app.UseAuthentication();
app.UseAuthorization();
app.UseResponseCompression();

app.MapControllers();

app.Run();

void LoadConfiguration(WebApplication app)
{

    app.UseRouting();
    app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
}

void ConfigureAuthentication(WebApplicationBuilder builder)
{
    Configuration.JwtKey = builder.Configuration.GetValue<string>("JwtKey");
    var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
}

void ConfigureMvc(WebApplicationBuilder builder)
{
    // Add services to the container.

    builder.Services.AddMemoryCache();
    builder.Services.AddResponseCompression(options =>
    {
        options.Providers.Add<GzipCompressionProvider>();
    });

    builder.Services.Configure<GzipCompressionProviderOptions>(options =>
    {
        options.Level = CompressionLevel.Optimal;
    });

    builder.Services.AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

}

void ConfigureServices(WebApplicationBuilder builder)
{
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    //builder.Services.AddDbContext<ComandAppDataContext>(opt => opt.UseInMemoryDatabase("ComandApp"));
    builder.Services.AddDbContext<ComandAppDataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
    builder.Services.AddTransient<CategoriaHandler, CategoriaHandler>();


    //Token
    builder.Services.AddTransient<TokenService>(); //Sempre novo, usado para itens sem estado
                                                   //builder.Services.AddScoped(); // por Requisicao
                                                   //builder.Services.AddSingleton(); // Por aplicação
}