using GraphQL.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace GraphQL.Types
{
    /// <summary>
    /// Allows you to automatically register the necessary fields for the specified type.
    /// Supports <see cref="DescriptionAttribute"/>, <see cref="ObsoleteAttribute"/>, <see cref="DefaultValueAttribute"/> and <see cref="RequiredAttribute"/>.
    /// </summary>
    /// <typeparam name="TSourceType"></typeparam>
    public class AutoRegisteringObjectGraphType<TSourceType> : ObjectGraphType<TSourceType>
    {
        /// <summary>
        /// Creates a GraphQL type by specifying fields to exclude from registration.
        /// </summary>
        /// <param name="excludedProperties"> Expressions for excluding fields, for example 'o => o.Age'. </param>
        public AutoRegisteringObjectGraphType(params Expression<Func<TSourceType, object>>[] excludedProperties)
        {
            foreach (var propertyInfo in GetRegisteredProperties())
            {
                if (excludedProperties?.Any(p => GetPropertyName(p) == propertyInfo.Name) == true)
                {
                    continue;
                }

                Field(
                    type: propertyInfo.PropertyType.GetGraphTypeFromType(IsNullableProperty(propertyInfo)),
                    name: propertyInfo.Name,
                    description: propertyInfo.Description(),
                    deprecationReason: propertyInfo.ObsoleteMessage()
                ).DefaultValue = (propertyInfo.GetCustomAttributes(typeof(DefaultValueAttribute), false).FirstOrDefault() as DefaultValueAttribute)?.Value;
            }
        }

        private static bool IsNullableProperty(PropertyInfo propertyInfo)
        {
            return AutoResolveHelper.IsNullableProperty(propertyInfo);
        }

        private static string GetPropertyName(Expression<Func<TSourceType, object>> expression)
        {
            return AutoResolveHelper.GetPropertyName(expression);
        }

        protected virtual IEnumerable<PropertyInfo> GetRegisteredProperties()
        {
            return AutoResolveHelper.GetRegisteredProperties<TSourceType>();
        }

        private static bool IsEnabledForRegister(Type propertyType, bool firstCall)
        {
            return AutoResolveHelper.IsEnabledForRegister(propertyType, firstCall);
        }

        private static Type GetRealType(Type propertyType)
        {
            return AutoResolveHelper.GetRealType(propertyType);
        }
    }
}
