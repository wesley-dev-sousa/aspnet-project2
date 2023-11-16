using App.Persistence;
using App.Common;
using Microsoft.EntityFrameworkCore;
using App.Domain.Interfaces.Application;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

internal class Program {
    private static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        var key = Encoding.ASCII.GetBytes(Settings.Secret);
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });


        //Configura o banco de dados
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("AppDb");
            options.UseNpgsql(connectionString);
        });






        //Injeção de dependências
        App.Application.DependencyInjectionConfig.Inject(builder.Services);
        DependencyInjectionConfig.Inject(builder.Services);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigin",
            builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });
        var app = builder.Build();


        //Executa Migration
        using (var scope = app.Services.CreateScope()) {
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();
        }
        if (app.Environment.IsDevelopment()) {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors(builder => builder
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod()
        );
        app.UseHttpsRedirection();
        app.UseAuthentication();//Authentication Sempre primeiro
        app.UseAuthorization();
        app.UseCors("AllowAnyOrigin");
        app.MapControllers();
        app.Run();
    }
}