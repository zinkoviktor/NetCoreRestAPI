using DataLayer.Models;

namespace BusinessLayer.Manager
{
    public class StubCategoryModel : CategoryModel
    {
        internal StubCategoryModel(int ID, string name, string description)
        {
            this.ID = ID;
            Name = name;
            Description = description;
        }
    }
}
