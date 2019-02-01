﻿using Optivem.Platform.Core.Common.Parsing;
using System.Collections.Generic;

namespace Optivem.Platform.Infrastructure.Common.Parsing.Default
{
    public class EnumStringParser<T> : IParser<T>
    {
        private Dictionary<string, T> map;

        public EnumStringParser(Dictionary<string, T> map)
        {
            this.map = map;
        }
        
        public T Parse(string value)
        {
            return map[value];
        }
    }
}