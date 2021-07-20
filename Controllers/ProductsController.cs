using System.Collections.Generic;
using products.Services;
using Microsoft.AspNetCore.Mvc;
using product.Models;

namespace products.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class ProductsController : ControllerBase
  {

    private readonly ProductsService _ps;
    public ProductsController(ProductsService ps)
    {
      _ps = ps;
    }

    [HttpGet]

    public ActionResult<List<Product>> GetAll()
    {
      try
      {
        var allProducts = _ps.GetAll();
        return Ok(allProducts);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<List<Product>> GetById(int id)
    {
      try
      {
        var product = _ps.GetById(id);
        return Ok(product);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }

    }

    [HttpPost]
    public ActionResult<Product> Post([FromBody] Product productData)
    {
      try
      {
        Product newProduct = _ps.Post(productData);
        return Ok(newProduct);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }

    }

    [HttpPut("{id}")]
    public ActionResult<Product> Put(int id, [FromBody] Product productData)
    {
      try
      {
        return Ok(_ps.Put(id, productData));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }

    }

    [HttpDelete("{id}")]
    public ActionResult<Product> Delete(int id)
    {
      try
      {
        return Ok(_ps.Delete(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }

    }
  }
}