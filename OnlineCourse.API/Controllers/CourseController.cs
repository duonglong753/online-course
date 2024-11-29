using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Core.Models;
using OnlineCourse.Service;

namespace OnlineCourse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;
        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }
        [HttpGet]
        public async Task<ActionResult<List<CourseModel>>> GetAllCourseAsync()
        {
            var courses = await courseService.GetAllCourseAsync();
            return Ok(courses);
        }
        [HttpGet("Category/{categoryId}")]
        public async Task<ActionResult<List<CourseModel>>> GetAllCourseByCategoryIdAsync([FromRoute] int categoryId)
        {
            var courses = courseService.GetAllCourseAsync(categoryId);
            return Ok(courses);
        }
        [HttpGet("Detail/{courseId}")]
        public async Task<ActionResult<CourseDetailModel>> GetCourseDetailAsync(int courseId)
        {
            var courseDetail = await courseService.GetCourseDetailAsync(courseId);
            if (courseDetail == null) { return NotFound(); }
            return Ok(courseDetail);
        }
    }
}
