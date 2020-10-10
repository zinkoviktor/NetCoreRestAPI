using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Helpers
{
    public static class ObjectPropertiesComparer
    {
        public static bool AreEqual(object a, object b)
        {
            if (a == null && b == null)
            {
                return true;
            }
          
            if (a == null || b == null) 
            { 
                return false; 
            }

            if (a.GetType() != b.GetType())
            {
                return false;
            }
            
            var Props = a.GetType().GetProperties();
            
            foreach (var Prop in Props)
            {
              
                var aPropValue = Prop.GetValue(a);
                var bPropValue = Prop.GetValue(b);
                   
                if (aPropValue?.ToString() != bPropValue?.ToString())
                {
                    return false;
                }                    
            }
            return true;
        }
    }
}
