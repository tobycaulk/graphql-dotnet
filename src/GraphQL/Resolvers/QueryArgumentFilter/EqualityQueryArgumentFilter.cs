using GraphQL.Types;

namespace GraphQL.Resolvers.QueryArgumentFilter
{
    public abstract class EqualityQueryArgumentFilter<TSourceType> : BaseQueryArgumentFilter<TSourceType>
        where TSourceType : IGraphType
    {
        public TSourceType Gt { get; set; }
        public TSourceType Lt { get; set; }
        public TSourceType Gte { get; set; }
        public TSourceType Lte { get; set; }

        public EqualityQueryArgumentFilter()
        {
            Field<TSourceType>("Gt");
            Field<TSourceType>("Lt");
            Field<TSourceType>("Gte");
            Field<TSourceType>("Lte");
        }
    } 
}