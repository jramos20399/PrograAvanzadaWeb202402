using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class CategoryHelper : ICategoryHelper
    {
        IServiceRepository ServiceRepository;
        public string Token { get; set; }

        public CategoryHelper(IServiceRepository serviceRepository)
        {
            this.ServiceRepository = serviceRepository;
        }


        public CategoryViewModel Add(CategoryViewModel category)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/category", Convertir(category));


            if (response != null)
            {

                var content = response.Content.ReadAsStringAsync().Result;


            }
            return category;
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


        private Category Convertir(CategoryViewModel category)
        {
            return new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
        }


        public List<CategoryViewModel> GetCategories()
         {


            ServiceRepository.Client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
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

        public CategoryViewModel GetCategory(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/category/" + id.ToString());
            Category resultado = new Category();
            if (responseMessage!=null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Category>(content);
            }

            return Convertir(resultado);

        }

       

        public CategoryViewModel Remove(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/category/" + id.ToString());
            Category resultado = new Category();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                
            }

            return Convertir(resultado);
        }

        public CategoryViewModel Update(CategoryViewModel category)
        {
            HttpResponseMessage response = ServiceRepository.PutResponse("api/category", Convertir(category));


            if (response != null)
            {

                var content = response.Content.ReadAsStringAsync().Result;


            }
            return category;
        }
    }
}
