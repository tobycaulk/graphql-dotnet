using System;
using System.Collections.Generic;
using GraphQL.Types;

namespace GraphQL.Resolvers.QueryArgumentFilter
{
    public static class QueryArgumentFilterRegistery
    {
        static readonly Dictionary<Type, Type> _entries;

        static QueryArgumentFilterRegistery()
        {
            _entries = new Dictionary<Type, Type>
            {
                [typeof(StringGraphType)] = typeof(StringQueryArgumentFilter),
                [typeof(IntGraphType)] = typeof(IntQueryArgumentFilter),
                [typeof(FloatGraphType)] = typeof(FloatQueryArgumentFilter),
                [typeof(BooleanGraphType)] = typeof(BooleanQueryArgumentFilter),
                [typeof(IdGraphType)] = typeof(IdQueryArgumentFilter),
                [typeof(DateGraphType)] = typeof(DateQueryArgumentFilter),
                [typeof(DateTimeGraphType)] = typeof(DateTimeOffsetQueryArgumentFilter),
                [typeof(DateTimeOffsetGraphType)] = typeof(DateTimeOffsetQueryArgumentFilter),
                [typeof(TimeSpanSecondsGraphType)] = typeof(TimeSpanSecondsQueryArgumentFilter),
                [typeof(TimeSpanMillisecondsGraphType)] = typeof(TimeSpanMilliseconsQueryArgumentFilter),
                [typeof(EnumerationGraphType)] = typeof(EnumQueryArgumentFilter),
                [typeof(DecimalGraphType)] = typeof(DecimalQueryArgumentFilter),
            };
        }

        public static void Register<T, TGraph>() where TGraph : GraphType
        {
            Register(typeof(T), typeof(TGraph));
        }

        public static void Register(Type clrType, Type graphType)
        {
            _entries[clrType ?? throw new ArgumentNullException(nameof(clrType))] = graphType ?? throw new ArgumentNullException(nameof(graphType));
        }

        public static Type Get<TClr>() => Get(typeof(TClr));

        public static Type Get(Type clrType) => _entries.TryGetValue(clrType, out var graphType) ? graphType : null;

        public static bool Contains(Type clrType) => _entries.ContainsKey(clrType);
    }
}
