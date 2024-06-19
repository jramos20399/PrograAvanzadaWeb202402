using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class SupplierHelper : ISupplierHelper
    {

        IServiceRepository _repository;

        public SupplierHelper(IServiceRepository service)
        {
                _repository = service;
        }


        SupplierViewModel Convertir (Supplier supplier)
        {
            return new SupplierViewModel
            {
                SupplierId = supplier.SupplierId,
                CompanyName = supplier.CompanyName,
            };
        }

        public List<SupplierViewModel> GetAll()
        {
            List<SupplierViewModel> lista = new List<SupplierViewModel>();
            List<Supplier> result = new List<Supplier>();
            HttpResponseMessage response = _repository.GetResponse("api/supplier");



            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
               result= JsonConvert.DeserializeObject<List<Supplier>>(content);

            }

            foreach (var item in result)
            {
                lista.Add(Convertir(item));
            }


            return lista;
            
        }
    }
}
