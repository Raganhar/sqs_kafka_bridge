using Amazon.Runtime;
using Amazon.SQS;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using WebApplication1.Config;
using WebApplication1.SqsStuff;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
Log.Logger = new LoggerConfiguration().WriteTo.Seq("http://localhost:5341/").CreateLogger();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configuration = builder.Configuration;
builder.Services.Configure<ServiceConfiguration>(configuration);
// var awsOptions = configuration.GetAWSOptions();
// awsOptions.Credentials = new EnvironmentVariablesAWSCredentials();
// builder.Services.AddDefaultAWSOptions(awsOptions);  
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