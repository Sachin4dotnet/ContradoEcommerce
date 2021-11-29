using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Ecomm.DataModel.Models;
using Ecomm.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Ecomm.DataRepository
{
    public class ProductAttributeLookupManager : IDataRepository<ProductAttributeLookup>
    {
        readonly EcommContext _employeeContext;

        public ProductAttributeLookupManager(EcommContext context)
        {
            _employeeContext = context;
        }

        public IEnumerable<ProductAttributeLookup> GetAll()
        {
            return _employeeContext.ProductAttributeLookups.ToList();
        }
        public IEnumerable<ProductAttributeLookup> GetAll(int take, int skip)
        {
            return _employeeContext.ProductAttributeLookups.Skip(skip).Take(take).ToList();
        }

        public ProductAttributeLookup Get(long id)
        {
            return _employeeContext.ProductAttributeLookups.Include(t => t.ProductCategory).FirstOrDefault(e => e.AttributeId == id);
        }

        public void Add(ProductAttributeLookup entity)
        {
            _employeeContext.ProductAttributeLookups.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Update(ProductAttributeLookup record, ProductAttributeLookup entity)
        {
            record.AttributeName = entity.AttributeName;
            record.ProductCategoryId = entity.ProductCategoryId;
            _employeeContext.SaveChanges();
        }

        public void Delete(ProductAttributeLookup record)
        {
            _employeeContext.ProductAttributeLookups.Remove(record);
            _employeeContext.SaveChanges();
        }
    }
}