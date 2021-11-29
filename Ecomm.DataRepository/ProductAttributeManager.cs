using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Ecomm.DataModel.Models;
using Ecomm.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Ecomm.DataRepository
{
    public class ProductAttributeManager : IDataRepository<ProductAttribute>
    {
        readonly EcommContext _employeeContext;

        public ProductAttributeManager(EcommContext context)
        {
            _employeeContext = context;
        }

        public IEnumerable<ProductAttribute> GetAll()
        {
            return _employeeContext.ProductAttributes.ToList();
        }
        public IEnumerable<ProductAttribute> GetAll(int take, int skip)
        {
            return _employeeContext.ProductAttributes.Skip(skip).Take(take).ToList();
        }

        public ProductAttribute Get(long id)
        {
            return _employeeContext.ProductAttributes.Include(t => t.ProductAttributeLookup).Include(t => t.Product).FirstOrDefault(e => e.ProductAttributeId == id);
        }

        public void Add(ProductAttribute entity)
        {
            _employeeContext.ProductAttributes.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Update(ProductAttribute record, ProductAttribute entity)
        {
            record.AttributeId = entity.AttributeId;
            record.ProductId = entity.ProductId;
            record.AttributeValue = entity.AttributeValue;
            _employeeContext.SaveChanges();
        }

        public void Delete(ProductAttribute record)
        {
            _employeeContext.ProductAttributes.Remove(record);
            _employeeContext.SaveChanges();
        }
    }
}