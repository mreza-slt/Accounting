using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.ViewModels.Customers;

namespace Accounting.DataLayer.Repositorys
{
    public interface ICustomerRepository
    {
        List<Customers> GetAllCustomers();

        IEnumerable<Customers> GetCustomersByFilter(string parameter);

        List<ListCustomerViewModel> GetNameCustomers(string filter = "");

        Customers GetCustomerById(int customerId);

        bool InsertCustomer(Customers customer);

        bool UpdateCustomer(Customers customer);

        bool DeleteCustomer(Customers customer);

        bool DeleteCustomer(int customerId);

        int GetCustomerByIdName(string name);

        string GetCustomerNameById(int customerId);
        
    }
}
