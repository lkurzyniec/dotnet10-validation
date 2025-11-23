using System.ComponentModel.DataAnnotations;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder();
builder.Services.AddValidation();
builder.Services.AddOpenApi();

using var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference("api-doc");

app.MapPost("/working", (WorkingValidationDto dto) => TypedResults.Ok(dto));
app.MapPost("/not-working", (NotWorkingValidationDto dto) => TypedResults.Ok(dto));

await app.RunAsync();

public record WorkingValidationDto(int? Id, [property: Required] string Title);

public record struct NotWorkingValidationDto(int? Id, [property: Required] string Title);