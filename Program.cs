using backend.src.Data;
using backend.src.Services;
using backend.src.Controllers;
using backend.src.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient<SelicService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddScoped<QuestionarioRepository>();
builder.Services.AddScoped<ConscientizacaoRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<RedeApoioRepository>();
builder.Services.AddScoped<DepoimentoRepository>();

builder.Services.AddScoped<ConscientizacaoService>();
builder.Services.AddScoped<QuestionarioService>();
builder.Services.AddScoped<RedeApoioService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<DepoimentoService>();
builder.Services.AddScoped<SelicService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    })
    .AddApplicationPart(typeof(QuestionarioController).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularApp");
app.UseAuthorization();
app.MapControllers();
app.Run();
