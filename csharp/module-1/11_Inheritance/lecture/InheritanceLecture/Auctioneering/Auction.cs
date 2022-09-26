using System;
using System.Collections.Generic;

namespace InheritanceLecture.Auctioneering
{
    /// <summary>
    /// This class represents a general auction.
    /// </summary>
    public class Auction
    {
   
        /// <summary>
        /// This is an encapsulated field that holds all placed bids.
        /// </summary>
        private List<Bid> allBids = new List<Bid>(); //the internal list of actual bids. 
        //only way to add a bid is via the PlaceBid method.

        /// <summary>
        /// Represents the current high bid.
        /// </summary>
        public Bid CurrentHighBid { get; private set; } = new Bid("", 0);

        /// <summary>
        /// All placed bids returned as an array.
        /// </summary>
        public Bid[] AllBids //read-only bc we're returning a non-editable list of all bids that have happened. also fixed length.
        {
            get { return allBids.ToArray(); }
        }

        /// <summary>
        /// Indicates if the auction has ended yet.
        /// </summary>
        public bool HasEnded { get; private set; }

        /// <summary>
        /// Places a Bid on the Auction
        /// </summary>
        /// <param name="offeredBid">The bid to place.</param>
        /// <returns>True if the new bid is the current winning bid</returns>
        public virtual bool PlaceBid(Bid offeredBid) //added "virtual" whild doing buyout
            //allows child classes to override parent class. 
        {


            bool newHighBid = false;
            // Print out the bid details.
            Console.WriteLine(offeredBid.Bidder + " bid " + offeredBid.BidAmount.ToString("C"));

            if(HasEnded == false) // or you can do if(!HasEnded){}
            {
                // Record it as a bid by adding it to allBids
                allBids.Add(offeredBid);

                // Check to see IF the offered bid is higher than the current bid amount
                // if yes, set offered bid as the current high bid
                if (offeredBid.BidAmount > CurrentHighBid.BidAmount) //need to add .BidAmount b/c offeredBid is bidder + amount
                {
                    CurrentHighBid = offeredBid;
                    newHighBid = true;
                }
            }
            else
            {
                Console.WriteLine("Bid not accepted. Auction has ended.");
            }
         
            // Output the current high bid
            Console.WriteLine($"Current highest bid is {CurrentHighBid.BidAmount.ToString("C")} by {CurrentHighBid.Bidder}.") ;
            // Return if this is the new highest bid
            return newHighBid;
        }

        // to end an auction:
        // announce winner & price paid. 
        // stop accepting bids once ended.
        public void EndAuction() //method signature. access modifier, return type, name, parameters.
        {
            HasEnded = true; // ends auction
            Console.WriteLine($"Auction has ended. {CurrentHighBid.Bidder} has won with a bid of {CurrentHighBid.BidAmount.ToString("C")}.");

            // to stop accepting bids, need to go to PlaceBid. set an if statement there for HasEnded
        }
    }
}
