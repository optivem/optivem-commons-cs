﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Optivem.Framework.Core.Domain.Repositories;
using Optivem.Framework.Core.Application.UseCases;

namespace Optivem.Framework.Web.AspNetCore.Rest
{
    public class AspNetCoreCrudController<TService, TFindAllRequest, TFindRequest, TCreateRequest, TUpdateRequest, TDeleteRequest, TFindAllResponse, TFindResponse, TCreateResponse, TKey> 
        : ControllerBase
        where TService : ICrudService<TFindAllRequest, TFindRequest, TCreateRequest, TUpdateRequest, TDeleteRequest, TFindAllResponse, TFindResponse, TCreateResponse, TKey>
        where TUpdateRequest : IIdentifiableRequest<bool, TKey>
        where TCreateResponse : IIdentifiableResponse<TKey>
    {
        public AspNetCoreCrudController(TService service)
        {
            this.Service = service;
        }

        protected TService Service { get; private set; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TFindAllResponse>>> GetResources()
        {
            var responses = await Service.FindAllAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TFindResponse>> GetResource(TKey id)
        {
            var supplier = await Service.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<TCreateResponse>> PostResource(TCreateRequest request)
        {
            var response = await Service.CreateAsync(request);

            var responseId = response.Id;

            return CreatedAtAction("GetResource", new { id = responseId }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutResource(TKey id, TUpdateRequest request)
        {
            var requestId = request.Id;

            var validId = id != null && requestId != null && id.Equals(requestId);
            
            if (!validId)
            {
                return BadRequest();
            }

            var updated = await Service.UpdateAsync(request);

            if(!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResource(TKey id)
        {
            var deleted = await Service.DeleteAsync(id);

            if(!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
