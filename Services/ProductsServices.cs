using System;
using System.Collections.Generic;
using product.Models;
using product.Repositories;



namespace products.Services
{
  public class ProductsService
  {


    private readonly ProductsRepository _Repo;

    public ProductsService(ProductsRepository Repo)
    {
      _Repo = Repo;
    }


    public List<Product> GetAll()
    {
      return _Repo.GetAll();
    }

    public Product GetById(int id)
    {
      return _Repo.GetById(id);
    }

    public Product Post(Product productData)
    {
      return _Repo.Post(productData);
    }

    public Product Put(int id, Product productData)
    {
      productData.Id = id;
      Product original = GetById(id);
      productData.Body = productData.Body == null ? original.Body : productData.Body;
      int updated = _Repo.Put(productData);
      if (updated > 0)
      {
        return productData;
      }
      else
      {
        throw new Exception("Update Failed");
      }
    }

    public string Delete(int id)
    {
      int updated = _Repo.delete(id);
      if (updated > 0)
      {
        return "Deleted";
      }
      else
      {
        throw new System.Exception("could not delete");
      }

    }
  }
}