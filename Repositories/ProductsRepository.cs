using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using product.Models;
using Dapper;

namespace product.Repositories
{

  public class ProductsRepository
  {
    private readonly IDbConnection _db;

    public ProductsRepository(IDbConnection db)
    {
      _db = db;
    }


    public List<Product> GetAll()
    {
      var sql = "SELECT * FROM products";
      return _db.Query<Product>(sql).ToList();
    }

    public Product GetById(int id)
    {
      string sql = "SELECT * FROM products WHERE id = @id";
      return _db.QueryFirstOrDefault<Product>(sql, new { id });
    }
    public Product Post(Product productData)
    {
      var sql = @"
            INSERT INTO products(body)
            VALUES(@Body);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, productData);
      productData.Id = id;
      return productData;
    }
    public int Put(Product productData)
    {
      string sql = @"
                UPDATE products SET
                body = @Body
                WHERE id = @id;
                ";
      return _db.Execute(sql, productData);
    }

    public int delete(int id)
    {
      string sql = @"
      DELETE FROM products WHERE id = @id";
      return _db.Execute(sql, new { id });
    }
  }
}