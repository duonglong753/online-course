using Microsoft.EntityFrameworkCore;
using OnlineCourse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    /*public CourseCategory? GetById(int id)
    {
        var data = dbContext.CourseCategories.Find(id);
        return data;
    }

    public List<CourseCategory> GetCourseCategories()
    {
        var data = dbContext.CourseCategories.ToList(); 
        return data;
    }*/
    }
}
