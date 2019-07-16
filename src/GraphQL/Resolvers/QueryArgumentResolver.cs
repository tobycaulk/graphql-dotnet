using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GraphQL.Resolvers.QueryArgumentFilter;
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

                var graphType = propertyInfo.PropertyType.GetGraphTypeFromType(AutoResolveHelper.IsNullableProperty(propertyInfo), GetGraphTypeMode.INPUT);
                if(graphType == null)
                {
                    continue;
                }


                var filterType = GetQueryArgumentFilterFromType(graphType);

                var queryArgument = new QueryArgument(filterType == null ? graphType : filterType)
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

        public static Type GetQueryArgumentFilterFromType(Type type)
        {
            if(QueryArgumentFilterRegistery.Contains(type))
            {
                return QueryArgumentFilterRegistery.Get(type);
            }

            return null;
        }
    }
}