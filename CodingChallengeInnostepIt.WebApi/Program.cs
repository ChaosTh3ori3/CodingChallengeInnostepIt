using CodingChallengeInnostepIt.Persistence.DTOs;
using CodingChallengeInnostepIt.WebApi.Domain;
using CodingChallengeInnostepIt.WebApi.Helper.Validation;
using CodingChallengeInnostepIt.WebApi.Mapper;
using CodingChallengeInnostepIt.WebApi.Persistence.Repositories;
using CodingChallengeInnostepIt.WebApi.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection(nameof(MongoDbSettings)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUserRepository, UserRepository>();

builder.Services.AddSingleton<IUserMapper, UserMapper>();

builder.Services.AddSingleton<IUserHandler, UserHandler>();

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.MapGet("/users", async (IUserHandler userHandler) =>
{
    return TypedResults.Ok(await userHandler.GetAllUsers());
 });

app.MapGet("/users/{id}", async (IUserHandler userHandler, [FromRoute] string id) =>
{
    var result = await userHandler.GetUserById(id);
    return result is not null
        ? Results.Ok(result)
        : Results.NotFound();
});

app.MapPut("/users", async (IUserHandler userHandler, [FromBody] CreateUserDto userDto) =>
{
    await userHandler.CreateUser(userDto);
    return TypedResults.Created();
}).Validate<CreateUserDto>();

app.MapPost("/users/{id}", async (IUserHandler userHandler, [FromRoute] string id, [FromBody] UpdateUserDto userDto) =>
{
    var result = await userHandler.UpdateUser(id, userDto);
    return result is not null
        ? Results.Ok(result)
        : Results.NotFound();
}).Validate<UpdateUserDto>();

app.MapDelete("/users/{id}", async (IUserHandler userhandler, [FromRoute] string id) =>
{
    var result = await userhandler.DeleteUser(id);
    return result
        ? Results.Ok(result)
        : Results.NotFound();
});

app.Run();
