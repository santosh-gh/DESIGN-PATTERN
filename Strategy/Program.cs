using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Provides a set of algorithm to choose to perform some operation.

/*******************************************
IStrategy: This is the common interface for all algorithms.

ConcreteStrategy: This class implements Istrategy This class implements the actual algorithm.

Context: This class maintains a reference of ConcreteStrategy Client will use this class to use the algorithms.
*******************************************/
namespace Strategy
{
    //'IStrategy' interface
    public interface IEncodingStrategy
    {
        void EncodeValue(string value);
    }
    //'ConcreteStrategyA' class
    public class RSAEncodingStrategy : IEncodingStrategy
    {
        public void EncodeValue(string value)
        {
            // Implement Encoding strategy
            Console.WriteLine("Value {0} is Encoded using RSA Algorithm", value);
        }
    }
    //'ConcreteStrategyB' class
    public class DESncodingStrategy : IEncodingStrategy
    {
        public void EncodeValue(string value)
        {
            // Implement Encoding strategy
            Console.WriteLine("Value {0} is Encoded using DES Algorithm", value);
        }
    }

    //'ConcreteStrategyC' class
    public class BlowFishEncodingStrategy : IEncodingStrategy
    {
        public void EncodeValue(string value)
        {
            // Implement Encoding strategy
            Console.WriteLine("Value {0} is Encoded using BlowFish Algorithm", value);
        }
    }

    //'Context' class
    public class Encoding
    {
        private IEncodingStrategy _encodeStrategy;

        public Encoding(IEncodingStrategy encodeStrategy)
        {
            _encodeStrategy = encodeStrategy;
        }

        public void Encode(string value)
        {
            _encodeStrategy.EncodeValue(value);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IEncodingStrategy encodingStrategy = new RSAEncodingStrategy();
            Encoding encoding = new Encoding(encodingStrategy);
            encoding.Encode("10000011110");

            encodingStrategy = new DESncodingStrategy();
            encoding = new Encoding(encodingStrategy);
            encoding.Encode("10000011110");

            encodingStrategy = new BlowFishEncodingStrategy();
            encoding = new Encoding(encodingStrategy);
            encoding.Encode("10000011110");

            Console.ReadLine();
        }
    }

}
