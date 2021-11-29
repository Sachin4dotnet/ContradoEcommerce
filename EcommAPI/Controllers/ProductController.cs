using Ecomm.DataModel.Models;
using Ecomm.DataRepository;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IDataRepository<Product> _dataRepository;
        public ProductController(ILoggerManager logger, IDataRepository<Product> dataRepository)
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
                IEnumerable<Product> products = _dataRepository.GetAll(take, skip);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError("Product-GetAll InnerException " + ex.InnerException);
                return BadRequest(ex);
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Product product = _dataRepository.Get(id);
                if (product == null)
                {
                    return NotFound("The Product record couldn't be found.");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError("Product-GetById InnerException " + ex.InnerException);
                return BadRequest(ex);
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product is null.");
                }
                _dataRepository.Add(product);
                return Ok(product);
                //return CreatedAtRoute("Post", new { Id = product.ProductId }, product);
            }
            catch (Exception ex)
            {
                _logger.LogError("Product-Post InnerException " + ex.InnerException);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product is null.");
                }
                Product productToUpdate = _dataRepository.Get(id);
                if (productToUpdate == null)
                {
                    return NotFound("The Product record couldn't be found.");
                }
                _dataRepository.Update(productToUpdate, product);
                return Ok();
                //return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("Product-Put InnerException " + ex.InnerException);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<ProductController>/5        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                Product product = _dataRepository.Get(id);
                if (product == null)
                {
                    return NotFound("The Product record couldn't be found.");
                }
                _dataRepository.Delete(product);
                return Ok();
                //return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("Product-Delete InnerException " + ex.InnerException);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
