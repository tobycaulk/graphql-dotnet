using GraphQL.Types;

namespace GraphQL.Resolvers.QueryArgumentFilter
{
    public class IdQueryArgumentFilter : EqualityQueryArgumentFilter<IdGraphType>
    {
        public IdQueryArgumentFilter()
        {
            Name = "IdQueryArgumentFilter";
        }
    }
}