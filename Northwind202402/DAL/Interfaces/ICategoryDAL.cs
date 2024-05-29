using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICategoryDAL
    {

        bool Add(Category category);
        bool Remove(Category category);
        bool Update(Category category);

        Category Get(int id);
        IEnumerable<Category> Get();


    }
}
