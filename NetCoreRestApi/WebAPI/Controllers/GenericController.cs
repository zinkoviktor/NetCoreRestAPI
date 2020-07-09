using BusinessLayer.Interfaces;
using Common.Converter;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class GenericController<TDto, TModel> : ControllerBase
    {
        public IManager<TModel> Manager { get; private set; }
        public IConverter<TDto, TModel> Converter { get; private set; }

        public GenericController(IManager<TModel> manager, IConverter<TDto, TModel> converter)
        {
            Manager = manager;
            Converter = converter;
        }
    }
}