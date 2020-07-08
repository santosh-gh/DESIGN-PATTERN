using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Solves problem of creating objects
/**********************
IFactory: Interface

PerrmanentEmployee and ContractEmployee: Concrete Product classes

EmployeeFactory: creator

ConcreteEmployeeFactory: Concrete creator class
***********************/

namespace FactoryMethod
{
    // 'IProduct' Interface
    interface IFactory
    {
        void details();
    }

    // 'ConcreteProduct' class
    class PermanentEmployee : IFactory
    {
        public void details()
        {
            Console.WriteLine("This is Permanent employee type object");
        }
    }
    // 'ConcreteProduct' class
    class ContractEmployee : IFactory
    {
        public void details()
        {
            Console.WriteLine("This is Contract employee type object");
        }
    }
    // 'Creator' abstract class
    abstract class EmployeeFactory
    {
        public abstract IFactory Factory(string employeeType);
    }
    // 'ConcrteCreator' class
    class ConcreteEmployeeFactory : EmployeeFactory
    {
        public override IFactory Factory(string employeeType)
        {
            switch (employeeType)
            {
                case "PermanentEmployee":
                    return new PermanentEmployee();
                case "ContractEmployee":
                    return new ContractEmployee();
                default:
                    throw new ApplicationException(string.Format("This type of employee can not be created"));
            }
        }
    }

    // factory method design pattern demo
    // calling class/ client
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeFactory EmployeeFactory = new ConcreteEmployeeFactory();

            IFactory permanentEmployee = EmployeeFactory.Factory("PermanentEmployee");
            permanentEmployee.details();

            IFactory ContractEmployee = EmployeeFactory.Factory("ContractEmployee");
            ContractEmployee.details();

            Console.ReadLine();
        }
    }
}
