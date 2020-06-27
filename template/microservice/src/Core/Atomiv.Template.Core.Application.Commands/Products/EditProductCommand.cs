﻿using Atomiv.Core.Application;
using System;

namespace Atomiv.Template.Core.Application.Commands.Products
{
    public class EditProductCommand : IRequest<EditProductCommandResponse>
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }
    }
}