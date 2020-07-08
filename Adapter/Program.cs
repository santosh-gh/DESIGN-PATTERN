using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Provides interface to interact between mutually incompatible classes

/****************************************
 * Client: This is the class which is incompatible with Adaptee class but wants to use Adaptee class code

ITarget: The interface that client class uses to achieve Adaptee class functionality.

Adapter: This class implements ITarget interface; this class also calls Adaptee class functionality inside.

Adaptee: This is the class which Client class want to use.
****************************************/
namespace Adapter
{// 'Adaptee' class
    class ThirdPartyEmployee
    {
        public List<string> GetEmployeeList()
        {
            List<string> EmployeeList = new List<string>();
            EmployeeList.Add("Tom");
            EmployeeList.Add("Sam");
            EmployeeList.Add("Jack");
            EmployeeList.Add("Mary");
            return EmployeeList;
        }
    }

    // 'ITarget' interface
    interface ITarget
    {
        List<string> GetEmployees();
    }
    // 'Adapter' class
    class EmployeeAdapter : ThirdPartyEmployee, ITarget
    {
        public List<string> GetEmployees()
        {
            return GetEmployeeList();
        }
    }

    // 'Client' class
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee List from ThridPartyEmployee class");
            // client will use ITarget interface to call functionality of Adaptee class i.e. ThirdPartyEmployee
            ITarget adapter = new EmployeeAdapter();
            foreach (string employee in adapter.GetEmployees())
            {
                Console.WriteLine(employee);
            }
            Console.ReadLine();
        }
    }
}
