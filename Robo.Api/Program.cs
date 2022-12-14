using AutoMapper;
using Robo.Api.AutoMapper;
using Robo.Domain.Interfaces;
using Robo.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new ModelMappingProfile());
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IHeadService, HeadService>();
builder.Services.AddScoped<IRoboService, RoboService>();
builder.Services.AddScoped<IRightArmService, RightArmService>();
builder.Services.AddScoped<ILeftArmService, LeftArmService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
  options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()
      );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();