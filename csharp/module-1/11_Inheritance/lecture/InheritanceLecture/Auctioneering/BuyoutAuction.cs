using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceLecture.Auctioneering
{
    public class BuyoutAuction : Auction
    { // could copy/paste everything into here, btu that's WET.
      // the : above shows that BuyoutAuction will inherit all of Auction. 

        public BuyoutAuction(int buyoutPrice) : base() // adding "base" explicitly states that you're calling the base calss of auction. it does it anyway, but this makes it clearer. 
        {
            _buyoutPrice = buyoutPrice; 
        }

        //buyout price
        //backing field

        private int _buyoutPrice;


        public int BuyoutPrice // we don't want it to change so no set
        {
            get
            {
                return _buyoutPrice; //give back the backing field.
            }
        }
        public override bool PlaceBid(Bid offeredBid) //override is the partner to virtual on the parent class
        {
            //if buyout price is not met, place bid as normal.
            bool newHighBid = base.PlaceBid(offeredBid); //base = look to parent class
            if(newHighBid && offeredBid.BidAmount >= this.BuyoutPrice)
            {
                Console.WriteLine($"Buyout met by {offeredBid.Bidder}.");
                base.EndAuction();
            }
            return newHighBid;
        }
    }
}
