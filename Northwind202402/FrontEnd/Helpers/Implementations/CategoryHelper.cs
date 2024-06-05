using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class CategoryHelper : ICategoryHelper
    {
        IServiceRepository ServiceRepository;

        public CategoryHelper(IServiceRepository serviceRepository)
        {
            this.ServiceRepository = serviceRepository;
        }


        private CategoryViewModel Convertir(Category category)
        {
            return new CategoryViewModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
        }
      

       public List<CategoryViewModel> GetCategories()
         {
             HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/category");
            List<Category> resultado = new List<Category>();

             if (responseMessage!=null)
             {
                 var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Category>>(content);


             }
             List<CategoryViewModel> categories = new List<CategoryViewModel>();

            foreach (var item in resultado)
            {   
                categories.Add(Convertir(item));
            }

            return categories;

         }
    }
}
