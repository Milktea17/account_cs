using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("jj", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance");
            
            account.MakeWithdrawal(500, DateTime.Now, "Rent Payment"); //인출 저장
            Console.WriteLine(account.Balance); //입력된 allTransaction 기록으로 계산해서 출력
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back"); //예금 저장
            Console.WriteLine(account.Balance);

            /* test
            try
            {
                var invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance ");
                Console.WriteLine(e.ToString());
            }
            
            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }
            */

            Console.WriteLine(account.GetAccountHistory());
        }
    }
}
