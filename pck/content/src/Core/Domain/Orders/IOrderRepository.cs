﻿using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Orders
{
    public interface IOrderRepository : ICrudRepository<Order, OrderIdentity>, IPageAggregatesRepository<Order, OrderIdentity>
    {
    }
}