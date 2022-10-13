using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.AspNetCore.OData.NewtonsoftJson;
using Microsoft.Extensions.Options;
using Microsoft.OData.Edm;
using Newtonsoft.Json;
using TestOData;
using TestOData.Model;
using TestOData.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddControllers()
    .AddOData(options =>
    {
        options
            .Select()
            .Expand()
            .AddRouteComponents(
                "v1",
                EdmModelBuilder.GetModelV1(),
                svc => svc.AddSingleton<ODataResourceSerializer, OmitNullResourceSerializer>());
            options.RouteOptions.EnableControllerNameCaseInsensitive = true;
        });
        // .AddNewtonsoftJson(setup => setup.UseCamelCasing(true))
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