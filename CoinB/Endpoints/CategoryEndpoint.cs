using CoinB.Data.Models;
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

        private static async Task<List<Category>> GetAllCategories(CategoryService service)
        {
            return await service.GetAllCategoriesAsync();
        }

        private static async Task<Category> GetCategoryById(int id, CategoryService service)
        {
            return await service.GetCategoryByIdAsync(id) ?? throw new Exception("");
        }

        private static async Task<Category> AddCategory(Category data, CategoryService service)
        {
            return await service.AddCategoryAsync(data);
        }

        private static async Task<Category> UpdateCategory(int id, Category data, CategoryService service)
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
