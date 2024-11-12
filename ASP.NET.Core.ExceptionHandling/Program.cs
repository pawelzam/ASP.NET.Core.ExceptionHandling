using ASP.NET.Core.ExceptionHandling.Exceptions;
using ASP.NET.Core.ExceptionHandling.Extensions;
using ApplicationException = ASP.NET.Core.ExceptionHandling.Exceptions.ApplicationException;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandlers();
builder.Services.AddProblemDetails();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();

app.MapGet("/item/{id}", () =>
    {
        throw new ItemNotFoundException();
    })
.WithName("Get Item")
.WithOpenApi();

app.MapPost("/item/{id}", (Item item, CancellationToken cancellationToken) => 
    {
        throw new  ApplicationException();
    })
    .WithName("Add item")
    .WithOpenApi();

app.Run();

internal record Item(string Name);