using System;
using System.Collections.Generic;
using Testing.Modles;
using System.Data;


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
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM PRODUCTS;");
        }
    }
}

