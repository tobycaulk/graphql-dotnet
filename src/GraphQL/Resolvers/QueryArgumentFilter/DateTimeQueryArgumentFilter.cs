using GraphQL.Types;

namespace GraphQL.Resolvers.QueryArgumentFilter
{
    public class DateTimeQueryArgumentFilter : EqualityQueryArgumentFilter<DateTimeGraphType>
    {
        public DateTimeQueryArgumentFilter()
        {
            Name = "DateTimeQueryArgumentFilter";
        }
    }
}