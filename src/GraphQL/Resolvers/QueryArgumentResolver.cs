using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GraphQL.Types;
using GraphQL.Utilities;

namespace GraphQL.Resolvers
{
    public class QueryArgumentResolver
    {
        public static List<QueryArgument> GetArguments<TSourceType>(params Expression<Func<TSourceType, object>>[] excludedProperties)
        {
            List<QueryArgument> queryArguments = new List<QueryArgument>();

            foreach (var propertyInfo in AutoResolveHelper.GetRegisteredProperties<TSourceType>())
            {
                if (excludedProperties?.Any(p => AutoResolveHelper.GetPropertyName(p) == propertyInfo.Name) == true)
                {
                    continue;
                }

                var queryArgument = new QueryArgument(propertyInfo.PropertyType.GetGraphTypeFromType(AutoResolveHelper.IsNullableProperty(propertyInfo), GetGraphTypeMode.INPUT))
                {
                    Name = propertyInfo.Name
                };
                
                if(queryArgument == null)
                {
                    continue;
                }

                queryArguments.Add(queryArgument);
            }

            return queryArguments;
        }
    }
}