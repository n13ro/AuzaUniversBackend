using BusinessLogic;
using BusinessLogic.Middleware;
using DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add castom services to the container.
builder.Services.AddDataAccess();
builder.Services.AddBusinessLogic();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("*");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

//Castom middleware
app.UseExceptionHandling();


//-----


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapSwagger();

app.Run();
