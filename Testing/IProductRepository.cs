using System;
using System.Collections.Generic;
using Testing.Models;

namespace Testing
{
    public interface IProductRepository
    {

        public IEnumerable<Product> GetAllProducts();
        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>(SELECT * from products where PRODUCTID = id,
                new { id = id });

        }
        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
             new { name = product.Name, price = product.Price, id = product.ProductID });
        }

        public void InsertProduct(Product productToInsert)
        {


            _conn.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
        new { name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID });
        }

        public IEnumerable<Category> GetCategories()
        {

            return _conn.Query<Category>("SELECT * FROM categories;");
        }

        public Product AssignCategory()
        {

            var prod = repo.AssignCategory();
            return View(prod);
        }

        public void DeleteProduct(Product product);

    }



}

