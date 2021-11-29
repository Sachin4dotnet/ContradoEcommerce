using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Ecomm.DataModel.Models;
using Ecomm.DataModel;

namespace Ecomm.DataRepository
{
    public class ProductCategoryManager : IDataRepository<ProductCategory>
    {
        readonly EcommContext _employeeContext;

        public ProductCategoryManager(EcommContext context)
        {
            _employeeContext = context;
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _employeeContext.ProductCategories.ToList();
        }
        public IEnumerable<ProductCategory> GetAll(int take, int skip)
        {
            return _employeeContext.ProductCategories.Skip(skip).Take(take).ToList();
        }

        public ProductCategory Get(long id)
        {
            return _employeeContext.ProductCategories.FirstOrDefault(e => e.ProductCategoryId == id);
        }

        public void Add(ProductCategory entity)
        {
            _employeeContext.ProductCategories.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Update(ProductCategory record, ProductCategory entity)
        {
            record.CategoryName = entity.CategoryName;
            _employeeContext.SaveChanges();
        }

        public void Delete(ProductCategory record)
        {
            _employeeContext.ProductCategories.Remove(record);
            _employeeContext.SaveChanges();
        }
    }
}