using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using UserApi;
using UserApi.DiModules;
using UserApi.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(option =>
{
    option.RegisterModule<AppModule>();
}));

var app = builder
    .Build();

var service = app.Services.GetAutofacRoot();
var userRepository = service.Resolve<IRepository<User>>();

app.MapGet("/user", () => userRepository.GetAll());
app.MapPut("/user", async (User user) => await userRepository.Create(user));
app.MapDelete("/user", (Guid guid) => userRepository.Delete(guid));
app.MapPost("/user", (User user) => userRepository.Update(user));

app.Run();