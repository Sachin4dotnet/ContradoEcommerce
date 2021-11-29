using Ecomm.DataModel.Models;
using Ecomm.DataRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoggerService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IDataRepository<ProductCategory> _dataRepository;
        public ProductCategoriesController(ILoggerManager logger, IDataRepository<ProductCategory> dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get(int take = 10, int skip = 0)
        {
            try
            {
                IEnumerable<ProductCategory> products = _dataRepository.GetAll(take, skip);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError("ProductCategory-GetAll InnerException " + ex.InnerException);
                return BadRequest(ex);
            }
        }

        // GET api/<ProductCategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                ProductCategory product = _dataRepository.Get(id);
                if (product == null)
                {
                    return NotFound("The ProductCategory record couldn't be found.");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError("ProductCategory-GetById InnerException " + ex.InnerException);
                return BadRequest(ex);
            }
        }

        // POST api/<ProductCategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductCategory product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("ProductCategory is null.");
                }
                _dataRepository.Add(product);
                return Ok(product);
                //return CreatedAtRoute("Post", new { Id = product.ProductCategoryId }, product);
            }
            catch (Exception Ex)
            {
                _logger.LogError("ProductCategory-Post InnerException " + Ex.InnerException);
                return StatusCode(StatusCodes.Status500InternalServerError, Ex.Message);
            }
        }

        // PUT api/<ProductCategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] ProductCategory product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("ProductCategory is null.");
                }
                ProductCategory productToUpdate = _dataRepository.Get(id);
                if (productToUpdate == null)
                {
                    return NotFound("The ProductCategory record couldn't be found.");
                }
                _dataRepository.Update(productToUpdate, product);
                return Ok();
                //return NoContent();
            }
            catch (Exception Ex)
            {
                _logger.LogError("ProductCategory-Put InnerException " + Ex.InnerException);
                return StatusCode(StatusCodes.Status500InternalServerError, Ex.Message);
            }
        }

        // DELETE api/<ProductCategoryController>/5        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                ProductCategory product = _dataRepository.Get(id);
                if (product == null)
                {
                    return NotFound("The ProductCategory record couldn't be found.");
                }
                _dataRepository.Delete(product);
                return Ok();
                //return NoContent();
            }
            catch (Exception Ex)
            {
                _logger.LogError("ProductCategory-Delete InnerException " + Ex.InnerException);
                return StatusCode(StatusCodes.Status500InternalServerError, Ex.Message);
            }
        }
    }
}
