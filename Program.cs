using _ClinicsManaegment.Middlware;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Middlware;
using System.Text;
static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

 

        // add Services for Server
        builder.Services.AddHangfire(x => x.UseSqlServerStorage("Data Source=.;Initial Catalog=ClinicDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"));
        builder.Services.AddHangfireServer();

        builder.Services.AddAuthentication(op=>op.DefaultAuthenticateScheme="Bearer")
              .AddJwtBearer("Bearer", options =>
              {
                  string Secretkey = "osidcfgw#$%#$@_()_!+_PWOSLX>W)EF(GIKFLD";
                  var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secretkey));
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = false,
                      ValidateAudience = false,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = key
                  };
                  // Other configurations...
              });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Type Your Token Like:Bearer YourToken"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
    {
             // link with all EndPoint
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"       // نفس الاسم اللي كتبناه في AddSecurityDefinition
            }
        },
        new string[] {}  // لو عايز تحدد أدوار تكتب هنا، بس هنا بنخليها فاضية
    }
            });
        });

        // lazm before app creation for EmailServices
        builder.Services.AddScoped<Services.EmailServices>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.Lifetime.ApplicationStarted.Register(() =>
        {
            using (var scope = app.Services.CreateScope())
            {
                var emailService = scope.ServiceProvider.GetRequiredService<Services.EmailServices>();
                RecurringJob.AddOrUpdate(
                    "SendMonthlyReportForDoctors",//name for process
                    () => emailService.SendMonthlyReportForDoctors(),
                    Cron.Monthly);
            }
        });

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.UseMiddleware<FillCurrentUserMiddleware>();
        app.UseMiddleware<AuthorizationMiddelware>();


        app.Run();



        }

        
}

