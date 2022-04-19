using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.DataLayer.Repositorys;
using System.Data.Entity;
using Accounting.ViewModels.Customers;

namespace Accounting.DataLayer.Services
{
    public class CustomerRepository : ICustomerRepository
    {

        Accounting_W_DBEntities1 db;

        public CustomerRepository(Accounting_W_DBEntities1 db)
        {
            this.db = db;
        }

        public List<Customers> GetAllCustomers()
        {
            return db.Customers.ToList();
        }

        public Customers GetCustomerById(int customerId)
        {
            return db.Customers.Find(customerId);
        }

        public bool InsertCustomer(Customers customer)
        {
            try
            {
                db.Customers.Add(customer);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateCustomer(Customers customer)
        {
            var local = db.Set<Customers>()
                         .Local
                         .FirstOrDefault(f => f.CustomerId == customer.CustomerId);
            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }

            db.Entry(customer).State = EntityState.Modified;
            return true;
        }

        public bool DeleteCustomer(Customers customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            try
            {
                var customer = GetCustomerById(customerId);
                DeleteCustomer(customer);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Customers> GetCustomersByFilter(string parameter)
        {
            return db.Customers.Where(c => c.FullName.Contains(parameter) || c.Email.Contains(parameter) || c.Mobile.Contains(parameter)).ToList();
        }

        public List<ListCustomerViewModel> GetNameCustomers(string filter = "")
        {
            if (filter == "")
            {
                return db.Customers.Select(c => new ListCustomerViewModel()
                {
                    CustomerId = c.CustomerId,
                    FullName = c.FullName
                }).ToList();
            }

            return db.Customers.Where(c => c.FullName.Contains(filter)).Select(c => new ListCustomerViewModel()
            {
                CustomerId = c.CustomerId,
                FullName = c.FullName
            }).ToList();
        }

        public int GetCustomerByIdName(string name)
        {
            return db.Customers.First(c => c.FullName == name).CustomerId;
        }

        public string GetCustomerNameById(int customerId)
        {
            return db.Customers.Find(customerId).FullName;
        }


    }
}
