using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise
{
    class CreditCardAccount : IAccountable

    {
        public CreditCardAccount(string accountHolderName, string accountNumber)
        {
            AccountHolderName = accountHolderName;
            AccountNumber = accountNumber;
        }

        public string AccountHolderName { get; private set; }
        public string AccountNumber { get; }
        public decimal Debt { get; private set; } = 0;
        public decimal Balance { get; private set; }

        public decimal Pay(decimal amountToPay)
        {
            this.Balance = Balance + amountToPay;
            this.Debt = Debt - amountToPay;
            return (0 - Debt);
        }
        public decimal Charge(decimal amountToCharge)
        {
            
            this.Balance = Balance - amountToCharge;
            this.Debt = Debt + amountToCharge;
            return (0 - Debt);
        }
    }
}
