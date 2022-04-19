using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.DataLayer.Repositorys;
using Accounting.DataLayer.Services;

namespace Accounting.DataLayer.Context
{
    public class Unit_Of_Work : IDisposable
    {

        Accounting_W_DBEntities1 db =new Accounting_W_DBEntities1();

        private ICustomerRepository _customerRepository;

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(db);
                }

                return _customerRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
