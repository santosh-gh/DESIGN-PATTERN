using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//An object stores all the required information that is used to perform some task.

/******************************************
ICommand: ICommand Interface

AddCommand & SubstractCommand: ConcreteCommand class

Calculator: Receiver class

Invoker: Invoker class
******************************************/
namespace Command
{
    //'ICommand' interface
    public interface ICommand
    {
        int Execute();
    }
    //'Invoker' class
    public class Invoker
    {
        public int ExecuteCommand(ICommand command)
        {
            return command.Execute();
        }
    }
    //'Receiver' class
    public class Calculator
    {
        private int _a, _b;

        public Calculator(int a, int b)
        {
            _a = a;
            _b = b;
        }
        public int Add()
        {
            return _a + _b;
        }

        public int Substract()
        {
            return _a - _b;
        }
    }
    //'ConcreteCommand1' class
    public class AddCommand : ICommand
    {
        private Calculator _calculator;

        public AddCommand(Calculator calculator)
        {
            _calculator = calculator;
        }

        public int Execute()
        {
            return _calculator.Add();
        }
    }
    //'ConcreteCommand2' class
    public class SubtractCommand : ICommand
    {
        private Calculator _calculator;

        public SubtractCommand(Calculator calculator)
        {
            _calculator = calculator;
        }

        public int Execute()
        {
            return _calculator.Substract();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter First Value");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second Value");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Commands for Calculator: Type 1 for Addition and 2 for substraction");
            string command = Console.ReadLine();

            Invoker invoker = new Invoker();
            Calculator calculator = new Calculator(a, b);
            AddCommand addCommand = new AddCommand(calculator);
            SubtractCommand substractCommand = new SubtractCommand(calculator);

            if (command == "1")
            {
                Console.WriteLine("Add Command is selected and the Result is {0}", invoker.ExecuteCommand(addCommand));
            }
            else if (command == "2")
            {
                Console.WriteLine("Substract Command is selected and the Result is {0}", invoker.ExecuteCommand(substractCommand));
            }
            else
            {
                Console.WriteLine("You have entered wrong command. Please type Command '1' for addition or '2' for substraction");
            }

            Console.ReadLine();
        }
    }
}
