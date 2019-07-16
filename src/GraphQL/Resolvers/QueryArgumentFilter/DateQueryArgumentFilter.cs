using GraphQL.Types;

namespace GraphQL.Resolvers.QueryArgumentFilter
{
    public class DateQueryArgumentFilter : EqualityQueryArgumentFilter<DateGraphType>
    {
        public DateQueryArgumentFilter()
        {
            Name = "DateQueryArgumentFilter";
        }
    }
}