using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
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

        public bool Add(Category category)
        {
            try
            {
                string sql = "exec [dbo].[sp_AddCategory] @CategoryName,@Description";

                var param = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@CategoryName",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = category.CategoryName

                    },
                    new SqlParameter()
                    {
                        ParameterName = "@Description",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = category.Description

                    }

                };
                context.Database.ExecuteSqlRaw( sql, param );


                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
      
       
    }
}
