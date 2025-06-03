using BusinessLogic;
using BusinessLogic.Middleware;
using DataAccess;
using Redis;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add castom services to the container.
builder.Services.AddDataAccess();
builder.Services.AddBusinessLogic();
builder.Services.AddRedis();


//-----------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedHosts",
        builder => builder
            .SetIsOriginAllowed(_ => true)  
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

//Castom middleware
app.UseExceptionHandling();
app.UseExceptionHandlingController();

//-----


app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.MapSwagger();

app.Run();
