using LibraryAuthApi.BLL.Data;
using LibraryAuthApi.BLL.Services;
using LibraryAuthApi.DAL.Repository;
using LibraryAuthApi.DAL.Services;
using LibraryAuthApi.Presentation.ExceptionHandlers;
using Microsoft.EntityFrameworkCore;

namespace LibraryAuthApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddDbContext<UserDBContext>(options
                => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection")));
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ISignInService, SignInService>(); 
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ITokenBuilder, TokenBuilder>();

            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseExceptionHandler(opt => { });
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
