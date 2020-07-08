using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Adds additional functionality to an already existing objects

/*******************************
Bike interface: Component interface

RoyalEnfield Class: ConcrteComponent Class

BikeDecorator abstract class: Decorator abstract class

PromotionalOffer, TransportOfficeCharges and AccessoriesPrice: ConcreteDecorator class
 ******************************/

namespace Decorator
{
    // 'Component' interface
    public interface Bike
    {
        string GetBikeDetails();
        int GetPrice();
    }
    // 'ConcreteComponent' class
    public class RoyalEnfield : Bike
    {
        public string GetBikeDetails()
        {
            return "Royal Enfield 350 CC classic Model";
        }

        public int GetPrice()
        {
            return 150000;
        }
    }

    //'Decorator' abstract class
    public abstract class BikeDecorator : Bike
    {
        public abstract string GetBikeDetails();
        public abstract int GetPrice();
    }

    // 'ConcreteDecorator' class
    public class PromotionalOffer : BikeDecorator
    {
        private Bike _bike;
        public int PromotionalDiscount;

        public PromotionalOffer(Bike bike)
        {
            _bike = bike;
        }
        public override string GetBikeDetails()
        {
            return "Promotional offer";
        }
        public override int GetPrice()
        {
            return _bike.GetPrice() - PromotionalDiscount;
        }
    }

    // 'ConcreteDecorator' class
    public class TransportOfficeCharges : BikeDecorator
    {
        private Bike _bike;
        public int TransportOfficeCharge;

        public TransportOfficeCharges(Bike bike)
        {
            _bike = bike;
        }

        public override string GetBikeDetails()
        {
            return "Transport Office Charges";
        }

        public override int GetPrice()
        {
            return _bike.GetPrice() + TransportOfficeCharge;
        }
    }
    // 'ConcreteDecorator' class
    public class AccessoriesPrice : BikeDecorator
    {
        private Bike _bike;
        public int AccessoriesCharge;

        public AccessoriesPrice(Bike bike)
        {
            _bike = bike;
        }


        public override string GetBikeDetails()
        {
            return "Accessories Charges";
        }

        public override int GetPrice()
        {
            return _bike.GetPrice() + AccessoriesCharge;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RoyalEnfield RoyalEnfieldBike = new RoyalEnfield();
            Console.WriteLine("-------------------" + RoyalEnfieldBike.GetBikeDetails() + "--------------------");
            Console.WriteLine("Royal Enfield Bike Base Price             :" + RoyalEnfieldBike.GetPrice());
            int test = RoyalEnfieldBike.GetPrice();

            PromotionalOffer promotionalOffer = new PromotionalOffer(RoyalEnfieldBike);
            promotionalOffer.PromotionalDiscount = 25000;
            Console.WriteLine("Price After Promotinal Discount (25000)   :" + promotionalOffer.GetPrice());
            test = promotionalOffer.GetPrice();

            TransportOfficeCharges trasportOfficeCharges = new TransportOfficeCharges(promotionalOffer);
            trasportOfficeCharges.TransportOfficeCharge = 20000;
            Console.WriteLine("Price After Tranport Charges (20000)      :" + trasportOfficeCharges.GetPrice());
            test = trasportOfficeCharges.GetPrice();

            AccessoriesPrice accessoriesPrice = new AccessoriesPrice(trasportOfficeCharges);
            accessoriesPrice.AccessoriesCharge = 15000;
            Console.WriteLine("Price After adding accessories (15000)    :" + accessoriesPrice.GetPrice());

            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("On road Price                             :" + accessoriesPrice.GetPrice());
            test = accessoriesPrice.GetPrice();

            Console.ReadLine();
        }
    }
}
