using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Ecomm.DataModel.Models;
using Ecomm.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Ecomm.DataRepository
{
    public class ProductManager : IDataRepository<Product>
    {
        readonly EcommContext _employeeContext;

        public ProductManager(EcommContext context)
        {
            _employeeContext = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _employeeContext.Products.ToList();
        }
        public IEnumerable<Product> GetAll(int take, int skip)
        {
            return _employeeContext.Products.Skip(skip).Take(take).ToList();
        }

        public Product Get(long id)
        {
            var product = _employeeContext.Products.Include(t => t.ProductCategory)
                  .FirstOrDefault(e => e.ProductId == id);
            product.Attributes = _employeeContext.ProductAttributes.Include(t => t.ProductAttributeLookup)
                  .Where(e => e.ProductId == id).ToList();
            return product;
        }

        public void Add(Product entity)
        {
            _employeeContext.Products.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Update(Product employee, Product entity)
        {
            employee.ProductName = entity.ProductName;
            employee.Description = entity.Description;
            employee.ProductCategoryId = entity.ProductCategoryId;

            _employeeContext.SaveChanges();
        }

        public void Delete(Product employee)
        {
            _employeeContext.Products.Remove(employee);
            _employeeContext.SaveChanges();
        }
    }
}