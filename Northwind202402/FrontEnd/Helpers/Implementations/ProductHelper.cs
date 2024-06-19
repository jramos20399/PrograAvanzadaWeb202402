using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace FrontEnd.Helpers.Implementations
{
    public class ProductHelper : IProductHelper
    {

        IServiceRepository ServiceRepository;

        ProductViewModel Convertir(Product product)
        {
            return new ProductViewModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
                Discontinued = product.Discontinued
            };
        }

        Product Convertir(ProductViewModel product)
        {
            return new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
                Discontinued = product.Discontinued
            };
        }


        public ProductHelper(IServiceRepository serviceRepository)
        {
            this.ServiceRepository = serviceRepository;
        }


        public ProductViewModel AddProduct(ProductViewModel ProductViewModel)
        {
            ProductViewModel product = new ProductViewModel();
            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Product", Convertir(ProductViewModel));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var result = JsonConvert.DeserializeObject<bool>(content);
            }

            return new ProductViewModel { };
        }

        public void DeleteProduct(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Product/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }
        }

        public ProductViewModel EdiProduct(ProductViewModel ProductViewModel)
        {
            ProductViewModel product = new ProductViewModel();
            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Product", Convertir(ProductViewModel));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var result = JsonConvert.DeserializeObject<bool>(content);
            }

            return new ProductViewModel { };
        }

        public List<ProductViewModel> GetAll()
        {
            List<ProductViewModel> lista = new List<ProductViewModel>();
            List<Product> result = new List<Product>();
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Product");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<Product>>(content);
            }

            foreach (var item in result)
            {
                lista.Add(Convertir(item));
            }

            return lista; throw new NotImplementedException();
        }

        public ProductViewModel GetById(int id)
        {
            ProductViewModel Product = new ProductViewModel();
            Product resultado = new Product();
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Product/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Product>(content);
            }
            Product = Convertir(resultado);
            return Product;
        }
    }
}
