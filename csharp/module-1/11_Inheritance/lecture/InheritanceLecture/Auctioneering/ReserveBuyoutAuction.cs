using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceLecture.Auctioneering
{
    public class SilentAuction : BuyoutAuction //needs buyout price
    {
        public SilentAuction(int buyoutPrice) : base(buyoutPrice)
        {

        }
    }
    /*public class ReserveBuyoutAuction : BuyoutAuction //cant add ReserveAuction here b/c you can't inherit from both.
        //you'd then have to copy/paste some of the criteria from ReserveAuction
        //adding both is impossible
        //becomes less relevant when you want to even try double-inheritance.
    {
    }*/
}
