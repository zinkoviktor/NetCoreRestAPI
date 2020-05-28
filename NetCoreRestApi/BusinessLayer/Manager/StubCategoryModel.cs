using DataLayer.Models;

namespace BusinessLayer.Manager
{
    public class StubCategoryModel : CategoryModel
    {
        internal StubCategoryModel(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
