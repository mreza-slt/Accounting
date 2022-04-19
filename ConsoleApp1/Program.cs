using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.DataLayer;
using Accounting.DataLayer.Repositorys;
using Accounting.DataLayer.Services;
using Accounting.DataLayer.Context;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Unit_Of_Work db = new Unit_Of_Work();

            var list=db.CustomerRepository.GetAllCustomers();  
            
            db.Dispose();
        }
    }
}
