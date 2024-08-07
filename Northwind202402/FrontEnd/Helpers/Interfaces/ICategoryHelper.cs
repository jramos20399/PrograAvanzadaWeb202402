using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ICategoryHelper
    {
        List<CategoryViewModel> GetCategories();
        CategoryViewModel GetCategory(int id);
        CategoryViewModel Add(CategoryViewModel category);
        CategoryViewModel Remove(int id);
        CategoryViewModel Update(CategoryViewModel category);

        string Token { get; set; }

    }
}
