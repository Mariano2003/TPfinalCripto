using CriproBack.Models;
using CriproBack.ServiciosExternos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.AllowAnyOrigin() 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});



builder.Services.AddHttpClient();
builder.Services.AddScoped<IServicioPrecioDeCripto, ServicioPrecioDeCripto>();

var app = builder.Build();






builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaCliente", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

app.UseCors("PoliticaCliente");





if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("PermitirFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
