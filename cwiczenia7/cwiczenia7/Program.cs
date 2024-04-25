using cwiczenia7.Services;
using cwiczenia7.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbService,DbService>();
builder.Services.AddValidatorsFromAssemblyContaining<OrderValidator>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();
