global using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using InternshipTask.Application.Services.ProductService;
using InternshipTask.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using InternshipTask.Identity;

var builder = WebApplication.CreateBuilder(args);
// Add new Services
builder.Services.AddIdentityServices(builder.Configuration);



// Add services to the container2.
object value = builder.Services.AddDbContext<DataContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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
