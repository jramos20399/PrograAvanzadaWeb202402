using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ICategoryService
    {


        bool Add(Category category);
        bool Remove(Category category);
        bool Update(Category category);

        Category Get(int id);
        IEnumerable<Category> Get();
    }
}
