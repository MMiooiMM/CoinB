using CoinB.Data.Models;
using CoinB.Models.Category;
using CoinB.Services;

namespace CoinB.Endpoints
{
    public static class CategoryEndpoint
    {
        public static void MapCategoryEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/categories", GetAllCategories)
            .WithName(nameof(GetAllCategories));

            routes.MapGet("/category/{id}", GetCategoryById)
            .WithName(nameof(GetCategoryById));

            routes.MapPost("/category", AddCategory)
            .WithName(nameof(AddCategory));

            routes.MapPut("/category/{id}", UpdateCategory)
           .WithName(nameof(UpdateCategory));

            routes.MapDelete("/category/{id}", DeleteCategory)
            .WithName(nameof(DeleteCategory));

        }

        private static async Task<List<CategoryResponseDto>> GetAllCategories(CategoryService service)
        {
            var list = await service.GetAllCategoriesAsync();
            return list.Select(data => new CategoryResponseDto
            {
                CategoryId = data.CategoryId,
                CategoryName = data.CategoryName
            }).ToList();
        }

        private static async Task<CategoryResponseDto> GetCategoryById(int id, CategoryService service)
        {
            var data = await service.GetCategoryByIdAsync(id) ?? throw new Exception("");
            return new CategoryResponseDto
            {
                CategoryId = data.CategoryId,
                CategoryName = data.CategoryName
            };
        }

        private static async Task<CategoryResponseDto> AddCategory(AddCategoryRequestDto data, CategoryService service)
        {
            var category = new Category
            {
                CategoryName = data.CategoryName
            };

            await service.AddCategoryAsync(category);

            return new CategoryResponseDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        private static async Task<Category> UpdateCategory(int id, UpdateCategoryRequestDto data, CategoryService service)
        {
            var category = await service.GetCategoryByIdAsync(id) ?? throw new Exception("Category not found");

            category.CategoryName = data.CategoryName;

            return await service.UpdateCategoryAsync(category);
        }

        private static async Task DeleteCategory(int id, CategoryService service)
        {
            await service.DeleteCategoryAsync(id);
        }
    }
}
