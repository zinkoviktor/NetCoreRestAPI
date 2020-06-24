﻿using System.Linq;
using BusinessLayer.Managers;
using Common.Converter;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DataTransferObjects;

namespace WebAPI.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryManager _categoryManager;
        private IConverter<CategoryDTO, CategoryModel> _converter;
        
        public CategoriesController(ICategoryManager categoryManager, IConverter<CategoryDTO, CategoryModel> converter)
        {            
            _categoryManager = categoryManager;
            _converter = converter;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categoryModels = _categoryManager.GetAll();           
            var categoriesDTO = _converter.ConvertFrom(categoryModels.ToList());

            return Ok(categoriesDTO);
        }
    }
}