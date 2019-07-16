using GraphQL.Types;

namespace GraphQL.Resolvers.QueryArgumentFilter
{
    public class BooleanQueryArgumentFilter : BaseQueryArgumentFilter<FloatGraphType>
    {
        public BooleanQueryArgumentFilter()
        {
            Name = "BooleanQueryArgumentFilter";
        }
    }
}