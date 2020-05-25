﻿using BusinessLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Manager
{
    public class StubProductModel : ProductModel
    {
        internal StubProductModel(string name)
        {
            Name = name;
            Description = "Description for " + name;
            CategoryList = new List<CategoryModel>();
            CategoryList.Add(new CategoryModel() { Name = "Category1", Description = "description" });
            CategoryList.Add(new CategoryModel() { Name = "Category2", Description = "description" });
            Price = 100.99m;
            AvailableCount = 9;
        }
    }
}