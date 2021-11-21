using CleanArchitecture.Sample.Application.Interfaces.Repositories;
using CleanArchitecture.Sample.Application.Utils;
using CleanArchitecture.Sample.Application.Utils.Exceptions;
using CleanArchitecture.Sample.Domain.Entities;
using CleanArchitecture.Sample.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Sample.Infrastructure.Repositories
{
    public sealed class ProductRepository : IProductRepository
    {
        private readonly SqlDbContext _dbContext;
        public ProductRepository(SqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Product CreateProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public void DeleteProductById(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }
            else throw new NotFoundException();
        }

        public Product GetProductById(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            if (product != null)
            {
                return product;
            }
            
            throw new NotFoundException();
        }

        public List<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product UpdateProduct(int productId, Product productUpdate)
        {
            var product = _dbContext.Products.Find(productId);
            if (product != null)
            {
                product.Name = productUpdate.Name;
                product.Description = productUpdate.Description;
                product.Price = productUpdate.Price;
                product.Stock = productUpdate.Stock;
                product.UpdatedAt = DateUtil.GetCurrentDate();

                _dbContext.Products.Update(product);
                _dbContext.SaveChanges();

                return product;
            }

            throw new NotFoundException();
        }
    }
}
