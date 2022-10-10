using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.NewtonsoftJson;
using Microsoft.OData.Edm;
using TestOData.Model;
using TestOData.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IEdmModel modelV1;

builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddControllers()
    .AddOData(options => options
        .Select()
        .AddRouteComponents("v1", EdmModelBuilder.GetModelV1()));
        // .AddNewtonsoftJson()
        // .AddODataNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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