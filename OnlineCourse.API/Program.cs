
using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data.Entities;
using OnlineCourse.Data;
using OnlineCourse.Service;

namespace OnlineCourse.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Service Config
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            //DB config goes here
            builder.Services.AddDbContextPool<OnlineCourseDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbContext"),
                    provideroptions => provideroptions.EnableRetryOnFailure());
                options.EnableDetailedErrors();
            });
            #endregion
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
            builder.Services.AddScoped<ICourseCategoryService, CourseCategoryService>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ICourseService, CourseService>();

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
        }
    }
}
