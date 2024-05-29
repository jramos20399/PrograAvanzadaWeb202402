using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CategoryService : ICategoryService
    {

        private ICategoryDAL categoryDAL;

        public CategoryService(ICategoryDAL categoryDAL)
        {
                this.categoryDAL = categoryDAL;
        }


        public bool Add(Category category)
        {
           return categoryDAL.Add(category);
        }

        public Category Get(int id)
        {
            return categoryDAL.Get(id);
        }

        public IEnumerable<Category> Get()
        {
            return categoryDAL.Get();
        }

        public bool Remove(Category category)
        {
            return categoryDAL.Remove(category);
        }

        public bool Update(Category category)
        {
            return categoryDAL.Update(category);    
        }
    }
}
