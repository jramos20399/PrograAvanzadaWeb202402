﻿using BackEnd.Model;

namespace BackEnd.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductModel> GetProducts();
        bool Add(ProductModel product);
        bool Update(ProductModel product);
        bool Delete(int id);
        ProductModel GetProduct(int id);

    }
}
