using Application.DAL.Repositories;
using Application.DAL.Repositories.Interfaces;
using Application.Domain.Entities;
using Application.Infrastucture.Services;
using Application.WebApi.Mappings;
using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Application.Tests
{
    public class ProductServiceTest
    {
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }

        [Test]        
        public void Add_New_Product()
        {
            // Arrange
            //var mockProductRepository = new Mock<IProductRepository>();
            //mockProductRepository.Setup(x => x.Add(It.IsAny<Product>())).Returns(1);
            // mockProductService = new ProductService(mockProductRepository.Object, _mapper);
            var asd = new FakeProductRepository();

            // Act
            var a = asd.Add(new Product
            {
                Id = 5,
                Name = "Name_5",
                //Price = "100"
            });

            // Assert
            Assert.AreEqual(a, 5);
        }

        [Test]
        public void GetAll_Returns_Three_Element_List()
        {
            // Arrange 
            var productList = new List<Product>()
            {
                new Product { Id = 1, Name = "Name_1", Price = 10 },
                new Product { Id = 2, Name = "Name_2", Price = 20 },
                new Product { Id = 3, Name = "Name_3", Price = 30 },
            };
            
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(m => m.GetAll()).Returns( productList );

            var mockService = new ProductService(mockProductRepository.Object, _mapper);

            // Act
            var response = mockService.GetAll().ToList();

            // Assert
            Assert.AreEqual(productList.Count, response.Count);
            Assert.That(productList.Count, Is.EqualTo(response.Count));
        }

        [Test]
        public void Sum_Prices_Of_All_Products()
        {
            // Arrange 
            var productList = new List<Product>()
            {
                new Product { Id = 1, Name = "Name_1", Price = 10 },
                new Product { Id = 2, Name = "Name_2", Price = 20 },
                new Product { Id = 3, Name = "Name_3", Price = 30 },
            };

            var productsPriceSum = productList.Sum(x => x.Price);

            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(m => m.GetAll()).Returns(productList);

            var mockService = new ProductService(mockProductRepository.Object, _mapper);

            // Act
            var response = mockService.GetSumPricesAllproducts();

            // Assert
            Assert.AreEqual(response, productsPriceSum);
            Assert.That(response, Is.EqualTo(productsPriceSum));
        }
    }
}