using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GraphQL.Types;
using GraphQL.Utilities;

namespace GraphQL.Resolvers
{
    public class ArgumentResolver
    {
        public static List<QueryArgument> GetArguments<TSourceType>(bool useFilters, params Expression<Func<TSourceType, object>>[] excludedProperties)
        {
            List<QueryArgument> queryArguments = new List<QueryArgument>();

            foreach (var propertyInfo in AutoResolveHelper.GetRegisteredProperties<TSourceType>())
            {
                if (excludedProperties?.Any(p => AutoResolveHelper.GetPropertyName(p) == propertyInfo.Name) == true)
                {
                    continue;
                }

                var graphType = propertyInfo.PropertyType.GetGraphTypeFromType(AutoResolveHelper.IsNullableProperty(propertyInfo), GetGraphTypeMode.INPUT);
                if(graphType == null)
                {
                    continue;
                }

                var filterType = AutoResolveHelper.GetQueryArgumentFilterFromType(graphType);

                var queryArgument = new QueryArgument(GetQueryArgumentType(graphType, filterType, useFilters))
                {
                    Name = propertyInfo.Name
                };

                if (queryArgument == null)
                {
                    continue;
                }

                queryArguments.Add(queryArgument);
            }

            return queryArguments;
        }

        private static Type GetQueryArgumentType(Type graphType, Type filterType, bool useFilters)
        {
            if(useFilters)
            {
                return filterType == null ? graphType : filterType;
            }

            return graphType;
        }
    }
}