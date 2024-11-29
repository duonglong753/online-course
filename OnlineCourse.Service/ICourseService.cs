using OnlineCourse.Core.Models;
using OnlineCourse.Data;

namespace OnlineCourse.Service
{
    public interface ICourseService
    {
        Task<List<CourseModel>> GetAllCourseAsync(int? categoryId = null);
        Task<CourseDetailModel> GetCourseDetailAsync(int courseId);
    }
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        public Task<List<CourseModel>> GetAllCourseAsync(int? categoryId = null)
        {
            return courseRepository.GetAllCourseAsync(categoryId);
        }  

        public Task<CourseDetailModel> GetCourseDetailAsync(int courseId)
        {
            return courseRepository.GetCourseDetailAsync(courseId);
        }
    }
}
