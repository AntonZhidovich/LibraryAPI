
using LibraryAuthApi.BLL.Data;
using LibraryAuthApi.DAL.Repository;
using LibraryAuthApi.DAL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;

namespace LibraryAuthApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddDbContext<UserDBContext>(options
				=> options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection")));
			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddScoped<ITokenBuilder, TokenBuilder>();

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}
