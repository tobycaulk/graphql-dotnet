using GraphQL.Types;

namespace GraphQL.Resolvers.QueryArgumentFilter
{
    public class TimeSpanSecondsQueryArgumentFilter : EqualityQueryArgumentFilter<TimeSpanSecondsGraphType>
    {
        public TimeSpanSecondsQueryArgumentFilter()
        {
            Name = "TimeSpanSecondsQueryArgumentFilter";
        }
    }
}