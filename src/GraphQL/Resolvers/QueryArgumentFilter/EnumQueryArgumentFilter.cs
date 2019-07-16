using GraphQL.Types;

namespace GraphQL.Resolvers.QueryArgumentFilter
{
    public class EnumQueryArgumentFilter : EqualityQueryArgumentFilter<EnumerationGraphType>
    {
        public EnumQueryArgumentFilter()
        {
            Name = "EnumQueryArgumentFilter";
        }
    }
}