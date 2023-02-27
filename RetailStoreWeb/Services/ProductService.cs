using System;
using System.Collections.Generic;
using System.Linq;
using RetailStoreWeb.Models;
using RetailStoreWeb.Data;
using RetailStoreWeb.Interfaces;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;

namespace RetailStoreWeb.Services
{
    public class ProductService : IProductRepository
    {
        private readonly RetailStoreDBContext _productContext;
        private BulkConfig _config;
        public ProductService(RetailStoreDBContext ProductContext)
        {
            _productContext = ProductContext;
            _config = new BulkConfig();
        }

        public IEnumerable<Product> Products
        {
            get
            {
                return _productContext.Set<Product>()
                .Select(x =>
                new Product
                {
                    Sku = x.Sku,
                    ProductName=x.ProductName,
                    StoreId = x.StoreId,
                    StoreName = x.Store.StoreName,
                    Price = x.Price,
                    EffectiveStartDate = x.EffectiveStartDate,
                    EffectiveEndDate = x.EffectiveEndDate,
                    Active = x.Active
                })
                .ToList();
            }
        }
        public async Task<Product> Create(Product newProduct)
        {
            _productContext.Set<Product>().Add(newProduct);
            await _productContext.SaveChangesAsync();
            return newProduct;
        }

        public async Task<Product> Delete(Guid productID)
        {
            var entity = await _productContext.Set<Product>().FindAsync(productID);
            if (entity == null)
            {
                return entity = null!;
            }

            entity.Active = false;
            _productContext.Entry(entity).State = EntityState.Modified;
            await _productContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Product> Read(Guid productID)
        {
            var a = await _productContext.Set<Product>().FirstOrDefaultAsync(_ => _.Sku == productID);
            return a = null!;
        }

        public async Task<Product> Update(Guid productID, Product updateProduct)
        {
            var entity = await _productContext.Set<Product>().FindAsync(productID);
            if (entity == null)
            {
                return entity = null!;
            }

            _productContext.Entry(entity).State = EntityState.Modified;
            await _productContext.SaveChangesAsync();
            return entity;
        }
        public async Task<int> BulkCreateOrUpdate(IEnumerable<Product> products)
        {
            int exitcode = 0;
            _config.CalculateStats = true;
            await _productContext.BulkInsertAsync<Product>(products.ToList(), _config);
            exitcode = _config.StatsInfo.StatsNumberInserted;
            return exitcode;
        }
    }
}