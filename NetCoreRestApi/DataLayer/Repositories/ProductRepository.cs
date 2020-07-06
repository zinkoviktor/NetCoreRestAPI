using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataLayer.Repositories
{
    public class ProductRepository<TId> : IProductRepository<TId>
    {
        private readonly IRepository<CategoryModel<TId>, TId> _categoryRepository;

        public ProductRepository(IRepository<CategoryModel<TId>, TId> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ProductModel<TId> GetById(TId id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductModel<TId>> GetAll()
        {
            IQueryable<CategoryModel<TId>> categoryModels = _categoryRepository.GetAll();
            Expression<Func<CategoryModel<TId>, bool>> IsLaptopsCategory = (x) => x.Name.Equals("Laptops");
            Expression<Func<CategoryModel<TId>, bool>> IsPritersCategory = (x) => x.Name.Equals("Printers");
            Expression<Func<CategoryModel<TId>, bool>> IsSaleCategory = (x) => x.Name.Equals("Sale");

            var productModels = new List<ProductModel<TId>>
            {
                new ProductModel<TId>()
                {                    
                    Name = "HP 410",
                    Description = "All-in-One Wireless Ink Tank Color Printer",
                    CategoryList = new List<CategoryModel<TId>>()
                    {
                        categoryModels
                            .Where(IsPritersCategory)
                            .FirstOrDefault(),
                        categoryModels
                            .Where(IsSaleCategory)
                            .FirstOrDefault()
                    },
                    Price = 90,
                    AvailableCount = 9,
                },
                new ProductModel<TId>()
                {                   
                    Name = "Epson L3152",
                    Description = "WiFi All in One Ink Tank Printer",
                    CategoryList = new List<CategoryModel<TId>>()
                    {
                        categoryModels
                            .Where(IsPritersCategory)
                            .FirstOrDefault()
                    },
                    Price = 60,
                    AvailableCount = 19,
                },
                new ProductModel<TId>()
                {                    
                    Name = "Dell Inspiron 3583",
                    Description = "15.6-inch FHD Laptop",
                    CategoryList = new List<CategoryModel<TId>>()
                    {
                        categoryModels
                            .Where(IsLaptopsCategory)
                            .FirstOrDefault(),
                        categoryModels
                            .Where(IsSaleCategory)
                            .FirstOrDefault()
                    },
                    Price = 50,
                    AvailableCount = 5,
                }
            };

            return productModels.AsQueryable();
        }

        public IQueryable<ProductModel<TId>> Create(ICollection<ProductModel<TId>> productModels)
        {
            throw new NotImplementedException();
        }

        public void Update(ICollection<ProductModel<TId>> productModels)
        {
            throw new NotImplementedException();
        }

        public void Delete(ICollection<ProductModel<TId>> productModels)
        {
            throw new NotImplementedException();
        }
    }
}
