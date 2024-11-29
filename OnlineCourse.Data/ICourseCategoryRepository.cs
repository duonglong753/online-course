using OnlineCourse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Data
{
    public interface ICourseCategoryRepository
    {
        /*CourseCategory GetById(int id);
        List<CourseCategory> GetCourseCategories();*/
        Task<CourseCategory> GetById(int id);
        Task<List<CourseCategory>> GetCourseCategories();
    }
}
