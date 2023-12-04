using LibraryAPI.BLL.ExceptionHandlers;
using LibraryAPI.BLL.Mapping;
using LibraryAPI.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LibraryAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
			builder.Services.AddDbContext<BookDBContext>(options
				=> options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection")));
			builder.Services.AddAutoMapper(typeof(BookMappingProfile));
			builder.Services.AddMediatR(config =>
			config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
			builder.Services.AddScoped<IBookRepository, BookRepository>();
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

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
