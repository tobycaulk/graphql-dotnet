using GraphQL.Types;

namespace GraphQL.Resolvers.QueryArgumentFilter
{
    public class IntQueryArgumentFilter : EqualityQueryArgumentFilter<IntGraphType>
    {
        public IntQueryArgumentFilter()
        {
            Name = "IntQueryArgumentFilter";
        }
    }
}