using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class CategoryDALImpl : ICategoryDAL
    {

        private NorthWindContext context;


        public CategoryDALImpl(NorthWindContext context)
        {
            this.context = context;
        }


        public bool Add(Category category)
        {
            try
            {
                context.Categories.Add(category);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Category Get(int id)
        {
            return context.Categories.Find(id) ?? new Category();
        }

        public IEnumerable<Category> Get()
        {
            return context.Categories.ToList();
        }

        public bool Remove(Category category)
        {
            try
            {
                context.Categories.Attach(category);
                context.Categories.Remove(category);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(Category category)
        {
            try
            {
                context.Entry(category).State = EntityState.Modified;
               
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
