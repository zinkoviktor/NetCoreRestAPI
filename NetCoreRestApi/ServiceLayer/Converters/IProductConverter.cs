using BusinessLayer.Models;
using ServiceLayer.DataTransferObjects;

namespace ServiceLayer.Converters
{
    public interface IProductConverter
    {
        ProductDTO ConverToDTO(ProductModel productModel);

        ProductModel ConverToModel(ProductDTO productDTO);
    }
}
