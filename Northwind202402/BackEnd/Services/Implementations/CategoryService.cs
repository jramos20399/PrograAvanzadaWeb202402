using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CategoryService : ICategoryService
    {

        private IUnidadDeTrabajo _unidadDeTrabajo;

        private ICategoryDAL categoryDAL;

        public CategoryService(IUnidadDeTrabajo unidadDeTrabajo)
        {
                this._unidadDeTrabajo = unidadDeTrabajo;
        }


        public bool Add(Category category)
        {
           return _unidadDeTrabajo.CategoryDAL.Add(category);
        }

        public Category Get(int id)
        {
            return _unidadDeTrabajo.CategoryDAL.Get(id);
        }

        public IEnumerable<Category> Get()
        {
            return _unidadDeTrabajo.CategoryDAL.GetAll();
        }

        public bool Remove(Category category)
        {
            return _unidadDeTrabajo.CategoryDAL.Remove(category);
        }

        public bool Update(Category category)
        {
            return _unidadDeTrabajo.CategoryDAL.Update(category);    
        }
    }
}
