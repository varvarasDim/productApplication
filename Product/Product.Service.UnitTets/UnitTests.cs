using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Product.DataAccess.Repository;
using Product.DataAccess.Entity;
using Product.Service.Service;

namespace Product.Service.UnitTets
{
    //The names of the tests are selfexplanatory
    [TestFixture]
    public class UnitTests
    {
        private Mock<IProductRepository> _productRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _productRepositoryMock.Setup(t => t.GetAll()).Returns(StaticData.GetMockedProducts);
        }

        [Test]
        public void GetAllProducts_Succeeds()
        {
            var sut = GetSut();
            var result = sut.GetAllProductInfos();

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.IsTrue(result.Count == 3);
        }

        [Test]
        public void GetOneProduct_Succeeds()
        {
            int productId = 100;
            var productToBeReturned = StaticData.GetMockedProducts().First(t => t.Id.Equals(100));
            _productRepositoryMock = new Mock<IProductRepository>();
            _productRepositoryMock.Setup(t => t.Get(productId)).Returns(productToBeReturned);

            var sut = GetSut();
            var result = sut.GetProduct(productId);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == productId);
            Assert.IsTrue(result.Description == productToBeReturned.Description);
            Assert.IsTrue(result.Price == productToBeReturned.Price);
            Assert.IsTrue(result.Name == productToBeReturned.Name);
        }

        [Test]
        public void GetOneProductThatDoesNotExist_Succeeds_ReturnsNull()
        {
            int productId = 1000;
            _productRepositoryMock = new Mock<IProductRepository>();
            _productRepositoryMock.Setup(t => t.Get(productId)).Returns((DataAccess.Entity.Product)null);

            var sut = GetSut();
            var result = sut.GetProduct(productId);

            Assert.IsNull(result);
        }

        private ProductService GetSut()
        {
            return new ProductService(_productRepositoryMock.Object);
        }
    }

    public static class StaticData
    {
        public static List<DataAccess.Entity.Product> GetMockedProducts()
        {
            return new List<DataAccess.Entity.Product>()
            {
                new DataAccess.Entity.Product() {Id = 100, Description = "description1", Name = "name1", Price = 10, Is4G = true, Weight = 100},
                new DataAccess.Entity.Product() {Id = 200, Description = "description2", Name = "name2", Price = 20, Is4G = true, Weight = 200},
                new DataAccess.Entity.Product() {Id = 300, Description = "description3", Name = "name3", Price = 30, Is4G = true, Weight = 300},
            };
        }
    }
}



