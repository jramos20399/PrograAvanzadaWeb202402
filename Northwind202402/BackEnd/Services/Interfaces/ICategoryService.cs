using BackEnd.Model;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ICategoryService
    {


        bool Add(CategoryModel category);
        bool Remove(CategoryModel category);
        bool Update(CategoryModel category);

        CategoryModel Get(int id);
        IEnumerable<CategoryModel> Get();
    }
}
