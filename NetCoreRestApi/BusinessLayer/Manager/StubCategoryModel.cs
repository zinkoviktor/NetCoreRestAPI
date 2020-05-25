using BusinessLayer.Models;

namespace BusinessLayer.Manager
{
    public class StubCategoryModel : CategoryModel
    {
        internal StubCategoryModel(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
