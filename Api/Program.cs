using Application.Interfaces;
using Application.Services;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy
            .WithOrigins("http://127.0.0.1:5500")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("Frontend", policy =>
//    {
//        policy
//            .WithOrigins("http://localhost:5173")
//            .AllowAnyHeader()
//            .AllowAnyMethod();
//    });
//});

builder.Services.AddSingleton<
    IMedicamentoRepository, 
    MedicamentoRepository>();

builder.Services.AddScoped<
    IMedicamentoService, 
    MedicamentoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Frontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
