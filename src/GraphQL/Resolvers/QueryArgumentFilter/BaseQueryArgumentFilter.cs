using System.Collections.Generic;
using GraphQL.Types;

namespace GraphQL.Resolvers.QueryArgumentFilter
{
    public abstract class BaseQueryArgumentFilter<TSourceType> : InputObjectGraphType
        where TSourceType : IGraphType
    {
        public TSourceType Eq { get; set; }
        public TSourceType Ne { get; set; }
        public List<TSourceType> In { get; set; }
        public List<TSourceType> Nin { get; set; }

        public BaseQueryArgumentFilter()
        {
            Field<TSourceType>(name: "Eq");
            Field<TSourceType>(name: "Ne");
            Field<ListGraphType<TSourceType>>(name: "In");
            Field<ListGraphType<TSourceType>>(name: "Nin");
        }
    }
}