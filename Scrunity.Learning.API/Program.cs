using MediatR;
using Scrunity.Learnig.Entities;
using Scrunity.Learning.Persistance;
using Scrunity.Learning.Services.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = "Host=localhost;Port=5432;Database=scrunity-db;Username=postgres;Password=1111";
builder.Services.AddPersistence(connectionString);
builder.Services.AddApplication();

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

app.MapPost("/students", async (Student student, IMediator mediator) =>
{
    var studentCommand = new AddStudentCommand(student);
    await mediator.Send(studentCommand);
});

app.Run();
