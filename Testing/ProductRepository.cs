using System;
using System.Collections.Generic;
using Testing.Models;
using System.Data;
using Dapper;

namespace Testing
{
    public class ProductRepository : IProductRepository
    {

        private readonly IDbConnection conn;
        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        private readonly IDbConnection _conn;

       

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM PRODUCTS;");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id", new { id = id });
        }

        public void DeleteProduct(Product product)
        {
            _conn.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;", new { id = product.ProductID });
            _conn.Execute("DELETE FROM Sales WHERE ProductID = @id;", new { id = product.ProductID });
            _conn.Execute("DELETE FROM Products WHERE ProductID = @id;", new { id = product.ProductID });
        }
    }
}

