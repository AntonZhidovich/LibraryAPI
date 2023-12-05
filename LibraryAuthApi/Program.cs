using LibraryAuthApi.BLL.Data;
using LibraryAuthApi.BLL.ExceptionHandlers;
using LibraryAuthApi.BLL.Services;
using LibraryAuthApi.DAL.Repository;
using LibraryAuthApi.DAL.Services;
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
			//builder.Services.AddSwaggerGen();
			builder.Services.AddScoped<ITokenBuilder, TokenBuilder>();

			var app = builder.Build();
			app.UseExceptionHandler(opt => { });

			//if (app.Environment.IsDevelopment())
			//{
			//	app.UseSwagger();
			//	app.UseSwaggerUI();
			//}

			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}
