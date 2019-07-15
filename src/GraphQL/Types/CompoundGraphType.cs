using System;

namespace GraphQL.Types
{
    public abstract class CompoundGraphType : GraphType
    {
        public abstract Type GetObjectGraphType();
        public abstract Type GetInputObjectGraphType();
    }
}