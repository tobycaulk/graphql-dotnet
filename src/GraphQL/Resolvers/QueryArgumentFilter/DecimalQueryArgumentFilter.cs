using GraphQL.Types;

namespace GraphQL.Resolvers.QueryArgumentFilter
{
    public class DecimalQueryArgumentFilter : EqualityQueryArgumentFilter<DecimalGraphType>
    {
        public DecimalQueryArgumentFilter()
        {
            Name = "DecimalQueryArgumentFilter";
        }
    }
}