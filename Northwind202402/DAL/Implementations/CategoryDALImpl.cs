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
    public class CategoryDALImpl : DALGenericoImpl<Category>, ICategoryDAL
    {

        private NorthWindContext context;


        public CategoryDALImpl(NorthWindContext context): base(context) 
        {
            this.context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            List<Category> list = new List<Category>();
            List<sp_GetAllCategories_Result> results;

            string sql = "[dbo].[sp_GetAllCategories]";

            results = context
                    .Sp_GetAllCategories_Results
                    .FromSqlRaw(sql)
                    .ToList();

            foreach (var item in results)
            {
                list.Add(
                    
                    new Category
                    {
                        CategoryId = item.CategoryId,
                        CategoryName = item.CategoryName,
                        Description = item.Description,
                        Picture = item.Picture
                    }
                    
                    
                    );
            }

            return list;


        }
      
       
    }
}
