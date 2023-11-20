using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
});

 .AddJwtBearer("JwtBearer", options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         //valida quem est� solicitando
         ValidateIssuer = true,

         //valida quem est� recebendo
         ValidateAudience = true,

         //define se o tempo de expira��o sera validado
         ValidateLifetime = true,

         //forma de criptografia e ainda valida a chave de autentica��o
         IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao-webapi-dev")),

         //valida o tempo de expira��o do token
         ClockSkew = TimeSpan.FromMinutes(60),

         //nome do issuer, de onde est� vindo
         ValidIssuer = "webapi.inlock",

         //nome do audience, para onde est� indo 
         ValidAudience = "webapi.inlock"
     };
 });





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
