using GraphQL.Types;

namespace GraphQL.Resolvers.QueryArgumentFilter
{
    public class DateTimeOffsetQueryArgumentFilter : EqualityQueryArgumentFilter<DateTimeOffsetGraphType>
    {
        public DateTimeOffsetQueryArgumentFilter()
        {
            Name = "DateTimeOffsetQueryArgumentFilter";
        }
    }
}