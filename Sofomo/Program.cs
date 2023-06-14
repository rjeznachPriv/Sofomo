using Microsoft.AspNetCore.Authentication.Negotiate;
using Sofomo.Api;
using Sofomo.Data;
using Sofomo.Logic.Queries.Factories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<AppDbContext, AppDbContext>();
builder.Services.AddTransient<IQueryFactory, QueryFactory>();
builder.Services.AddTransient<ICommandFactory, CommandFactory>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMvc(x => x.Conventions.Add(new SwaggerIgnore()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization(); //TODO

app.MapControllers();

app.Run();
