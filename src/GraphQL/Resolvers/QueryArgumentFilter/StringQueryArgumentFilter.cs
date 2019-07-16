using GraphQL.Types;

namespace GraphQL.Resolvers.QueryArgumentFilter
{
    public class StringQueryArgumentFilter : BaseQueryArgumentFilter<StringGraphType>
    {
        public string Regex { get; set; }

        public StringQueryArgumentFilter()
        {
            Name = "StringQueryArgumentFilter";

            Field<StringGraphType>("regex");
        }
    }
}