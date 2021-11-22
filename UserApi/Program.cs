using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World! \nI'm Get Method!");
app.MapPut("/", () => "Hello World! \nI'm Put Method!");
app.MapDelete("/", () => "Hello World! \nI'm Delete Method!");
app.MapPost("/", () => "Hello World! \nI'm Post Method!");

app.Run();