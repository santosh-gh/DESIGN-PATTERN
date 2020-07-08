using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Duplicates the given object

/**********************************
IEmployee: IPrototype Interface

PermanentEmployee and ContractEmployee: ConcreteProtoype1 and ConcreteProtoype2 class

Program: Client class
**********************************/
namespace Prototype
{
    // 'IPrototype' interface
    public interface IEmployee
    {
        // Method for cloning
        IEmployee Clone();
    }
    // 'ConcretePrototype1' class implements IPrototype interface
    public class PermanentEmployee : IEmployee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string EmploymentType { get; set; }

        // Implement shallow cloning method
        public IEmployee Clone()
        {
            // Shallow Copy
            return this.MemberwiseClone() as IEmployee;

            // Deep Copy
            // Implement Memberwise clone method for every reference type object 
            // return ..
        }
    }

    public class ContractEmployee : IEmployee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string EmploymentType { get; set; }

        // Implement shallow cloning method
        public IEmployee Clone()
        {
            // Shallow Copy 
            return this.MemberwiseClone() as IEmployee;

            // Deep Copy
            // Implement Memberwise clone method for every reference type object 
            // return ..
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PermanentEmployee permanentEmployee = new PermanentEmployee();
            permanentEmployee.Name = "Sam";
            permanentEmployee.Age = 25;
            permanentEmployee.EmploymentType = "Permanent";

            // clone permanent employee object with Clone method
            // If you will not set the new value for any field the it will take the default value from original object
            PermanentEmployee permanentEmployeeClone = (PermanentEmployee)permanentEmployee.Clone();
            permanentEmployeeClone.Name = "Tom";
            permanentEmployeeClone.Age = 30;

            Console.WriteLine("Permanent Employee Details");
            Console.WriteLine("Name: {0}; Age: {1}; Employment Type: {2}", permanentEmployee.Name, permanentEmployee.Age, permanentEmployee.EmploymentType);

            Console.WriteLine("Cloned Permanent Employee Details");
            Console.WriteLine("Name: {0}; Age: {1}; Employment Type: {2}", permanentEmployeeClone.Name, permanentEmployeeClone.Age, permanentEmployeeClone.EmploymentType);

            // you can perform the same operation for Temporary Employee

            Console.ReadLine();
        }
    }
}
