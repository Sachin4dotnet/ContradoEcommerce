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
    public class ProductAttributeController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IDataRepository<ProductAttribute> _dataRepository;
        public ProductAttributeController(ILoggerManager logger, IDataRepository<ProductAttribute> dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }

        // GET: api/<ProductAttributeController>
        [HttpGet]
        public IActionResult Get(int take = 10, int skip = 0)
        {
            try
            {
                IEnumerable<ProductAttribute> products = _dataRepository.GetAll(take, skip);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError("ProductAttribute-GetAll InnerException " + ex.InnerException);
                return BadRequest(ex);
            }
        }

        // GET api/<ProductAttributeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                ProductAttribute product = _dataRepository.Get(id);
                if (product == null)
                {
                    return NotFound("The ProductAttribute record couldn't be found.");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError("ProductAttribute-GetById InnerException " + ex.InnerException);
                return BadRequest(ex);
            }
        }

        // POST api/<ProductAttributeController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductAttribute product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("ProductAttribute is null.");
                }
                _dataRepository.Add(product);
                return Ok(product);
                //return CreatedAtRoute("Post", new { Id = product.ProductAttributeId }, product);
            }
            catch (Exception Ex)
            {
                _logger.LogError("ProductAttribute-Post InnerException " + Ex.InnerException);
                return StatusCode(StatusCodes.Status500InternalServerError, Ex.Message);
            }
        }

        // PUT api/<ProductAttributeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] ProductAttribute product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("ProductAttribute is null.");
                }
                ProductAttribute productToUpdate = _dataRepository.Get(id);
                if (productToUpdate == null)
                {
                    return NotFound("The ProductAttribute record couldn't be found.");
                }
                _dataRepository.Update(productToUpdate, product);
                return Ok();
                //return NoContent();
            }
            catch (Exception Ex)
            {
                _logger.LogError("ProductAttribute-Put InnerException " + Ex.InnerException);
                return StatusCode(StatusCodes.Status500InternalServerError, Ex.Message);
            }
        }

        // DELETE api/<ProductAttributeController>/5        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                ProductAttribute product = _dataRepository.Get(id);
                if (product == null)
                {
                    return NotFound("The ProductAttribute record couldn't be found.");
                }
                _dataRepository.Delete(product);
                return Ok();
                //return NoContent();
            }
            catch (Exception Ex)
            {
                _logger.LogError("ProductAttribute-Delete InnerException " + Ex.InnerException);
                return StatusCode(StatusCodes.Status500InternalServerError, Ex.Message);
            }
        }
    }
}
