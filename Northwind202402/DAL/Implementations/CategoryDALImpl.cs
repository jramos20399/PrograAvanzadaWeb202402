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


      
       
    }
}
