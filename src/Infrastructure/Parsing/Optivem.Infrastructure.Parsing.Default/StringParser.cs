﻿namespace Optivem.Infrastructure.Parsing.Default
{
    public class StringParser : BaseParser<string>
    {
        protected override string ParseInner(string value)
        {
            return value;
        }
    }
}
