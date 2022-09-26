using InheritanceLecture.Auctioneering;
using System;

namespace InheritanceLecture
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new general auction
            Console.WriteLine("Starting a general auction");
            Console.WriteLine("-----------------");

            Auction generalAuction = new Auction(); //auction is the class, per our auction.cs class.

            generalAuction.PlaceBid(new Bid("Josh", 1));
            generalAuction.PlaceBid(new Bid("Fonz", 23));
            generalAuction.PlaceBid(new Bid("Rick Astley", 13));
            //....
            //....
            // This might go on until the auction runs out of time or hits a max # of bids
            generalAuction.PlaceBid(new Bid("David", 25));
            generalAuction.PlaceBid(new Bid("Ben", 50));
            generalAuction.EndAuction();
            generalAuction.PlaceBid(new Bid("David", 51));


            //buy out

            Console.WriteLine("Starting a buyout auction");
            Console.WriteLine("--------");
            BuyoutAuction buyoutAuction = new BuyoutAuction(1000);
            
            buyoutAuction.PlaceBid(new Bid("David", 5));  // bc it has inherited Auction-class, we can do things like add bids.
            buyoutAuction.PlaceBid(new Bid("Taylor", 1000));
            Console.WriteLine(buyoutAuction.CurrentHighBid.Bidder); // has all qualities of Auction.

            // reserve auction

            ReserveAuction reserveAuction = new ReserveAuction(200);
            reserveAuction.PlaceBid(new Bid("David", 150));
            reserveAuction.PlaceBid(new Bid("Kate", 201));
            reserveAuction.PlaceBid(new Bid("Ben", 200000));
            reserveAuction.EndAuction();

            Console.ReadLine();
        }
    }
}
