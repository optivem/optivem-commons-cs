﻿using Optivem.Atomiv.Core.Application;

namespace Optivem.Atomiv.Template.Core.Application.Orders.Queries
{
    public class BrowseOrdersQuery : IRequest<BrowseOrdersQueryResponse>
    {
        public int Page { get; set; }

        public int Size { get; set; }
    }
}