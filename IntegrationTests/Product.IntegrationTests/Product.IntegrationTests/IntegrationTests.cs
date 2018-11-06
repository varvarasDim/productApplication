using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Product.IntegrationTests
{
    [TestFixture]
    public class IntegrationTests
    {

        //The names of the tests are selfexplanatory
        //The tests are preparing the datalayer before execution by removing the test data and then creating the data again and running the actual test
        private string _baseUrl;
        public IntegrationTests()
        {
            
        }

        [Test]
        public void CheckThatGetAllEndpointReturnsProducts()
        {
            //Removing test products
            Assert.IsTrue(ProductClient.DeleteProduct(100));
            Assert.IsTrue(ProductClient.DeleteProduct(200));
            //Creating the products that will be used by the test
            Assert.IsTrue(ProductClient.PostProduct( new Model.Product() {Id = 100, Description = "Some description1", Is4G = true, Name = "name1", Price = 100, Weight = 100}));
            Assert.IsTrue(ProductClient.PostProduct(new Model.Product() { Id = 200, Description = "Some description2", Is4G = false, Name = "name2", Price = 200, Weight = 200 }));

            //The actual call that is being tested
            var result = ProductClient.GetAllProducts();

            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Count >= 2);
            Assert.IsTrue(result.FirstOrDefault(t => t.Id == 100)?.Name == "name1");
            Assert.IsTrue(result.FirstOrDefault(t => t.Id == 200)?.Name == "name2");
        }

        [Test]
        public void CheckThatGetOneEndpointReturnsAProduct()
        {
            //Removing test products
            Assert.IsTrue(ProductClient.DeleteProduct(100));
            //Creating the products that will be used by the test
            Assert.IsTrue(ProductClient.PostProduct(new Model.Product() { Id = 100, Description = "Some description1", Is4G = true, Name = "name1", Price = 100, Weight = 100 }));
            //The actual call that is being tested
            var result = ProductClient.GetProduct(100);

            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Is4G);
            Assert.IsTrue(result.Description == "Some description1");
            Assert.IsTrue(result.Name == "name1");
            Assert.IsTrue(result.Price == 100);
            Assert.IsTrue(result.Weight == 100);
        }

        [Test]
        public void CheckThatGetOneEndpointThatDoesNotExistReturnsNull()
        {
            //Removing test products
            Assert.IsTrue(ProductClient.DeleteProduct(100));
            //The actual call that is being tested
            var result = ProductClient.GetProduct(100);

            Assert.IsNull(result);
        }
    }
}
