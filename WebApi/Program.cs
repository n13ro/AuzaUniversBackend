using BusinessLogic;
using BusinessLogic.Middleware;
using Chat;
using Chat.Services;
using DataAccess;
using RabbitMQ;
using Redis;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add castom services to the container.
builder.Services.AddDataAccess();
builder.Services.AddBusinessLogic();
//builder.Services.AddChatGrpcLogic();
builder.Services.AddRedis();
builder.Services.AddRabbitMQ();




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

//app.MapGrpcService<ChatService>().RequireCors("AllowedHosts");

app.MapSwagger();

app.Run();
