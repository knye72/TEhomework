using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise
{
    class BankCustomer : IAccountable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public List<IAccountable> totalAccounts { get; set; } = new List<IAccountable>();

        
        public bool IsVip
        {
            get
            {
                decimal sum = 0;
                foreach  (IAccountable account in totalAccounts)
                {
                    sum += account.Balance;
                    
                }
                if (sum >= 25000)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public decimal Balance { get;  }

   
        public void AddAccount(IAccountable newAccount)
        {
            totalAccounts.Add(newAccount);
        }
        public IAccountable[] GetAccounts()
        {
            return totalAccounts.ToArray();
        }


    }
}
