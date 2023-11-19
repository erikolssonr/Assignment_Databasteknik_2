using Assignment_Databasteknik.Entities;
using Assignment_Databasteknik.Models;
using Assignment_Databasteknik.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Diagnostics;

namespace Assignment_Databasteknik.Services;

internal class ProductService
{
    private readonly ProductRepo _productRepo;
    private readonly ProductTypeRepo _productTypeRepo;

    public ProductService(ProductRepo productRepo, ProductTypeRepo productTypeRepo)
    {
        _productRepo = productRepo;
        _productTypeRepo = productTypeRepo;
    }

    public async Task<bool> CreateProductAsync(ProductRegistrationForm form)
    {
        if (!await _productRepo.ExistsAsync(x => x.ProductName == form.ProductName))
        {
            var productTypeEntity = await _productTypeRepo.GetAsync(x => x.ProductTypeName == form.ProductType);
            productTypeEntity ??= await _productTypeRepo.CreateAsync(new ProductTypeEntity { ProductTypeName = form.ProductType });

            var productEntity = await _productRepo.CreateAsync(new ProductEntity
            {
                ProductName = form.ProductName,
                ProductDescription = form.ProductDescription,
                ProductPrice = form.ProductPrice,
                ProductTypeId = productTypeEntity.Id,
            });

            if (productEntity != null)
                return true;
        }

        return false;
    }

    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        var products = await _productRepo.GetAllAsync();
        return products;
    }

}
