using Microsoft.OpenApi.Models;
using ProspAI_Sprint3.Data;
using Microsoft.EntityFrameworkCore;
using ProspAI_Sprint3.Repositories;
using ProspAI_Sprint3.Services;
using System.Reflection;
using System.Text.Json.Serialization;
using ProspAI_Sprint3.Models;
using ProspAI_Sprint3.Persistencia.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configurar autenticação JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"]; // Obter a chave do appsettings.json
var key = Encoding.ASCII.GetBytes(secretKey);

builder.Services.AddSingleton(new AuthService(secretKey));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization();

// Repositórios
builder.Services.AddScoped<IRepository<Funcionario>, FuncionarioRepository>();
builder.Services.AddScoped<IRepository<Reclamacao>, ReclamacaoRepository>();
builder.Services.AddScoped<IRepository<Desempenho>, DesempenhoRepository>();

// Serviços
builder.Services.AddScoped<IService<Funcionario>, FuncionarioService>();
builder.Services.AddScoped<IService<Reclamacao>, ReclamacaoService>();
builder.Services.AddScoped<IService<Desempenho>, DesempenhoService>();
builder.Services.AddScoped<ReclamacaoPredictionService>();

// Contexto do banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleFIAP")));

// Configuração do Serializador JSON para ignorar ciclos
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// Adicionando controllers
builder.Services.AddControllers();

// Configurando Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ProspAI API",
        Version = "v1",
        Description = "API para ProspAI usando Oracle"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddSingleton<MLModelTrainer>();

var app = builder.Build();

// Configurar o middleware de autenticação e autorização
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProspAI API v1");
    c.RoutePrefix = string.Empty;
});

app.UseRouting();

// Habilitar autenticação e autorização
app.UseAuthentication(); // Certifique-se de chamar UseAuthentication antes de UseAuthorization
app.UseAuthorization();

app.MapControllers();

app.Run();
