using Microsoft.AspNetCore.Mvc;
using SimpleWebApiWithResultPattern.Extensions;
using SimpleWebApiWithResultPattern.Models;
using SimpleWebApiWithResultPattern.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<UserService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/users", ([FromBody] User user, [FromServices] UserService userService) =>
{
    var result = userService.AddUser(user);
    return result.ToApiResult();
})
.WithOpenApi();

app.MapGet("/users/{id}", ([FromRoute] int id, [FromServices] UserService userService) =>
{
    var result = userService.GetUserById(id);
    return result.ToApiResult();
})
.WithOpenApi();

app.Run();
