using System;
using System.Collections.Generic;
using GraphQL.Types;

namespace GraphQL.Utilities
{
    public class CompoundGraphTypeRegistery
    {
        static readonly Dictionary<Type, CompoundGraphType> _entries = new Dictionary<Type, CompoundGraphType>();

        public static void Register<T>(CompoundGraphType compoundGraphType)
        {
            Register(typeof(T), compoundGraphType);
        }

        public static void Register(Type clrType, CompoundGraphType graphType)
        {
            _entries[clrType ?? throw new ArgumentNullException(nameof(clrType))] = graphType ?? throw new ArgumentNullException(nameof(graphType));
        }

        public static CompoundGraphType Get<TClr>() => Get(typeof(TClr));

        public static CompoundGraphType Get(Type clrType) => _entries.TryGetValue(clrType, out var graphType) ? graphType : null;

        public static bool Contains(Type clrType) => _entries.ContainsKey(clrType);
    }
}