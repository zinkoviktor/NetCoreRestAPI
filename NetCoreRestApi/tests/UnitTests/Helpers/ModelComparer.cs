using DataLayer.Models;
using System.Collections.Generic;

namespace UnitTests.Helpers
{
    public class ModelComparer : BaseComparer
    {
        public static readonly ModelComparer Instance = new ModelComparer();

        private ModelComparer()
        {

        }

        public static bool AreCategoryModelEquals(CategoryModel model1, CategoryModel model2)
        {            
            return Instance.AreObjectTypesEquals<CategoryModel>(model1, model2) 
                && model1.Id == model2.Id
                    && model1.Name == model2.Name
                        && model1.Description == model2.Description;
        }

        public static bool AreCategoryModelEquals(List<CategoryModel> models1, List<CategoryModel> models2)
        {
            if(models1.Count != models2.Count)
            {
                return false;
            }

            for(var i = 0; i < models1.Count; i++)
            {
                if (!AreCategoryModelEquals(models1[1], models2[1]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
