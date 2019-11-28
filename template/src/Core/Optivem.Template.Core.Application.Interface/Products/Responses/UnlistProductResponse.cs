﻿using System;

namespace Optivem.Template.Core.Application.Products.Responses
{
    public class UnlistProductResponse
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public bool IsActive { get; set; }
    }
}