using WanderPaws.Application.Interfaces;
using WanderPaws.DataAccess;
using WanderPaws.Implementation;
using WanderPaws.Implementation.Auth.Queries;
using WanderPaws.Implementation.Services;
using WanderPaws.Implementation.Validation;
using WanderPaws.Server.Core;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


//builder.Services.AddAuthentication();
//builder.Services.AddAuthorization();

var builder = WebApplication.CreateBuilder(args);

// 1. Register DbContext
//builder.Services.AddDbContext<WanderPawsContext>();

var connectionString = builder.Configuration.GetConnectionString("sqlConnectionString");
builder.Services.AddDbContext<WanderPawsContext>(options => options.UseSqlServer(connectionString));

// 2. Register Validators (individual and via assembly discovery)
builder.Services.AddValidatorsFromAssemblyContaining<RegisterUserCommandValidator>();

// 3. Add MediatR (must be done after validators are registered)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginUserQueryHandler).Assembly));

// 4. Register pipeline behaviors
//builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(DbContextInjectionBehavior<,>)); // DbContext Injection behavior
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>)); // Validation behavior

// 5. Add controllers
builder.Services.AddControllers();



var jwtTokenConfig = builder.Configuration.GetSection("jwtTokenConfig").Get<JwtTokenConfig>()!;
builder.Services.AddSingleton(jwtTokenConfig);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = true;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtTokenConfig.Issuer,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
        ValidAudience = jwtTokenConfig.Audience,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromMinutes(1)
    };
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
builder.Services.AddHostedService<JwtRefreshTokenCache>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Wander Paws API", Version = "v1" });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter JWT Bearer token **_only_**",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer", // must be lowercase
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {securityScheme, Array.Empty<string>()}
            });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandler>();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Wander Paws API v1");
    });
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});
app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
