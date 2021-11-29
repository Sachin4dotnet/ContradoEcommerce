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
    public class ProductAttributeLookupController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IDataRepository<ProductAttributeLookup> _dataRepository;
        public ProductAttributeLookupController(ILoggerManager logger, IDataRepository<ProductAttributeLookup> dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }

        // GET: api/<ProductAttributeLookupController>
        [HttpGet]
        public IActionResult Get(int take = 10, int skip = 0)
        {
            try
            {
                IEnumerable<ProductAttributeLookup> products = _dataRepository.GetAll(take, skip);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError("ProductAttributeLookup-GetAll InnerException " + ex.InnerException);
                return BadRequest(ex);
            }
        }

        // GET api/<ProductAttributeLookupController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                ProductAttributeLookup product = _dataRepository.Get(id);
                if (product == null)
                {
                    return NotFound("The ProductAttributeLookup record couldn't be found.");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError("ProductAttributeLookup-GetById InnerException " + ex.InnerException);
                return BadRequest(ex);
            }
        }

        // POST api/<ProductAttributeLookupController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductAttributeLookup product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("ProductAttributeLookup is null.");
                }
                _dataRepository.Add(product);
                return Ok(product);
                //return CreatedAtRoute("Post", new { Id = product.ProductAttributeLookupId }, product);
            }
            catch (Exception Ex)
            {
                _logger.LogError("ProductAttributeLookup-Post InnerException " + Ex.InnerException);
                return StatusCode(StatusCodes.Status500InternalServerError, Ex.Message);
            }
        }

        // PUT api/<ProductAttributeLookupController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] ProductAttributeLookup product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("ProductAttributeLookup is null.");
                }
                ProductAttributeLookup productToUpdate = _dataRepository.Get(id);
                if (productToUpdate == null)
                {
                    return NotFound("The ProductAttributeLookup record couldn't be found.");
                }
                _dataRepository.Update(productToUpdate, product);
                return Ok();
                //return NoContent();
            }
            catch (Exception Ex)
            {
                _logger.LogError("ProductAttributeLookup-Put InnerException " + Ex.InnerException);
                return StatusCode(StatusCodes.Status500InternalServerError, Ex.Message);
            }
        }

        // DELETE api/<ProductAttributeLookupController>/5        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                ProductAttributeLookup product = _dataRepository.Get(id);
                if (product == null)
                {
                    return NotFound("The ProductAttributeLookup record couldn't be found.");
                }
                _dataRepository.Delete(product);
                return Ok();
                //return NoContent();
            }
            catch (Exception Ex)
            {
                _logger.LogError("ProductAttributeLookup-Delete InnerException " + Ex.InnerException);
                return StatusCode(StatusCodes.Status500InternalServerError, Ex.Message);
            }
        }
    }
}
