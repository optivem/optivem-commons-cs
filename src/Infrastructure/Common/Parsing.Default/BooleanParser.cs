﻿namespace Optivem.Platform.Infrastructure.Common.Parsing.Default
{
    public class BooleanParser : BaseParser<bool?>
    {
        protected override bool? ParseInner(string value)
        {
            return bool.Parse(value);
        }
    }
}