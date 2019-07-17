using System.Collections.Generic;
using GraphQL.Types;

namespace GraphQL.Resolvers.QueryArgumentFilter
{
    public abstract class BaseQueryArgumentFilter<TSourceType> : InputObjectGraphType
        where TSourceType : IGraphType
    {
        public TSourceType Eq { get; set; }
        public TSourceType Ne { get; set; }
        public TSourceType In { get; set; }
        public TSourceType Nin { get; set; }

        public BaseQueryArgumentFilter()
        {
            Field<TSourceType>(name: "Eq");
            Field<TSourceType>(name: "Ne");
            Field<TSourceType>(name: "In");
            Field<TSourceType>(name: "Nin");
        }
    }
}