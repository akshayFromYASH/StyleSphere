using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StyleSphere.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConString = builder.Configuration.GetConnectionString("MyConStr") ?? throw new InvalidOperationException("Invalid Connection String");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConString));
builder.Services.AddCors(c =>
{
     c.AddDefaultPolicy(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
//Add the services to authenticate a user using tokens.. This code is to be written 
//for the application that authenticates/authorizes a request. Not for Issuing a token
builder.Services.AddAuthentication(options =>
{
     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
     .AddJwtBearer(c =>
     {
         c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
         {
             ValidateAudience = true,
             ValidateIssuer = true,
             ValidateLifetime = true,
             ValidateIssuerSigningKey = true,
             ValidIssuer = builder.Configuration.GetValue<string>("Jwt:issuer"),
             ValidAudience = builder.Configuration.GetValue<string>("Jwt:audience"),
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Jwt:secret")))
         };
     });

// injecting dependency of IUnitOfWork as service to the project
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseCors(x => x
   .AllowAnyOrigin()
   .AllowAnyMethod()
   .AllowAnyHeader());
   
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
