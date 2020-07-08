using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//http://gyanendushekhar.com/design-pattern-c/
//Ensures a single instance of a class.
namespace Singleton
{
     // create a public class
    public class Singleton
    {
        // make constructor private
        private Singleton ()
        {
        }
        // create private instance of singleton class
        private volatile static Singleton Instance;

        // Define locking object
        private static object lockObj = new Object();

        // static method to create instance of singleton class
        public static Singleton GetInstance()
        {
            if (Instance == null)
            {
                // lock will ensure only one instance of singleton class will be created even for multithreaded environment
                // Once a thread will enter the inside the method then it will be locked and no other thread can enter inside
                lock (lockObj)
                {
                    if (Instance == null)
                    {
                        Instance = new Singleton();
                    }
                }
            }
            return Instance;
        }
        // Public method to test singleton class
        public void DisplayMessage()
        {
            Console.WriteLine("This is instance of singleton class");
        }
    }
 
    class Program
    {
        static void Main(string[] args)
        {
            Singleton singleton1 = Singleton.GetInstance();
            Singleton singleton2 = Singleton.GetInstance();
            singleton1.DisplayMessage();
            singleton2.DisplayMessage();
            Console.ReadLine();
        }
    }
}
