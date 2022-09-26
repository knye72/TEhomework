namespace BankTellerExercise.Classes
{
  
    public class CheckingAccount : BankAccount
    {
        

        public CheckingAccount(string accountHolderName, string accountNumber, decimal balance)
            : base(accountHolderName, accountNumber, balance) { }

        public override decimal Withdraw(decimal amountToWithdraw)
        {
            if (Balance - amountToWithdraw < -100)
            {
                return Balance;
            }
            else if (Balance - amountToWithdraw < 0 && Balance - amountToWithdraw > -100)
            {
                System.Console.WriteLine("10 dollar overdraft fee!");
                return base.Withdraw(amountToWithdraw + 10);
                
            }
            
            return base.Withdraw(amountToWithdraw);

           
        }

    }
        //gonna need to create new constructors for the overdraft fees.

}
