using OnlineCourse.Core.Entities;
using Microsoft.EntityFrameworkCore;

using OnlineCourseDbContext = OnlineCourse.Data.Entities.OnlineCourseDbContext;

namespace OnlineCourse.Data
{
    public class CourseCategoryRepository : ICourseCategoryRepository
    {
        private readonly OnlineCourseDbContext dbContext;

        public CourseCategoryRepository(OnlineCourseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<CourseCategory?> GetById(int id)
        {
            return dbContext.CourseCategories.FindAsync(id).AsTask();
        }

        public Task<List<CourseCategory>> GetCourseCategories()
        {
            return dbContext.CourseCategories.ToListAsync();
        }
    }
}
