using GraphQL.Types;

namespace GraphQL.Resolvers.QueryArgumentFilter
{
    public class TimeSpanMilliseconsQueryArgumentFilter : EqualityQueryArgumentFilter<TimeSpanMillisecondsGraphType>
    {
        public TimeSpanMilliseconsQueryArgumentFilter()
        {
            Name = "TimeSpanMilliseconsQueryArgumentFilter";
        }
    }
}