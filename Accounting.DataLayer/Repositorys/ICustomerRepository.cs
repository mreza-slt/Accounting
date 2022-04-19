﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Repositorys
{
    public interface ICustomerRepository
    {
        List<Customers> GetAllCustomers();

        IEnumerable<Customers> GetCustomersByFilter(string parameter);

        Customers GetCustomerById(int customerId);

        bool InsertCustomer(Customers customer);

        bool UpdateCustomer(Customers customer);

        bool DeleteCustomer(Customers customer);

        bool DeleteCustomer(int customerId);

    }
}
