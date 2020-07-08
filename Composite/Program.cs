using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Sets up objects into the tree structure to represent part-whole hierarchy

/******************************************
IEmployee: IComponent interface

Employee: Leaf Class

Supervisor: Composite class
******************************************/
namespace Composite
{ //'IComponent' interface
    public interface IEmployee
    {
        int EmployeeID { get; set; }
        string Name { get; set; }
        int Rating { get; set; }
        void PerformanceSummary();
    }
    //'Leaf' class - will be leaf node in tree structure
    public class Employee : IEmployee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }

        public void PerformanceSummary()
        {
            Console.WriteLine("Performance summary of employee: {0} is {1} out 0f 5", Name, Rating);
        }
    }
    //'Composite' class - will be branch node in tree structure
    public class Supervisor : IEmployee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }

        public List<IEmployee> ListSubordinates = new List<IEmployee>();

        public void PerformanceSummary()
        {
            Console.WriteLine("Performance summary of supervisor: {0} is {1} out 0f 5", Name, Rating);
        }

        public void AddSubordinate(IEmployee employee)
        {
            ListSubordinates.Add(employee);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee tom = new Employee { EmployeeID = 1, Name = "Tom", Rating = 3 };
            Employee jack = new Employee { EmployeeID = 2, Name = "jack", Rating = 4 };
            Employee sam = new Employee { EmployeeID = 3, Name = "sam", Rating = 5 };
            Employee mary = new Employee { EmployeeID = 4, Name = "mary", Rating = 3 };
            Employee tina = new Employee { EmployeeID = 5, Name = "tina", Rating = 4 };
            Employee rose = new Employee { EmployeeID = 6, Name = "rose", Rating = 5 };

            Supervisor john = new Supervisor { EmployeeID = 7, Name = "john", Rating = 3 };
            Supervisor james = new Supervisor { EmployeeID = 7, Name = "john", Rating = 3 };

            john.AddSubordinate(tom);
            john.AddSubordinate(jack);
            john.AddSubordinate(sam);

            james.AddSubordinate(mary);
            james.AddSubordinate(tina);
            james.AddSubordinate(rose);

            Console.WriteLine("--- Employee can see their Perfarmance Summary --------");
            tom.PerformanceSummary();

            Console.WriteLine("--- Superwiser can also see their subordinates performance summary-----");
            john.PerformanceSummary();
            Console.WriteLine("Subordinate Performance Record:");
            foreach (Employee employee in john.ListSubordinates)
            {
                employee.PerformanceSummary();
            }

            Console.ReadLine();
        }
    }
}
