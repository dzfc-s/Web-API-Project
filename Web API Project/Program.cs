using Web_API_Project.Data;
using Web_API_Project.Interfaces;
using Web_API_Project.Models;
using Web_API_Project.Services.AssistantService;
using Web_API_Project.Services.ProfessorService;
using Web_API_Project.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});
builder.Services.AddScoped<IUserService<Student>, StudentService>();
builder.Services.AddScoped<IUserService<Assistant>, AssistantService>();
builder.Services.AddScoped<IUserService<Professor>, ProfessorService>();
builder.Services.AddDbContext<DataContext>();

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
