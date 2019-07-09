using System;
using System.Collections.Generic;

namespace GraphQL.Types
{
    public class CustomTypeHandler
    {
        private static IDictionary<Type, CustomTypeResolver> _CustomTypeResolvers = new Dictionary<Type, CustomTypeResolver>();
        public static IDictionary<Type, CustomTypeResolver> CustomTypeResolvers
        {
            get
            {
                return _CustomTypeResolvers;
            }
        }

        public static void AddResolver(Type fieldType, CustomTypeResolver resolver)
        {
            if(!CustomTypeResolvers.ContainsKey(fieldType))
            {
                CustomTypeResolvers.Add(fieldType, resolver);
            }
        }
    }

    public interface CustomTypeResolver
    {
        Type GetFieldType();
        Type GetGraphQLType();
        object Resolve(Type sourceType);
    }
}