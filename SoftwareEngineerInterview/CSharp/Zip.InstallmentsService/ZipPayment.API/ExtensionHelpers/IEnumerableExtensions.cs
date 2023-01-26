using System.Dynamic;
using System.Reflection;

namespace ZipPayment.API.ExtensionHelpers
{
    /// <summary>
    /// Shape data class using dynamically add the objects using ExpandoObject
    /// </summary>
    public static class IEnumerableExtensions
    {
        public static IEnumerable<ExpandoObject> ShapeData<TSource>(this IEnumerable<TSource> source, string fields)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            //create a list to hold our ExpandoObjects
            var expandoObjectList = new List<ExpandoObject>();

            //create a list with PropertyInfo object on TSource. Reflection is expensive,
            //so rather then doing it for each object in the list , we do it once and
            //resue it results. After all, part of the reflection is on type of the object (TSource), not on the instance

            var propertyInfoList = new List<PropertyInfo>();
            if (string.IsNullOrEmpty(fields))
            {
                // all public properties should be in the ExpandoObject
                var propertyInfos = typeof(TSource).GetProperties(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                propertyInfoList.AddRange(propertyInfos);
            }
            else
            {
                var fieldAfterSplit = fields.Split(',');
                foreach (var field in fieldAfterSplit)
                {
                    var propertyName = field.Trim();

                    var propertyInfo = typeof(TSource).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (propertyInfo == null)
                    {
                        throw new Exception($"Property {propertyName} wasn't found on {typeof(TSource)}");
                    }
                    propertyInfoList.Add(propertyInfo);
                }
            }

            foreach (TSource sourceObject in source)
            {
                var dataShapedObject = new ExpandoObject();

                foreach (var propertyInfo in propertyInfoList)
                {
                    var propertyValue = propertyInfo.GetValue(sourceObject);
                    ((IDictionary<string,object?>)dataShapedObject).Add(propertyInfo.Name, propertyValue);
                }

                expandoObjectList.Add(dataShapedObject);
            }

            return expandoObjectList;
        }
    }
}
