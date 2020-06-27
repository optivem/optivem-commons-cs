﻿using Atomiv.Infrastructure.SequentialGuid;
using Atomiv.Template.Core.Domain.Products;
using System;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.IdentityGenerators
{
    public class ProductIdentityGenerator : IdentityGenerator<ProductIdentity>
    {
        protected override ProductIdentity Create(string value)
        {
            return new ProductIdentity(value);
        }
    }
}
