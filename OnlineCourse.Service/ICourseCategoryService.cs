using OnlineCourse.Core.Models;
using OnlineCourse.Data;

namespace OnlineCourse.Service
{
    public interface ICourseCategoryService
    {
        Task<CourseCategoryModel> GetByIdAsync(int id);
        Task<List<CourseCategoryModel>> GetCourseCategories();
    }
    public class CourseCategoryService : ICourseCategoryService
    {
        private readonly ICourseCategoryRepository _categoryRepository;
        public CourseCategoryService(ICourseCategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public async Task<CourseCategoryModel> GetByIdAsync(int id)
        {
            var data = await _categoryRepository.GetById(id);
            return new CourseCategoryModel()
            {
                CategoryId = data.CategoryId,
                CategoryName = data.CategoryName,
                Description = data.Description,
            };
        }

        public async Task<List<CourseCategoryModel>> GetCourseCategories()
        {
            var data = await _categoryRepository.GetCourseCategories();
            var modelData = data.Select(s=> new CourseCategoryModel()
            {
                CategoryId = s.CategoryId,
                CategoryName = s.CategoryName,
                Description = s.Description,
            }).ToList();
            return modelData;
        }
    }
}
