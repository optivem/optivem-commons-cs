﻿using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Records;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Repositories
{
    public class CustomerRepository : CustomerReadRepository, ICustomerRepository
    {
        public CustomerRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            var customerRecord = GetCustomerRecord(customer);
            Context.Customers.Add(customerRecord);
            await Context.SaveChangesAsync();
            return GetCustomer(customerRecord);
        }

        public async Task RemoveAsync(CustomerIdentity customerId)
        {
            var customerRecord = GetCustomerRecord(customerId);
            Context.Remove(customerRecord);
            await Context.SaveChangesAsync();
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            var customerRecordId = customer.Id.Id;
            var customerRecord = await Context.Customers.FindAsync(customerRecordId);

            UpdateCustomerRecord(customerRecord, customer);

            try
            {
                Context.Customers.Update(customerRecord);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrentUpdateException(ex.Message, ex);
            }

            return GetCustomer(customerRecord);
        }

        protected CustomerRecord GetCustomerRecord(Customer customer)
        {
            var id = customer.Id.Id;
            var firstName = customer.FirstName;
            var lastName = customer.LastName;

            return new CustomerRecord
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
            };
        }

        protected CustomerRecord GetCustomerRecord(CustomerIdentity customerId)
        {
            var id = customerId.Id;

            return new CustomerRecord
            {
                Id = id,
            };
        }

        protected void UpdateCustomerRecord(CustomerRecord customerRecord, Customer customer)
        {
            var id = customer.Id.Id;
            var firstName = customer.FirstName;
            var lastName = customer.LastName;

            customerRecord.Id = id;
            customerRecord.FirstName = firstName;
            customerRecord.LastName = lastName;
        }
    }
}