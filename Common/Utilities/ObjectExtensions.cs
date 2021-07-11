using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common.Utilities
{
    public static class ObjectExtensions
    {
        public static bool IsAnyNullOrEmpty(this object obj)
        {
            //Step 1: Set the result variable to false;
            bool result = true;

            //Step 2: Check if the incoming object has values or not.
            if (obj == null)
                return false;
            else
            {
                //Step 3: Iterate over the properties and check for null values based on the type.
                foreach (PropertyInfo pi in obj.GetType().GetProperties())
                {
                    //Step 4: The null check condition only works if the value of the result is false, whenever the result gets true, the value is returned from the method.
                    if (result == true)
                    {
                        //Step 5: Different conditions to satisfy different types
                        dynamic value;

                        if (pi.PropertyType == typeof(string))
                        {
                            value = (string)pi.GetValue(obj);
                            result = (string.IsNullOrEmpty(value) ? true : false || string.IsNullOrWhiteSpace(value) ? true : false);
                        }
                        else if (pi.PropertyType == typeof(int))
                        {
                            value = (int)pi.GetValue(obj);
                            result = (value <= 0 ? true : false || value == null ? true : false);
                        }
                        else if (pi.PropertyType == typeof(bool))
                        {
                            value = pi.GetValue(obj);
                            result = (value == null || value == false ? true : false);
                        }
                        else if (pi.PropertyType == typeof(Guid))
                        {
                            value = pi.GetValue(obj);
                            result = (value == Guid.Empty ? true : false || value == null ? true : false);
                        }
                    }
                    //Step 6 - If the result becomes true, the value is returned from the method.
                    else
                        return result;
                }
            }


            //Step 7: If the value doesn't become true at the end of foreach loop, the value is returned.
            return result;
        }

        public static void RemoveNullobject(this object obj, string Contains, string NotContains)
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                if (prop.Name.Contains(Contains) && prop.Name != NotContains)
                {
                    dynamic objs = obj.GetType().GetProperty(prop.Name).GetValue(obj);
                    if (objs is IEnumerable)
                    {
                        var objsForLoop = Enumerable.ToList(objs);

                        foreach (var item in objsForLoop)
                        {
                            if ((item as object).IsAnyNullOrEmpty())
                            {
                                objs.Remove(item);
                            }
                        }
                    }
                }
            }
        }
    }
}
