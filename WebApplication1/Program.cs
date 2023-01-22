using Amazon.SQS;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Config;
using WebApplication1.SqsStuff;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ServiceConfiguration>(builder.Configuration);  
builder.Services.AddAWSService<IAmazonSQS>();  
builder.Services.AddTransient<IAWSSQSService, AWSSQSService>();  
builder.Services.AddTransient<IAWSSQSHelper, AWSSQSHelper>();  


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