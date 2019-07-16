using GraphQL.Types;

namespace GraphQL.Resolvers.QueryArgumentFilter
{
    public class FloatQueryArgumentFilter : EqualityQueryArgumentFilter<FloatGraphType>
    {
        public FloatQueryArgumentFilter()
        {
            Name = "FloatQueryArgumentFilter";
        }
    }
}