using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using InternshipTask.Identity;
using InternshipTask.Persistance;
using InternshipTask.Persistance.Services.ProductService;
using InternshipTask.Application.Contracts;

var builder = WebApplication.CreateBuilder(args);
// Add new Services
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddPersistanceServices(builder.Configuration);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Authorization",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IProductService,ProductService>();



var app = builder.Build();
// using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
//       {
//             var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
//             context.Database.Migrate();
//       }
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
