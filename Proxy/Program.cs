using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public interface IShape
    {
        string GetShape();
    }

    public class RealPolygon : IShape
    {
        public void Details()
        {
            Console.WriteLine("This is real polygon Class");
        }
        public string GetShape()
        {
            return "This is polygon shape from real/ actual class";
        }
    }

    public class ProxyPolygon : IShape
    {
        IShape _shape;
        public void Details()
        {
            Console.WriteLine("This is Proxy polygon Class");
        }
        public string GetShape()
        {
            _shape = new RealPolygon();
            return _shape.GetShape();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ProxyPolygon proxyClass = new ProxyPolygon();
            proxyClass.Details();
            string RealPolygonDetails = proxyClass.GetShape();
            Console.WriteLine(RealPolygonDetails);
            Console.ReadLine();
        }
    }
}
