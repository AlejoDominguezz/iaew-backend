using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMvc();

 // 1. Add Authentication Services
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://dev-ih2kh0g0o06mjqyy.us.auth0.com/";
    options.Audience = "https://api.example.com/estudiantes";
});

builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("read:estudiantes", policy => policy.Requirements.Add(new HasScopeRequirement("read:estudiantes", "https://dev-ih2kh0g0o06mjqyy.us.auth0.com/")));
        options.AddPolicy("write:estudiantes", policy => policy.Requirements.Add(new HasScopeRequirement("write:estudiantes", "https://dev-ih2kh0g0o06mjqyy.us.auth0.com/")));
    });
    
builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

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
