﻿using Atomiv.Core.Application;
using System;

namespace Atomiv.Template.Core.Application.Commands.Orders
{
    public class CancelOrderCommand : IRequest<CancelOrderCommandResponse>
    {
        public string Id { get; set; }
    }
}